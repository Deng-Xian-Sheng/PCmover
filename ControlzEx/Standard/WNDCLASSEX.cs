using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000079 RID: 121
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WNDCLASSEX
	{
		// Token: 0x040005AC RID: 1452
		public int cbSize;

		// Token: 0x040005AD RID: 1453
		public CS style;

		// Token: 0x040005AE RID: 1454
		public WndProc lpfnWndProc;

		// Token: 0x040005AF RID: 1455
		public int cbClsExtra;

		// Token: 0x040005B0 RID: 1456
		public int cbWndExtra;

		// Token: 0x040005B1 RID: 1457
		public IntPtr hInstance;

		// Token: 0x040005B2 RID: 1458
		public IntPtr hIcon;

		// Token: 0x040005B3 RID: 1459
		public IntPtr hCursor;

		// Token: 0x040005B4 RID: 1460
		public IntPtr hbrBackground;

		// Token: 0x040005B5 RID: 1461
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszMenuName;

		// Token: 0x040005B6 RID: 1462
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszClassName;

		// Token: 0x040005B7 RID: 1463
		public IntPtr hIconSm;
	}
}
