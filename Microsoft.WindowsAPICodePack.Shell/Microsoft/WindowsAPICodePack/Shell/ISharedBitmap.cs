using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Taskbar;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200016B RID: 363
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("091162a4-bc96-411f-aae8-c5122cd03363")]
	[ComImport]
	internal interface ISharedBitmap
	{
		// Token: 0x06000E5E RID: 3678
		void GetSharedBitmap(out IntPtr phbm);

		// Token: 0x06000E5F RID: 3679
		void GetSize(out CoreNativeMethods.Size pSize);

		// Token: 0x06000E60 RID: 3680
		void GetFormat(out ThumbnailAlphaType pat);

		// Token: 0x06000E61 RID: 3681
		void InitializeBitmap([In] IntPtr hbm, [In] ThumbnailAlphaType wtsAT);

		// Token: 0x06000E62 RID: 3682
		void Detach(out IntPtr phbm);
	}
}
