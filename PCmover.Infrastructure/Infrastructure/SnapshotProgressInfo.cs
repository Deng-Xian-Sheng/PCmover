using System;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000037 RID: 55
	public class SnapshotProgressInfo
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000081B0 File Offset: 0x000063B0
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000081B8 File Offset: 0x000063B8
		public int TotalItems { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060002CE RID: 718 RVA: 0x000081C1 File Offset: 0x000063C1
		// (set) Token: 0x060002CF RID: 719 RVA: 0x000081C9 File Offset: 0x000063C9
		public ProgressInfo ProgressInfo { get; set; }
	}
}
