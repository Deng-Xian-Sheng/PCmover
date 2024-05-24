using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Interop
{
	// Token: 0x02000010 RID: 16
	internal static class HandlerNativeMethods
	{
		// Token: 0x06000062 RID: 98
		[DllImport("user32.dll")]
		internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		// Token: 0x06000063 RID: 99
		[DllImport("user32.dll")]
		internal static extern IntPtr GetFocus();

		// Token: 0x06000064 RID: 100
		[DllImport("user32.dll")]
		internal static extern void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPositionOptions flags);

		// Token: 0x0400000E RID: 14
		internal static readonly Guid IPreviewHandlerGuid = new Guid("8895b1c6-b41f-4c1c-a562-0d564250836f");

		// Token: 0x0400000F RID: 15
		internal static readonly Guid IThumbnailProviderGuid = new Guid("e357fccd-a995-4576-b01f-234630154e96");

		// Token: 0x04000010 RID: 16
		internal static readonly Guid IInitializeWithFileGuid = new Guid("b7d14566-0509-4cce-a71f-0a554233bd9b");

		// Token: 0x04000011 RID: 17
		internal static readonly Guid IInitializeWithStreamGuid = new Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f");

		// Token: 0x04000012 RID: 18
		internal static readonly Guid IInitializeWithItemGuid = new Guid("7f73be3f-fb79-493c-a6c7-7ee14e245841");

		// Token: 0x04000013 RID: 19
		internal static readonly Guid IMarshalGuid = new Guid("00000003-0000-0000-C000-000000000046");
	}
}
