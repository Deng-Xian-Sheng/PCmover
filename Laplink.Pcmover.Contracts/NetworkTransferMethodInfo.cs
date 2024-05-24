using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000082 RID: 130
	public class NetworkTransferMethodInfo
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00004106 File Offset: 0x00002306
		// (set) Token: 0x0600036B RID: 875 RVA: 0x0000410E File Offset: 0x0000230E
		public string Target { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00004117 File Offset: 0x00002317
		// (set) Token: 0x0600036D RID: 877 RVA: 0x0000411F File Offset: 0x0000231F
		public string Password { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00004128 File Offset: 0x00002328
		// (set) Token: 0x0600036F RID: 879 RVA: 0x00004130 File Offset: 0x00002330
		public bool bSecure { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00004139 File Offset: 0x00002339
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00004141 File Offset: 0x00002341
		public string CertificateName { get; set; }
	}
}
