using System;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using ControlzEx.Native;
using ControlzEx.Standard;
using ControlzEx.Windows.Shell;

namespace ControlzEx.Behaviors
{
	// Token: 0x020000C2 RID: 194
	public class WindowChromeBehavior : Behavior<Window>
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x0000B324 File Offset: 0x00009524
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x0000B336 File Offset: 0x00009536
		public Thickness ResizeBorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(WindowChromeBehavior.ResizeBorderThicknessProperty);
			}
			set
			{
				base.SetValue(WindowChromeBehavior.ResizeBorderThicknessProperty, value);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000B349 File Offset: 0x00009549
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000B35B File Offset: 0x0000955B
		public Thickness GlassFrameThickness
		{
			get
			{
				return (Thickness)base.GetValue(WindowChromeBehavior.GlassFrameThicknessProperty);
			}
			set
			{
				base.SetValue(WindowChromeBehavior.GlassFrameThicknessProperty, value);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0000B36E File Offset: 0x0000956E
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000B380 File Offset: 0x00009580
		public Brush GlowBrush
		{
			get
			{
				return (Brush)base.GetValue(WindowChromeBehavior.GlowBrushProperty);
			}
			set
			{
				base.SetValue(WindowChromeBehavior.GlowBrushProperty, value);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000B38E File Offset: 0x0000958E
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0000B3A0 File Offset: 0x000095A0
		public bool IgnoreTaskbarOnMaximize
		{
			get
			{
				return (bool)base.GetValue(WindowChromeBehavior.IgnoreTaskbarOnMaximizeProperty);
			}
			set
			{
				base.SetValue(WindowChromeBehavior.IgnoreTaskbarOnMaximizeProperty, value);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000B3B3 File Offset: 0x000095B3
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0000B3C5 File Offset: 0x000095C5
		public bool KeepBorderOnMaximize
		{
			get
			{
				return (bool)base.GetValue(WindowChromeBehavior.KeepBorderOnMaximizeProperty);
			}
			set
			{
				base.SetValue(WindowChromeBehavior.KeepBorderOnMaximizeProperty, value);
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000B3D8 File Offset: 0x000095D8
		private static bool IsWindows10OrHigher()
		{
			Version version = NtDll.RtlGetVersion();
			if (null == version)
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Caption, Version FROM Win32_OperatingSystem"))
				{
					ManagementObject managementObject = managementObjectSearcher.Get().OfType<ManagementObject>().FirstOrDefault<ManagementObject>();
					version = new Version((((managementObject != null) ? managementObject.GetPropertyValue("Version") : null) ?? "0.0.0.0").ToString());
				}
			}
			return version >= new Version(10, 0);
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000B460 File Offset: 0x00009660
		protected override void OnAttached()
		{
			this.isWindwos10OrHigher = WindowChromeBehavior.IsWindows10OrHigher();
			this.InitializeWindowChrome();
			if (base.AssociatedObject.AllowsTransparency && !base.AssociatedObject.IsLoaded && new WindowInteropHelper(base.AssociatedObject).Handle == IntPtr.Zero)
			{
				try
				{
					base.AssociatedObject.AllowsTransparency = false;
				}
				catch (Exception)
				{
				}
			}
			base.AssociatedObject.WindowStyle = WindowStyle.None;
			this.savedBorderThickness = new Thickness?(base.AssociatedObject.BorderThickness);
			this.borderThicknessChangeNotifier = new PropertyChangeNotifier(base.AssociatedObject, Control.BorderThicknessProperty);
			this.borderThicknessChangeNotifier.ValueChanged += this.BorderThicknessChangeNotifierOnValueChanged;
			this.savedResizeBorderThickness = new Thickness?(this.ResizeBorderThickness);
			this.resizeBorderThicknessChangeNotifier = new PropertyChangeNotifier(this, WindowChromeBehavior.ResizeBorderThicknessProperty);
			this.resizeBorderThicknessChangeNotifier.ValueChanged += this.ResizeBorderThicknessChangeNotifierOnValueChanged;
			this.savedTopMost = base.AssociatedObject.Topmost;
			this.topMostChangeNotifier = new PropertyChangeNotifier(base.AssociatedObject, Window.TopmostProperty);
			this.topMostChangeNotifier.ValueChanged += this.TopMostChangeNotifierOnValueChanged;
			base.AssociatedObject.SourceInitialized += this.AssociatedObject_SourceInitialized;
			base.AssociatedObject.Loaded += this.AssociatedObject_Loaded;
			base.AssociatedObject.Unloaded += this.AssociatedObject_Unloaded;
			base.AssociatedObject.Closed += this.AssociatedObject_Closed;
			base.AssociatedObject.StateChanged += this.AssociatedObject_StateChanged;
			base.AssociatedObject.LostFocus += this.AssociatedObject_LostFocus;
			base.AssociatedObject.Deactivated += this.AssociatedObject_Deactivated;
			base.OnAttached();
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000B644 File Offset: 0x00009844
		private void TopMostHack()
		{
			if (base.AssociatedObject.Topmost)
			{
				bool raiseValueChanged = this.topMostChangeNotifier.RaiseValueChanged;
				this.topMostChangeNotifier.RaiseValueChanged = false;
				base.AssociatedObject.Topmost = false;
				base.AssociatedObject.Topmost = true;
				this.topMostChangeNotifier.RaiseValueChanged = raiseValueChanged;
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000B69C File Offset: 0x0000989C
		private void InitializeWindowChrome()
		{
			this.windowChrome = new WindowChrome();
			BindingOperations.SetBinding(this.windowChrome, WindowChrome.ResizeBorderThicknessProperty, new Binding
			{
				Path = new PropertyPath(WindowChromeBehavior.ResizeBorderThicknessProperty),
				Source = this
			});
			BindingOperations.SetBinding(this.windowChrome, WindowChrome.GlassFrameThicknessProperty, new Binding
			{
				Path = new PropertyPath(WindowChromeBehavior.GlassFrameThicknessProperty),
				Source = this
			});
			this.windowChrome.CaptionHeight = 0.0;
			this.windowChrome.CornerRadius = default(CornerRadius);
			this.windowChrome.UseAeroCaptionButtons = false;
			base.AssociatedObject.SetValue(WindowChrome.WindowChromeProperty, this.windowChrome);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000B758 File Offset: 0x00009958
		public static Thickness GetDefaultResizeBorderThickness()
		{
			return SystemParameters.WindowResizeBorderThickness;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000B760 File Offset: 0x00009960
		private void BorderThicknessChangeNotifierOnValueChanged(object sender, EventArgs e)
		{
			Window associatedObject = base.AssociatedObject;
			if (associatedObject != null)
			{
				this.savedBorderThickness = new Thickness?(associatedObject.BorderThickness);
			}
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0000B788 File Offset: 0x00009988
		private void ResizeBorderThicknessChangeNotifierOnValueChanged(object sender, EventArgs e)
		{
			this.savedResizeBorderThickness = new Thickness?(this.ResizeBorderThickness);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000B79C File Offset: 0x0000999C
		private void TopMostChangeNotifierOnValueChanged(object sender, EventArgs e)
		{
			Window associatedObject = base.AssociatedObject;
			if (associatedObject != null)
			{
				this.savedTopMost = associatedObject.Topmost;
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0000B7C0 File Offset: 0x000099C0
		private static void OnGlassFrameThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			WindowChromeBehavior windowChromeBehavior = (WindowChromeBehavior)d;
			if (windowChromeBehavior.AssociatedObject == null)
			{
				return;
			}
			windowChromeBehavior.AssociatedObject.SetValue(WindowChrome.WindowChromeProperty, null);
			windowChromeBehavior.InitializeWindowChrome();
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000B7F4 File Offset: 0x000099F4
		private static void OnIgnoreTaskbarOnMaximizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			WindowChromeBehavior windowChromeBehavior = (WindowChromeBehavior)d;
			if (windowChromeBehavior.windowChrome != null && !object.Equals(windowChromeBehavior.windowChrome.IgnoreTaskbarOnMaximize, windowChromeBehavior.IgnoreTaskbarOnMaximize))
			{
				windowChromeBehavior.windowChrome.IgnoreTaskbarOnMaximize = windowChromeBehavior.IgnoreTaskbarOnMaximize;
				if (windowChromeBehavior.AssociatedObject.WindowState == WindowState.Maximized)
				{
					windowChromeBehavior.AssociatedObject.WindowState = WindowState.Normal;
					windowChromeBehavior.AssociatedObject.WindowState = WindowState.Maximized;
				}
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000B869 File Offset: 0x00009A69
		private static void OnKeepBorderOnMaximizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((WindowChromeBehavior)d).HandleMaximize();
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000B878 File Offset: 0x00009A78
		private void Cleanup()
		{
			if (!this.isCleanedUp)
			{
				this.isCleanedUp = true;
				if (this.taskbarHandle != IntPtr.Zero && this.isWindwos10OrHigher)
				{
					this.DeactivateTaskbarFix(this.taskbarHandle);
				}
				base.AssociatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
				base.AssociatedObject.Loaded -= this.AssociatedObject_Loaded;
				base.AssociatedObject.Unloaded -= this.AssociatedObject_Unloaded;
				base.AssociatedObject.Closed -= this.AssociatedObject_Closed;
				base.AssociatedObject.StateChanged -= this.AssociatedObject_StateChanged;
				base.AssociatedObject.LostFocus -= this.AssociatedObject_LostFocus;
				base.AssociatedObject.Deactivated -= this.AssociatedObject_Deactivated;
				HwndSource hwndSource = this.hwndSource;
				if (hwndSource != null)
				{
					hwndSource.RemoveHook(new HwndSourceHook(this.WindowProc));
				}
				this.windowChrome = null;
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000B983 File Offset: 0x00009B83
		protected override void OnDetaching()
		{
			this.Cleanup();
			base.OnDetaching();
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000B994 File Offset: 0x00009B94
		private void AssociatedObject_SourceInitialized(object sender, EventArgs e)
		{
			this.handle = new WindowInteropHelper(base.AssociatedObject).Handle;
			if (IntPtr.Zero == this.handle)
			{
				throw new Exception("Uups, at this point we really need the Handle from the associated object!");
			}
			if (base.AssociatedObject.SizeToContent != SizeToContent.Manual && base.AssociatedObject.WindowState == WindowState.Normal)
			{
				WindowChromeBehavior.Invoke(base.AssociatedObject, delegate
				{
					base.AssociatedObject.InvalidateMeasure();
					RECT rect;
					if (UnsafeNativeMethods.GetWindowRect(this.handle, out rect))
					{
						SWP swp = SWP.SHOWWINDOW;
						if (!base.AssociatedObject.ShowActivated)
						{
							swp |= SWP.NOACTIVATE;
						}
						NativeMethods.SetWindowPos(this.handle, Constants.HWND_NOTOPMOST, rect.Left, rect.Top, rect.Width, rect.Height, swp);
					}
				});
			}
			this.hwndSource = HwndSource.FromHwnd(this.handle);
			HwndSource hwndSource = this.hwndSource;
			if (hwndSource != null)
			{
				hwndSource.AddHook(new HwndSourceHook(this.WindowProc));
			}
			this.HandleMaximize();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00007247 File Offset: 0x00005447
		protected virtual void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000BA39 File Offset: 0x00009C39
		private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
		{
			this.Cleanup();
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000BA39 File Offset: 0x00009C39
		private void AssociatedObject_Closed(object sender, EventArgs e)
		{
			this.Cleanup();
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000BA41 File Offset: 0x00009C41
		private void AssociatedObject_StateChanged(object sender, EventArgs e)
		{
			this.HandleMaximize();
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000BA49 File Offset: 0x00009C49
		private void AssociatedObject_Deactivated(object sender, EventArgs e)
		{
			this.TopMostHack();
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000BA49 File Offset: 0x00009C49
		private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
		{
			this.TopMostHack();
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000BA54 File Offset: 0x00009C54
		private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			IntPtr zero = IntPtr.Zero;
			if (msg != 70)
			{
				if (msg == 133)
				{
					handled = (this.GlassFrameThickness == default(Thickness) && this.GlowBrush == null);
				}
			}
			else
			{
				WINDOWPOS windowpos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
				if ((windowpos.flags & SWP.NOMOVE) != (SWP)0)
				{
					return IntPtr.Zero;
				}
				Window associatedObject = base.AssociatedObject;
				if (associatedObject != null)
				{
					HwndSource hwndSource = this.hwndSource;
					if (((hwndSource != null) ? hwndSource.CompositionTarget : null) != null)
					{
						bool flag = false;
						Matrix transformToDevice = this.hwndSource.CompositionTarget.TransformToDevice;
						double num = associatedObject.MinWidth * transformToDevice.M11;
						double num2 = associatedObject.MinHeight * transformToDevice.M22;
						if ((double)windowpos.cx < num)
						{
							windowpos.cx = (int)num;
							flag = true;
						}
						if ((double)windowpos.cy < num2)
						{
							windowpos.cy = (int)num2;
							flag = true;
						}
						double num3 = associatedObject.MaxWidth * transformToDevice.M11;
						double num4 = associatedObject.MaxHeight * transformToDevice.M22;
						if ((double)windowpos.cx > num3 && num3 > 0.0)
						{
							windowpos.cx = (int)Math.Round(num3);
							flag = true;
						}
						if ((double)windowpos.cy > num4 && num4 > 0.0)
						{
							windowpos.cy = (int)Math.Round(num4);
							flag = true;
						}
						if (!flag)
						{
							return IntPtr.Zero;
						}
						Marshal.StructureToPtr<WINDOWPOS>(windowpos, lParam, true);
						handled = true;
						return zero;
					}
				}
				return IntPtr.Zero;
			}
			return zero;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000BBE0 File Offset: 0x00009DE0
		private void HandleMaximize()
		{
			bool raiseValueChanged = this.topMostChangeNotifier.RaiseValueChanged;
			this.topMostChangeNotifier.RaiseValueChanged = false;
			this.HandleBorderAndResizeBorderThicknessDuringMaximize();
			if (base.AssociatedObject.WindowState == WindowState.Maximized)
			{
				if (this.handle != IntPtr.Zero)
				{
					IntPtr intPtr = UnsafeNativeMethods.MonitorFromWindow(this.handle, MonitorOptions.MONITOR_DEFAULTTONEAREST);
					if (intPtr != IntPtr.Zero)
					{
						MONITORINFO monitorInfo = NativeMethods.GetMonitorInfo(intPtr);
						RECT rect = this.IgnoreTaskbarOnMaximize ? monitorInfo.rcMonitor : monitorInfo.rcWork;
						int left = rect.Left;
						int top = rect.Top;
						int width = rect.Width;
						int height = rect.Height;
						if (this.IgnoreTaskbarOnMaximize && this.isWindwos10OrHigher)
						{
							this.ActivateTaskbarFix(intPtr);
						}
						NativeMethods.SetWindowPos(this.handle, Constants.HWND_NOTOPMOST, left, top, width, height, SWP.SHOWWINDOW);
					}
				}
			}
			else if (this.taskbarHandle != IntPtr.Zero && this.isWindwos10OrHigher)
			{
				this.DeactivateTaskbarFix(this.taskbarHandle);
			}
			base.AssociatedObject.Topmost = false;
			base.AssociatedObject.Topmost = (base.AssociatedObject.WindowState == WindowState.Minimized || this.savedTopMost);
			this.topMostChangeNotifier.RaiseValueChanged = raiseValueChanged;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000BD24 File Offset: 0x00009F24
		private void HandleBorderAndResizeBorderThicknessDuringMaximize()
		{
			this.borderThicknessChangeNotifier.RaiseValueChanged = false;
			this.resizeBorderThicknessChangeNotifier.RaiseValueChanged = false;
			if (base.AssociatedObject.WindowState == WindowState.Maximized)
			{
				IntPtr intPtr = IntPtr.Zero;
				if (this.handle != IntPtr.Zero)
				{
					intPtr = UnsafeNativeMethods.MonitorFromWindow(this.handle, MonitorOptions.MONITOR_DEFAULTTONEAREST);
				}
				if (intPtr != IntPtr.Zero)
				{
					MONITORINFO monitorInfo = NativeMethods.GetMonitorInfo(intPtr);
					RECT rect = this.IgnoreTaskbarOnMaximize ? monitorInfo.rcMonitor : monitorInfo.rcWork;
					double right = 0.0;
					double bottom = 0.0;
					if (this.KeepBorderOnMaximize && this.savedBorderThickness != null)
					{
						if (base.AssociatedObject.MaxWidth < (double)rect.Width)
						{
							right = this.savedBorderThickness.Value.Right;
						}
						if (base.AssociatedObject.MaxHeight < (double)rect.Height)
						{
							bottom = this.savedBorderThickness.Value.Bottom;
						}
					}
					base.AssociatedObject.BorderThickness = new Thickness(0.0, 0.0, right, bottom);
				}
				else
				{
					base.AssociatedObject.BorderThickness = new Thickness(0.0);
				}
				this.windowChrome.ResizeBorderThickness = new Thickness(0.0);
			}
			else
			{
				base.AssociatedObject.BorderThickness = this.savedBorderThickness.GetValueOrDefault(new Thickness(0.0));
				Thickness valueOrDefault = this.savedResizeBorderThickness.GetValueOrDefault(new Thickness(0.0));
				if (this.windowChrome.ResizeBorderThickness != valueOrDefault)
				{
					this.windowChrome.ResizeBorderThickness = valueOrDefault;
				}
			}
			this.borderThicknessChangeNotifier.RaiseValueChanged = true;
			this.resizeBorderThicknessChangeNotifier.RaiseValueChanged = true;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000BF00 File Offset: 0x0000A100
		private void ActivateTaskbarFix(IntPtr monitor)
		{
			IntPtr taskBarHandleForMonitor = NativeMethods.GetTaskBarHandleForMonitor(monitor);
			if (taskBarHandleForMonitor != IntPtr.Zero)
			{
				this.taskbarHandle = taskBarHandleForMonitor;
				NativeMethods.SetWindowPos(taskBarHandleForMonitor, Constants.HWND_BOTTOM, 0, 0, 0, 0, SWP.TOPMOST);
				NativeMethods.SetWindowPos(taskBarHandleForMonitor, Constants.HWND_TOP, 0, 0, 0, 0, SWP.TOPMOST);
				NativeMethods.SetWindowPos(taskBarHandleForMonitor, Constants.HWND_NOTOPMOST, 0, 0, 0, 0, SWP.TOPMOST);
			}
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000BF64 File Offset: 0x0000A164
		private void DeactivateTaskbarFix(IntPtr trayWndHandle)
		{
			if (trayWndHandle != IntPtr.Zero)
			{
				this.taskbarHandle = IntPtr.Zero;
				NativeMethods.SetWindowPos(trayWndHandle, Constants.HWND_BOTTOM, 0, 0, 0, 0, SWP.TOPMOST);
				NativeMethods.SetWindowPos(trayWndHandle, Constants.HWND_TOP, 0, 0, 0, 0, SWP.TOPMOST);
				NativeMethods.SetWindowPos(trayWndHandle, Constants.HWND_TOPMOST, 0, 0, 0, 0, SWP.TOPMOST);
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000BFC5 File Offset: 0x0000A1C5
		private static void Invoke(DispatcherObject dispatcherObject, Action invokeAction)
		{
			if (dispatcherObject == null)
			{
				throw new ArgumentNullException("dispatcherObject");
			}
			if (invokeAction == null)
			{
				throw new ArgumentNullException("invokeAction");
			}
			if (dispatcherObject.Dispatcher.CheckAccess())
			{
				invokeAction();
				return;
			}
			dispatcherObject.Dispatcher.Invoke(invokeAction);
		}

		// Token: 0x040006CA RID: 1738
		private IntPtr handle;

		// Token: 0x040006CB RID: 1739
		private HwndSource hwndSource;

		// Token: 0x040006CC RID: 1740
		private WindowChrome windowChrome;

		// Token: 0x040006CD RID: 1741
		private PropertyChangeNotifier topMostChangeNotifier;

		// Token: 0x040006CE RID: 1742
		private PropertyChangeNotifier borderThicknessChangeNotifier;

		// Token: 0x040006CF RID: 1743
		private PropertyChangeNotifier resizeBorderThicknessChangeNotifier;

		// Token: 0x040006D0 RID: 1744
		private Thickness? savedBorderThickness;

		// Token: 0x040006D1 RID: 1745
		private Thickness? savedResizeBorderThickness;

		// Token: 0x040006D2 RID: 1746
		private bool savedTopMost;

		// Token: 0x040006D3 RID: 1747
		private bool isWindwos10OrHigher;

		// Token: 0x040006D4 RID: 1748
		public static readonly DependencyProperty ResizeBorderThicknessProperty = DependencyProperty.Register("ResizeBorderThickness", typeof(Thickness), typeof(WindowChromeBehavior), new PropertyMetadata(WindowChromeBehavior.GetDefaultResizeBorderThickness()));

		// Token: 0x040006D5 RID: 1749
		public static readonly DependencyProperty GlassFrameThicknessProperty = DependencyProperty.Register("GlassFrameThickness", typeof(Thickness), typeof(WindowChromeBehavior), new PropertyMetadata(default(Thickness), new PropertyChangedCallback(WindowChromeBehavior.OnGlassFrameThicknessChanged)));

		// Token: 0x040006D6 RID: 1750
		public static readonly DependencyProperty GlowBrushProperty = DependencyProperty.Register("GlowBrush", typeof(Brush), typeof(WindowChromeBehavior), new PropertyMetadata());

		// Token: 0x040006D7 RID: 1751
		public static readonly DependencyProperty IgnoreTaskbarOnMaximizeProperty = DependencyProperty.Register("IgnoreTaskbarOnMaximize", typeof(bool), typeof(WindowChromeBehavior), new PropertyMetadata(false, new PropertyChangedCallback(WindowChromeBehavior.OnIgnoreTaskbarOnMaximizePropertyChanged)));

		// Token: 0x040006D8 RID: 1752
		public static readonly DependencyProperty KeepBorderOnMaximizeProperty = DependencyProperty.Register("KeepBorderOnMaximize", typeof(bool), typeof(WindowChromeBehavior), new PropertyMetadata(true, new PropertyChangedCallback(WindowChromeBehavior.OnKeepBorderOnMaximizeChanged)));

		// Token: 0x040006D9 RID: 1753
		private bool isCleanedUp;

		// Token: 0x040006DA RID: 1754
		private IntPtr taskbarHandle;
	}
}
