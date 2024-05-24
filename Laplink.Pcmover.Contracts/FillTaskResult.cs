using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000069 RID: 105
	public enum FillTaskResult
	{
		// Token: 0x04000273 RID: 627
		Success,
		// Token: 0x04000274 RID: 628
		NotInitialized,
		// Token: 0x04000275 RID: 629
		SelfTransferDisallowed,
		// Token: 0x04000276 RID: 630
		InvalidMachineHandle,
		// Token: 0x04000277 RID: 631
		DomainsDoNotMatch,
		// Token: 0x04000278 RID: 632
		CreateFailed,
		// Token: 0x04000279 RID: 633
		ConfigureFailed,
		// Token: 0x0400027A RID: 634
		UnexpectedException,
		// Token: 0x0400027B RID: 635
		UnverifiedHardwareOemOnOld,
		// Token: 0x0400027C RID: 636
		UnverifiedHardwareOemOnNew
	}
}
