using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200004F RID: 79
	public enum PcmoverState
	{
		// Token: 0x040001CD RID: 461
		idle,
		// Token: 0x040001CE RID: 462
		initInProgress,
		// Token: 0x040001CF RID: 463
		initialized,
		// Token: 0x040001D0 RID: 464
		initializationFailed,
		// Token: 0x040001D1 RID: 465
		shutdownInProgress,
		// Token: 0x040001D2 RID: 466
		terminated,
		// Token: 0x040001D3 RID: 467
		rebooting,
		// Token: 0x040001D4 RID: 468
		invalid
	}
}
