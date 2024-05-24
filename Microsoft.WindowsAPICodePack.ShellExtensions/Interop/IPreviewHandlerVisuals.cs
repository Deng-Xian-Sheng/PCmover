using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000006 RID: 6
	[Guid("8327b13c-b63f-4b24-9b8a-d010dcc3f599")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	internal interface IPreviewHandlerVisuals
	{
		// Token: 0x0600000B RID: 11
		void SetBackgroundColor(NativeColorRef color);

		// Token: 0x0600000C RID: 12
		void SetFont(ref LogFont plf);

		// Token: 0x0600000D RID: 13
		void SetTextColor(NativeColorRef color);
	}
}
