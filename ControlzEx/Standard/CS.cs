using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000036 RID: 54
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Flags]
	public enum CS : uint
	{
		// Token: 0x04000343 RID: 835
		VREDRAW = 1U,
		// Token: 0x04000344 RID: 836
		HREDRAW = 2U,
		// Token: 0x04000345 RID: 837
		DBLCLKS = 8U,
		// Token: 0x04000346 RID: 838
		OWNDC = 32U,
		// Token: 0x04000347 RID: 839
		CLASSDC = 64U,
		// Token: 0x04000348 RID: 840
		PARENTDC = 128U,
		// Token: 0x04000349 RID: 841
		NOCLOSE = 512U,
		// Token: 0x0400034A RID: 842
		SAVEBITS = 2048U,
		// Token: 0x0400034B RID: 843
		BYTEALIGNCLIENT = 4096U,
		// Token: 0x0400034C RID: 844
		BYTEALIGNWINDOW = 8192U,
		// Token: 0x0400034D RID: 845
		GLOBALCLASS = 16384U,
		// Token: 0x0400034E RID: 846
		IME = 65536U,
		// Token: 0x0400034F RID: 847
		DROPSHADOW = 131072U
	}
}
