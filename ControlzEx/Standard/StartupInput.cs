using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000075 RID: 117
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential)]
	public class StartupInput
	{
		// Token: 0x04000591 RID: 1425
		public int GdiplusVersion = 1;

		// Token: 0x04000592 RID: 1426
		public IntPtr DebugEventCallback;

		// Token: 0x04000593 RID: 1427
		public bool SuppressBackgroundThread;

		// Token: 0x04000594 RID: 1428
		public bool SuppressExternalCodecs;
	}
}
