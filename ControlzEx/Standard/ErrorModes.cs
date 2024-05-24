using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200002D RID: 45
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Flags]
	public enum ErrorModes
	{
		// Token: 0x040001BB RID: 443
		Default = 0,
		// Token: 0x040001BC RID: 444
		FailCriticalErrors = 1,
		// Token: 0x040001BD RID: 445
		NoGpFaultErrorBox = 2,
		// Token: 0x040001BE RID: 446
		NoAlignmentFaultExcept = 4,
		// Token: 0x040001BF RID: 447
		NoOpenFileErrorBox = 32768
	}
}
