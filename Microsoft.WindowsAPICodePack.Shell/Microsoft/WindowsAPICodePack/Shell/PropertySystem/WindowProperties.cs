using System;
using System.Windows;
using System.Windows.Interop;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200010F RID: 271
	public static class WindowProperties
	{
		// Token: 0x06000B86 RID: 2950 RVA: 0x0002CAFB File Offset: 0x0002ACFB
		public static void SetWindowProperty(IntPtr windowHandle, PropertyKey propKey, string value)
		{
			TaskbarNativeMethods.SetWindowProperty(windowHandle, propKey, value);
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0002CB07 File Offset: 0x0002AD07
		public static void SetWindowProperty(Window window, PropertyKey propKey, string value)
		{
			TaskbarNativeMethods.SetWindowProperty(new WindowInteropHelper(window).Handle, propKey, value);
		}
	}
}
