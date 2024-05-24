using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200016A RID: 362
	[Guid("F676C15D-596A-4ce2-8234-33996F445DB1")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IThumbnailCache
	{
		// Token: 0x06000E5C RID: 3676
		void GetThumbnail([In] IShellItem pShellItem, [In] uint cxyRequestedThumbSize, [In] ShellNativeMethods.ThumbnailOptions flags, out ISharedBitmap ppvThumb, out ShellNativeMethods.ThumbnailCacheOptions pOutFlags, [Out] ShellNativeMethods.ThumbnailId pThumbnailID);

		// Token: 0x06000E5D RID: 3677
		void GetThumbnailByID([In] ShellNativeMethods.ThumbnailId thumbnailID, [In] uint cxyRequestedThumbSize, out ISharedBitmap ppvThumb, out ShellNativeMethods.ThumbnailCacheOptions pOutFlags);
	}
}
