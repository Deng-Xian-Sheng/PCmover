using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000011 RID: 17
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("e357fccd-a995-4576-b01f-234630154e96")]
	[ComImport]
	internal interface IThumbnailProvider
	{
		// Token: 0x06000066 RID: 102
		void GetThumbnail(uint squareLength, out IntPtr bitmapHandle, out uint bitmapType);
	}
}
