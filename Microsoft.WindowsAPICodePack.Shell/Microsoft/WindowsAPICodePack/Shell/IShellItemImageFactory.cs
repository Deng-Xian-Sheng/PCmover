using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000169 RID: 361
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
	[ComImport]
	internal interface IShellItemImageFactory
	{
		// Token: 0x06000E5B RID: 3675
		[PreserveSig]
		HResult GetImage([MarshalAs(UnmanagedType.Struct)] [In] CoreNativeMethods.Size size, [In] ShellNativeMethods.SIIGBF flags, out IntPtr phbm);
	}
}
