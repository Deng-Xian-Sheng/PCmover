using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200007A RID: 122
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct WINDOWINFO
	{
		// Token: 0x040005B8 RID: 1464
		public int cbSize;

		// Token: 0x040005B9 RID: 1465
		public RECT rcWindow;

		// Token: 0x040005BA RID: 1466
		public RECT rcClient;

		// Token: 0x040005BB RID: 1467
		public int dwStyle;

		// Token: 0x040005BC RID: 1468
		public int dwExStyle;

		// Token: 0x040005BD RID: 1469
		public uint dwWindowStatus;

		// Token: 0x040005BE RID: 1470
		public uint cxWindowBorders;

		// Token: 0x040005BF RID: 1471
		public uint cyWindowBorders;

		// Token: 0x040005C0 RID: 1472
		public ushort atomWindowType;

		// Token: 0x040005C1 RID: 1473
		public ushort wCreatorVersion;
	}
}
