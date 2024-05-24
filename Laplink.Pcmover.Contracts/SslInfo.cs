using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000084 RID: 132
	public class SslInfo
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000373 RID: 883 RVA: 0x0000414A File Offset: 0x0000234A
		// (set) Token: 0x06000374 RID: 884 RVA: 0x00004152 File Offset: 0x00002352
		public bool IsSecure { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000375 RID: 885 RVA: 0x0000415B File Offset: 0x0000235B
		// (set) Token: 0x06000376 RID: 886 RVA: 0x00004163 File Offset: 0x00002363
		public SSLState State { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0000416C File Offset: 0x0000236C
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00004174 File Offset: 0x00002374
		public bool IsCertificateValid { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0000417D File Offset: 0x0000237D
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00004185 File Offset: 0x00002385
		public bool IsSSLClient { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600037B RID: 891 RVA: 0x0000418E File Offset: 0x0000238E
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00004196 File Offset: 0x00002396
		public byte[] PeerCertificate { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0000419F File Offset: 0x0000239F
		// (set) Token: 0x0600037E RID: 894 RVA: 0x000041A7 File Offset: 0x000023A7
		public byte[] LocalCertificate { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600037F RID: 895 RVA: 0x000041B0 File Offset: 0x000023B0
		public string Issuer
		{
			get
			{
				string result = string.Empty;
				if (this.PeerCertificate != null)
				{
					try
					{
						string[] array = Regex.Split(new X509Certificate2(this.PeerCertificate).Issuer, " \\+ ");
						for (int i = 0; i < array.Length; i++)
						{
							foreach (DistinguishedName.Part part in DistinguishedName.Parse(array[i]))
							{
								if (part.Name == "O")
								{
									return part.Value;
								}
								if (part.Name == "CN")
								{
									result = part.Value;
								}
							}
						}
					}
					catch (Exception)
					{
					}
					return result;
				}
				return result;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00004284 File Offset: 0x00002484
		public string PeerName
		{
			get
			{
				if (this.PeerCertificate != null)
				{
					try
					{
						string text = Regex.Split(new X509Certificate2(this.PeerCertificate).Subject, " \\+ ").FirstOrDefault((string dn) => dn.StartsWith("CN="));
						if (text != null)
						{
							return text.Substring(3);
						}
					}
					catch (Exception)
					{
					}
				}
				return string.Empty;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00004304 File Offset: 0x00002504
		public string PeerSerialNumber
		{
			get
			{
				if (this.PeerCertificate != null)
				{
					try
					{
						string text = Regex.Split(new X509Certificate2(this.PeerCertificate).Subject, " \\+ ").FirstOrDefault((string dn) => dn.StartsWith("SERIALNUMBER="));
						if (text != null)
						{
							return text.Substring(13);
						}
					}
					catch (Exception)
					{
						return string.Empty;
					}
				}
				return string.Empty;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00004388 File Offset: 0x00002588
		public string LocalIssuer
		{
			get
			{
				string result = string.Empty;
				if (this.LocalCertificate != null)
				{
					try
					{
						string[] array = Regex.Split(new X509Certificate2(this.LocalCertificate).Issuer, " \\+ ");
						for (int i = 0; i < array.Length; i++)
						{
							foreach (DistinguishedName.Part part in DistinguishedName.Parse(array[i]))
							{
								if (part.Name == "O")
								{
									return part.Value;
								}
								if (part.Name == "CN")
								{
									result = part.Value;
								}
							}
						}
					}
					catch (Exception)
					{
					}
					return result;
				}
				return result;
			}
		}
	}
}
