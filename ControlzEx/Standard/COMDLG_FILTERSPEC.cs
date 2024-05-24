using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200009E RID: 158
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct COMDLG_FILTERSPEC
	{
		// Token: 0x040006A3 RID: 1699
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszName;

		// Token: 0x040006A4 RID: 1700
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszSpec;
	}
}
