using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using PcmBrandUI.Properties;

namespace PCmover.Infrastructure
{
	// Token: 0x02000036 RID: 54
	public class SignPolicy
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00002A5D File Offset: 0x00000C5D
		public static bool CheckPrivateKey
		{
			get
			{
				return !DefaultPolicy.InDebugMode;
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00007ADF File Offset: 0x00005CDF
		public static bool IsPinnedKey(X509Certificate2 certificate, bool bCheckingSignature)
		{
			return bCheckingSignature;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00007AE4 File Offset: 0x00005CE4
		public static void SignXml(XmlDocument xmlDoc, X509Certificate2 cert)
		{
			if (xmlDoc == null)
			{
				throw new ArgumentException("xmlDoc");
			}
			if (cert == null)
			{
				throw new ArgumentException("cert");
			}
			AsymmetricAlgorithm asymmetricAlgorithm = cert.GetRSAPrivateKey();
			if (asymmetricAlgorithm is RSACryptoServiceProvider)
			{
				asymmetricAlgorithm = SignPolicy.UpgradeCsp(cert.PrivateKey);
			}
			SignedXml signedXml = new SignedXml(xmlDoc);
			signedXml.SigningKey = asymmetricAlgorithm;
			Reference reference = new Reference();
			reference.Uri = "";
			XmlDsigEnvelopedSignatureTransform transform = new XmlDsigEnvelopedSignatureTransform();
			reference.AddTransform(transform);
			signedXml.AddReference(reference);
			KeyInfo keyInfo = new KeyInfo();
			KeyInfoX509Data clause = new KeyInfoX509Data(cert);
			KeyInfoName keyInfoName = new KeyInfoName();
			keyInfoName.Value = cert.Subject;
			RSAKeyValue clause2 = new RSAKeyValue((RSACryptoServiceProvider)cert.PublicKey.Key);
			keyInfo.AddClause(keyInfoName);
			keyInfo.AddClause(clause2);
			keyInfo.AddClause(clause);
			signedXml.KeyInfo = keyInfo;
			signedXml.AddReference(reference);
			signedXml.ComputeSignature();
			XmlElement xml = signedXml.GetXml();
			xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xml, true));
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00007BDC File Offset: 0x00005DDC
		private static AsymmetricAlgorithm UpgradeCsp(AsymmetricAlgorithm key)
		{
			try
			{
				CspKeyContainerInfo cspKeyContainerInfo = ((RSACryptoServiceProvider)key).CspKeyContainerInfo;
				CspParameters cspParameters = new CspParameters(24)
				{
					KeyContainerName = cspKeyContainerInfo.KeyContainerName,
					KeyNumber = (int)cspKeyContainerInfo.KeyNumber,
					Flags = CspProviderFlags.UseExistingKey
				};
				if (cspKeyContainerInfo.MachineKeyStore)
				{
					cspParameters.Flags |= CspProviderFlags.UseMachineKeyStore;
				}
				if (cspKeyContainerInfo.ProviderType == 24)
				{
					cspParameters.ProviderName = cspKeyContainerInfo.ProviderName;
				}
				return new RSACryptoServiceProvider(cspParameters);
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Failed to convert certificate CSP: " + ex.Message);
			}
			return key;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00007C7C File Offset: 0x00005E7C
		public static bool VerifyXmlFile(XmlDocument xmlDocument, out string certString)
		{
			bool result;
			try
			{
				SignedXml signedXml = new SignedXml(xmlDocument);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Signature");
				if (elementsByTagName.Count == 0)
				{
					throw new Exception("Document not signed");
				}
				signedXml.LoadXml((XmlElement)elementsByTagName[0]);
				XmlNodeList elementsByTagName2 = ((XmlElement)elementsByTagName[0]).GetElementsByTagName("X509Certificate");
				if (elementsByTagName2.Count == 0)
				{
					throw new Exception("No certificate in document signature");
				}
				X509Certificate2 x509Certificate = new X509Certificate2(Convert.FromBase64String(elementsByTagName2[0].InnerText));
				certString = x509Certificate.Subject;
				Trace.WriteLine("Policy signed by: " + x509Certificate.Subject);
				if (!SignPolicy.IsPinnedKey(x509Certificate, true))
				{
					Trace.WriteLine("Invalid signing certificate");
					result = false;
				}
				else
				{
					bool flag = signedXml.CheckSignature(x509Certificate, true);
					if (!flag)
					{
						Trace.WriteLine("Signature check failied");
					}
					else
					{
						flag = new X509Chain
						{
							ChainPolicy = 
							{
								RevocationFlag = X509RevocationFlag.ExcludeRoot,
								RevocationMode = X509RevocationMode.NoCheck,
								UrlRetrievalTimeout = new TimeSpan(0, 1, 0),
								VerificationFlags = X509VerificationFlags.NoFlag
							}
						}.Build(x509Certificate);
						if (!flag)
						{
							Trace.WriteLine("Signing certificate not trusted");
						}
					}
					result = flag;
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Exception checking signature: " + ex.Message);
				certString = string.Empty;
				result = false;
			}
			return result;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00007DE8 File Offset: 0x00005FE8
		public static ObservableCollection<X509Certificate2> GetCertList()
		{
			ObservableCollection<X509Certificate2> observableCollection = new ObservableCollection<X509Certificate2>();
			try
			{
				X509Store x509Store = new X509Store(StoreLocation.LocalMachine);
				x509Store.Open(OpenFlags.ReadOnly);
				foreach (X509Certificate2 x509Certificate in x509Store.Certificates)
				{
					if ((!SignPolicy.CheckPrivateKey || x509Certificate.HasPrivateKey) && !(DateTime.Now > x509Certificate.NotAfter - TimeSpan.FromDays(1.0)))
					{
						bool flag = true;
						bool flag2 = true;
						foreach (X509Extension x509Extension in x509Certificate.Extensions)
						{
							if (x509Extension.Oid.Value == "2.5.29.15" && (((X509KeyUsageExtension)x509Extension).KeyUsages & (X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature)) == X509KeyUsageFlags.None)
							{
								flag = false;
								break;
							}
							if (x509Extension.Oid.Value == "2.5.29.37")
							{
								flag2 = false;
								foreach (Oid oid in ((X509EnhancedKeyUsageExtension)x509Extension).EnhancedKeyUsages)
								{
									if (oid.Value == "1.3.6.1.4.1.311.10.3.12" || oid.Value == "1.3.6.1.5.5.7.3.3" || oid.Value == "1.3.6.1.5.5.7.3.4")
									{
										flag2 = true;
									}
								}
								if (!flag2)
								{
									break;
								}
							}
						}
						if ((flag && flag2) || SignPolicy.IsPinnedKey(x509Certificate, false))
						{
							observableCollection.Add(x509Certificate);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
			return observableCollection;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00007F88 File Offset: 0x00006188
		public static bool SignXmlDocument(XmlDocument xmlDoc, string certificateName)
		{
			if (xmlDoc == null)
			{
				throw new ArgumentException("xmlDoc");
			}
			if (string.IsNullOrWhiteSpace(certificateName))
			{
				throw new ArgumentException("certificateName");
			}
			try
			{
				bool flag = !string.IsNullOrWhiteSpace(Resources.Cert_PublicKey);
				X509Certificate2 x509Certificate = null;
				X509Store x509Store = new X509Store(StoreLocation.LocalMachine);
				x509Store.Open(OpenFlags.ReadOnly);
				foreach (X509Certificate2 x509Certificate2 in x509Store.Certificates)
				{
					if ((!SignPolicy.CheckPrivateKey || x509Certificate2.HasPrivateKey) && !(DateTime.Now > x509Certificate2.NotAfter - TimeSpan.FromDays(1.0)))
					{
						if (flag)
						{
							if (!SignPolicy.IsPinnedKey(x509Certificate2, false))
							{
								continue;
							}
						}
						else
						{
							bool flag2 = true;
							bool flag3 = true;
							foreach (X509Extension x509Extension in x509Certificate2.Extensions)
							{
								if (x509Extension.Oid.Value == "2.5.29.15" && (((X509KeyUsageExtension)x509Extension).KeyUsages & (X509KeyUsageFlags.NonRepudiation | X509KeyUsageFlags.DigitalSignature)) == X509KeyUsageFlags.None)
								{
									flag2 = false;
									break;
								}
								if (x509Extension.Oid.Value == "2.5.29.37")
								{
									flag3 = false;
									foreach (Oid oid in ((X509EnhancedKeyUsageExtension)x509Extension).EnhancedKeyUsages)
									{
										if (oid.Value == "1.3.6.1.4.1.311.10.3.12" || oid.Value == "1.3.6.1.5.5.7.3.3" || oid.Value == "1.3.6.1.5.5.7.3.4")
										{
											flag3 = true;
										}
									}
									if (!flag3)
									{
										break;
									}
								}
							}
							if (!flag2 || !flag3)
							{
								continue;
							}
						}
						if (x509Certificate2.Subject.ToLower().Contains(certificateName.ToLower()))
						{
							x509Certificate = x509Certificate2;
							break;
						}
					}
				}
				if (x509Certificate == null)
				{
					throw new Exception("Valid signing certificate (" + certificateName + ") not found");
				}
				SignPolicy.SignXml(xmlDoc, x509Certificate);
				return true;
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Failed to sign policy with '" + certificateName + "': " + ex.Message);
			}
			return false;
		}
	}
}
