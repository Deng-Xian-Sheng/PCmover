using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200003E RID: 62
	public enum GetSnapshotActivityPhase
	{
		// Token: 0x04000176 RID: 374
		Idle,
		// Token: 0x04000177 RID: 375
		Connecting,
		// Token: 0x04000178 RID: 376
		CheckingVersion,
		// Token: 0x04000179 RID: 377
		RequestingSnapshot,
		// Token: 0x0400017A RID: 378
		WaitingForSnapshotReady,
		// Token: 0x0400017B RID: 379
		ReceivingSnapshot,
		// Token: 0x0400017C RID: 380
		GetSnapshotEnded
	}
}
