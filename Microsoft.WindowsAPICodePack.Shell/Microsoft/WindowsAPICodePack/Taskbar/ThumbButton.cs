using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000139 RID: 313
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct ThumbButton
	{
		// Token: 0x04000552 RID: 1362
		internal const int Clicked = 6144;

		// Token: 0x04000553 RID: 1363
		[MarshalAs(UnmanagedType.U4)]
		internal ThumbButtonMask Mask;

		// Token: 0x04000554 RID: 1364
		internal uint Id;

		// Token: 0x04000555 RID: 1365
		internal uint Bitmap;

		// Token: 0x04000556 RID: 1366
		internal IntPtr Icon;

		// Token: 0x04000557 RID: 1367
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		internal string Tip;

		// Token: 0x04000558 RID: 1368
		[MarshalAs(UnmanagedType.U4)]
		internal ThumbButtonOptions Flags;
	}
}
