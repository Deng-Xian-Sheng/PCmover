using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000071 RID: 113
	public enum TransferProcessResult
	{
		// Token: 0x040002B9 RID: 697
		Success,
		// Token: 0x040002BA RID: 698
		UserStop,
		// Token: 0x040002BB RID: 699
		EofIntentional,
		// Token: 0x040002BC RID: 700
		EofUnexpected = 8,
		// Token: 0x040002BD RID: 701
		DiskFull,
		// Token: 0x040002BE RID: 702
		ConnectionError,
		// Token: 0x040002BF RID: 703
		InternalError,
		// Token: 0x040002C0 RID: 704
		OtherError,
		// Token: 0x040002C1 RID: 705
		InvalidTask,
		// Token: 0x040002C2 RID: 706
		TransferFailed,
		// Token: 0x040002C3 RID: 707
		BeginUnexpected = 8
	}
}
