using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200003F RID: 63
	public enum GetSnapshotActivityFailureReason
	{
		// Token: 0x0400017E RID: 382
		None,
		// Token: 0x0400017F RID: 383
		Unknown,
		// Token: 0x04000180 RID: 384
		Cancelled,
		// Token: 0x04000181 RID: 385
		Exception,
		// Token: 0x04000182 RID: 386
		FailedToConnect,
		// Token: 0x04000183 RID: 387
		CommunicationError,
		// Token: 0x04000184 RID: 388
		VersionVerificationFailed,
		// Token: 0x04000185 RID: 389
		BadPassword,
		// Token: 0x04000186 RID: 390
		GetSnapshotRejected,
		// Token: 0x04000187 RID: 391
		GetSnapshotFailed,
		// Token: 0x04000188 RID: 392
		CreateMachineFailed,
		// Token: 0x04000189 RID: 393
		InitMachineFailed,
		// Token: 0x0400018A RID: 394
		HostNotFound
	}
}
