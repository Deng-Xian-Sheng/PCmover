using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000045 RID: 69
	public enum ListenActivityPhase
	{
		// Token: 0x04000190 RID: 400
		Idle,
		// Token: 0x04000191 RID: 401
		WaitingForConnection,
		// Token: 0x04000192 RID: 402
		ConnectedOn,
		// Token: 0x04000193 RID: 403
		WaitingForCommand,
		// Token: 0x04000194 RID: 404
		ProcessingCommand,
		// Token: 0x04000195 RID: 405
		AnalyzingPC,
		// Token: 0x04000196 RID: 406
		WaitingToCompleteTransfer,
		// Token: 0x04000197 RID: 407
		ReceivingTransferInstructions,
		// Token: 0x04000198 RID: 408
		WaitingToTransferData,
		// Token: 0x04000199 RID: 409
		StartingTransfer,
		// Token: 0x0400019A RID: 410
		FinishedTransfer,
		// Token: 0x0400019B RID: 411
		FinishedTransferWithError,
		// Token: 0x0400019C RID: 412
		SavingLog,
		// Token: 0x0400019D RID: 413
		VersionError,
		// Token: 0x0400019E RID: 414
		InvalidCommand,
		// Token: 0x0400019F RID: 415
		ListenProtocolEnded,
		// Token: 0x040001A0 RID: 416
		CommTest,
		// Token: 0x040001A1 RID: 417
		CommTestSucceeded,
		// Token: 0x040001A2 RID: 418
		CommTestFailed,
		// Token: 0x040001A3 RID: 419
		RemoteMachineNameReceived,
		// Token: 0x040001A4 RID: 420
		EndReceived,
		// Token: 0x040001A5 RID: 421
		SetDirection
	}
}
