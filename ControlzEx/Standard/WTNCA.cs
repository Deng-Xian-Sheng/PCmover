using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000042 RID: 66
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Flags]
	public enum WTNCA : uint
	{
		// Token: 0x04000448 RID: 1096
		NODRAWCAPTION = 1U,
		// Token: 0x04000449 RID: 1097
		NODRAWICON = 2U,
		// Token: 0x0400044A RID: 1098
		NOSYSMENU = 4U,
		// Token: 0x0400044B RID: 1099
		NOMIRRORHELP = 8U,
		// Token: 0x0400044C RID: 1100
		VALIDBITS = 15U
	}
}
