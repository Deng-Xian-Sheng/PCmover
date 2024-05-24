using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000070 RID: 112
	public enum TransferActivityFailureReason
	{
		// Token: 0x040002AA RID: 682
		None,
		// Token: 0x040002AB RID: 683
		Unknown,
		// Token: 0x040002AC RID: 684
		Cancelled,
		// Token: 0x040002AD RID: 685
		Exception,
		// Token: 0x040002AE RID: 686
		FailedToConnect,
		// Token: 0x040002AF RID: 687
		CommunicationError,
		// Token: 0x040002B0 RID: 688
		VersionVerificationFailed,
		// Token: 0x040002B1 RID: 689
		BadPassword,
		// Token: 0x040002B2 RID: 690
		SendJournalFailed,
		// Token: 0x040002B3 RID: 691
		CreateTask,
		// Token: 0x040002B4 RID: 692
		ReadHeader,
		// Token: 0x040002B5 RID: 693
		ProcessHeader,
		// Token: 0x040002B6 RID: 694
		SerialNumberRequired,
		// Token: 0x040002B7 RID: 695
		ProcessData
	}
}
