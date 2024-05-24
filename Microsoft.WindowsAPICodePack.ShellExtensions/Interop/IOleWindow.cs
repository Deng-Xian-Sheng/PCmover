using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000007 RID: 7
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("00000114-0000-0000-C000-000000000046")]
	[ComImport]
	internal interface IOleWindow
	{
		// Token: 0x0600000E RID: 14
		void GetWindow(out IntPtr phwnd);

		// Token: 0x0600000F RID: 15
		void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
	}
}
