using System;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x0200003E RID: 62
	[Flags]
	public enum ExecutionStates
	{
		// Token: 0x04000230 RID: 560
		None = 0,
		// Token: 0x04000231 RID: 561
		SystemRequired = 1,
		// Token: 0x04000232 RID: 562
		DisplayRequired = 2,
		// Token: 0x04000233 RID: 563
		AwayModeRequired = 64,
		// Token: 0x04000234 RID: 564
		Continuous = -2147483648
	}
}
