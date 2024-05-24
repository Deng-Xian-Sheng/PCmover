using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200002F RID: 47
	public class CategoryParameters
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00002D38 File Offset: 0x00000F38
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00002D40 File Offset: 0x00000F40
		public ItemType Type { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00002D49 File Offset: 0x00000F49
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00002D51 File Offset: 0x00000F51
		public bool RegularUsersOnly { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00002D5A File Offset: 0x00000F5A
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00002D62 File Offset: 0x00000F62
		public bool IncludeCounts { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00002D6B File Offset: 0x00000F6B
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00002D73 File Offset: 0x00000F73
		public bool AllAppsOnly { get; set; }
	}
}
