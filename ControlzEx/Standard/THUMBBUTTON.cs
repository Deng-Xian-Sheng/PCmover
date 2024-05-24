using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200009F RID: 159
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
	internal struct THUMBBUTTON
	{
		// Token: 0x040006A5 RID: 1701
		public const int THBN_CLICKED = 6144;

		// Token: 0x040006A6 RID: 1702
		public THB dwMask;

		// Token: 0x040006A7 RID: 1703
		public uint iId;

		// Token: 0x040006A8 RID: 1704
		public uint iBitmap;

		// Token: 0x040006A9 RID: 1705
		public IntPtr hIcon;

		// Token: 0x040006AA RID: 1706
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szTip;

		// Token: 0x040006AB RID: 1707
		public THBF dwFlags;
	}
}
