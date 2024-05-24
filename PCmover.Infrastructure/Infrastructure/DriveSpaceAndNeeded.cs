using System;

namespace PCmover.Infrastructure
{
	// Token: 0x02000013 RID: 19
	public class DriveSpaceAndNeeded
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00004D8F File Offset: 0x00002F8F
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00004D97 File Offset: 0x00002F97
		public string Drive { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00004DA0 File Offset: 0x00002FA0
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00004DA8 File Offset: 0x00002FA8
		public ulong Required { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00004DB1 File Offset: 0x00002FB1
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00004DB9 File Offset: 0x00002FB9
		public ulong Available { get; set; }
	}
}
