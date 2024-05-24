using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.Interop
{
	// Token: 0x0200003D RID: 61
	internal static class ShellObjectWatcherNativeMethods
	{
		// Token: 0x0600025A RID: 602
		[DllImport("Ole32.dll")]
		public static extern HResult CreateBindCtx(int reserved, out IBindCtx bindCtx);

		// Token: 0x0600025B RID: 603
		[DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern uint RegisterClassEx(ref WindowClassEx windowClass);

		// Token: 0x0600025C RID: 604
		[DllImport("User32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr CreateWindowEx(int extendedStyle, [MarshalAs(UnmanagedType.LPWStr)] string className, [MarshalAs(UnmanagedType.LPWStr)] string windowName, int style, int x, int y, int width, int height, IntPtr parentHandle, IntPtr menuHandle, IntPtr instanceHandle, IntPtr additionalData);

		// Token: 0x0600025D RID: 605
		[DllImport("User32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetMessage(out Message message, IntPtr windowHandle, uint filterMinMessage, uint filterMaxMessage);

		// Token: 0x0600025E RID: 606
		[DllImport("User32.dll")]
		public static extern int DefWindowProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam);

		// Token: 0x0600025F RID: 607
		[DllImport("User32.dll")]
		public static extern void DispatchMessage([In] ref Message message);

		// Token: 0x0200003E RID: 62
		// (Invoke) Token: 0x06000261 RID: 609
		public delegate int WndProcDelegate(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam);
	}
}
