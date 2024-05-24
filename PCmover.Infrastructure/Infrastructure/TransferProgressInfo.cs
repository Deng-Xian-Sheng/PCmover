using System;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000039 RID: 57
	public class TransferProgressInfo
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000081FF File Offset: 0x000063FF
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00008207 File Offset: 0x00006407
		public int TotalItems { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00008210 File Offset: 0x00006410
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00008218 File Offset: 0x00006418
		public int ItemsRemaining { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00008221 File Offset: 0x00006421
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00008229 File Offset: 0x00006429
		public string CurrentCategory { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00008232 File Offset: 0x00006432
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x0000823A File Offset: 0x0000643A
		public string CurrentItem { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00008244 File Offset: 0x00006444
		public string TimeRemaining
		{
			get
			{
				TimeSpan estimatedTimeRemaining = this.EstimatedTimeRemaining;
				return this.EstimatedTimeRemaining.ToString();
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060002DB RID: 731 RVA: 0x0000826C File Offset: 0x0000646C
		// (set) Token: 0x060002DC RID: 732 RVA: 0x00008274 File Offset: 0x00006474
		public TimeSpan EstimatedTimeRemaining { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060002DD RID: 733 RVA: 0x0000827D File Offset: 0x0000647D
		public double Progress
		{
			get
			{
				return (double)((this.ProgressInfo == null) ? 0 : this.ProgressInfo.Percentage);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00008296 File Offset: 0x00006496
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0000829E File Offset: 0x0000649E
		public TimeSpan ElapsedTime { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x000082A7 File Offset: 0x000064A7
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x000082AF File Offset: 0x000064AF
		public ActivityInfo ActivityInfo { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x000082B8 File Offset: 0x000064B8
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x000082C0 File Offset: 0x000064C0
		public ProgressInfo ProgressInfo { get; set; }
	}
}
