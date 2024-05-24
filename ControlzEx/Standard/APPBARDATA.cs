using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000081 RID: 129
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct APPBARDATA
	{
		// Token: 0x040005FB RID: 1531
		public int cbSize;

		// Token: 0x040005FC RID: 1532
		public IntPtr hWnd;

		// Token: 0x040005FD RID: 1533
		public int uCallbackMessage;

		// Token: 0x040005FE RID: 1534
		public int uEdge;

		// Token: 0x040005FF RID: 1535
		public RECT rc;

		// Token: 0x04000600 RID: 1536
		public bool lParam;
	}
}
