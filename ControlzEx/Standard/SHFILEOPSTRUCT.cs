using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000062 RID: 98
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
	public struct SHFILEOPSTRUCT
	{
		// Token: 0x0400051E RID: 1310
		public IntPtr hwnd;

		// Token: 0x0400051F RID: 1311
		[MarshalAs(UnmanagedType.U4)]
		public FO wFunc;

		// Token: 0x04000520 RID: 1312
		public string pFrom;

		// Token: 0x04000521 RID: 1313
		public string pTo;

		// Token: 0x04000522 RID: 1314
		[MarshalAs(UnmanagedType.U2)]
		public FOF fFlags;

		// Token: 0x04000523 RID: 1315
		[MarshalAs(UnmanagedType.Bool)]
		public int fAnyOperationsAborted;

		// Token: 0x04000524 RID: 1316
		public IntPtr hNameMappings;

		// Token: 0x04000525 RID: 1317
		public string lpszProgressTitle;
	}
}
