using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000012 RID: 18
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("fec87aaf-35f9-447a-adb7-20234491401a")]
	[ComImport]
	internal interface IPreviewHandlerFrame
	{
		// Token: 0x06000067 RID: 103
		void GetWindowContext(IntPtr pinfo);

		// Token: 0x06000068 RID: 104
		[PreserveSig]
		HResult TranslateAccelerator(ref Message pmsg);
	}
}
