using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000005 RID: 5
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("8895b1c6-b41f-4c1c-a562-0d564250836f")]
	[ComImport]
	internal interface IPreviewHandler
	{
		// Token: 0x06000004 RID: 4
		void SetWindow(IntPtr hwnd, ref NativeRect rect);

		// Token: 0x06000005 RID: 5
		void SetRect(ref NativeRect rect);

		// Token: 0x06000006 RID: 6
		void DoPreview();

		// Token: 0x06000007 RID: 7
		void Unload();

		// Token: 0x06000008 RID: 8
		void SetFocus();

		// Token: 0x06000009 RID: 9
		void QueryFocus(out IntPtr phwnd);

		// Token: 0x0600000A RID: 10
		[PreserveSig]
		HResult TranslateAccelerator(ref Message pmsg);
	}
}
