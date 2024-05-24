using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000011 RID: 17
	public class AppUpdateData
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000026B6 File Offset: 0x000008B6
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000026BE File Offset: 0x000008BE
		public bool Checked { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000026C7 File Offset: 0x000008C7
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000026CF File Offset: 0x000008CF
		public string AppUpdateUrl { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000026D8 File Offset: 0x000008D8
		// (set) Token: 0x06000053 RID: 83 RVA: 0x000026E0 File Offset: 0x000008E0
		public bool AppUpdateAvailable { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000026E9 File Offset: 0x000008E9
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000026F1 File Offset: 0x000008F1
		public bool AppUpdateRequired { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000026FA File Offset: 0x000008FA
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002702 File Offset: 0x00000902
		public bool DataUpdateAvailable { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000270B File Offset: 0x0000090B
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002713 File Offset: 0x00000913
		public bool DataUpdateRequired { get; set; }
	}
}
