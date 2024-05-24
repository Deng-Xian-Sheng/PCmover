using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using ControlzEx.Standard;

namespace ControlzEx.Native
{
	// Token: 0x0200000E RID: 14
	[SuppressUnmanagedCodeSecurity]
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public static class UnsafeNativeMethods
	{
		// Token: 0x06000063 RID: 99
		[DllImport("user32")]
		internal static extern IntPtr DefWindowProc([In] IntPtr hwnd, [In] int msg, [In] IntPtr wParam, [In] IntPtr lParam);

		// Token: 0x06000064 RID: 100
		[DllImport("user32", CharSet = CharSet.Unicode, EntryPoint = "GetMonitorInfoW", ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetMonitorInfo([In] IntPtr hMonitor, [Out] MONITORINFO lpmi);

		// Token: 0x06000065 RID: 101
		[DllImport("user32")]
		internal static extern IntPtr MonitorFromWindow([In] IntPtr handle, [In] MonitorOptions flags);

		// Token: 0x06000066 RID: 102
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

		// Token: 0x06000067 RID: 103
		[DllImport("user32", CharSet = CharSet.Unicode, EntryPoint = "LoadStringW", ExactSpelling = true, SetLastError = true)]
		public static extern int LoadString([In] [Optional] SafeLibraryHandle hInstance, [In] uint uID, [Out] StringBuilder lpBuffer, [In] int nBufferMax);

		// Token: 0x06000068 RID: 104
		[DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
		internal static extern bool IsWindow([In] [Optional] IntPtr hWnd);

		// Token: 0x06000069 RID: 105
		[DllImport("user32")]
		internal static extern IntPtr GetSystemMenu([In] IntPtr hWnd, [In] bool bRevert);

		// Token: 0x0600006A RID: 106
		[DllImport("user32")]
		internal static extern uint TrackPopupMenuEx([In] IntPtr hmenu, [In] uint fuFlags, [In] int x, [In] int y, [In] IntPtr hwnd, [In] [Optional] IntPtr lptpm);

		// Token: 0x0600006B RID: 107
		[DllImport("user32", EntryPoint = "PostMessage", SetLastError = true)]
		private static extern bool _PostMessage([In] [Optional] IntPtr hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

		// Token: 0x0600006C RID: 108
		[DllImport("kernel32", CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", ExactSpelling = true, SetLastError = true)]
		public static extern SafeLibraryHandle LoadLibrary([MarshalAs(UnmanagedType.LPWStr)] [In] string lpFileName);

		// Token: 0x0600006D RID: 109
		[DllImport("kernel32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeLibrary([In] IntPtr hModule);

		// Token: 0x0600006E RID: 110
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x0600006F RID: 111 RVA: 0x0000363C File Offset: 0x0000183C
		internal static void PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam)
		{
			if (!UnsafeNativeMethods._PostMessage(hWnd, Msg, wParam, lParam))
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x06000070 RID: 112
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		// Token: 0x06000071 RID: 113
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate, IntPtr hrgnUpdate, Constants.RedrawWindowFlags flags);

		// Token: 0x06000072 RID: 114
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, Constants.RedrawWindowFlags flags);

		// Token: 0x06000073 RID: 115
		[DllImport("user32.dll")]
		internal static extern int MapVirtualKey(uint uCode, uint uMapType);

		// Token: 0x06000074 RID: 116
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetKeyNameText(int lParam, [MarshalAs(UnmanagedType.LPWStr)] [Out] StringBuilder str, int size);
	}
}
