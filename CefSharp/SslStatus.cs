using System;
using System.Security.Cryptography.X509Certificates;

namespace CefSharp
{
	// Token: 0x02000093 RID: 147
	public sealed class SslStatus
	{
		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00006BC0 File Offset: 0x00004DC0
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00006BC8 File Offset: 0x00004DC8
		public bool IsSecureConnection { get; private set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00006BD1 File Offset: 0x00004DD1
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00006BD9 File Offset: 0x00004DD9
		public CertStatus CertStatus { get; private set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x00006BE2 File Offset: 0x00004DE2
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x00006BEA File Offset: 0x00004DEA
		public SslVersion SslVersion { get; private set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00006BF3 File Offset: 0x00004DF3
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x00006BFB File Offset: 0x00004DFB
		public SslContentStatus ContentStatus { get; private set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00006C04 File Offset: 0x00004E04
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x00006C0C File Offset: 0x00004E0C
		public X509Certificate2 X509Certificate { get; private set; }

		// Token: 0x06000447 RID: 1095 RVA: 0x00006C15 File Offset: 0x00004E15
		public SslStatus(bool isSecureConnection, CertStatus certStatus, SslVersion sslVersion, SslContentStatus contentStatus, X509Certificate2 certificate)
		{
			this.IsSecureConnection = isSecureConnection;
			this.CertStatus = certStatus;
			this.SslVersion = sslVersion;
			this.ContentStatus = contentStatus;
			this.X509Certificate = certificate;
		}
	}
}
