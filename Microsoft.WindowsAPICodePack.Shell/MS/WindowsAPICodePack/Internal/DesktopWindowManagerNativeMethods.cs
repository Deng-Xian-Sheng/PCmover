using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.WindowsAPICodePack.Shell;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000021 RID: 33
	[SuppressUnmanagedCodeSecurity]
	internal static class DesktopWindowManagerNativeMethods
	{
		// Token: 0x06000117 RID: 279
		[DllImport("DwmApi.dll")]
		internal static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref Margins m);

		// Token: 0x06000118 RID: 280
		[DllImport("DwmApi.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DwmIsCompositionEnabled();

		// Token: 0x06000119 RID: 281
		[DllImport("DwmApi.dll")]
		internal static extern int DwmEnableComposition(CompositionEnable compositionAction);

		// Token: 0x0600011A RID: 282
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetWindowRect(IntPtr hwnd, out NativeRect rect);

		// Token: 0x0600011B RID: 283
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetClientRect(IntPtr hwnd, out NativeRect rect);
	}
}
