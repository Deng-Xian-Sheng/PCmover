using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000042 RID: 66
	internal static class StockIconsNativeMethods
	{
		// Token: 0x06000274 RID: 628
		[DllImport("Shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern HResult SHGetStockIconInfo(StockIconIdentifier identifier, StockIconsNativeMethods.StockIconOptions flags, ref StockIconsNativeMethods.StockIconInfo info);

		// Token: 0x02000043 RID: 67
		[Flags]
		internal enum StockIconOptions
		{
			// Token: 0x040000FC RID: 252
			Large = 0,
			// Token: 0x040000FD RID: 253
			Small = 1,
			// Token: 0x040000FE RID: 254
			ShellSize = 4,
			// Token: 0x040000FF RID: 255
			Handle = 256,
			// Token: 0x04000100 RID: 256
			SystemIndex = 16384,
			// Token: 0x04000101 RID: 257
			LinkOverlay = 32768,
			// Token: 0x04000102 RID: 258
			Selected = 65536
		}

		// Token: 0x02000044 RID: 68
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct StockIconInfo
		{
			// Token: 0x04000103 RID: 259
			internal uint StuctureSize;

			// Token: 0x04000104 RID: 260
			internal IntPtr Handle;

			// Token: 0x04000105 RID: 261
			internal int ImageIndex;

			// Token: 0x04000106 RID: 262
			internal int Identifier;

			// Token: 0x04000107 RID: 263
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			internal string Path;
		}
	}
}
