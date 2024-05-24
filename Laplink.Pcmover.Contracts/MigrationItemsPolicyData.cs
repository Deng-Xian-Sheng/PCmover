using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200001F RID: 31
	public class MigrationItemsPolicyData
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000029FB File Offset: 0x00000BFB
		// (set) Token: 0x0600009E RID: 158 RVA: 0x00002A03 File Offset: 0x00000C03
		public MigrationItemsOption DefaultOption { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002A0C File Offset: 0x00000C0C
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00002A14 File Offset: 0x00000C14
		public MigrationItemsEnabled Enabled { get; set; } = MigrationItemsEnabled.All | MigrationItemsEnabled.FilesAndSettings | MigrationItemsEnabled.FilesOnly;
	}
}
