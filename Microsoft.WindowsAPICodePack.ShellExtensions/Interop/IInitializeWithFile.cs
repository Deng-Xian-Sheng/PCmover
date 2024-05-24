using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x0200000B RID: 11
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b7d14566-0509-4cce-a71f-0a554233bd9b")]
	[ComImport]
	internal interface IInitializeWithFile
	{
		// Token: 0x06000014 RID: 20
		void Initialize([MarshalAs(UnmanagedType.LPWStr)] string filePath, AccessModes fileMode);
	}
}
