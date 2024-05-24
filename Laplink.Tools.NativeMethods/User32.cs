using System;
using System.Runtime.InteropServices;

namespace Laplink.Tools.NativeMethods
{
	// Token: 0x02000006 RID: 6
	public static class User32
	{
		// Token: 0x0600000C RID: 12
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(IntPtr hWnd, out User32.RECT lpRect);

		// Token: 0x0600000D RID: 13
		[DllImport("user32")]
		public static extern int SetWindowPos(IntPtr hWnd, int hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);

		// Token: 0x0600000E RID: 14
		[DllImport("user32.dll")]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

		// Token: 0x0600000F RID: 15
		[DllImport("user32")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		// Token: 0x06000010 RID: 16
		[DllImport("user32")]
		public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

		// Token: 0x06000011 RID: 17
		[DllImport("user32", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string cls, string win);

		// Token: 0x06000012 RID: 18
		[DllImport("user32")]
		public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000013 RID: 19
		[DllImport("user32")]
		public static extern bool IsIconic(IntPtr hWnd);

		// Token: 0x06000014 RID: 20
		[DllImport("user32")]
		public static extern bool OpenIcon(IntPtr hWnd);

		// Token: 0x04000005 RID: 5
		public const uint MouseEventLeftDown = 2U;

		// Token: 0x04000006 RID: 6
		public const uint MouseEventLeftUp = 4U;

		// Token: 0x04000007 RID: 7
		public const uint MouseEventRightDown = 8U;

		// Token: 0x04000008 RID: 8
		public const uint MouseEventRightUp = 16U;

		// Token: 0x04000009 RID: 9
		public const int MF_BYCOMMAND = 0;

		// Token: 0x0400000A RID: 10
		public const int MF_DISABLED = 2;

		// Token: 0x0400000B RID: 11
		public const int SC_CLOSE = 61536;

		// Token: 0x0200000D RID: 13
		public struct RECT
		{
			// Token: 0x04000031 RID: 49
			public int Left;

			// Token: 0x04000032 RID: 50
			public int Top;

			// Token: 0x04000033 RID: 51
			public int Right;

			// Token: 0x04000034 RID: 52
			public int Bottom;
		}
	}
}
