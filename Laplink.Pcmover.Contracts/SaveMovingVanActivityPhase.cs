using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200005D RID: 93
	public enum SaveMovingVanActivityPhase
	{
		// Token: 0x0400022B RID: 555
		Idle,
		// Token: 0x0400022C RID: 556
		StartingTransfer,
		// Token: 0x0400022D RID: 557
		FinishedTransfer,
		// Token: 0x0400022E RID: 558
		FinishedTransferWithError,
		// Token: 0x0400022F RID: 559
		SavingLog
	}
}
