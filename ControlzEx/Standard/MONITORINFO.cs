using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000C0 RID: 192
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class MONITORINFO
	{
		// Token: 0x040006C2 RID: 1730
		public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

		// Token: 0x040006C3 RID: 1731
		public RECT rcMonitor;

		// Token: 0x040006C4 RID: 1732
		public RECT rcWork;

		// Token: 0x040006C5 RID: 1733
		public int dwFlags;
	}
}
