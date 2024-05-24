using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000014 RID: 20
	internal static class CoreNativeMethods
	{
		// Token: 0x06000055 RID: 85
		[DllImport("user32.dll", CharSet = CharSet.Auto, PreserveSig = false, SetLastError = true)]
		public static extern void PostMessage(IntPtr windowHandle, WindowMessage message, IntPtr wparam, IntPtr lparam);

		// Token: 0x06000056 RID: 86
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr windowHandle, WindowMessage message, IntPtr wparam, IntPtr lparam);

		// Token: 0x06000057 RID: 87
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr windowHandle, uint message, IntPtr wparam, IntPtr lparam);

		// Token: 0x06000058 RID: 88
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr windowHandle, uint message, IntPtr wparam, [MarshalAs(UnmanagedType.LPWStr)] string lparam);

		// Token: 0x06000059 RID: 89 RVA: 0x00002B74 File Offset: 0x00000D74
		public static IntPtr SendMessage(IntPtr windowHandle, uint message, int wparam, string lparam)
		{
			return CoreNativeMethods.SendMessage(windowHandle, message, (IntPtr)wparam, lparam);
		}

		// Token: 0x0600005A RID: 90
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr windowHandle, uint message, ref int wparam, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lparam);

		// Token: 0x0600005B RID: 91
		[DllImport("kernel32.dll", BestFitMapping = false, SetLastError = true, ThrowOnUnmappableChar = true)]
		internal static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string fileName);

		// Token: 0x0600005C RID: 92
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DeleteObject(IntPtr graphicsObjectHandle);

		// Token: 0x0600005D RID: 93
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int LoadString(IntPtr instanceHandle, int id, StringBuilder buffer, int bufferSize);

		// Token: 0x0600005E RID: 94
		[DllImport("Kernel32.dll")]
		internal static extern IntPtr LocalFree(ref Guid guid);

		// Token: 0x0600005F RID: 95
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DestroyIcon(IntPtr hIcon);

		// Token: 0x06000060 RID: 96
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		internal static extern int DestroyWindow(IntPtr handle);

		// Token: 0x06000061 RID: 97 RVA: 0x00002B94 File Offset: 0x00000D94
		public static int GetHiWord(long value, int size)
		{
			return (int)((short)(value >> size));
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002BB0 File Offset: 0x00000DB0
		public static int GetLoWord(long value)
		{
			return (int)((short)(value & 65535L));
		}

		// Token: 0x040000F8 RID: 248
		internal const int UserMessage = 1024;

		// Token: 0x040000F9 RID: 249
		internal const int EnterIdleMessage = 289;

		// Token: 0x040000FA RID: 250
		internal const int FormatMessageFromSystem = 4096;

		// Token: 0x040000FB RID: 251
		internal const uint ResultFailed = 2147500037U;

		// Token: 0x040000FC RID: 252
		internal const uint ResultInvalidArgument = 2147942487U;

		// Token: 0x040000FD RID: 253
		internal const uint ResultFalse = 1U;

		// Token: 0x040000FE RID: 254
		internal const uint ResultNotFound = 2147943568U;

		// Token: 0x040000FF RID: 255
		internal const int DWMNCRP_USEWINDOWSTYLE = 0;

		// Token: 0x04000100 RID: 256
		internal const int DWMNCRP_DISABLED = 1;

		// Token: 0x04000101 RID: 257
		internal const int DWMNCRP_ENABLED = 2;

		// Token: 0x04000102 RID: 258
		internal const int DWMWA_NCRENDERING_ENABLED = 1;

		// Token: 0x04000103 RID: 259
		internal const int DWMWA_NCRENDERING_POLICY = 2;

		// Token: 0x04000104 RID: 260
		internal const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;

		// Token: 0x04000105 RID: 261
		internal const uint StatusAccessDenied = 3221225506U;

		// Token: 0x02000015 RID: 21
		public struct Size
		{
			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000063 RID: 99 RVA: 0x00002BCC File Offset: 0x00000DCC
			// (set) Token: 0x06000064 RID: 100 RVA: 0x00002BE4 File Offset: 0x00000DE4
			public int Width
			{
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000065 RID: 101 RVA: 0x00002BF0 File Offset: 0x00000DF0
			// (set) Token: 0x06000066 RID: 102 RVA: 0x00002C08 File Offset: 0x00000E08
			public int Height
			{
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

			// Token: 0x04000106 RID: 262
			private int width;

			// Token: 0x04000107 RID: 263
			private int height;
		}

		// Token: 0x02000016 RID: 22
		// (Invoke) Token: 0x06000068 RID: 104
		public delegate int WNDPROC(IntPtr hWnd, uint uMessage, IntPtr wParam, IntPtr lParam);
	}
}
