using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000063 RID: 99
	public enum SerialNumberInfoResult
	{
		// Token: 0x04000250 RID: 592
		Unknown,
		// Token: 0x04000251 RID: 593
		NotInitialized,
		// Token: 0x04000252 RID: 594
		InternetAccessProblem,
		// Token: 0x04000253 RID: 595
		InvalidSerialNumber,
		// Token: 0x04000254 RID: 596
		ValidSerialNumber,
		// Token: 0x04000255 RID: 597
		IsValidationCode,
		// Token: 0x04000256 RID: 598
		ProxyAuthRequired
	}
}
