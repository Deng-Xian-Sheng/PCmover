using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using ControlzEx.Standard;

namespace ControlzEx.Windows.Shell
{
	// Token: 0x02000014 RID: 20
	internal class WindowChromeWorker : DependencyObject
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00004C78 File Offset: 0x00002E78
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		public WindowChromeWorker()
		{
			this._messageTable = new List<KeyValuePair<WM, MessageHandler>>
			{
				new KeyValuePair<WM, MessageHandler>(WM.NCUAHDRAWCAPTION, new MessageHandler(this._HandleNCUAHDrawCaption)),
				new KeyValuePair<WM, MessageHandler>(WM.SETTEXT, new MessageHandler(this._HandleSetTextOrIcon)),
				new KeyValuePair<WM, MessageHandler>(WM.SETICON, new MessageHandler(this._HandleSetTextOrIcon)),
				new KeyValuePair<WM, MessageHandler>(WM.SYSCOMMAND, new MessageHandler(this._HandleRestoreWindow)),
				new KeyValuePair<WM, MessageHandler>(WM.NCACTIVATE, new MessageHandler(this._HandleNCActivate)),
				new KeyValuePair<WM, MessageHandler>(WM.NCCALCSIZE, new MessageHandler(this._HandleNCCalcSize)),
				new KeyValuePair<WM, MessageHandler>(WM.NCHITTEST, new MessageHandler(this._HandleNCHitTest)),
				new KeyValuePair<WM, MessageHandler>(WM.NCRBUTTONUP, new MessageHandler(this._HandleNCRButtonUp)),
				new KeyValuePair<WM, MessageHandler>(WM.SIZE, new MessageHandler(this._HandleSize)),
				new KeyValuePair<WM, MessageHandler>(WM.WINDOWPOSCHANGING, new MessageHandler(this._HandleWindowPosChanging)),
				new KeyValuePair<WM, MessageHandler>(WM.WINDOWPOSCHANGED, new MessageHandler(this._HandleWindowPosChanged)),
				new KeyValuePair<WM, MessageHandler>(WM.GETMINMAXINFO, new MessageHandler(this._HandleGetMinMaxInfo)),
				new KeyValuePair<WM, MessageHandler>(WM.DWMCOMPOSITIONCHANGED, new MessageHandler(this._HandleDwmCompositionChanged)),
				new KeyValuePair<WM, MessageHandler>(WM.ENTERSIZEMOVE, new MessageHandler(this._HandleEnterSizeMoveForAnimation)),
				new KeyValuePair<WM, MessageHandler>(WM.MOVE, new MessageHandler(this._HandleMoveForRealSize)),
				new KeyValuePair<WM, MessageHandler>(WM.EXITSIZEMOVE, new MessageHandler(this._HandleExitSizeMoveForAnimation))
			};
			if (Utility.IsPresentationFrameworkVersionLessThan4)
			{
				this._messageTable.AddRange(new KeyValuePair<WM, MessageHandler>[]
				{
					new KeyValuePair<WM, MessageHandler>(WM.WININICHANGE, new MessageHandler(this._HandleSettingChange)),
					new KeyValuePair<WM, MessageHandler>(WM.ENTERSIZEMOVE, new MessageHandler(this._HandleEnterSizeMove)),
					new KeyValuePair<WM, MessageHandler>(WM.EXITSIZEMOVE, new MessageHandler(this._HandleExitSizeMove)),
					new KeyValuePair<WM, MessageHandler>(WM.MOVE, new MessageHandler(this._HandleMove))
				});
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004EC8 File Offset: 0x000030C8
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		public void SetWindowChrome(WindowChrome newChrome)
		{
			base.VerifyAccess();
			if (newChrome == this._chromeInfo)
			{
				return;
			}
			if (this._chromeInfo != null)
			{
				this._chromeInfo.PropertyChangedThatRequiresRepaint -= this._OnChromePropertyChangedThatRequiresRepaint;
			}
			this._chromeInfo = newChrome;
			if (this._chromeInfo != null)
			{
				this._chromeInfo.PropertyChangedThatRequiresRepaint += this._OnChromePropertyChangedThatRequiresRepaint;
			}
			this._ApplyNewCustomChrome();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004F30 File Offset: 0x00003130
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private void _OnChromePropertyChangedThatRequiresRepaint(object sender, EventArgs e)
		{
			this._UpdateFrameState(true);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004F3C File Offset: 0x0000313C
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private static void _OnChromeWorkerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Window window = (Window)d;
			((WindowChromeWorker)e.NewValue)._SetWindow(window);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004F64 File Offset: 0x00003164
		[SecurityCritical]
		private void _SetWindow(Window window)
		{
			this.UnsubscribeWindowEvents();
			this._window = window;
			this._hwnd = new WindowInteropHelper(this._window).Handle;
			Utility.AddDependencyPropertyChangeListener(this._window, Control.TemplateProperty, new EventHandler(this._OnWindowPropertyChangedThatRequiresTemplateFixup));
			Utility.AddDependencyPropertyChangeListener(this._window, FrameworkElement.FlowDirectionProperty, new EventHandler(this._OnWindowPropertyChangedThatRequiresTemplateFixup));
			this._window.Closed += this._UnsetWindow;
			if (IntPtr.Zero != this._hwnd)
			{
				this._hwndSource = HwndSource.FromHwnd(this._hwnd);
				this._window.ApplyTemplate();
				if (this._chromeInfo != null)
				{
					this._ApplyNewCustomChrome();
					return;
				}
			}
			else
			{
				this._window.SourceInitialized += this._WindowSourceInitialized;
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00005038 File Offset: 0x00003238
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private void _WindowSourceInitialized(object sender, EventArgs e)
		{
			this._hwnd = new WindowInteropHelper(this._window).Handle;
			this._hwndSource = HwndSource.FromHwnd(this._hwnd);
			if (this._chromeInfo != null)
			{
				this._ApplyNewCustomChrome();
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005070 File Offset: 0x00003270
		[SecurityCritical]
		private void UnsubscribeWindowEvents()
		{
			if (this._window != null)
			{
				Utility.RemoveDependencyPropertyChangeListener(this._window, Control.TemplateProperty, new EventHandler(this._OnWindowPropertyChangedThatRequiresTemplateFixup));
				Utility.RemoveDependencyPropertyChangeListener(this._window, FrameworkElement.FlowDirectionProperty, new EventHandler(this._OnWindowPropertyChangedThatRequiresTemplateFixup));
				this._window.SourceInitialized -= this._WindowSourceInitialized;
				this._window.StateChanged -= this._FixupRestoreBounds;
				this._window.Closed -= this._UnsetWindow;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005102 File Offset: 0x00003302
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private void _UnsetWindow(object sender, EventArgs e)
		{
			this.UnsubscribeWindowEvents();
			if (this._chromeInfo != null)
			{
				this._chromeInfo.PropertyChangedThatRequiresRepaint -= this._OnChromePropertyChangedThatRequiresRepaint;
			}
			this._RestoreStandardChromeState(true);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00005130 File Offset: 0x00003330
		public static WindowChromeWorker GetWindowChromeWorker(Window window)
		{
			Verify.IsNotNull<Window>(window, "window");
			return (WindowChromeWorker)window.GetValue(WindowChromeWorker.WindowChromeWorkerProperty);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000514D File Offset: 0x0000334D
		public static void SetWindowChromeWorker(Window window, WindowChromeWorker chrome)
		{
			Verify.IsNotNull<Window>(window, "window");
			window.SetValue(WindowChromeWorker.WindowChromeWorkerProperty, chrome);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00005166 File Offset: 0x00003366
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private void _OnWindowPropertyChangedThatRequiresTemplateFixup(object sender, EventArgs e)
		{
			if (this._chromeInfo != null && this._hwnd != IntPtr.Zero)
			{
				this._window.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new WindowChromeWorker._Action(this._FixupTemplateIssues));
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000051A0 File Offset: 0x000033A0
		[SecurityCritical]
		private void _ApplyNewCustomChrome()
		{
			if (this._hwnd == IntPtr.Zero || this._hwndSource.IsDisposed)
			{
				return;
			}
			if (this._chromeInfo == null)
			{
				this._RestoreStandardChromeState(false);
				return;
			}
			if (!this._isHooked)
			{
				this._hwndSource.AddHook(new HwndSourceHook(this._WndProc));
				this._isHooked = true;
			}
			if (this._MinimizeAnimation)
			{
				this._ModifyStyle(WS.OVERLAPPED, WS.CAPTION);
			}
			this._FixupTemplateIssues();
			this._UpdateSystemMenu(new WindowState?(this._window.WindowState));
			this._UpdateFrameState(true);
			if (this._hwndSource.IsDisposed)
			{
				this._UnsetWindow(this._window, EventArgs.Empty);
				return;
			}
			NativeMethods.SetWindowPos(this._hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP.DRAWFRAME | SWP.NOACTIVATE | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOZORDER);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005274 File Offset: 0x00003474
		[SecurityCritical]
		private void _FixupTemplateIssues()
		{
			if (this._window.Template == null)
			{
				return;
			}
			if (VisualTreeHelper.GetChildrenCount(this._window) == 0)
			{
				this._window.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new WindowChromeWorker._Action(this._FixupTemplateIssues));
				return;
			}
			Thickness margin = default(Thickness);
			FrameworkElement frameworkElement = (FrameworkElement)VisualTreeHelper.GetChild(this._window, 0);
			if (this._chromeInfo.SacrificialEdge != SacrificialEdge.None)
			{
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 2))
				{
					margin.Top -= SystemParameters.WindowResizeBorderThickness.Top;
				}
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 1))
				{
					margin.Left -= SystemParameters.WindowResizeBorderThickness.Left;
				}
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 8))
				{
					margin.Bottom -= SystemParameters.WindowResizeBorderThickness.Bottom;
				}
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 4))
				{
					margin.Right -= SystemParameters.WindowResizeBorderThickness.Right;
				}
			}
			if (Utility.IsPresentationFrameworkVersionLessThan4)
			{
				DpiScale dpi = this._window.GetDpi();
				RECT windowRect = NativeMethods.GetWindowRect(this._hwnd);
				RECT rect = this._GetAdjustedWindowRect(windowRect);
				Rect rect2 = DpiHelper.DeviceRectToLogical(new Rect((double)windowRect.Left, (double)windowRect.Top, (double)windowRect.Width, (double)windowRect.Height), dpi.DpiScaleX, dpi.DpiScaleY);
				Rect rect3 = DpiHelper.DeviceRectToLogical(new Rect((double)rect.Left, (double)rect.Top, (double)rect.Width, (double)rect.Height), dpi.DpiScaleX, dpi.DpiScaleY);
				if (!Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 1))
				{
					margin.Right -= SystemParameters.WindowResizeBorderThickness.Left;
				}
				if (!Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 4))
				{
					margin.Right -= SystemParameters.WindowResizeBorderThickness.Right;
				}
				if (!Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 2))
				{
					margin.Bottom -= SystemParameters.WindowResizeBorderThickness.Top;
				}
				if (!Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 8))
				{
					margin.Bottom -= SystemParameters.WindowResizeBorderThickness.Bottom;
				}
				margin.Bottom -= SystemParameters.WindowCaptionHeight;
				Transform renderTransform;
				if (this._window.FlowDirection == FlowDirection.RightToLeft)
				{
					Thickness thickness = new Thickness(rect2.Left - rect3.Left, rect2.Top - rect3.Top, rect3.Right - rect2.Right, rect3.Bottom - rect2.Bottom);
					renderTransform = new MatrixTransform(1.0, 0.0, 0.0, 1.0, -(thickness.Left + thickness.Right), 0.0);
				}
				else
				{
					renderTransform = null;
				}
				frameworkElement.RenderTransform = renderTransform;
			}
			frameworkElement.Margin = margin;
			if (Utility.IsPresentationFrameworkVersionLessThan4 && !this._isFixedUp)
			{
				this._hasUserMovedWindow = false;
				this._window.StateChanged += this._FixupRestoreBounds;
				this._isFixedUp = true;
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000055EC File Offset: 0x000037EC
		[SecuritySafeCritical]
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private void _FixupRestoreBounds(object sender, EventArgs e)
		{
			if ((this._window.WindowState == WindowState.Maximized || this._window.WindowState == WindowState.Minimized) && this._hasUserMovedWindow)
			{
				DpiScale dpi = this._window.GetDpi();
				this._hasUserMovedWindow = false;
				WINDOWPLACEMENT windowPlacement = NativeMethods.GetWindowPlacement(this._hwnd);
				RECT rect = this._GetAdjustedWindowRect(new RECT
				{
					Bottom = 100,
					Right = 100
				});
				Point point = DpiHelper.DevicePixelsToLogical(new Point((double)(windowPlacement.normalPosition.Left - rect.Left), (double)(windowPlacement.normalPosition.Top - rect.Top)), dpi.DpiScaleX, dpi.DpiScaleY);
				this._window.Top = point.Y;
				this._window.Left = point.X;
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000056CC File Offset: 0x000038CC
		[SecurityCritical]
		private RECT _GetAdjustedWindowRect(RECT rcWindow)
		{
			WS dwStyle = (WS)((int)NativeMethods.GetWindowLongPtr(this._hwnd, GWL.STYLE));
			WS_EX dwExStyle = (WS_EX)((int)NativeMethods.GetWindowLongPtr(this._hwnd, GWL.EXSTYLE));
			return NativeMethods.AdjustWindowRectEx(rcWindow, dwStyle, false, dwExStyle);
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00005708 File Offset: 0x00003908
		private bool _IsWindowDocked
		{
			[SecurityCritical]
			get
			{
				if (this._window.WindowState != WindowState.Normal)
				{
					return false;
				}
				DpiScale dpi = this._window.GetDpi();
				RECT rect = this._GetAdjustedWindowRect(new RECT
				{
					Bottom = 100,
					Right = 100
				});
				Point point = new Point(this._window.Left, this._window.Top);
				point -= (Vector)DpiHelper.DevicePixelsToLogical(new Point((double)rect.Left, (double)rect.Top), dpi.DpiScaleX, dpi.DpiScaleY);
				return this._window.RestoreBounds.Location != point;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000ED RID: 237 RVA: 0x000057BD File Offset: 0x000039BD
		private bool _MinimizeAnimation
		{
			get
			{
				return SystemParameters.MinimizeAnimation && !this._chromeInfo.IgnoreTaskbarOnMaximize;
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000057D8 File Offset: 0x000039D8
		[SecurityCritical]
		private IntPtr _WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			HwndSource hwndSource = this._hwndSource;
			if (((hwndSource != null) ? hwndSource.RootVisual : null) == null)
			{
				return IntPtr.Zero;
			}
			foreach (KeyValuePair<WM, MessageHandler> keyValuePair in this._messageTable)
			{
				if (keyValuePair.Key == (WM)msg)
				{
					return keyValuePair.Value((WM)msg, wParam, lParam, out handled);
				}
			}
			return IntPtr.Zero;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005868 File Offset: 0x00003A68
		[SecurityCritical]
		private IntPtr _HandleNCUAHDrawCaption(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (!this._window.ShowInTaskbar && this._GetHwndState() == WindowState.Minimized)
			{
				bool flag = this._ModifyStyle(WS.VISIBLE, WS.OVERLAPPED);
				IntPtr result = NativeMethods.DefWindowProc(this._hwnd, uMsg, wParam, lParam);
				if (flag)
				{
					this._ModifyStyle(WS.OVERLAPPED, WS.VISIBLE);
				}
				handled = true;
				return result;
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000058C4 File Offset: 0x00003AC4
		private IntPtr _HandleSetTextOrIcon(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			bool flag = this._ModifyStyle(WS.VISIBLE, WS.OVERLAPPED);
			IntPtr result = NativeMethods.DefWindowProc(this._hwnd, uMsg, wParam, lParam);
			if (flag)
			{
				this._ModifyStyle(WS.OVERLAPPED, WS.VISIBLE);
			}
			handled = true;
			return result;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005900 File Offset: 0x00003B00
		[SecurityCritical]
		private IntPtr _HandleRestoreWindow(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			WINDOWPLACEMENT windowPlacement = NativeMethods.GetWindowPlacement(this._hwnd);
			SC sc = (SC)(Environment.Is64BitProcess ? wParam.ToInt64() : ((long)wParam.ToInt32()));
			if (SC.RESTORE == sc && windowPlacement.showCmd == SW.SHOWMAXIMIZED && this._MinimizeAnimation)
			{
				bool flag = this._ModifyStyle(WS.SYSMENU, WS.OVERLAPPED);
				IntPtr result = NativeMethods.DefWindowProc(this._hwnd, uMsg, wParam, lParam);
				if (flag)
				{
					this._ModifyStyle(WS.OVERLAPPED, WS.SYSMENU);
				}
				handled = true;
				return result;
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005985 File Offset: 0x00003B85
		[SecurityCritical]
		private IntPtr _HandleNCActivate(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			IntPtr result = NativeMethods.DefWindowProc(this._hwnd, WM.NCACTIVATE, wParam, new IntPtr(-1));
			handled = true;
			return result;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000059A4 File Offset: 0x00003BA4
		[SecurityCritical]
		private static RECT AdjustWorkingAreaForAutoHide(IntPtr monitorContainingApplication, RECT area)
		{
			IntPtr taskBarHandleForMonitor = NativeMethods.GetTaskBarHandleForMonitor(monitorContainingApplication);
			if (taskBarHandleForMonitor == IntPtr.Zero)
			{
				return area;
			}
			APPBARDATA appbardata = default(APPBARDATA);
			appbardata.cbSize = Marshal.SizeOf<APPBARDATA>(appbardata);
			appbardata.hWnd = taskBarHandleForMonitor;
			NativeMethods.SHAppBarMessage(5, ref appbardata);
			if (!Convert.ToBoolean(NativeMethods.SHAppBarMessage(4, ref appbardata)))
			{
				return area;
			}
			switch (appbardata.uEdge)
			{
			case 0:
				area.Left += 2;
				break;
			case 1:
				area.Top += 2;
				break;
			case 2:
				area.Right -= 2;
				break;
			case 3:
				area.Bottom -= 2;
				break;
			default:
				return area;
			}
			return area;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005A64 File Offset: 0x00003C64
		[SecurityCritical]
		private IntPtr _HandleNCCalcSize(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (NativeMethods.GetWindowPlacement(this._hwnd).showCmd == SW.SHOWMAXIMIZED && this._MinimizeAnimation)
			{
				IntPtr intPtr = NativeMethods.MonitorFromWindow(this._hwnd, MonitorOptions.MONITOR_DEFAULTTONEAREST);
				MONITORINFO monitorInfo = NativeMethods.GetMonitorInfo(intPtr);
				RECT rect = this._chromeInfo.IgnoreTaskbarOnMaximize ? monitorInfo.rcMonitor : monitorInfo.rcWork;
				RECT rect2 = (RECT)Marshal.PtrToStructure(lParam, typeof(RECT));
				rect2.Left = rect.Left;
				rect2.Top = rect.Top;
				rect2.Right = rect.Right;
				rect2.Bottom = rect.Bottom;
				if (monitorInfo.rcMonitor.Height == monitorInfo.rcWork.Height && monitorInfo.rcMonitor.Width == monitorInfo.rcWork.Width)
				{
					rect2 = WindowChromeWorker.AdjustWorkingAreaForAutoHide(intPtr, rect2);
				}
				Marshal.StructureToPtr<RECT>(rect2, lParam, true);
			}
			if (this._chromeInfo.SacrificialEdge != SacrificialEdge.None)
			{
				DpiScale dpi = this._window.GetDpi();
				Thickness thickness = DpiHelper.LogicalThicknessToDevice(SystemParameters.WindowResizeBorderThickness, dpi.DpiScaleX, dpi.DpiScaleY);
				RECT structure = (RECT)Marshal.PtrToStructure(lParam, typeof(RECT));
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 2))
				{
					structure.Top += (int)thickness.Top;
				}
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 1))
				{
					structure.Left += (int)thickness.Left;
				}
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 8))
				{
					structure.Bottom -= (int)thickness.Bottom;
				}
				if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 4))
				{
					structure.Right -= (int)thickness.Right;
				}
				Marshal.StructureToPtr<RECT>(structure, lParam, false);
			}
			handled = true;
			IntPtr zero = IntPtr.Zero;
			if (wParam.ToInt32() != 0)
			{
				zero = new IntPtr(1792);
			}
			return zero;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005C70 File Offset: 0x00003E70
		private HT _GetHTFromResizeGripDirection(ResizeGripDirection direction)
		{
			bool flag = this._window.FlowDirection == FlowDirection.RightToLeft;
			switch (direction)
			{
			case ResizeGripDirection.TopLeft:
				if (!flag)
				{
					return HT.TOPLEFT;
				}
				return HT.TOPRIGHT;
			case ResizeGripDirection.Top:
				return HT.TOP;
			case ResizeGripDirection.TopRight:
				if (!flag)
				{
					return HT.TOPRIGHT;
				}
				return HT.TOPLEFT;
			case ResizeGripDirection.Right:
				if (!flag)
				{
					return HT.RIGHT;
				}
				return HT.LEFT;
			case ResizeGripDirection.BottomRight:
				if (!flag)
				{
					return HT.BOTTOMRIGHT;
				}
				return HT.BOTTOMLEFT;
			case ResizeGripDirection.Bottom:
				return HT.BOTTOM;
			case ResizeGripDirection.BottomLeft:
				if (!flag)
				{
					return HT.BOTTOMLEFT;
				}
				return HT.BOTTOMRIGHT;
			case ResizeGripDirection.Left:
				if (!flag)
				{
					return HT.LEFT;
				}
				return HT.RIGHT;
			case ResizeGripDirection.Caption:
				return HT.CAPTION;
			default:
				return HT.NOWHERE;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00005CFC File Offset: 0x00003EFC
		[SecurityCritical]
		private IntPtr _HandleNCHitTest(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			DpiScale dpi = this._window.GetDpi();
			Point point = Utility.GetPoint(lParam);
			Rect deviceRectangle = this._GetWindowRect();
			Point point2 = point;
			point2.Offset(-deviceRectangle.X, -deviceRectangle.Y);
			point2 = DpiHelper.DevicePixelsToLogical(point2, dpi.DpiScaleX, dpi.DpiScaleY);
			IInputElement inputElement = this._window.InputHitTest(point2);
			if (inputElement != null)
			{
				if (WindowChrome.GetIsHitTestVisibleInChrome(inputElement))
				{
					handled = true;
					return new IntPtr(1);
				}
				ResizeGripDirection resizeGripDirection = WindowChrome.GetResizeGripDirection(inputElement);
				if (resizeGripDirection != ResizeGripDirection.None)
				{
					handled = true;
					return new IntPtr((int)this._GetHTFromResizeGripDirection(resizeGripDirection));
				}
			}
			if (this._chromeInfo.UseAeroCaptionButtons && Utility.IsOSVistaOrNewer && this._chromeInfo.GlassFrameThickness != default(Thickness) && this._isGlassEnabled)
			{
				IntPtr intPtr;
				handled = NativeMethods.DwmDefWindowProc(this._hwnd, uMsg, wParam, lParam, out intPtr);
				if (IntPtr.Zero != intPtr)
				{
					return intPtr;
				}
			}
			int value = (int)this._HitTestNca(DpiHelper.DeviceRectToLogical(deviceRectangle, dpi.DpiScaleX, dpi.DpiScaleY), DpiHelper.DevicePixelsToLogical(point, dpi.DpiScaleX, dpi.DpiScaleY));
			handled = true;
			return new IntPtr(value);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005E29 File Offset: 0x00004029
		[SecurityCritical]
		private IntPtr _HandleNCRButtonUp(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (2 == (int)(Environment.Is64BitProcess ? wParam.ToInt64() : ((long)wParam.ToInt32())))
			{
				SystemCommands.ShowSystemMenuPhysicalCoordinates(this._window, Utility.GetPoint(lParam));
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00005E64 File Offset: 0x00004064
		[SecurityCritical]
		private IntPtr _HandleSize(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			WindowState? assumeState = null;
			if ((Environment.Is64BitProcess ? wParam.ToInt64() : ((long)wParam.ToInt32())) == 2L)
			{
				assumeState = new WindowState?(WindowState.Maximized);
			}
			this._UpdateSystemMenu(assumeState);
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00005EB0 File Offset: 0x000040B0
		[SecurityCritical]
		private IntPtr _HandleWindowPosChanging(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (!this._isGlassEnabled)
			{
				WINDOWPOS windowpos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
				if (this._chromeInfo.IgnoreTaskbarOnMaximize && this._GetHwndState() == WindowState.Maximized && windowpos.flags == SWP.DRAWFRAME)
				{
					windowpos.flags = (SWP)0;
					Marshal.StructureToPtr<WINDOWPOS>(windowpos, lParam, true);
				}
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005F14 File Offset: 0x00004114
		[SecurityCritical]
		private IntPtr _HandleWindowPosChanged(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			this._UpdateSystemMenu(null);
			if (!this._isGlassEnabled)
			{
				WINDOWPOS windowpos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
				if (!windowpos.Equals(this._previousWP))
				{
					this._previousWP = windowpos;
					this._SetRoundingRegion(new WINDOWPOS?(windowpos));
				}
				this._previousWP = windowpos;
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005F8C File Offset: 0x0000418C
		[SecurityCritical]
		private IntPtr _HandleGetMinMaxInfo(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (this._chromeInfo.IgnoreTaskbarOnMaximize && NativeMethods.IsZoomed(this._hwnd))
			{
				MINMAXINFO structure = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
				IntPtr intPtr = NativeMethods.MonitorFromWindow(this._hwnd, MonitorOptions.MONITOR_DEFAULTTONEAREST);
				if (intPtr != IntPtr.Zero)
				{
					MONITORINFO monitorInfoW = NativeMethods.GetMonitorInfoW(intPtr);
					RECT rcWork = monitorInfoW.rcWork;
					RECT rcMonitor = monitorInfoW.rcMonitor;
					structure.ptMaxPosition.X = Math.Abs(rcWork.Left - rcMonitor.Left);
					structure.ptMaxPosition.Y = Math.Abs(rcWork.Top - rcMonitor.Top);
					structure.ptMaxSize.X = Math.Abs(monitorInfoW.rcMonitor.Width);
					structure.ptMaxSize.Y = Math.Abs(monitorInfoW.rcMonitor.Height);
					structure.ptMaxTrackSize.X = structure.ptMaxSize.X;
					structure.ptMaxTrackSize.Y = structure.ptMaxSize.Y;
				}
				Marshal.StructureToPtr<MINMAXINFO>(structure, lParam, true);
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000060BB File Offset: 0x000042BB
		[SecurityCritical]
		private IntPtr _HandleDwmCompositionChanged(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			this._UpdateFrameState(false);
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000060CD File Offset: 0x000042CD
		[SecurityCritical]
		private IntPtr _HandleSettingChange(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			this._FixupTemplateIssues();
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000060E0 File Offset: 0x000042E0
		[SecurityCritical]
		private IntPtr _HandleEnterSizeMove(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			this._isUserResizing = true;
			if (this._window.WindowState != WindowState.Maximized && !this._IsWindowDocked)
			{
				this._windowPosAtStartOfUserMove = new Point(this._window.Left, this._window.Top);
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00006134 File Offset: 0x00004334
		[SecurityCritical]
		private IntPtr _HandleEnterSizeMoveForAnimation(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (this._MinimizeAnimation)
			{
				this._ModifyStyle(WS.CAPTION, WS.OVERLAPPED);
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00006154 File Offset: 0x00004354
		[SecurityCritical]
		private IntPtr _HandleMoveForRealSize(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (this._GetHwndState() == WindowState.Maximized)
			{
				IntPtr intPtr = NativeMethods.MonitorFromWindow(this._hwnd, MonitorOptions.MONITOR_DEFAULTTONEAREST);
				if (intPtr != IntPtr.Zero)
				{
					bool ignoreTaskbarOnMaximize = this._chromeInfo.IgnoreTaskbarOnMaximize;
					MONITORINFO monitorInfoW = NativeMethods.GetMonitorInfoW(intPtr);
					RECT rect = ignoreTaskbarOnMaximize ? monitorInfoW.rcMonitor : monitorInfoW.rcWork;
					NativeMethods.SetWindowPos(this._hwnd, IntPtr.Zero, rect.Left, rect.Top, rect.Width, rect.Height, SWP.ASYNCWINDOWPOS | SWP.DRAWFRAME | SWP.NOCOPYBITS);
				}
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000061E1 File Offset: 0x000043E1
		[SecurityCritical]
		private IntPtr _HandleExitSizeMoveForAnimation(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (this._MinimizeAnimation && this._ModifyStyle(WS.OVERLAPPED, WS.CAPTION))
			{
				NativeMethods.SetWindowPos(this._hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP.DRAWFRAME | SWP.NOACTIVATE | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOZORDER);
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000621C File Offset: 0x0000441C
		private IntPtr _HandleExitSizeMove(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			this._isUserResizing = false;
			if (this._window.WindowState == WindowState.Maximized)
			{
				this._window.Top = this._windowPosAtStartOfUserMove.Y;
				this._window.Left = this._windowPosAtStartOfUserMove.X;
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00006273 File Offset: 0x00004473
		private IntPtr _HandleMove(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			if (this._isUserResizing)
			{
				this._hasUserMovedWindow = true;
			}
			handled = false;
			return IntPtr.Zero;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00006290 File Offset: 0x00004490
		[SecurityCritical]
		private bool _ModifyStyle(WS removeStyle, WS addStyle)
		{
			IntPtr windowLongPtr = NativeMethods.GetWindowLongPtr(this._hwnd, GWL.STYLE);
			uint num = (uint)(Environment.Is64BitProcess ? windowLongPtr.ToInt64() : ((long)windowLongPtr.ToInt32()));
			WS ws = (WS)((num & (uint)(~(uint)removeStyle)) | (uint)addStyle);
			if (num == (uint)ws)
			{
				return false;
			}
			NativeMethods.SetWindowLongPtr(this._hwnd, GWL.STYLE, new IntPtr((int)ws));
			return true;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000062E8 File Offset: 0x000044E8
		[SecurityCritical]
		private WindowState _GetHwndState()
		{
			SW showCmd = NativeMethods.GetWindowPlacement(this._hwnd).showCmd;
			if (showCmd == SW.SHOWMINIMIZED)
			{
				return WindowState.Minimized;
			}
			if (showCmd != SW.SHOWMAXIMIZED)
			{
				return WindowState.Normal;
			}
			return WindowState.Maximized;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00006318 File Offset: 0x00004518
		[SecurityCritical]
		private Rect _GetWindowRect()
		{
			RECT windowRect = NativeMethods.GetWindowRect(this._hwnd);
			return new Rect((double)windowRect.Left, (double)windowRect.Top, (double)windowRect.Width, (double)windowRect.Height);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00006358 File Offset: 0x00004558
		[SecurityCritical]
		private void _UpdateSystemMenu(WindowState? assumeState)
		{
			WindowState windowState = assumeState ?? this._GetHwndState();
			if (assumeState != null || this._lastMenuState != windowState)
			{
				this._lastMenuState = windowState;
				IntPtr systemMenu = NativeMethods.GetSystemMenu(this._hwnd, false);
				if (IntPtr.Zero != systemMenu)
				{
					IntPtr windowLongPtr = NativeMethods.GetWindowLongPtr(this._hwnd, GWL.STYLE);
					uint value = (uint)(Environment.Is64BitProcess ? windowLongPtr.ToInt64() : ((long)windowLongPtr.ToInt32()));
					bool flag = Utility.IsFlagSet((int)value, 131072);
					bool flag2 = Utility.IsFlagSet((int)value, 65536);
					bool flag3 = Utility.IsFlagSet((int)value, 262144);
					if (windowState == WindowState.Minimized)
					{
						NativeMethods.EnableMenuItem(systemMenu, SC.RESTORE, MF.ENABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.MOVE, MF.GRAYED | MF.DISABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.SIZE, MF.GRAYED | MF.DISABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.MINIMIZE, MF.GRAYED | MF.DISABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.MAXIMIZE, flag2 ? MF.ENABLED : (MF.GRAYED | MF.DISABLED));
						return;
					}
					if (windowState == WindowState.Maximized)
					{
						NativeMethods.EnableMenuItem(systemMenu, SC.RESTORE, MF.ENABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.MOVE, MF.GRAYED | MF.DISABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.SIZE, MF.GRAYED | MF.DISABLED);
						NativeMethods.EnableMenuItem(systemMenu, SC.MINIMIZE, flag ? MF.ENABLED : (MF.GRAYED | MF.DISABLED));
						NativeMethods.EnableMenuItem(systemMenu, SC.MAXIMIZE, MF.GRAYED | MF.DISABLED);
						return;
					}
					NativeMethods.EnableMenuItem(systemMenu, SC.RESTORE, MF.GRAYED | MF.DISABLED);
					NativeMethods.EnableMenuItem(systemMenu, SC.MOVE, MF.ENABLED);
					NativeMethods.EnableMenuItem(systemMenu, SC.SIZE, flag3 ? MF.ENABLED : (MF.GRAYED | MF.DISABLED));
					NativeMethods.EnableMenuItem(systemMenu, SC.MINIMIZE, flag ? MF.ENABLED : (MF.GRAYED | MF.DISABLED));
					NativeMethods.EnableMenuItem(systemMenu, SC.MAXIMIZE, flag2 ? MF.ENABLED : (MF.GRAYED | MF.DISABLED));
				}
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000064FC File Offset: 0x000046FC
		[SecurityCritical]
		private void _UpdateFrameState(bool force)
		{
			if (IntPtr.Zero == this._hwnd || this._hwndSource.IsDisposed)
			{
				return;
			}
			bool flag = NativeMethods.DwmIsCompositionEnabled();
			if (force || flag != this._isGlassEnabled)
			{
				this._isGlassEnabled = (flag && this._chromeInfo.GlassFrameThickness != default(Thickness));
				if (!this._isGlassEnabled)
				{
					this._SetRoundingRegion(null);
				}
				else
				{
					this._ClearRoundingRegion();
					this._ExtendGlassFrame();
				}
				if (this._hwndSource.IsDisposed)
				{
					return;
				}
				if (this._MinimizeAnimation)
				{
					this._ModifyStyle(WS.OVERLAPPED, WS.CAPTION);
				}
				else
				{
					this._ModifyStyle(WS.CAPTION, WS.OVERLAPPED);
				}
				NativeMethods.SetWindowPos(this._hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP.DRAWFRAME | SWP.NOACTIVATE | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOZORDER);
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000065D3 File Offset: 0x000047D3
		[SecurityCritical]
		private void _ClearRoundingRegion()
		{
			NativeMethods.SetWindowRgn(this._hwnd, IntPtr.Zero, NativeMethods.IsWindowVisible(this._hwnd));
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000065F0 File Offset: 0x000047F0
		[SecurityCritical]
		private RECT _GetClientRectRelativeToWindowRect(IntPtr hWnd)
		{
			RECT windowRect = NativeMethods.GetWindowRect(hWnd);
			RECT clientRect = NativeMethods.GetClientRect(hWnd);
			POINT point = new POINT
			{
				X = 0,
				Y = 0
			};
			NativeMethods.ClientToScreen(hWnd, ref point);
			if (this._window.FlowDirection == FlowDirection.RightToLeft)
			{
				clientRect.Offset(windowRect.Right - point.X, point.Y - windowRect.Top);
			}
			else
			{
				clientRect.Offset(point.X - windowRect.Left, point.Y - windowRect.Top);
			}
			return clientRect;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000668C File Offset: 0x0000488C
		[SecurityCritical]
		private void _SetRoundingRegion(WINDOWPOS? wp)
		{
			if (NativeMethods.GetWindowPlacement(this._hwnd).showCmd == SW.SHOWMAXIMIZED)
			{
				RECT lprc;
				if (this._MinimizeAnimation)
				{
					lprc = this._GetClientRectRelativeToWindowRect(this._hwnd);
				}
				else
				{
					int num;
					int num2;
					if (wp != null)
					{
						num = wp.Value.x;
						num2 = wp.Value.y;
					}
					else
					{
						Rect rect = this._GetWindowRect();
						num = (int)rect.Left;
						num2 = (int)rect.Top;
					}
					MONITORINFO monitorInfo = NativeMethods.GetMonitorInfo(NativeMethods.MonitorFromWindow(this._hwnd, MonitorOptions.MONITOR_DEFAULTTONEAREST));
					lprc = (this._chromeInfo.IgnoreTaskbarOnMaximize ? monitorInfo.rcMonitor : monitorInfo.rcWork);
					lprc.Offset(-num, -num2);
				}
				IntPtr hRgn = IntPtr.Zero;
				try
				{
					hRgn = NativeMethods.CreateRectRgnIndirect(lprc);
					NativeMethods.SetWindowRgn(this._hwnd, hRgn, NativeMethods.IsWindowVisible(this._hwnd));
					hRgn = IntPtr.Zero;
					return;
				}
				finally
				{
					Utility.SafeDeleteObject(ref hRgn);
				}
			}
			Size size;
			if (wp != null && !Utility.IsFlagSet((int)wp.Value.flags, 1))
			{
				size = new Size((double)wp.Value.cx, (double)wp.Value.cy);
			}
			else
			{
				if (wp != null && this._lastRoundingState == this._window.WindowState)
				{
					return;
				}
				size = this._GetWindowRect().Size;
			}
			this._lastRoundingState = this._window.WindowState;
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				DpiScale dpi = this._window.GetDpi();
				double num3 = Math.Min(size.Width, size.Height);
				double num4 = DpiHelper.LogicalPixelsToDevice(new Point(this._chromeInfo.CornerRadius.TopLeft, 0.0), dpi.DpiScaleX, dpi.DpiScaleY).X;
				num4 = Math.Min(num4, num3 / 2.0);
				if (WindowChromeWorker._IsUniform(this._chromeInfo.CornerRadius))
				{
					intPtr = WindowChromeWorker._CreateRoundRectRgn(new Rect(size), num4);
				}
				else
				{
					intPtr = WindowChromeWorker._CreateRoundRectRgn(new Rect(0.0, 0.0, size.Width / 2.0 + num4, size.Height / 2.0 + num4), num4);
					double num5 = DpiHelper.LogicalPixelsToDevice(new Point(this._chromeInfo.CornerRadius.TopRight, 0.0), dpi.DpiScaleX, dpi.DpiScaleY).X;
					num5 = Math.Min(num5, num3 / 2.0);
					Rect region = new Rect(0.0, 0.0, size.Width / 2.0 + num5, size.Height / 2.0 + num5);
					region.Offset(size.Width / 2.0 - num5, 0.0);
					WindowChromeWorker._CreateAndCombineRoundRectRgn(intPtr, region, num5);
					double num6 = DpiHelper.LogicalPixelsToDevice(new Point(this._chromeInfo.CornerRadius.BottomLeft, 0.0), dpi.DpiScaleX, dpi.DpiScaleY).X;
					num6 = Math.Min(num6, num3 / 2.0);
					Rect region2 = new Rect(0.0, 0.0, size.Width / 2.0 + num6, size.Height / 2.0 + num6);
					region2.Offset(0.0, size.Height / 2.0 - num6);
					WindowChromeWorker._CreateAndCombineRoundRectRgn(intPtr, region2, num6);
					double num7 = DpiHelper.LogicalPixelsToDevice(new Point(this._chromeInfo.CornerRadius.BottomRight, 0.0), dpi.DpiScaleX, dpi.DpiScaleY).X;
					num7 = Math.Min(num7, num3 / 2.0);
					Rect region3 = new Rect(0.0, 0.0, size.Width / 2.0 + num7, size.Height / 2.0 + num7);
					region3.Offset(size.Width / 2.0 - num7, size.Height / 2.0 - num7);
					WindowChromeWorker._CreateAndCombineRoundRectRgn(intPtr, region3, num7);
				}
				NativeMethods.SetWindowRgn(this._hwnd, intPtr, NativeMethods.IsWindowVisible(this._hwnd));
				intPtr = IntPtr.Zero;
			}
			finally
			{
				Utility.SafeDeleteObject(ref intPtr);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006B9C File Offset: 0x00004D9C
		[SecurityCritical]
		private static IntPtr _CreateRoundRectRgn(Rect region, double radius)
		{
			if (DoubleUtilities.AreClose(0.0, radius))
			{
				return NativeMethods.CreateRectRgn((int)Math.Floor(region.Left), (int)Math.Floor(region.Top), (int)Math.Ceiling(region.Right), (int)Math.Ceiling(region.Bottom));
			}
			return NativeMethods.CreateRoundRectRgn((int)Math.Floor(region.Left), (int)Math.Floor(region.Top), (int)Math.Ceiling(region.Right) + 1, (int)Math.Ceiling(region.Bottom) + 1, (int)Math.Ceiling(radius), (int)Math.Ceiling(radius));
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006C40 File Offset: 0x00004E40
		[SecurityCritical]
		private static void _CreateAndCombineRoundRectRgn(IntPtr hrgnSource, Rect region, double radius)
		{
			IntPtr hrgnSrc = IntPtr.Zero;
			try
			{
				hrgnSrc = WindowChromeWorker._CreateRoundRectRgn(region, radius);
				if (NativeMethods.CombineRgn(hrgnSource, hrgnSource, hrgnSrc, RGN.OR) == CombineRgnResult.ERROR)
				{
					throw new InvalidOperationException("Unable to combine two HRGNs.");
				}
			}
			catch
			{
				Utility.SafeDeleteObject(ref hrgnSrc);
				throw;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006C90 File Offset: 0x00004E90
		private static bool _IsUniform(CornerRadius cornerRadius)
		{
			return DoubleUtilities.AreClose(cornerRadius.BottomLeft, cornerRadius.BottomRight) && DoubleUtilities.AreClose(cornerRadius.TopLeft, cornerRadius.TopRight) && DoubleUtilities.AreClose(cornerRadius.BottomLeft, cornerRadius.TopRight);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00006CE4 File Offset: 0x00004EE4
		[SecurityCritical]
		private void _ExtendGlassFrame()
		{
			if (!Utility.IsOSVistaOrNewer)
			{
				return;
			}
			if (IntPtr.Zero == this._hwnd)
			{
				return;
			}
			if (this._hwndSource.IsDisposed)
			{
				return;
			}
			if (NativeMethods.DwmIsCompositionEnabled())
			{
				DpiScale dpi = this._window.GetDpi();
				if (this._window.AllowsTransparency)
				{
					this._hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;
				}
				Thickness thickness = DpiHelper.LogicalThicknessToDevice(this._chromeInfo.GlassFrameThickness, dpi.DpiScaleX, dpi.DpiScaleY);
				if (this._chromeInfo.SacrificialEdge != SacrificialEdge.None)
				{
					Thickness thickness2 = DpiHelper.LogicalThicknessToDevice(SystemParameters.WindowResizeBorderThickness, dpi.DpiScaleX, dpi.DpiScaleY);
					if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 2))
					{
						thickness.Top -= thickness2.Top;
						thickness.Top = Math.Max(0.0, thickness.Top);
					}
					if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 1))
					{
						thickness.Left -= thickness2.Left;
						thickness.Left = Math.Max(0.0, thickness.Left);
					}
					if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 8))
					{
						thickness.Bottom -= thickness2.Bottom;
						thickness.Bottom = Math.Max(0.0, thickness.Bottom);
					}
					if (Utility.IsFlagSet((int)this._chromeInfo.SacrificialEdge, 4))
					{
						thickness.Right -= thickness2.Right;
						thickness.Right = Math.Max(0.0, thickness.Right);
					}
				}
				MARGINS margins = new MARGINS
				{
					cxLeftWidth = (int)Math.Ceiling(thickness.Left),
					cxRightWidth = (int)Math.Ceiling(thickness.Right),
					cyTopHeight = (int)Math.Ceiling(thickness.Top),
					cyBottomHeight = (int)Math.Ceiling(thickness.Bottom)
				};
				NativeMethods.DwmExtendFrameIntoClientArea(this._hwnd, ref margins);
				return;
			}
			if (this._window.AllowsTransparency)
			{
				this._hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;
				return;
			}
			this._hwndSource.CompositionTarget.BackgroundColor = SystemColors.WindowColor;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00006F48 File Offset: 0x00005148
		private HT _HitTestNca(Rect windowPosition, Point mousePosition)
		{
			int num = 1;
			int num2 = 1;
			bool flag = false;
			if (mousePosition.Y >= windowPosition.Top && mousePosition.Y < windowPosition.Top + this._chromeInfo.ResizeBorderThickness.Top + this._chromeInfo.CaptionHeight)
			{
				flag = (mousePosition.Y < windowPosition.Top + this._chromeInfo.ResizeBorderThickness.Top);
				num = 0;
			}
			else if (mousePosition.Y < windowPosition.Bottom && mousePosition.Y >= windowPosition.Bottom - (double)((int)this._chromeInfo.ResizeBorderThickness.Bottom))
			{
				num = 2;
			}
			if (mousePosition.X >= windowPosition.Left && mousePosition.X < windowPosition.Left + (double)((int)this._chromeInfo.ResizeBorderThickness.Left))
			{
				num2 = 0;
			}
			else if (mousePosition.X < windowPosition.Right && mousePosition.X >= windowPosition.Right - this._chromeInfo.ResizeBorderThickness.Right)
			{
				num2 = 2;
			}
			if (num == 0 && num2 != 1 && !flag)
			{
				num = 1;
			}
			HT ht = WindowChromeWorker._HitTestBorders[num, num2];
			if (ht == HT.TOP && !flag)
			{
				ht = HT.CAPTION;
			}
			return ht;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007095 File Offset: 0x00005295
		[SecurityCritical]
		private void _RestoreStandardChromeState(bool isClosing)
		{
			base.VerifyAccess();
			this._UnhookCustomChrome();
			if (!isClosing && !this._hwndSource.IsDisposed)
			{
				this._RestoreFrameworkIssueFixups();
				this._RestoreGlassFrame();
				this._RestoreHrgn();
				this._window.InvalidateMeasure();
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000070D0 File Offset: 0x000052D0
		[SecurityCritical]
		private void _UnhookCustomChrome()
		{
			if (this._isHooked)
			{
				this._hwndSource.RemoveHook(new HwndSourceHook(this._WndProc));
				this._isHooked = false;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000070F8 File Offset: 0x000052F8
		[SecurityCritical]
		private void _RestoreFrameworkIssueFixups()
		{
			((FrameworkElement)VisualTreeHelper.GetChild(this._window, 0)).Margin = default(Thickness);
			if (Utility.IsPresentationFrameworkVersionLessThan4)
			{
				this._window.StateChanged -= this._FixupRestoreBounds;
				this._isFixedUp = false;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000714C File Offset: 0x0000534C
		[SecurityCritical]
		private void _RestoreGlassFrame()
		{
			if (!Utility.IsOSVistaOrNewer || this._hwnd == IntPtr.Zero)
			{
				return;
			}
			this._hwndSource.CompositionTarget.BackgroundColor = SystemColors.WindowColor;
			if (NativeMethods.DwmIsCompositionEnabled())
			{
				MARGINS margins = default(MARGINS);
				NativeMethods.DwmExtendFrameIntoClientArea(this._hwnd, ref margins);
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000071A4 File Offset: 0x000053A4
		[SecurityCritical]
		private void _RestoreHrgn()
		{
			this._ClearRoundingRegion();
			NativeMethods.SetWindowPos(this._hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP.DRAWFRAME | SWP.NOACTIVATE | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOZORDER);
		}

		// Token: 0x0400007B RID: 123
		private const SWP _SwpFlags = SWP.DRAWFRAME | SWP.NOACTIVATE | SWP.NOMOVE | SWP.NOOWNERZORDER | SWP.NOSIZE | SWP.NOZORDER;

		// Token: 0x0400007C RID: 124
		private readonly List<KeyValuePair<WM, MessageHandler>> _messageTable;

		// Token: 0x0400007D RID: 125
		private Window _window;

		// Token: 0x0400007E RID: 126
		[SecurityCritical]
		private IntPtr _hwnd;

		// Token: 0x0400007F RID: 127
		[SecurityCritical]
		private HwndSource _hwndSource;

		// Token: 0x04000080 RID: 128
		private bool _isHooked;

		// Token: 0x04000081 RID: 129
		private bool _isFixedUp;

		// Token: 0x04000082 RID: 130
		private bool _isUserResizing;

		// Token: 0x04000083 RID: 131
		private bool _hasUserMovedWindow;

		// Token: 0x04000084 RID: 132
		private Point _windowPosAtStartOfUserMove;

		// Token: 0x04000085 RID: 133
		private WindowChrome _chromeInfo;

		// Token: 0x04000086 RID: 134
		private WindowState _lastRoundingState;

		// Token: 0x04000087 RID: 135
		private WindowState _lastMenuState;

		// Token: 0x04000088 RID: 136
		private bool _isGlassEnabled;

		// Token: 0x04000089 RID: 137
		private WINDOWPOS _previousWP;

		// Token: 0x0400008A RID: 138
		public static readonly DependencyProperty WindowChromeWorkerProperty = DependencyProperty.RegisterAttached("WindowChromeWorker", typeof(WindowChromeWorker), typeof(WindowChromeWorker), new PropertyMetadata(null, new PropertyChangedCallback(WindowChromeWorker._OnChromeWorkerChanged)));

		// Token: 0x0400008B RID: 139
		private static readonly HT[,] _HitTestBorders = new HT[,]
		{
			{
				HT.TOPLEFT,
				HT.TOP,
				HT.TOPRIGHT
			},
			{
				HT.LEFT,
				HT.CLIENT,
				HT.RIGHT
			},
			{
				HT.BOTTOMLEFT,
				HT.BOTTOM,
				HT.BOTTOMRIGHT
			}
		};

		// Token: 0x020000CE RID: 206
		// (Invoke) Token: 0x0600043A RID: 1082
		private delegate void _Action();
	}
}
