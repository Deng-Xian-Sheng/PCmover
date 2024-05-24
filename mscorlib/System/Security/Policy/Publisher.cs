using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Security.Policy
{
	// Token: 0x02000376 RID: 886
	[ComVisible(true)]
	[Serializable]
	public sealed class Publisher : EvidenceBase, IIdentityPermissionFactory
	{
		// Token: 0x06002BFB RID: 11259 RVA: 0x000A3E34 File Offset: 0x000A2034
		public Publisher(X509Certificate cert)
		{
			if (cert == null)
			{
				throw new ArgumentNullException("cert");
			}
			this.m_cert = cert;
		}

		// Token: 0x06002BFC RID: 11260 RVA: 0x000A3E51 File Offset: 0x000A2051
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new PublisherIdentityPermission(this.m_cert);
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x000A3E60 File Offset: 0x000A2060
		public override bool Equals(object o)
		{
			Publisher publisher = o as Publisher;
			return publisher != null && Publisher.PublicKeyEquals(this.m_cert, publisher.m_cert);
		}

		// Token: 0x06002BFE RID: 11262 RVA: 0x000A3E8C File Offset: 0x000A208C
		internal static bool PublicKeyEquals(X509Certificate cert1, X509Certificate cert2)
		{
			if (cert1 == null)
			{
				return cert2 == null;
			}
			if (cert2 == null)
			{
				return false;
			}
			byte[] publicKey = cert1.GetPublicKey();
			string keyAlgorithm = cert1.GetKeyAlgorithm();
			byte[] keyAlgorithmParameters = cert1.GetKeyAlgorithmParameters();
			byte[] publicKey2 = cert2.GetPublicKey();
			string keyAlgorithm2 = cert2.GetKeyAlgorithm();
			byte[] keyAlgorithmParameters2 = cert2.GetKeyAlgorithmParameters();
			int num = publicKey.Length;
			if (num != publicKey2.Length)
			{
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				if (publicKey[i] != publicKey2[i])
				{
					return false;
				}
			}
			if (!keyAlgorithm.Equals(keyAlgorithm2))
			{
				return false;
			}
			num = keyAlgorithmParameters.Length;
			if (keyAlgorithmParameters2.Length != num)
			{
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				if (keyAlgorithmParameters[j] != keyAlgorithmParameters2[j])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002BFF RID: 11263 RVA: 0x000A3F37 File Offset: 0x000A2137
		public override int GetHashCode()
		{
			return this.m_cert.GetHashCode();
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06002C00 RID: 11264 RVA: 0x000A3F44 File Offset: 0x000A2144
		public X509Certificate Certificate
		{
			get
			{
				return new X509Certificate(this.m_cert);
			}
		}

		// Token: 0x06002C01 RID: 11265 RVA: 0x000A3F51 File Offset: 0x000A2151
		public override EvidenceBase Clone()
		{
			return new Publisher(this.m_cert);
		}

		// Token: 0x06002C02 RID: 11266 RVA: 0x000A3F5E File Offset: 0x000A215E
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002C03 RID: 11267 RVA: 0x000A3F68 File Offset: 0x000A2168
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Publisher");
			securityElement.AddAttribute("version", "1");
			securityElement.AddChild(new SecurityElement("X509v3Certificate", (this.m_cert != null) ? this.m_cert.GetRawCertDataString() : ""));
			return securityElement;
		}

		// Token: 0x06002C04 RID: 11268 RVA: 0x000A3FBB File Offset: 0x000A21BB
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002C05 RID: 11269 RVA: 0x000A3FC8 File Offset: 0x000A21C8
		internal object Normalize()
		{
			return new MemoryStream(this.m_cert.GetRawCertData())
			{
				Position = 0L
			};
		}

		// Token: 0x040011B2 RID: 4530
		private X509Certificate m_cert;
	}
}
