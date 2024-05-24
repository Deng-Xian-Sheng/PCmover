using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200007B RID: 123
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct MOUSEINPUT
	{
		// Token: 0x040005C2 RID: 1474
		public int dx;

		// Token: 0x040005C3 RID: 1475
		public int dy;

		// Token: 0x040005C4 RID: 1476
		public int mouseData;

		// Token: 0x040005C5 RID: 1477
		public int dwFlags;

		// Token: 0x040005C6 RID: 1478
		public int time;

		// Token: 0x040005C7 RID: 1479
		public IntPtr dwExtraInfo;
	}
}
