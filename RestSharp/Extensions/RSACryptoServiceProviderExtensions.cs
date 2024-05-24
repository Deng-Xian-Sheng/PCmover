using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml;

namespace RestSharp.Extensions
{
	// Token: 0x0200004B RID: 75
	[NullableContext(1)]
	[Nullable(0)]
	public static class RSACryptoServiceProviderExtensions
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x0000BD5D File Offset: 0x00009F5D
		public static void FromXmlString2(this RSACryptoServiceProvider rsa, string xmlString)
		{
			rsa.FromXmlString(xmlString);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0000BD68 File Offset: 0x00009F68
		internal static void FromXmlStringImpl(RSACryptoServiceProvider rsa, string xmlString)
		{
			RSAParameters parameters = default(RSAParameters);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xmlString);
			if (!xmlDocument.DocumentElement.Name.Equals("RSAKeyValue"))
			{
				throw new InvalidOperationException("Invalid XML RSA key.");
			}
			foreach (object obj in xmlDocument.DocumentElement.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				string name = xmlNode.Name;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
				if (num <= 2183145318U)
				{
					if (num <= 684613497U)
					{
						if (num != 667835878U)
						{
							if (num == 684613497U)
							{
								if (name == "DP")
								{
									parameters.DP = Convert.FromBase64String(xmlNode.InnerText);
									continue;
								}
							}
						}
						else if (name == "DQ")
						{
							parameters.DQ = Convert.FromBase64String(xmlNode.InnerText);
							continue;
						}
					}
					else if (num != 1898057334U)
					{
						if (num == 2183145318U)
						{
							if (name == "Exponent")
							{
								parameters.Exponent = Convert.FromBase64String(xmlNode.InnerText);
								continue;
							}
						}
					}
					else if (name == "InverseQ")
					{
						parameters.InverseQ = Convert.FromBase64String(xmlNode.InnerText);
						continue;
					}
				}
				else if (num <= 3557560316U)
				{
					if (num != 3238785555U)
					{
						if (num == 3557560316U)
						{
							if (name == "Q")
							{
								parameters.Q = Convert.FromBase64String(xmlNode.InnerText);
								continue;
							}
						}
					}
					else if (name == "D")
					{
						parameters.D = Convert.FromBase64String(xmlNode.InnerText);
						continue;
					}
				}
				else if (num != 3574337935U)
				{
					if (num == 3883103162U)
					{
						if (name == "Modulus")
						{
							parameters.Modulus = Convert.FromBase64String(xmlNode.InnerText);
							continue;
						}
					}
				}
				else if (name == "P")
				{
					parameters.P = Convert.FromBase64String(xmlNode.InnerText);
					continue;
				}
				throw new InvalidOperationException("Unknown node name: " + xmlNode.Name);
			}
			rsa.ImportParameters(parameters);
		}
	}
}
