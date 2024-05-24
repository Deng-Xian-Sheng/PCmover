using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200003D RID: 61
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[Flags]
	public enum MF : uint
	{
		// Token: 0x0400042B RID: 1067
		DOES_NOT_EXIST = 4294967295U,
		// Token: 0x0400042C RID: 1068
		ENABLED = 0U,
		// Token: 0x0400042D RID: 1069
		BYCOMMAND = 0U,
		// Token: 0x0400042E RID: 1070
		GRAYED = 1U,
		// Token: 0x0400042F RID: 1071
		DISABLED = 2U
	}
}
