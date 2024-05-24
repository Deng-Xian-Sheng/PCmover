using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000025 RID: 37
	public class ExpandSnapshotActivityParameters
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00002BCF File Offset: 0x00000DCF
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00002BD7 File Offset: 0x00000DD7
		public int MachineHandle { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00002BE0 File Offset: 0x00000DE0
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00002BE8 File Offset: 0x00000DE8
		public ItemType ItemType { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00002BF1 File Offset: 0x00000DF1
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00002BF9 File Offset: 0x00000DF9
		public bool RegularUsersOnly { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00002C02 File Offset: 0x00000E02
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00002C0A File Offset: 0x00000E0A
		public bool ExpandGlobalCategories { get; set; }
	}
}
