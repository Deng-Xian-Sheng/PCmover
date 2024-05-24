using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200006F RID: 111
	public enum TransferActivityPhase
	{
		// Token: 0x0400029C RID: 668
		Idle,
		// Token: 0x0400029D RID: 669
		Connecting,
		// Token: 0x0400029E RID: 670
		CheckingVersion,
		// Token: 0x0400029F RID: 671
		AuthorizingTransfer,
		// Token: 0x040002A0 RID: 672
		SendingJournal,
		// Token: 0x040002A1 RID: 673
		ReceivingVan,
		// Token: 0x040002A2 RID: 674
		Initializing,
		// Token: 0x040002A3 RID: 675
		ReadingHeader,
		// Token: 0x040002A4 RID: 676
		ProcessingHeader,
		// Token: 0x040002A5 RID: 677
		ProcessingData,
		// Token: 0x040002A6 RID: 678
		SavingLog,
		// Token: 0x040002A7 RID: 679
		SendingEnd,
		// Token: 0x040002A8 RID: 680
		ApplicationAutoRun
	}
}
