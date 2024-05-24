using System;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200003A RID: 58
	public class TransferCompleteInfo
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x000082C9 File Offset: 0x000064C9
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x000082D1 File Offset: 0x000064D1
		public ActivityInfo ActivityInfo { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x000082DA File Offset: 0x000064DA
		public TimeSpan ElapsedTime
		{
			get
			{
				return this.ActivityInfo.EndTimeUtc - this.ActivityInfo.StartTimeUtc;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x000082F7 File Offset: 0x000064F7
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x000082FF File Offset: 0x000064FF
		public TransferProcessResult TransferResult { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00008308 File Offset: 0x00006508
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00008310 File Offset: 0x00006510
		public TaskStats Stats { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00008319 File Offset: 0x00006519
		public bool TransferSucceeded
		{
			get
			{
				return this.ActivityInfo.State == ActivityState.Success || (this.ActivityInfo.FailureReason == 2 && this.TransferResult == TransferProcessResult.UserStop);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00008345 File Offset: 0x00006545
		public bool TransferComplete
		{
			get
			{
				return this.TransferSucceeded && (this.TransferResult == TransferProcessResult.Success || this.TransferResult == TransferProcessResult.EofIntentional);
			}
		}
	}
}
