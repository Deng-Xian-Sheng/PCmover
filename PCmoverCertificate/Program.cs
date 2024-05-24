using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CertificateServer;
using Laplink.Pcmover.Service;
using Microsoft.Win32;

namespace PCmoverCertificate
{
	// Token: 0x02000004 RID: 4
	internal class Program
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002268 File Offset: 0x00000468
		[STAThread]
		private static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Program.Usage(null);
			}
			string text = Environment.Is64BitProcess ? "LLCertificateServer64.dll" : "LLCertificateServer.dll";
			Console.WriteLine("Loading: {0}", text);
			uint num;
			RegFreeCOMObject regFreeCOMObject = new RegFreeCOMObject(text, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ref num);
			CertificateService service = null;
			try
			{
				regFreeCOMObject.CallInContext(delegate
				{
					CertificateService certificateService = (CertificateService)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("A4BD43CF-6776-4FD7-9725-20A41419A519")));
					certificateService.Logging = true;
					certificateService.Application = "PCmover";
					service = certificateService;
				});
				string text2 = null;
				string text3 = null;
				ushort num2 = 0;
				int i = 0;
				while (i < args.Length)
				{
					Console.WriteLine("\nProcessing: \"{0}\"", args[i]);
					if (string.Compare(args[i], "-HttpsPort", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						if (i >= args.Length)
						{
							Program.Usage("Port number needed for '-HttpsPort'");
						}
						try
						{
							num2 = Convert.ToUInt16(args[i]);
						}
						catch (Exception ex)
						{
							Console.WriteLine("Exception parsing port: {0}", ex.Message);
							Program.Usage("invalid port");
						}
						i++;
					}
					else if (string.Compare(args[i], "-CAServer", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						if (i >= args.Length)
						{
							Program.Usage("Server hostname number needed for '-CAServer'");
						}
						service.CAServer = args[i];
						i++;
					}
					else if (string.Compare(args[i], "-Uninstall", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						service.Uninstall();
						Console.WriteLine("Certificates and keys are uninstalled");
					}
					else if (string.Compare(args[i], "-Info", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						Program.DisplayInfo(service, service.CANames);
					}
					else if (string.Compare(args[i], "-CheckCertificateFile", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						if (i >= args.Length || string.IsNullOrEmpty(args[i]))
						{
							Program.Usage("Invalid -CheckCertificateFile argument");
						}
						string certificateFile = args[i];
						i++;
						Console.WriteLine("Checking certificate in: {0}", certificateFile);
						CertificateContext context = null;
						regFreeCOMObject.CallInContext(delegate
						{
							context = service.ContextFromFile(certificateFile);
							if (context == null)
							{
								Console.WriteLine("Invalid certificate file");
								return;
							}
							Console.WriteLine("Certificate name: {0}", context.CommonName);
						});
						if (context != null)
						{
							bool flag;
							if (service.VerifyEx(context, out flag))
							{
								Console.WriteLine("Certificate is {0}", flag ? "from the Laplink CA" : "trusted by the OS");
							}
							else
							{
								Console.WriteLine("Certificate verification failed");
							}
						}
					}
					else if (string.Compare(args[i], "-ClientCertificate", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						if (i >= args.Length || string.IsNullOrEmpty(args[i]))
						{
							Program.Usage("Invalid -ClientCertificate argument");
						}
						text2 = args[i];
						Console.WriteLine("Using client certificate: {0}", text2);
						i++;
					}
					else if (string.Compare(args[i], "-ClientCertificateRequired", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						if (i >= args.Length || string.IsNullOrEmpty(args[i]))
						{
							Program.Usage("Invalid -ClientCertificateRequired argument");
						}
						text3 = args[i];
						Console.WriteLine("Require client certificate: {0}", text3);
						service.SSLFlags |= SSL_FLAGS.RequireClientCertificate;
						i++;
					}
					else if (string.Compare(args[i], "-EnforceCertificateName", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						service.SSLFlags |= SSL_FLAGS.EnforceCertificateName;
					}
					else if (string.Compare(args[i], "-AllowNetBIOSCertificateName", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						service.SSLFlags |= SSL_FLAGS.NetBIOSCertificateName;
					}
					else if (string.Compare(args[i], "-CustomerCA", StringComparison.OrdinalIgnoreCase) == 0)
					{
						i++;
						if (i >= args.Length || string.IsNullOrEmpty(args[i]))
						{
							Program.Usage("Invalid -CustomerCA argument");
						}
						string text4 = args[i];
						i++;
						if (text4 == "-")
						{
							OpenFileDialog openFileDialog = new OpenFileDialog
							{
								Filter = "Certificates (*.cer,*.p7b)|*.cer;*.p7b|All files (*.*)|*.*",
								CheckFileExists = true
							};
							if (openFileDialog.ShowDialog() == DialogResult.OK)
							{
								text4 = openFileDialog.FileName;
							}
							else
							{
								Program.Usage("Invalid -CustomerCA argument");
							}
						}
						string arg;
						byte[] array = Program.ConvertCAFile(text4, out arg);
						Console.WriteLine("{0}", arg);
						if (array == null)
						{
							Console.WriteLine("Not a valid customer CA file");
							Program.Usage("Invalid -CustomerCA argument");
						}
						else
						{
							service.CustomerCA = array;
							service.SSLFlags |= SSL_FLAGS.RequireCustomerCA;
						}
					}
					else if (string.Compare(args[i], "-TestSSL", StringComparison.OrdinalIgnoreCase) == 0)
					{
						Console.WriteLine("SSLFlags: {0}", ((SSLFlags)service.SSLFlags).ToString());
						Console.WriteLine("Default certificate name: {0}", service.DefaultCertificateName);
						Console.WriteLine("TestSSL: client certificate {0}, client certificate required {1}", text2 ?? "none", text3 ?? "none");
						bool flag2 = true;
						if (text3 != null && (text2 == null || string.Compare(text3, text2) != 0))
						{
							flag2 = false;
						}
						byte[] rawData;
						bool flag3 = service.TestSSL(text2, text3, out rawData);
						if (flag3)
						{
							X509Certificate2 x509Certificate = new X509Certificate2(rawData);
							X500DistinguishedName subjectName = x509Certificate.SubjectName;
							X500DistinguishedName issuerName = x509Certificate.IssuerName;
							Console.WriteLine("TestSSL: server certificate name: {0}, issuer: {1}", x509Certificate.GetNameInfo(X509NameType.SimpleName, false), issuerName.Name);
						}
						Console.WriteLine("Test {0} (expected {1}, got {2})", (flag3 == flag2) ? "Succeeded" : "Failed", flag2, flag3);
						i++;
					}
					else if (string.Compare(args[i], "-InstalledCertificate", StringComparison.OrdinalIgnoreCase) == 0)
					{
						string certificateNameFromRegistry = service.CertificateNameFromRegistry;
						Console.WriteLine("Certificate name from registry: " + certificateNameFromRegistry);
						byte[] certificate = service.Certificate;
						if (certificate == null)
						{
							Console.WriteLine("No valid certificate found");
						}
						else
						{
							try
							{
								X509Certificate2 x509Certificate2 = new X509Certificate2(certificate);
								string[] array2 = Regex.Split(x509Certificate2.Subject, " \\+ ");
								for (int j = 0; j < array2.Length; j++)
								{
									foreach (DistinguishedName.Part part in DistinguishedName.Parse(array2[j]))
									{
										if (part.Name == "CN")
										{
											Console.WriteLine("Common name: {0}", part.Value);
										}
										else if (part.Name == "SERIALNUMBER")
										{
											Console.WriteLine("PCmover Serial Number: {0}", part.Value);
										}
										else
										{
											Console.WriteLine("Name: {0}, Value: {1}", part.Name, part.Value);
										}
									}
								}
								string nameInfo = x509Certificate2.GetNameInfo(X509NameType.EmailName, false);
								if (nameInfo != null)
								{
									Console.WriteLine("Email address: {0}", nameInfo);
								}
							}
							catch (Exception ex2)
							{
								Console.WriteLine("Exception decoding certificate: {0}", ex2.Message);
							}
						}
						i++;
					}
					else
					{
						bool flag4 = string.Compare(args[i], "-SelfSigned", StringComparison.OrdinalIgnoreCase) == 0;
						if (flag4 || string.Compare(args[i], "-Request", StringComparison.OrdinalIgnoreCase) == 0)
						{
							i++;
							if (i >= args.Length)
							{
								Program.Usage("Email address needed for -Request and -SelfSigned");
							}
							string text5 = Program.GetSerialNumber();
							if (text5 != null)
							{
								Console.WriteLine("Found serial number: {0}", text5);
							}
							else
							{
								text5 = "XPMACHINE";
								Console.WriteLine("Using {0} for serial number", text5);
							}
							if (flag4)
							{
								try
								{
									service.CreateSelfSignedCertificate(args[i], text5, "Self Signed");
									Console.WriteLine("Created Self-Signed certificate");
								}
								catch (Exception ex3)
								{
									Console.WriteLine("CreateSelfSignedCertificate failed: {0}", ex3.Message);
								}
								i++;
							}
							else
							{
								string text6 = "https://" + service.CAServer;
								if (num2 != 0)
								{
									text6 = text6 + ":" + num2.ToString();
									service.HttpsPort = num2;
								}
								Console.WriteLine("Requesting certificate for <{0}> from {1}", args[i], text6);
								text6 += service.CASignPath;
								Program.SetProxy(new Uri(text6), service);
								int num3 = 0;
								uint num4;
								do
								{
									byte[] cert;
									num4 = service.RequestCertificate(args[i], text5, out cert);
									if (num4 == 200U)
									{
										Console.WriteLine("Requested Certificate:");
										Program.DisplayCert(cert);
										Console.WriteLine("Actual CAServer: {0}", service.CAServer);
										Console.WriteLine("DownloadCACertificate returns: {0}", service.DownloadCACertificate());
									}
									else if (num4 == 407U)
									{
										Program.SetProxyAuth(service);
									}
									else
									{
										Console.WriteLine("RequestCertificate({0}) failed, status {1}", args[i], num4);
									}
								}
								while (num4 == 407U && ++num3 < 2);
								i++;
							}
						}
						else
						{
							Program.Usage("Invalid parameter: \"" + args[i] + "\"");
						}
					}
				}
			}
			catch (Exception ex4)
			{
				Console.WriteLine("Exception: {0}", ex4.ToString());
			}
			try
			{
				CertificateService service2 = service;
				if (service2 != null)
				{
					service2.Dispose();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002BE4 File Offset: 0x00000DE4
		private static string GetSerialNumber()
		{
			string result = null;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Laplink\\PCmover\\Reg", RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.QueryValues))
				{
					if (registryKey2 != null)
					{
						result = Program.ReadEncryptedString(registryKey2, "SN_ValidationCode");
					}
				}
			}
			return result;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002C54 File Offset: 0x00000E54
		private static string ReadEncryptedString(RegistryKey key, string valueName)
		{
			string result = null;
			try
			{
				RegistryValueKind valueKind = key.GetValueKind(valueName);
				if (valueKind == RegistryValueKind.Binary)
				{
					byte[] array = (byte[])key.GetValue(valueName);
					array = ProtectedData.Unprotect(array, null, DataProtectionScope.LocalMachine);
					result = Encoding.UTF8.GetString(array);
				}
				else if (valueKind == RegistryValueKind.String)
				{
					result = key.GetValue(valueName).ToString();
				}
			}
			catch (IOException)
			{
			}
			return result;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002CBC File Offset: 0x00000EBC
		private static void DisplayCert(byte[] cert)
		{
			if (cert == null)
			{
				Console.WriteLine("\tNo certificate found!");
				return;
			}
			try
			{
				X509Certificate2 x509Certificate = new X509Certificate2(cert);
				string[] array = Regex.Split(x509Certificate.Subject, " \\+ ");
				for (int i = 0; i < array.Length; i++)
				{
					foreach (DistinguishedName.Part part in DistinguishedName.Parse(array[i]))
					{
						if (part.Name == "CN")
						{
							Console.WriteLine("\tCommon name: {0}", part.Value);
						}
						else if (part.Name == "SERIALNUMBER")
						{
							Console.WriteLine("\tPCmover Serial Number: {0}", part.Value);
						}
						else
						{
							Console.WriteLine("\tName: {0}, Value: {1}", part.Name, part.Value);
						}
					}
				}
				Console.WriteLine("\tCertificate Serial Number: {0}", x509Certificate.SerialNumber);
				DateTime notBefore = x509Certificate.NotBefore;
				DateTime now = DateTime.Now;
				Console.WriteLine("\tNot before: {0} {1} ms, Now: {2} {3} ms", new object[]
				{
					notBefore.ToLongTimeString(),
					notBefore.Millisecond,
					now.ToLongTimeString(),
					now.Millisecond
				});
				if (now.CompareTo(notBefore) < 0)
				{
					Console.WriteLine("\tWarning, certificate is not yet valid.  This can happen if your computer's clock is slightly off.\n\tNote: PCmover gives a 48 hour grace period on 'Not before'.");
				}
				if (now > x509Certificate.NotAfter)
				{
					Console.WriteLine("\tCertificate has expired.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("\tException decoding certificate: {0}", ex.Message);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002E78 File Offset: 0x00001078
		private static void DisplayInfo(CertificateService service, string CANames)
		{
			Console.WriteLine("CertificateService logging is {0}", service.Logging ? "On" : "Off");
			Console.WriteLine("CertificateService using application name: {0}", service.Application);
			Console.WriteLine("CA Server: {0}", service.CAServer);
			Console.WriteLine("Proxy user: {0}", service.ProxyUser);
			Console.WriteLine("Proxy password: {0}", service.ProxyPassword);
			Console.WriteLine("Proxy url: {0}", service.ProxyUrl);
			if (string.IsNullOrEmpty(CANames))
			{
				Console.WriteLine("No CA set");
			}
			else
			{
				Console.WriteLine("CA names: {0}", CANames);
				Console.WriteLine("Root CA name: {0}", service.RootCAName);
			}
			string defaultCertificateName = service.DefaultCertificateName;
			Console.WriteLine("Default certificate name: {0}", defaultCertificateName ?? "No certificate found");
			Console.WriteLine("Laplink Certificate information:");
			Program.DisplayCert(service.Certificate);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002F54 File Offset: 0x00001154
		private static void SetProxy(Uri uri, CertificateService service)
		{
			IWebProxy systemWebProxy = WebRequest.GetSystemWebProxy();
			try
			{
				if (systemWebProxy != null && !systemWebProxy.IsBypassed(uri))
				{
					Uri proxy = systemWebProxy.GetProxy(uri);
					Console.WriteLine("Using proxy: {0}", proxy.AbsoluteUri);
					service.ProxyUrl = proxy.AbsoluteUri;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002FAC File Offset: 0x000011AC
		private static void SetProxyAuth(CertificateService service)
		{
			Console.WriteLine("Proxy authentication required, ask the user for username/password here! (Using test password.)");
			service.ProxyUser = "orin";
			service.ProxyPassword = "UraP1nHead";
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002FD0 File Offset: 0x000011D0
		private static int GetEncodedLength(byte[] data, ref int index)
		{
			int num = index;
			index = num + 1;
			int num2 = (int)data[num];
			if ((num2 & 128) != 0)
			{
				int num3 = num2 & -129;
				num2 = 0;
				for (int i = 0; i < num3; i++)
				{
					num2 <<= 8;
					int num4 = num2;
					num = index;
					index = num + 1;
					num2 = (num4 | (int)data[num]);
				}
			}
			return num2;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000301C File Offset: 0x0000121C
		private static byte[] ConvertCAFile(string file, out string traceString)
		{
			traceString = string.Format("CA File: {0}", file);
			try
			{
				string text = null;
				X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
				x509Certificate2Collection.Import(file);
				foreach (X509Certificate2 x509Certificate in x509Certificate2Collection)
				{
					traceString = traceString + Environment.NewLine + string.Format("Checking: {0}", x509Certificate.GetNameInfo(X509NameType.SimpleName, false));
					string text2 = null;
					string text3 = null;
					foreach (X509Extension x509Extension in x509Certificate.Extensions)
					{
						if (x509Extension.Oid.Value == "2.5.29.14")
						{
							text3 = ((X509SubjectKeyIdentifierExtension)x509Extension).SubjectKeyIdentifier;
							traceString = traceString + Environment.NewLine + string.Format("Subject KeyID={0}", text3);
							break;
						}
						if (x509Extension.Oid.Value == "2.5.29.1" || x509Extension.Oid.Value == "2.5.29.35")
						{
							byte[] rawData = x509Extension.RawData;
							try
							{
								int num = 0;
								if (rawData[num++] == 48 && Program.GetEncodedLength(rawData, ref num) + num <= rawData.Length && rawData[num++] == 128)
								{
									int encodedLength = Program.GetEncodedLength(rawData, ref num);
									if (encodedLength + num <= rawData.Length)
									{
										StringBuilder stringBuilder = new StringBuilder(encodedLength * 2);
										while (encodedLength-- > 0)
										{
											stringBuilder.AppendFormat("{0:X2}", rawData[num++]);
										}
										text2 = stringBuilder.ToString();
										traceString = traceString + Environment.NewLine + string.Format("Authority KeyID={0}", text2);
									}
								}
							}
							catch (Exception ex)
							{
								traceString = traceString + Environment.NewLine + string.Format("Exception getting certificate Auhority: {0}", ex.Message);
								return null;
							}
						}
						if (text3 != null && text2 != null)
						{
							break;
						}
					}
					if (x509Certificate.Issuer.Equals(x509Certificate.Subject))
					{
						text = x509Certificate.GetNameInfo(X509NameType.SimpleName, false);
						traceString = traceString + Environment.NewLine + string.Format("Assuming root certificate: {0}", text);
					}
					else
					{
						X509Certificate2Collection x509Certificate2Collection2 = x509Certificate2Collection.Find(X509FindType.FindBySubjectDistinguishedName, x509Certificate.Issuer, false);
						if (x509Certificate2Collection2.Count == 0)
						{
							traceString = traceString + Environment.NewLine + string.Format("Issuer for {0} not found!", x509Certificate.GetNameInfo(X509NameType.SimpleName, false));
							return null;
						}
						string text4 = null;
						foreach (X509Certificate2 x509Certificate2 in x509Certificate2Collection2)
						{
							foreach (X509Extension x509Extension2 in x509Certificate2.Extensions)
							{
								if (x509Extension2.Oid.Value == "2.5.29.14")
								{
									text4 = ((X509SubjectKeyIdentifierExtension)x509Extension2).SubjectKeyIdentifier;
									traceString = traceString + Environment.NewLine + string.Format("Issuer KeyID={0}", text4);
									if (text2 != null && !text4.Equals(text2))
									{
										text4 = null;
										break;
									}
									break;
								}
							}
							if (text4 != null)
							{
								break;
							}
						}
						if (text2 != null && text4 == null)
						{
							traceString = traceString + Environment.NewLine + string.Format("Valid issuer for {0} not found!", x509Certificate.GetNameInfo(X509NameType.SimpleName, false));
							return null;
						}
					}
				}
				if (text == null)
				{
					traceString = traceString + Environment.NewLine + string.Format("Root/self-signed certificate not found in {0}", file);
					return null;
				}
				return x509Certificate2Collection.Export(X509ContentType.Pkcs7);
			}
			catch (Exception ex2)
			{
				traceString = string.Format("Exception reading CA: {0}", ex2.Message);
			}
			return null;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000033C4 File Offset: 0x000015C4
		private static void Usage(string msg)
		{
			if (msg != null)
			{
				Console.WriteLine("{0}", msg);
			}
			Console.WriteLine("\nUsage: PCmoverCertificate <options>...\n\nOptions:\n\n-HttpsPort <port>\t\thttps port for the CA server (default 443)\n-Request <email address>\tGenerate a CSR, send it to the server and install the returned certificate in the \"My\" store.\n-SelfSigned <email address>\tGenerate a self-signed certificate and install it in the \"My\" store.\n-Uninstall\t\t\tRemove the certificate installed by '-Request' or '-SelfSigned'\n-TestSSL\t\t\tMake a test SSL connection using the certificate installed by '-Request'\n-ClientCertificate <certificate name>\t\tCertificate to be used by the client during '-TestSSL'\n-ClientCertificateRequired <certificate name>\tClient certificate required by the server during '-TestSSL'\n-Info\t\t\t\tList information about the PCmover certificate and CA.\n-InstalledCertificate\t\tList information about the PCmover certificate.\n-CustomerCA <file path or '-'>\tRequire certificates from the customer CA file.\n\t\t\t\tUse '-' (without the quotes) for file-open dialog.\n-AllowNetBIOSCertificateName\tUse just the NetBIOS computer name for certificate names.\n\nNOTES:\n\nThe PCmover CA certificate is stored in the registry, not a system store.\nOptions are processed in the order they appear on the command line.\n");
			Environment.Exit(-1);
		}
	}
}
