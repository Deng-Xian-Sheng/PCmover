using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;

namespace ControlzEx.Standard
{
	// Token: 0x02000088 RID: 136
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public static class NativeMethods
	{
		// Token: 0x060001D3 RID: 467
		[DllImport("user32.dll", EntryPoint = "AdjustWindowRectEx", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _AdjustWindowRectEx(ref RECT lpRect, WS dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, WS_EX dwExStyle);

		// Token: 0x060001D4 RID: 468 RVA: 0x00008EA7 File Offset: 0x000070A7
		public static RECT AdjustWindowRectEx(RECT lpRect, WS dwStyle, bool bMenu, WS_EX dwExStyle)
		{
			if (!NativeMethods._AdjustWindowRectEx(ref lpRect, dwStyle, bMenu, dwExStyle))
			{
				HRESULT.ThrowLastError();
			}
			return lpRect;
		}

		// Token: 0x060001D5 RID: 469
		[DllImport("user32.dll", EntryPoint = "AllowSetForegroundWindow", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _AllowSetForegroundWindow(int dwProcessId);

		// Token: 0x060001D6 RID: 470 RVA: 0x00008EBB File Offset: 0x000070BB
		public static void AllowSetForegroundWindow()
		{
			NativeMethods.AllowSetForegroundWindow(-1);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00008EC3 File Offset: 0x000070C3
		public static void AllowSetForegroundWindow(int dwProcessId)
		{
			if (!NativeMethods._AllowSetForegroundWindow(dwProcessId))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x060001D8 RID: 472
		[DllImport("user32.dll", EntryPoint = "ChangeWindowMessageFilter", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _ChangeWindowMessageFilter(WM message, MSGFLT dwFlag);

		// Token: 0x060001D9 RID: 473
		[DllImport("user32.dll", EntryPoint = "ChangeWindowMessageFilterEx", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _ChangeWindowMessageFilterEx(IntPtr hwnd, WM message, MSGFLT action, [In] [Out] [Optional] ref CHANGEFILTERSTRUCT pChangeFilterStruct);

		// Token: 0x060001DA RID: 474 RVA: 0x00008ED4 File Offset: 0x000070D4
		public static HRESULT ChangeWindowMessageFilterEx(IntPtr hwnd, WM message, MSGFLT action, out MSGFLTINFO filterInfo)
		{
			filterInfo = MSGFLTINFO.NONE;
			if (!Utility.IsOSVistaOrNewer)
			{
				return HRESULT.S_FALSE;
			}
			if (!Utility.IsOSWindows7OrNewer)
			{
				if (!NativeMethods._ChangeWindowMessageFilter(message, action))
				{
					return (HRESULT)Win32Error.GetLastError();
				}
				return HRESULT.S_OK;
			}
			else
			{
				CHANGEFILTERSTRUCT changefilterstruct = new CHANGEFILTERSTRUCT
				{
					cbSize = (uint)Marshal.SizeOf(typeof(CHANGEFILTERSTRUCT))
				};
				if (!NativeMethods._ChangeWindowMessageFilterEx(hwnd, message, action, ref changefilterstruct))
				{
					return (HRESULT)Win32Error.GetLastError();
				}
				filterInfo = changefilterstruct.ExtStatus;
				return HRESULT.S_OK;
			}
		}

		// Token: 0x060001DB RID: 475
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

		// Token: 0x060001DC RID: 476
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ScreenToClient(IntPtr hWnd, ref POINT point);

		// Token: 0x060001DD RID: 477
		[DllImport("gdi32.dll")]
		public static extern CombineRgnResult CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, RGN fnCombineMode);

		// Token: 0x060001DE RID: 478
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommandLineToArgvW")]
		private static extern IntPtr _CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string cmdLine, out int numArgs);

		// Token: 0x060001DF RID: 479 RVA: 0x00008F58 File Offset: 0x00007158
		public static string[] CommandLineToArgvW(string cmdLine)
		{
			IntPtr intPtr = IntPtr.Zero;
			string[] result;
			try
			{
				int num = 0;
				intPtr = NativeMethods._CommandLineToArgvW(cmdLine, out num);
				if (intPtr == IntPtr.Zero)
				{
					throw new Win32Exception();
				}
				string[] array = new string[num];
				for (int i = 0; i < num; i++)
				{
					IntPtr ptr = Marshal.ReadIntPtr(intPtr, i * Marshal.SizeOf(typeof(IntPtr)));
					array[i] = Marshal.PtrToStringUni(ptr);
				}
				result = array;
			}
			finally
			{
				NativeMethods._LocalFree(intPtr);
			}
			return result;
		}

		// Token: 0x060001E0 RID: 480
		[DllImport("gdi32.dll", EntryPoint = "CreateDIBSection", SetLastError = true)]
		private static extern SafeHBITMAP _CreateDIBSection(SafeDC hdc, [In] ref BITMAPINFO bitmapInfo, int iUsage, out IntPtr ppvBits, IntPtr hSection, int dwOffset);

		// Token: 0x060001E1 RID: 481
		[DllImport("gdi32.dll", EntryPoint = "CreateDIBSection", SetLastError = true)]
		private static extern SafeHBITMAP _CreateDIBSectionIntPtr(IntPtr hdc, [In] ref BITMAPINFO bitmapInfo, int iUsage, out IntPtr ppvBits, IntPtr hSection, int dwOffset);

		// Token: 0x060001E2 RID: 482 RVA: 0x00008FE0 File Offset: 0x000071E0
		public static SafeHBITMAP CreateDIBSection(SafeDC hdc, ref BITMAPINFO bitmapInfo, out IntPtr ppvBits, IntPtr hSection, int dwOffset)
		{
			SafeHBITMAP safeHBITMAP;
			if (hdc == null)
			{
				safeHBITMAP = NativeMethods._CreateDIBSectionIntPtr(IntPtr.Zero, ref bitmapInfo, 0, out ppvBits, hSection, dwOffset);
			}
			else
			{
				safeHBITMAP = NativeMethods._CreateDIBSection(hdc, ref bitmapInfo, 0, out ppvBits, hSection, dwOffset);
			}
			if (safeHBITMAP.IsInvalid)
			{
				HRESULT.ThrowLastError();
			}
			return safeHBITMAP;
		}

		// Token: 0x060001E3 RID: 483
		[DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn", SetLastError = true)]
		private static extern IntPtr _CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060001E4 RID: 484 RVA: 0x00009020 File Offset: 0x00007220
		public static IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse)
		{
			IntPtr intPtr = NativeMethods._CreateRoundRectRgn(nLeftRect, nTopRect, nRightRect, nBottomRect, nWidthEllipse, nHeightEllipse);
			if (IntPtr.Zero == intPtr)
			{
				throw new Win32Exception();
			}
			return intPtr;
		}

		// Token: 0x060001E5 RID: 485
		[DllImport("gdi32.dll", EntryPoint = "CreateRectRgn", SetLastError = true)]
		private static extern IntPtr _CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

		// Token: 0x060001E6 RID: 486 RVA: 0x00009050 File Offset: 0x00007250
		public static IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
		{
			IntPtr intPtr = NativeMethods._CreateRectRgn(nLeftRect, nTopRect, nRightRect, nBottomRect);
			if (IntPtr.Zero == intPtr)
			{
				throw new Win32Exception();
			}
			return intPtr;
		}

		// Token: 0x060001E7 RID: 487
		[DllImport("gdi32.dll", EntryPoint = "CreateRectRgnIndirect", SetLastError = true)]
		private static extern IntPtr _CreateRectRgnIndirect([In] ref RECT lprc);

		// Token: 0x060001E8 RID: 488 RVA: 0x0000907C File Offset: 0x0000727C
		public static IntPtr CreateRectRgnIndirect(RECT lprc)
		{
			IntPtr intPtr = NativeMethods._CreateRectRgnIndirect(ref lprc);
			if (IntPtr.Zero == intPtr)
			{
				throw new Win32Exception();
			}
			return intPtr;
		}

		// Token: 0x060001E9 RID: 489
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateSolidBrush(int crColor);

		// Token: 0x060001EA RID: 490
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW", SetLastError = true)]
		private static extern IntPtr _CreateWindowEx(WS_EX dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, WS dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

		// Token: 0x060001EB RID: 491 RVA: 0x000090A8 File Offset: 0x000072A8
		public static IntPtr CreateWindowEx(WS_EX dwExStyle, string lpClassName, string lpWindowName, WS dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam)
		{
			IntPtr intPtr = NativeMethods._CreateWindowEx(dwExStyle, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);
			if (IntPtr.Zero == intPtr)
			{
				HRESULT.ThrowLastError();
			}
			return intPtr;
		}

		// Token: 0x060001EC RID: 492
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefWindowProcW")]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x060001ED RID: 493
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060001EE RID: 494
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyIcon(IntPtr handle);

		// Token: 0x060001EF RID: 495
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyWindow(IntPtr hwnd);

		// Token: 0x060001F0 RID: 496
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindow(IntPtr hwnd);

		// Token: 0x060001F1 RID: 497
		[DllImport("dwmapi.dll", PreserveSig = false)]
		public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMarInset);

		// Token: 0x060001F2 RID: 498
		[DllImport("dwmapi.dll", EntryPoint = "DwmGetColorizationColor")]
		private static extern HRESULT _DwmGetColorizationColor(out uint pcrColorization, [MarshalAs(UnmanagedType.Bool)] out bool pfOpaqueBlend);

		// Token: 0x060001F3 RID: 499 RVA: 0x000090E4 File Offset: 0x000072E4
		public static bool DwmGetColorizationColor(out uint pcrColorization, out bool pfOpaqueBlend)
		{
			if (Utility.IsOSVistaOrNewer && NativeMethods.IsThemeActive() && NativeMethods._DwmGetColorizationColor(out pcrColorization, out pfOpaqueBlend).Succeeded)
			{
				return true;
			}
			pcrColorization = 4278190080U;
			pfOpaqueBlend = true;
			return false;
		}

		// Token: 0x060001F4 RID: 500
		[DllImport("dwmapi.dll", EntryPoint = "DwmGetCompositionTimingInfo")]
		private static extern HRESULT _DwmGetCompositionTimingInfo(IntPtr hwnd, ref DWM_TIMING_INFO pTimingInfo);

		// Token: 0x060001F5 RID: 501 RVA: 0x00009120 File Offset: 0x00007320
		public static DWM_TIMING_INFO? DwmGetCompositionTimingInfo(IntPtr hwnd)
		{
			if (!Utility.IsOSVistaOrNewer)
			{
				return null;
			}
			DWM_TIMING_INFO value = new DWM_TIMING_INFO
			{
				cbSize = Marshal.SizeOf(typeof(DWM_TIMING_INFO))
			};
			HRESULT hrLeft = NativeMethods._DwmGetCompositionTimingInfo(hwnd, ref value);
			if (hrLeft == HRESULT.E_PENDING)
			{
				return null;
			}
			hrLeft.ThrowIfFailed();
			return new DWM_TIMING_INFO?(value);
		}

		// Token: 0x060001F6 RID: 502
		[DllImport("dwmapi.dll", EntryPoint = "DwmIsCompositionEnabled", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _DwmIsCompositionEnabled();

		// Token: 0x060001F7 RID: 503 RVA: 0x0000918B File Offset: 0x0000738B
		public static bool DwmIsCompositionEnabled()
		{
			return Utility.IsOSVistaOrNewer && NativeMethods._DwmIsCompositionEnabled();
		}

		// Token: 0x060001F8 RID: 504
		[DllImport("dwmapi.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DwmDefWindowProc(IntPtr hwnd, WM msg, IntPtr wParam, IntPtr lParam, out IntPtr plResult);

		// Token: 0x060001F9 RID: 505
		[DllImport("dwmapi.dll", EntryPoint = "DwmSetWindowAttribute")]
		private static extern void _DwmSetWindowAttribute(IntPtr hwnd, DWMWA dwAttribute, ref int pvAttribute, int cbAttribute);

		// Token: 0x060001FA RID: 506 RVA: 0x0000919C File Offset: 0x0000739C
		public static void DwmSetWindowAttributeFlip3DPolicy(IntPtr hwnd, DWMFLIP3D flip3dPolicy)
		{
			int num = (int)flip3dPolicy;
			NativeMethods._DwmSetWindowAttribute(hwnd, DWMWA.FLIP3D_POLICY, ref num, 4);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000091B8 File Offset: 0x000073B8
		public static void DwmSetWindowAttributeDisallowPeek(IntPtr hwnd, bool disallowPeek)
		{
			int num = disallowPeek ? 1 : 0;
			NativeMethods._DwmSetWindowAttribute(hwnd, DWMWA.DISALLOW_PEEK, ref num, 4);
		}

		// Token: 0x060001FC RID: 508
		[DllImport("user32.dll", EntryPoint = "EnableMenuItem")]
		private static extern int _EnableMenuItem(IntPtr hMenu, SC uIDEnableItem, MF uEnable);

		// Token: 0x060001FD RID: 509 RVA: 0x000091D8 File Offset: 0x000073D8
		public static MF EnableMenuItem(IntPtr hMenu, SC uIDEnableItem, MF uEnable)
		{
			return (MF)NativeMethods._EnableMenuItem(hMenu, uIDEnableItem, uEnable);
		}

		// Token: 0x060001FE RID: 510
		[DllImport("user32.dll", EntryPoint = "RemoveMenu", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

		// Token: 0x060001FF RID: 511 RVA: 0x000091E2 File Offset: 0x000073E2
		public static void RemoveMenu(IntPtr hMenu, SC uPosition, MF uFlags)
		{
			if (!NativeMethods._RemoveMenu(hMenu, (uint)uPosition, (uint)uFlags))
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x06000200 RID: 512
		[DllImport("user32.dll", EntryPoint = "DrawMenuBar", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _DrawMenuBar(IntPtr hWnd);

		// Token: 0x06000201 RID: 513 RVA: 0x000091F4 File Offset: 0x000073F4
		public static void DrawMenuBar(IntPtr hWnd)
		{
			if (!NativeMethods._DrawMenuBar(hWnd))
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x06000202 RID: 514
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindClose(IntPtr handle);

		// Token: 0x06000203 RID: 515
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern SafeFindHandle FindFirstFileW(string lpFileName, [MarshalAs(UnmanagedType.LPStruct)] [In] [Out] WIN32_FIND_DATAW lpFindFileData);

		// Token: 0x06000204 RID: 516
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindNextFileW(SafeFindHandle hndFindFile, [MarshalAs(UnmanagedType.LPStruct)] [In] [Out] WIN32_FIND_DATAW lpFindFileData);

		// Token: 0x06000205 RID: 517
		[DllImport("user32.dll", EntryPoint = "GetClientRect", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _GetClientRect(IntPtr hwnd, out RECT lpRect);

		// Token: 0x06000206 RID: 518 RVA: 0x00009204 File Offset: 0x00007404
		public static RECT GetClientRect(IntPtr hwnd)
		{
			RECT result;
			if (!NativeMethods._GetClientRect(hwnd, out result))
			{
				HRESULT.ThrowLastError();
			}
			return result;
		}

		// Token: 0x06000207 RID: 519
		[SecurityCritical]
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetCursorPos", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _GetCursorPos(out POINT lpPoint);

		// Token: 0x06000208 RID: 520 RVA: 0x00009224 File Offset: 0x00007424
		[SecurityCritical]
		public static POINT GetCursorPos()
		{
			POINT result;
			if (!NativeMethods._GetCursorPos(out result))
			{
				HRESULT.ThrowLastError();
			}
			return result;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00009240 File Offset: 0x00007440
		[SecurityCritical]
		public static bool TryGetCursorPos(out POINT pt)
		{
			bool flag = NativeMethods._GetCursorPos(out pt);
			if (!flag)
			{
				pt.X = 0;
				pt.Y = 0;
			}
			return flag;
		}

		// Token: 0x0600020A RID: 522
		[SecurityCritical]
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetPhysicalCursorPos", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _GetPhysicalCursorPos(out POINT lpPoint);

		// Token: 0x0600020B RID: 523 RVA: 0x0000925C File Offset: 0x0000745C
		[SecurityCritical]
		public static POINT GetPhysicalCursorPos()
		{
			POINT result;
			if (!NativeMethods._GetPhysicalCursorPos(out result))
			{
				HRESULT.ThrowLastError();
			}
			return result;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00009278 File Offset: 0x00007478
		[SecurityCritical]
		public static bool TryGetPhysicalCursorPos(out POINT pt)
		{
			bool flag = NativeMethods._GetPhysicalCursorPos(out pt);
			if (!flag)
			{
				pt.X = 0;
				pt.Y = 0;
			}
			return flag;
		}

		// Token: 0x0600020D RID: 525
		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentThemeName")]
		private static extern HRESULT _GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int cchMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);

		// Token: 0x0600020E RID: 526 RVA: 0x00009294 File Offset: 0x00007494
		public static void GetCurrentThemeName(out string themeFileName, out string color, out string size)
		{
			StringBuilder stringBuilder = new StringBuilder(260);
			StringBuilder stringBuilder2 = new StringBuilder(260);
			StringBuilder stringBuilder3 = new StringBuilder(260);
			NativeMethods._GetCurrentThemeName(stringBuilder, stringBuilder.Capacity, stringBuilder2, stringBuilder2.Capacity, stringBuilder3, stringBuilder3.Capacity).ThrowIfFailed();
			themeFileName = stringBuilder.ToString();
			color = stringBuilder2.ToString();
			size = stringBuilder3.ToString();
		}

		// Token: 0x0600020F RID: 527
		[DllImport("uxtheme.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeActive();

		// Token: 0x06000210 RID: 528 RVA: 0x00007247 File Offset: 0x00005447
		[Obsolete("Use SafeDC.GetDC instead.", true)]
		public static void GetDC()
		{
		}

		// Token: 0x06000211 RID: 529
		[DllImport("gdi32.dll")]
		public static extern int GetDeviceCaps(SafeDC hdc, DeviceCap nIndex);

		// Token: 0x06000212 RID: 530
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleFileName", SetLastError = true)]
		private static extern int _GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, int nSize);

		// Token: 0x06000213 RID: 531 RVA: 0x000092FC File Offset: 0x000074FC
		public static string GetModuleFileName(IntPtr hModule)
		{
			StringBuilder stringBuilder = new StringBuilder(260);
			for (;;)
			{
				int num = NativeMethods._GetModuleFileName(hModule, stringBuilder, stringBuilder.Capacity);
				if (num == 0)
				{
					HRESULT.ThrowLastError();
				}
				if (num != stringBuilder.Capacity)
				{
					break;
				}
				stringBuilder.EnsureCapacity(stringBuilder.Capacity * 2);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000214 RID: 532
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandleW", SetLastError = true)]
		private static extern IntPtr _GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

		// Token: 0x06000215 RID: 533 RVA: 0x00009348 File Offset: 0x00007548
		public static IntPtr GetModuleHandle(string lpModuleName)
		{
			IntPtr intPtr = NativeMethods._GetModuleHandle(lpModuleName);
			if (intPtr == IntPtr.Zero)
			{
				HRESULT.ThrowLastError();
			}
			return intPtr;
		}

		// Token: 0x06000216 RID: 534
		[DllImport("user32.dll", EntryPoint = "GetMonitorInfo", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _GetMonitorInfo(IntPtr hMonitor, [In] [Out] MONITORINFO lpmi);

		// Token: 0x06000217 RID: 535 RVA: 0x00009364 File Offset: 0x00007564
		public static MONITORINFO GetMonitorInfo(IntPtr hMonitor)
		{
			MONITORINFO monitorinfo = new MONITORINFO();
			if (!NativeMethods._GetMonitorInfo(hMonitor, monitorinfo))
			{
				throw new Win32Exception();
			}
			return monitorinfo;
		}

		// Token: 0x06000218 RID: 536
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMonitorInfoW", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _GetMonitorInfoW([In] IntPtr hMonitor, [Out] MONITORINFO lpmi);

		// Token: 0x06000219 RID: 537 RVA: 0x00009388 File Offset: 0x00007588
		public static MONITORINFO GetMonitorInfoW(IntPtr hMonitor)
		{
			MONITORINFO monitorinfo = new MONITORINFO();
			if (!NativeMethods._GetMonitorInfoW(hMonitor, monitorinfo))
			{
				throw new Win32Exception();
			}
			return monitorinfo;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000093AC File Offset: 0x000075AC
		public static IntPtr GetTaskBarHandleForMonitor(IntPtr monitor)
		{
			IntPtr intPtr = NativeMethods.FindWindow("Shell_TrayWnd", null);
			IntPtr intPtr2 = NativeMethods.MonitorFromWindow(intPtr, MonitorOptions.MONITOR_DEFAULTTONEAREST);
			if (!object.Equals(monitor, intPtr2))
			{
				intPtr = NativeMethods.FindWindow("Shell_SecondaryTrayWnd", null);
				intPtr2 = NativeMethods.MonitorFromWindow(intPtr, MonitorOptions.MONITOR_DEFAULTTONEAREST);
				if (!object.Equals(monitor, intPtr2))
				{
					return IntPtr.Zero;
				}
			}
			return intPtr;
		}

		// Token: 0x0600021B RID: 539
		[DllImport("gdi32.dll", EntryPoint = "GetStockObject", SetLastError = true)]
		private static extern IntPtr _GetStockObject(StockObject fnObject);

		// Token: 0x0600021C RID: 540 RVA: 0x0000940E File Offset: 0x0000760E
		public static IntPtr GetStockObject(StockObject fnObject)
		{
			return NativeMethods._GetStockObject(fnObject);
		}

		// Token: 0x0600021D RID: 541
		[DllImport("user32.dll")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

		// Token: 0x0600021E RID: 542
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(SM nIndex);

		// Token: 0x0600021F RID: 543
		[DllImport("user32.dll", EntryPoint = "GetWindowInfo", SetLastError = true)]
		private static extern bool _GetWindowInfo(IntPtr hWnd, ref WINDOWINFO pwi);

		// Token: 0x06000220 RID: 544 RVA: 0x00009418 File Offset: 0x00007618
		public static WINDOWINFO GetWindowInfo(IntPtr hWnd)
		{
			WINDOWINFO result = new WINDOWINFO
			{
				cbSize = Marshal.SizeOf(typeof(WINDOWINFO))
			};
			if (!NativeMethods._GetWindowInfo(hWnd, ref result))
			{
				HRESULT.ThrowLastError();
			}
			return result;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00009455 File Offset: 0x00007655
		public static WS GetWindowStyle(IntPtr hWnd)
		{
			return (WS)((int)NativeMethods.GetWindowLongPtr(hWnd, GWL.STYLE));
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00009464 File Offset: 0x00007664
		public static WS_EX GetWindowStyleEx(IntPtr hWnd)
		{
			return (WS_EX)((int)NativeMethods.GetWindowLongPtr(hWnd, GWL.EXSTYLE));
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00009473 File Offset: 0x00007673
		public static WS SetWindowStyle(IntPtr hWnd, WS dwNewLong)
		{
			return (WS)((int)NativeMethods.SetWindowLongPtr(hWnd, GWL.STYLE, (IntPtr)((int)dwNewLong)));
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00009488 File Offset: 0x00007688
		public static WS_EX SetWindowStyleEx(IntPtr hWnd, WS_EX dwNewLong)
		{
			return (WS_EX)((int)NativeMethods.SetWindowLongPtr(hWnd, GWL.EXSTYLE, (IntPtr)((int)dwNewLong)));
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000094A0 File Offset: 0x000076A0
		public static IntPtr GetWindowLongPtr(IntPtr hwnd, GWL nIndex)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (8 == IntPtr.Size)
			{
				intPtr = NativeMethods.GetWindowLongPtr64(hwnd, nIndex);
			}
			else
			{
				intPtr = NativeMethods.GetWindowLongPtr32(hwnd, nIndex);
			}
			if (IntPtr.Zero == intPtr)
			{
				throw new Win32Exception();
			}
			return intPtr;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000094E1 File Offset: 0x000076E1
		public static IntPtr GetClassLong(IntPtr hWnd, int nIndex)
		{
			if (IntPtr.Size == 4)
			{
				return new IntPtr((long)((ulong)NativeMethods.GetClassLong32(hWnd, nIndex)));
			}
			return NativeMethods.GetClassLong64(hWnd, nIndex);
		}

		// Token: 0x06000227 RID: 551
		[DllImport("user32.dll", EntryPoint = "GetClassLong")]
		private static extern uint GetClassLong32(IntPtr hWnd, int nIndex);

		// Token: 0x06000228 RID: 552
		[DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
		private static extern IntPtr GetClassLong64(IntPtr hWnd, int nIndex);

		// Token: 0x06000229 RID: 553
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProp", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SetProp(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string lpString, IntPtr hData);

		// Token: 0x0600022A RID: 554 RVA: 0x00009500 File Offset: 0x00007700
		public static void SetProp(IntPtr hwnd, string lpString, IntPtr hData)
		{
			if (!NativeMethods._SetProp(hwnd, lpString, hData))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x0600022B RID: 555
		[DllImport("uxtheme.dll", PreserveSig = false)]
		public static extern void SetWindowThemeAttribute([In] IntPtr hwnd, [In] WINDOWTHEMEATTRIBUTETYPE eAttribute, [In] ref WTA_OPTIONS pvAttribute, [In] uint cbAttribute);

		// Token: 0x0600022C RID: 556
		[DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
		private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, GWL nIndex);

		// Token: 0x0600022D RID: 557
		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", SetLastError = true)]
		private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, GWL nIndex);

		// Token: 0x0600022E RID: 558
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowPlacement(IntPtr hwnd, [In] [Out] WINDOWPLACEMENT lpwndpl);

		// Token: 0x0600022F RID: 559 RVA: 0x00009514 File Offset: 0x00007714
		public static WINDOWPLACEMENT GetWindowPlacement(IntPtr hwnd)
		{
			WINDOWPLACEMENT windowplacement = new WINDOWPLACEMENT();
			if (NativeMethods.GetWindowPlacement(hwnd, windowplacement))
			{
				return windowplacement;
			}
			throw new Win32Exception();
		}

		// Token: 0x06000230 RID: 560
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowPlacement(IntPtr hWnd, [In] WINDOWPLACEMENT lpwndpl);

		// Token: 0x06000231 RID: 561
		[DllImport("user32.dll", EntryPoint = "GetWindowRect", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _GetWindowRect(IntPtr hWnd, out RECT lpRect);

		// Token: 0x06000232 RID: 562 RVA: 0x00009538 File Offset: 0x00007738
		public static RECT GetWindowRect(IntPtr hwnd)
		{
			RECT result;
			if (!NativeMethods._GetWindowRect(hwnd, out result))
			{
				HRESULT.ThrowLastError();
			}
			return result;
		}

		// Token: 0x06000233 RID: 563
		[DllImport("gdiplus.dll")]
		public static extern Status GdipCreateBitmapFromStream(IStream stream, out IntPtr bitmap);

		// Token: 0x06000234 RID: 564
		[DllImport("gdiplus.dll")]
		public static extern Status GdipCreateHBITMAPFromBitmap(IntPtr bitmap, out IntPtr hbmReturn, int background);

		// Token: 0x06000235 RID: 565
		[DllImport("gdiplus.dll")]
		public static extern Status GdipCreateHICONFromBitmap(IntPtr bitmap, out IntPtr hbmReturn);

		// Token: 0x06000236 RID: 566
		[DllImport("gdiplus.dll")]
		public static extern Status GdipDisposeImage(IntPtr image);

		// Token: 0x06000237 RID: 567
		[DllImport("gdiplus.dll")]
		public static extern Status GdipImageForceValidation(IntPtr image);

		// Token: 0x06000238 RID: 568
		[DllImport("gdiplus.dll")]
		public static extern Status GdiplusStartup(out IntPtr token, StartupInput input, out StartupOutput output);

		// Token: 0x06000239 RID: 569
		[DllImport("gdiplus.dll")]
		public static extern Status GdiplusShutdown(IntPtr token);

		// Token: 0x0600023A RID: 570
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsZoomed(IntPtr hwnd);

		// Token: 0x0600023B RID: 571
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWindowVisible(IntPtr hwnd);

		// Token: 0x0600023C RID: 572
		[DllImport("kernel32.dll", EntryPoint = "LocalFree", SetLastError = true)]
		private static extern IntPtr _LocalFree(IntPtr hMem);

		// Token: 0x0600023D RID: 573
		[DllImport("user32.dll")]
		public static extern IntPtr MonitorFromWindow(IntPtr hwnd, MonitorOptions dwFlags);

		// Token: 0x0600023E RID: 574
		[DllImport("user32.dll")]
		public static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

		// Token: 0x0600023F RID: 575
		[DllImport("user32.dll")]
		public static extern IntPtr MonitorFromRect([In] ref RECT lprc, MonitorOptions dwFlags);

		// Token: 0x06000240 RID: 576
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr LoadImage(IntPtr hinst, IntPtr lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

		// Token: 0x06000241 RID: 577
		[DllImport("user32.dll")]
		public static extern IntPtr GetFocus();

		// Token: 0x06000242 RID: 578
		[DllImport("user32.dll")]
		public static extern IntPtr SetFocus(IntPtr hWnd);

		// Token: 0x06000243 RID: 579
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern int ToUnicode(uint virtualKey, uint scanCode, byte[] keyStates, [MarshalAs(UnmanagedType.LPArray)] [Out] char[] chars, int charMaxCount, uint flags);

		// Token: 0x06000244 RID: 580
		[DllImport("user32.dll")]
		public static extern bool GetKeyboardState(byte[] lpKeyState);

		// Token: 0x06000245 RID: 581
		[DllImport("user32.dll")]
		public static extern uint MapVirtualKey(uint uCode, NativeMethods.MapType uMapType);

		// Token: 0x06000246 RID: 582
		[DllImport("comdlg32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ChooseColor(NativeMethods.CHOOSECOLOR lpcc);

		// Token: 0x06000247 RID: 583
		[DllImport("user32.dll", EntryPoint = "PostMessage", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _PostMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000248 RID: 584 RVA: 0x00009555 File Offset: 0x00007755
		public static void PostMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam)
		{
			if (!NativeMethods._PostMessage(hWnd, Msg, wParam, lParam))
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x06000249 RID: 585
		[DllImport("user32.dll", EntryPoint = "RegisterClassExW", SetLastError = true)]
		private static extern short _RegisterClassEx([In] ref WNDCLASSEX lpwcx);

		// Token: 0x0600024A RID: 586 RVA: 0x00009568 File Offset: 0x00007768
		public static short RegisterClassEx(ref WNDCLASSEX lpwcx)
		{
			short num = NativeMethods._RegisterClassEx(ref lpwcx);
			if (num == 0)
			{
				HRESULT.ThrowLastError();
			}
			return num;
		}

		// Token: 0x0600024B RID: 587
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterWindowMessage", SetLastError = true)]
		private static extern uint _RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)] string lpString);

		// Token: 0x0600024C RID: 588 RVA: 0x00009578 File Offset: 0x00007778
		public static WM RegisterWindowMessage(string lpString)
		{
			uint num = NativeMethods._RegisterWindowMessage(lpString);
			if (num == 0U)
			{
				HRESULT.ThrowLastError();
			}
			return (WM)num;
		}

		// Token: 0x0600024D RID: 589
		[DllImport("user32.dll", EntryPoint = "SetActiveWindow", SetLastError = true)]
		private static extern IntPtr _SetActiveWindow(IntPtr hWnd);

		// Token: 0x0600024E RID: 590 RVA: 0x00009588 File Offset: 0x00007788
		public static IntPtr SetActiveWindow(IntPtr hwnd)
		{
			Verify.IsNotDefault<IntPtr>(hwnd, "hwnd");
			IntPtr intPtr = NativeMethods._SetActiveWindow(hwnd);
			if (intPtr == IntPtr.Zero)
			{
				HRESULT.ThrowLastError();
			}
			return intPtr;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000095AD File Offset: 0x000077AD
		public static IntPtr SetClassLongPtr(IntPtr hwnd, GCLP nIndex, IntPtr dwNewLong)
		{
			if (8 == IntPtr.Size)
			{
				return NativeMethods.SetClassLongPtr64(hwnd, nIndex, dwNewLong);
			}
			return new IntPtr(NativeMethods.SetClassLongPtr32(hwnd, nIndex, dwNewLong.ToInt32()));
		}

		// Token: 0x06000250 RID: 592
		[DllImport("user32.dll", EntryPoint = "SetClassLong", SetLastError = true)]
		private static extern int SetClassLongPtr32(IntPtr hWnd, GCLP nIndex, int dwNewLong);

		// Token: 0x06000251 RID: 593
		[DllImport("user32.dll", EntryPoint = "SetClassLongPtr", SetLastError = true)]
		private static extern IntPtr SetClassLongPtr64(IntPtr hWnd, GCLP nIndex, IntPtr dwNewLong);

		// Token: 0x06000252 RID: 594
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern ErrorModes SetErrorMode(ErrorModes newMode);

		// Token: 0x06000253 RID: 595
		[DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SetProcessWorkingSetSize(IntPtr hProcess, IntPtr dwMinimiumWorkingSetSize, IntPtr dwMaximumWorkingSetSize);

		// Token: 0x06000254 RID: 596 RVA: 0x000095D3 File Offset: 0x000077D3
		public static void SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize)
		{
			if (!NativeMethods._SetProcessWorkingSetSize(hProcess, new IntPtr(dwMinimumWorkingSetSize), new IntPtr(dwMaximumWorkingSetSize)))
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000095EF File Offset: 0x000077EF
		public static IntPtr SetWindowLongPtr(IntPtr hwnd, GWL nIndex, IntPtr dwNewLong)
		{
			if (8 == IntPtr.Size)
			{
				return NativeMethods.SetWindowLongPtr64(hwnd, nIndex, dwNewLong);
			}
			return new IntPtr(NativeMethods.SetWindowLongPtr32(hwnd, nIndex, dwNewLong.ToInt32()));
		}

		// Token: 0x06000256 RID: 598
		[DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
		private static extern int SetWindowLongPtr32(IntPtr hWnd, GWL nIndex, int dwNewLong);

		// Token: 0x06000257 RID: 599
		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
		private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, GWL nIndex, IntPtr dwNewLong);

		// Token: 0x06000258 RID: 600
		[DllImport("user32.dll", EntryPoint = "SetWindowRgn", SetLastError = true)]
		private static extern int _SetWindowRgn(IntPtr hWnd, IntPtr hRgn, [MarshalAs(UnmanagedType.Bool)] bool bRedraw);

		// Token: 0x06000259 RID: 601 RVA: 0x00009618 File Offset: 0x00007818
		public static void SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw)
		{
			if (NativeMethods._SetWindowRgn(hWnd, hRgn, bRedraw) == 0)
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x0600025A RID: 602
		[DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP uFlags);

		// Token: 0x0600025B RID: 603 RVA: 0x00009637 File Offset: 0x00007837
		public static void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP uFlags)
		{
			if (!NativeMethods._SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, uFlags))
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x0600025C RID: 604
		[DllImport("shell32.dll")]
		public static extern Win32Error SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

		// Token: 0x0600025D RID: 605
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfoW", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SystemParametersInfo_String(SPI uiAction, int uiParam, [MarshalAs(UnmanagedType.LPWStr)] string pvParam, SPIF fWinIni);

		// Token: 0x0600025E RID: 606
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemParametersInfoW", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SystemParametersInfo_NONCLIENTMETRICS(SPI uiAction, int uiParam, [In] [Out] ref NONCLIENTMETRICS pvParam, SPIF fWinIni);

		// Token: 0x0600025F RID: 607
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SystemParametersInfoW", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SystemParametersInfo_HIGHCONTRAST(SPI uiAction, int uiParam, [In] [Out] ref HIGHCONTRAST pvParam, SPIF fWinIni);

		// Token: 0x06000260 RID: 608 RVA: 0x00009650 File Offset: 0x00007850
		public static void SystemParametersInfo(SPI uiAction, int uiParam, string pvParam, SPIF fWinIni)
		{
			if (!NativeMethods._SystemParametersInfo_String(uiAction, uiParam, pvParam, fWinIni))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00009664 File Offset: 0x00007864
		public static NONCLIENTMETRICS SystemParameterInfo_GetNONCLIENTMETRICS()
		{
			NONCLIENTMETRICS nonclientmetrics = Utility.IsOSVistaOrNewer ? NONCLIENTMETRICS.VistaMetricsStruct : NONCLIENTMETRICS.XPMetricsStruct;
			if (!NativeMethods._SystemParametersInfo_NONCLIENTMETRICS(SPI.GETNONCLIENTMETRICS, nonclientmetrics.cbSize, ref nonclientmetrics, SPIF.None))
			{
				HRESULT.ThrowLastError();
			}
			return nonclientmetrics;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000096A0 File Offset: 0x000078A0
		public static HIGHCONTRAST SystemParameterInfo_GetHIGHCONTRAST()
		{
			HIGHCONTRAST highcontrast = new HIGHCONTRAST
			{
				cbSize = Marshal.SizeOf(typeof(HIGHCONTRAST))
			};
			if (!NativeMethods._SystemParametersInfo_HIGHCONTRAST(SPI.GETHIGHCONTRAST, highcontrast.cbSize, ref highcontrast, SPIF.None))
			{
				HRESULT.ThrowLastError();
			}
			return highcontrast;
		}

		// Token: 0x06000263 RID: 611
		[DllImport("user32.dll")]
		public static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

		// Token: 0x06000264 RID: 612
		[DllImport("gdi32.dll", EntryPoint = "SelectObject", SetLastError = true)]
		private static extern IntPtr _SelectObject(SafeDC hdc, IntPtr hgdiobj);

		// Token: 0x06000265 RID: 613 RVA: 0x000096E5 File Offset: 0x000078E5
		public static IntPtr SelectObject(SafeDC hdc, IntPtr hgdiobj)
		{
			IntPtr intPtr = NativeMethods._SelectObject(hdc, hgdiobj);
			if (intPtr == IntPtr.Zero)
			{
				HRESULT.ThrowLastError();
			}
			return intPtr;
		}

		// Token: 0x06000266 RID: 614
		[DllImport("gdi32.dll", EntryPoint = "SelectObject", SetLastError = true)]
		private static extern IntPtr _SelectObjectSafeHBITMAP(SafeDC hdc, SafeHBITMAP hgdiobj);

		// Token: 0x06000267 RID: 615 RVA: 0x00009700 File Offset: 0x00007900
		public static IntPtr SelectObject(SafeDC hdc, SafeHBITMAP hgdiobj)
		{
			IntPtr intPtr = NativeMethods._SelectObjectSafeHBITMAP(hdc, hgdiobj);
			if (intPtr == IntPtr.Zero)
			{
				HRESULT.ThrowLastError();
			}
			return intPtr;
		}

		// Token: 0x06000268 RID: 616
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);

		// Token: 0x06000269 RID: 617
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SendMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600026A RID: 618
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr hwnd, SW nCmdShow);

		// Token: 0x0600026B RID: 619
		[DllImport("user32.dll", EntryPoint = "UnregisterClass", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _UnregisterClassAtom(IntPtr lpClassName, IntPtr hInstance);

		// Token: 0x0600026C RID: 620
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterClass", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _UnregisterClassName(string lpClassName, IntPtr hInstance);

		// Token: 0x0600026D RID: 621 RVA: 0x0000971B File Offset: 0x0000791B
		public static void UnregisterClass(short atom, IntPtr hinstance)
		{
			if (!NativeMethods._UnregisterClassAtom(new IntPtr((int)atom), hinstance))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00009730 File Offset: 0x00007930
		public static void UnregisterClass(string lpClassName, IntPtr hInstance)
		{
			if (!NativeMethods._UnregisterClassName(lpClassName, hInstance))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x0600026F RID: 623
		[DllImport("user32.dll", EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _UpdateLayeredWindow(IntPtr hwnd, SafeDC hdcDst, [In] ref POINT pptDst, [In] ref SIZE psize, SafeDC hdcSrc, [In] ref POINT pptSrc, int crKey, ref BLENDFUNCTION pblend, ULW dwFlags);

		// Token: 0x06000270 RID: 624
		[DllImport("user32.dll", EntryPoint = "UpdateLayeredWindow", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _UpdateLayeredWindowIntPtr(IntPtr hwnd, IntPtr hdcDst, IntPtr pptDst, IntPtr psize, IntPtr hdcSrc, IntPtr pptSrc, int crKey, ref BLENDFUNCTION pblend, ULW dwFlags);

		// Token: 0x06000271 RID: 625 RVA: 0x00009740 File Offset: 0x00007940
		public static void UpdateLayeredWindow(IntPtr hwnd, SafeDC hdcDst, ref POINT pptDst, ref SIZE psize, SafeDC hdcSrc, ref POINT pptSrc, int crKey, ref BLENDFUNCTION pblend, ULW dwFlags)
		{
			if (!NativeMethods._UpdateLayeredWindow(hwnd, hdcDst, ref pptDst, ref psize, hdcSrc, ref pptSrc, crKey, ref pblend, dwFlags))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00009768 File Offset: 0x00007968
		public static void UpdateLayeredWindow(IntPtr hwnd, int crKey, ref BLENDFUNCTION pblend, ULW dwFlags)
		{
			if (!NativeMethods._UpdateLayeredWindowIntPtr(hwnd, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, crKey, ref pblend, dwFlags))
			{
				HRESULT.ThrowLastError();
			}
		}

		// Token: 0x06000273 RID: 627
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterClipboardFormatW", SetLastError = true)]
		private static extern uint _RegisterClipboardFormat(string lpszFormatName);

		// Token: 0x06000274 RID: 628 RVA: 0x0000979E File Offset: 0x0000799E
		public static uint RegisterClipboardFormat(string formatName)
		{
			uint num = NativeMethods._RegisterClipboardFormat(formatName);
			if (num == 0U)
			{
				HRESULT.ThrowLastError();
			}
			return num;
		}

		// Token: 0x06000275 RID: 629
		[DllImport("ole32.dll")]
		public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);

		// Token: 0x06000276 RID: 630
		[DllImport("ole32.dll")]
		public static extern HRESULT CreateStreamOnHGlobal(IntPtr hGlobal, [MarshalAs(UnmanagedType.Bool)] bool fDeleteOnRelease, out IStream ppstm);

		// Token: 0x06000277 RID: 631
		[DllImport("urlmon.dll")]
		public static extern HRESULT CopyStgMedium(ref STGMEDIUM pcstgmedSrc, ref STGMEDIUM pstgmedDest);

		// Token: 0x06000278 RID: 632
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000279 RID: 633
		[DllImport("shell32.dll", CallingConvention = CallingConvention.StdCall)]
		public static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

		// Token: 0x0600027A RID: 634
		[DllImport("dwmapi.dll", PreserveSig = false)]
		public static extern void DwmInvalidateIconicBitmaps(IntPtr hwnd);

		// Token: 0x0600027B RID: 635
		[DllImport("dwmapi.dll", PreserveSig = false)]
		public static extern void DwmSetIconicThumbnail(IntPtr hwnd, IntPtr hbmp, DWM_SIT dwSITFlags);

		// Token: 0x0600027C RID: 636
		[DllImport("dwmapi.dll", PreserveSig = false)]
		public static extern void DwmSetIconicLivePreviewBitmap(IntPtr hwnd, IntPtr hbmp, RefPOINT pptClient, DWM_SIT dwSITFlags);

		// Token: 0x0600027D RID: 637
		[DllImport("shell32.dll", PreserveSig = false)]
		public static extern void SHGetItemFromDataObject(IDataObject pdtobj, DOGIF dwFlags, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		// Token: 0x0600027E RID: 638
		[DllImport("shell32.dll", EntryPoint = "SHAddToRecentDocs", PreserveSig = false)]
		private static extern void _SHAddToRecentDocsObj(SHARD uFlags, object pv);

		// Token: 0x0600027F RID: 639
		[DllImport("shell32.dll", EntryPoint = "SHAddToRecentDocs")]
		private static extern void _SHAddToRecentDocs_String(SHARD uFlags, [MarshalAs(UnmanagedType.LPWStr)] string pv);

		// Token: 0x06000280 RID: 640
		[DllImport("shell32.dll", EntryPoint = "SHAddToRecentDocs")]
		private static extern void _SHAddToRecentDocs_ShellLink(SHARD uFlags, IShellLinkW pv);

		// Token: 0x06000281 RID: 641 RVA: 0x000097AE File Offset: 0x000079AE
		public static void SHAddToRecentDocs(string path)
		{
			NativeMethods._SHAddToRecentDocs_String(SHARD.PATHW, path);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000097B7 File Offset: 0x000079B7
		public static void SHAddToRecentDocs(IShellLinkW shellLink)
		{
			NativeMethods._SHAddToRecentDocs_ShellLink(SHARD.LINK, shellLink);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000097C0 File Offset: 0x000079C0
		public static void SHAddToRecentDocs(SHARDAPPIDINFO info)
		{
			NativeMethods._SHAddToRecentDocsObj(SHARD.APPIDINFO, info);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x000097C9 File Offset: 0x000079C9
		public static void SHAddToRecentDocs(SHARDAPPIDINFOIDLIST infodIdList)
		{
			NativeMethods._SHAddToRecentDocsObj(SHARD.APPIDINFOIDLIST, infodIdList);
		}

		// Token: 0x06000285 RID: 645
		[DllImport("shell32.dll", PreserveSig = false)]
		public static extern HRESULT SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, IBindCtx pbc, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		// Token: 0x06000286 RID: 646
		[DllImport("shell32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Shell_NotifyIcon(NIM dwMessage, [In] NOTIFYICONDATA lpdata);

		// Token: 0x06000287 RID: 647
		[DllImport("shell32.dll", PreserveSig = false)]
		public static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

		// Token: 0x06000288 RID: 648
		[DllImport("shell32.dll")]
		public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] out string AppID);

		// Token: 0x020000D4 RID: 212
		public enum MapType : uint
		{
			// Token: 0x0400070C RID: 1804
			MAPVK_VK_TO_VSC,
			// Token: 0x0400070D RID: 1805
			MAPVK_VSC_TO_VK,
			// Token: 0x0400070E RID: 1806
			MAPVK_VK_TO_CHAR,
			// Token: 0x0400070F RID: 1807
			MAPVK_VSC_TO_VK_EX
		}

		// Token: 0x020000D5 RID: 213
		[StructLayout(LayoutKind.Sequential)]
		public class CHOOSECOLOR
		{
			// Token: 0x04000710 RID: 1808
			public int lStructSize = Marshal.SizeOf(typeof(NativeMethods.CHOOSECOLOR));

			// Token: 0x04000711 RID: 1809
			public IntPtr hwndOwner;

			// Token: 0x04000712 RID: 1810
			public IntPtr hInstance = IntPtr.Zero;

			// Token: 0x04000713 RID: 1811
			public int rgbResult;

			// Token: 0x04000714 RID: 1812
			public IntPtr lpCustColors = IntPtr.Zero;

			// Token: 0x04000715 RID: 1813
			public int Flags;

			// Token: 0x04000716 RID: 1814
			public IntPtr lCustData = IntPtr.Zero;

			// Token: 0x04000717 RID: 1815
			public IntPtr lpfnHook = IntPtr.Zero;

			// Token: 0x04000718 RID: 1816
			public IntPtr lpTemplateName = IntPtr.Zero;
		}
	}
}
