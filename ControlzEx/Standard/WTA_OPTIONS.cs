using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200006D RID: 109
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Explicit)]
	public struct WTA_OPTIONS
	{
		// Token: 0x04000579 RID: 1401
		public const uint Size = 8U;

		// Token: 0x0400057A RID: 1402
		[FieldOffset(0)]
		public WTNCA dwFlags;

		// Token: 0x0400057B RID: 1403
		[FieldOffset(4)]
		public WTNCA dwMask;
	}
}
