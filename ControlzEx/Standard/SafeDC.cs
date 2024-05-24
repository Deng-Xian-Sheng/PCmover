using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ControlzEx.Standard
{
	// Token: 0x02000057 RID: 87
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public sealed class SafeDC : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x17000032 RID: 50
		// (set) Token: 0x06000170 RID: 368 RVA: 0x000084BF File Offset: 0x000066BF
		public IntPtr Hwnd
		{
			set
			{
				this._hwnd = new IntPtr?(value);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00003626 File Offset: 0x00001826
		private SafeDC() : base(true)
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000084D0 File Offset: 0x000066D0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle()
		{
			if (this._created)
			{
				return SafeDC.NativeMethods.DeleteDC(this.handle);
			}
			return this._hwnd == null || this._hwnd.Value == IntPtr.Zero || SafeDC.NativeMethods.ReleaseDC(this._hwnd.Value, this.handle) == 1;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00008530 File Offset: 0x00006730
		public static SafeDC CreateDC(string deviceName)
		{
			SafeDC safeDC = null;
			try
			{
				safeDC = SafeDC.NativeMethods.CreateDC(deviceName, null, IntPtr.Zero, IntPtr.Zero);
			}
			finally
			{
				if (safeDC != null)
				{
					safeDC._created = true;
				}
			}
			if (safeDC.IsInvalid)
			{
				safeDC.Dispose();
				throw new SystemException("Unable to create a device context from the specified device information.");
			}
			return safeDC;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008588 File Offset: 0x00006788
		public static SafeDC CreateCompatibleDC(SafeDC hdc)
		{
			SafeDC safeDC = null;
			try
			{
				IntPtr hdc2 = IntPtr.Zero;
				if (hdc != null)
				{
					hdc2 = hdc.handle;
				}
				safeDC = SafeDC.NativeMethods.CreateCompatibleDC(hdc2);
				if (safeDC == null)
				{
					HRESULT.ThrowLastError();
				}
			}
			finally
			{
				if (safeDC != null)
				{
					safeDC._created = true;
				}
			}
			if (safeDC.IsInvalid)
			{
				safeDC.Dispose();
				throw new SystemException("Unable to create a device context from the specified device information.");
			}
			return safeDC;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000085F0 File Offset: 0x000067F0
		public static SafeDC GetDC(IntPtr hwnd)
		{
			SafeDC safeDC = null;
			try
			{
				safeDC = SafeDC.NativeMethods.GetDC(hwnd);
			}
			finally
			{
				if (safeDC != null)
				{
					safeDC.Hwnd = hwnd;
				}
			}
			if (safeDC.IsInvalid)
			{
				HRESULT.E_FAIL.ThrowIfFailed();
			}
			return safeDC;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000863C File Offset: 0x0000683C
		public static SafeDC GetDesktop()
		{
			return SafeDC.GetDC(IntPtr.Zero);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00008648 File Offset: 0x00006848
		public static SafeDC WrapDC(IntPtr hdc)
		{
			return new SafeDC
			{
				handle = hdc,
				_created = false,
				_hwnd = new IntPtr?(IntPtr.Zero)
			};
		}

		// Token: 0x040004F5 RID: 1269
		private IntPtr? _hwnd;

		// Token: 0x040004F6 RID: 1270
		private bool _created;

		// Token: 0x020000D2 RID: 210
		private static class NativeMethods
		{
			// Token: 0x06000448 RID: 1096
			[DllImport("user32.dll")]
			public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

			// Token: 0x06000449 RID: 1097
			[DllImport("user32.dll")]
			public static extern SafeDC GetDC(IntPtr hwnd);

			// Token: 0x0600044A RID: 1098
			[DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
			public static extern SafeDC CreateDC([MarshalAs(UnmanagedType.LPWStr)] string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)] string lpszDevice, IntPtr lpszOutput, IntPtr lpInitData);

			// Token: 0x0600044B RID: 1099
			[DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			public static extern SafeDC CreateCompatibleDC(IntPtr hdc);

			// Token: 0x0600044C RID: 1100
			[DllImport("gdi32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool DeleteDC(IntPtr hdc);
		}
	}
}
