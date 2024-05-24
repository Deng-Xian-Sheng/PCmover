using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000009 RID: 9
	public enum ConnectingActivityFailureReason
	{
		// Token: 0x0400002D RID: 45
		None,
		// Token: 0x0400002E RID: 46
		Unknown,
		// Token: 0x0400002F RID: 47
		Cancelled,
		// Token: 0x04000030 RID: 48
		Exception,
		// Token: 0x04000031 RID: 49
		FailedToConnect,
		// Token: 0x04000032 RID: 50
		CommunicationError,
		// Token: 0x04000033 RID: 51
		VersionVerificationFailed,
		// Token: 0x04000034 RID: 52
		BadPassword
	}
}
