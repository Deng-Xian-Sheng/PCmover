using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000061 RID: 97
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct CREATESTRUCT
	{
		// Token: 0x04000512 RID: 1298
		public IntPtr lpCreateParams;

		// Token: 0x04000513 RID: 1299
		public IntPtr hInstance;

		// Token: 0x04000514 RID: 1300
		public IntPtr hMenu;

		// Token: 0x04000515 RID: 1301
		public IntPtr hwndParent;

		// Token: 0x04000516 RID: 1302
		public int cy;

		// Token: 0x04000517 RID: 1303
		public int cx;

		// Token: 0x04000518 RID: 1304
		public int y;

		// Token: 0x04000519 RID: 1305
		public int x;

		// Token: 0x0400051A RID: 1306
		public WS style;

		// Token: 0x0400051B RID: 1307
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszName;

		// Token: 0x0400051C RID: 1308
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpszClass;

		// Token: 0x0400051D RID: 1309
		public WS_EX dwExStyle;
	}
}
