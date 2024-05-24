using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Media;
using ControlzEx.Standard;

namespace ControlzEx.Windows.Shell
{
	// Token: 0x02000010 RID: 16
	internal class SystemParameters2 : INotifyPropertyChanged
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000389C File Offset: 0x00001A9C
		private void _InitializeIsGlassEnabled()
		{
			this.IsGlassEnabled = NativeMethods.DwmIsCompositionEnabled();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000038A9 File Offset: 0x00001AA9
		private void _UpdateIsGlassEnabled(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeIsGlassEnabled();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000038B4 File Offset: 0x00001AB4
		private void _InitializeGlassColor()
		{
			uint num;
			bool flag;
			NativeMethods.DwmGetColorizationColor(out num, out flag);
			num |= (flag ? 4278190080U : 0U);
			this.WindowGlassColor = Utility.ColorFromArgbDword(num);
			SolidColorBrush solidColorBrush = new SolidColorBrush(this.WindowGlassColor);
			solidColorBrush.Freeze();
			this.WindowGlassBrush = solidColorBrush;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003900 File Offset: 0x00001B00
		private void _UpdateGlassColor(IntPtr wParam, IntPtr lParam)
		{
			bool flag = lParam != IntPtr.Zero;
			uint num = (uint)((int)wParam.ToInt64());
			num |= (flag ? 4278190080U : 0U);
			this.WindowGlassColor = Utility.ColorFromArgbDword(num);
			SolidColorBrush solidColorBrush = new SolidColorBrush(this.WindowGlassColor);
			solidColorBrush.Freeze();
			this.WindowGlassBrush = solidColorBrush;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003958 File Offset: 0x00001B58
		private void _InitializeCaptionHeight()
		{
			Point devicePoint = new Point(0.0, (double)NativeMethods.GetSystemMetrics(SM.CYCAPTION));
			this.WindowCaptionHeight = DpiHelper.DevicePixelsToLogical(devicePoint, (double)SystemParameters2.DpiX / 96.0, (double)SystemParameters2.Dpi / 96.0).Y;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000039B0 File Offset: 0x00001BB0
		private void _UpdateCaptionHeight(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeCaptionHeight();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000039B8 File Offset: 0x00001BB8
		private void _InitializeWindowResizeBorderThickness()
		{
			Size size = DpiHelper.DeviceSizeToLogical(new Size((double)NativeMethods.GetSystemMetrics(SM.CXFRAME), (double)NativeMethods.GetSystemMetrics(SM.CYFRAME)), (double)SystemParameters2.DpiX / 96.0, (double)SystemParameters2.Dpi / 96.0);
			this.WindowResizeBorderThickness = new Thickness(size.Width, size.Height, size.Width, size.Height);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003A27 File Offset: 0x00001C27
		private void _UpdateWindowResizeBorderThickness(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeWindowResizeBorderThickness();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003A30 File Offset: 0x00001C30
		private void _InitializeWindowNonClientFrameThickness()
		{
			Size size = DpiHelper.DeviceSizeToLogical(new Size((double)NativeMethods.GetSystemMetrics(SM.CXFRAME), (double)NativeMethods.GetSystemMetrics(SM.CYFRAME)), (double)SystemParameters2.DpiX / 96.0, (double)SystemParameters2.Dpi / 96.0);
			int systemMetrics = NativeMethods.GetSystemMetrics(SM.CYCAPTION);
			double y = DpiHelper.DevicePixelsToLogical(new Point(0.0, (double)systemMetrics), (double)SystemParameters2.DpiX / 96.0, (double)SystemParameters2.Dpi / 96.0).Y;
			this.WindowNonClientFrameThickness = new Thickness(size.Width, size.Height + y, size.Width, size.Height);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003AE6 File Offset: 0x00001CE6
		private void _UpdateWindowNonClientFrameThickness(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeWindowNonClientFrameThickness();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003AEE File Offset: 0x00001CEE
		private void _InitializeSmallIconSize()
		{
			this.SmallIconSize = new Size((double)NativeMethods.GetSystemMetrics(SM.CXSMICON), (double)NativeMethods.GetSystemMetrics(SM.CYSMICON));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003B0B File Offset: 0x00001D0B
		private void _UpdateSmallIconSize(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeSmallIconSize();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003B14 File Offset: 0x00001D14
		private void _LegacyInitializeCaptionButtonLocation()
		{
			int systemMetrics = NativeMethods.GetSystemMetrics(SM.CXSIZE);
			int systemMetrics2 = NativeMethods.GetSystemMetrics(SM.CYSIZE);
			int num = NativeMethods.GetSystemMetrics(SM.CXFRAME) + NativeMethods.GetSystemMetrics(SM.CXEDGE);
			int num2 = NativeMethods.GetSystemMetrics(SM.CYFRAME) + NativeMethods.GetSystemMetrics(SM.CYEDGE);
			Rect windowCaptionButtonsLocation = new Rect(0.0, 0.0, (double)(systemMetrics * 3), (double)systemMetrics2);
			windowCaptionButtonsLocation.Offset((double)(-(double)num) - windowCaptionButtonsLocation.Width, (double)num2);
			this.WindowCaptionButtonsLocation = windowCaptionButtonsLocation;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003B8C File Offset: 0x00001D8C
		private void _InitializeCaptionButtonLocation()
		{
			if (!Utility.IsOSVistaOrNewer || !NativeMethods.IsThemeActive())
			{
				this._LegacyInitializeCaptionButtonLocation();
				return;
			}
			TITLEBARINFOEX titlebarinfoex = new TITLEBARINFOEX
			{
				cbSize = Marshal.SizeOf(typeof(TITLEBARINFOEX))
			};
			IntPtr intPtr = Marshal.AllocHGlobal(titlebarinfoex.cbSize);
			try
			{
				Marshal.StructureToPtr<TITLEBARINFOEX>(titlebarinfoex, intPtr, false);
				NativeMethods.ShowWindow(this._messageHwnd.Handle, SW.SHOWNA);
				NativeMethods.SendMessage(this._messageHwnd.Handle, WM.GETTITLEBARINFOEX, IntPtr.Zero, intPtr);
				titlebarinfoex = (TITLEBARINFOEX)Marshal.PtrToStructure(intPtr, typeof(TITLEBARINFOEX));
			}
			finally
			{
				NativeMethods.ShowWindow(this._messageHwnd.Handle, SW.HIDE);
				Utility.SafeFreeHGlobal(ref intPtr);
			}
			RECT rect = RECT.Union(titlebarinfoex.rgrect_CloseButton, titlebarinfoex.rgrect_MinimizeButton);
			RECT windowRect = NativeMethods.GetWindowRect(this._messageHwnd.Handle);
			Rect windowCaptionButtonsLocation = DpiHelper.DeviceRectToLogical(new Rect((double)(rect.Left - windowRect.Width - windowRect.Left), (double)(rect.Top - windowRect.Top), (double)rect.Width, (double)rect.Height), (double)SystemParameters2.DpiX / 96.0, (double)SystemParameters2.Dpi / 96.0);
			this.WindowCaptionButtonsLocation = windowCaptionButtonsLocation;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003CE4 File Offset: 0x00001EE4
		private void _UpdateCaptionButtonLocation(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeCaptionButtonLocation();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003CEC File Offset: 0x00001EEC
		private void _InitializeHighContrast()
		{
			HIGHCONTRAST highcontrast = NativeMethods.SystemParameterInfo_GetHIGHCONTRAST();
			this.HighContrast = ((highcontrast.dwFlags & HCF.HIGHCONTRASTON) > (HCF)0);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003D10 File Offset: 0x00001F10
		private void _UpdateHighContrast(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeHighContrast();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003D18 File Offset: 0x00001F18
		private void _InitializeThemeInfo()
		{
			if (!NativeMethods.IsThemeActive())
			{
				this.UxThemeName = "Classic";
				this.UxThemeColor = "";
				return;
			}
			try
			{
				string path;
				string uxThemeColor;
				string text;
				NativeMethods.GetCurrentThemeName(out path, out uxThemeColor, out text);
				this.UxThemeName = Path.GetFileNameWithoutExtension(path);
				this.UxThemeColor = uxThemeColor;
			}
			catch (Exception)
			{
				this.UxThemeName = "Classic";
				this.UxThemeColor = "";
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003D90 File Offset: 0x00001F90
		private void _UpdateThemeInfo(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeThemeInfo();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003D98 File Offset: 0x00001F98
		private void _InitializeWindowCornerRadius()
		{
			CornerRadius windowCornerRadius = default(CornerRadius);
			string a = this.UxThemeName.ToUpperInvariant();
			if (!(a == "LUNA"))
			{
				if (!(a == "AERO"))
				{
					if (!(a == "CLASSIC") && !(a == "ZUNE") && !(a == "ROYALE"))
					{
					}
					windowCornerRadius = new CornerRadius(0.0);
				}
				else if (NativeMethods.DwmIsCompositionEnabled())
				{
					windowCornerRadius = new CornerRadius(8.0);
				}
				else
				{
					windowCornerRadius = new CornerRadius(6.0, 6.0, 0.0, 0.0);
				}
			}
			else
			{
				windowCornerRadius = new CornerRadius(6.0, 6.0, 0.0, 0.0);
			}
			this.WindowCornerRadius = windowCornerRadius;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003E8C File Offset: 0x0000208C
		private void _UpdateWindowCornerRadius(IntPtr wParam, IntPtr lParam)
		{
			this._InitializeWindowCornerRadius();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003E94 File Offset: 0x00002094
		private SystemParameters2()
		{
			this._messageHwnd = new MessageWindow((CS)0U, WS.DISABLED | WS.BORDER | WS.DLGFRAME | WS.SYSMENU | WS.THICKFRAME | WS.GROUP | WS.TABSTOP, WS_EX.None, new Rect(-16000.0, -16000.0, 100.0, 100.0), "", new WndProc(this._WndProc));
			this._messageHwnd.Dispatcher.ShutdownStarted += delegate(object sender, EventArgs e)
			{
				Utility.SafeDispose<MessageWindow>(ref this._messageHwnd);
			};
			this._InitializeIsGlassEnabled();
			this._InitializeGlassColor();
			this._InitializeCaptionHeight();
			this._InitializeWindowNonClientFrameThickness();
			this._InitializeWindowResizeBorderThickness();
			this._InitializeCaptionButtonLocation();
			this._InitializeSmallIconSize();
			this._InitializeHighContrast();
			this._InitializeThemeInfo();
			this._InitializeWindowCornerRadius();
			this._UpdateTable = new Dictionary<WM, List<SystemParameters2._SystemMetricUpdate>>
			{
				{
					WM.THEMECHANGED,
					new List<SystemParameters2._SystemMetricUpdate>
					{
						new SystemParameters2._SystemMetricUpdate(this._UpdateThemeInfo),
						new SystemParameters2._SystemMetricUpdate(this._UpdateHighContrast),
						new SystemParameters2._SystemMetricUpdate(this._UpdateWindowCornerRadius),
						new SystemParameters2._SystemMetricUpdate(this._UpdateCaptionButtonLocation)
					}
				},
				{
					WM.WININICHANGE,
					new List<SystemParameters2._SystemMetricUpdate>
					{
						new SystemParameters2._SystemMetricUpdate(this._UpdateCaptionHeight),
						new SystemParameters2._SystemMetricUpdate(this._UpdateWindowResizeBorderThickness),
						new SystemParameters2._SystemMetricUpdate(this._UpdateSmallIconSize),
						new SystemParameters2._SystemMetricUpdate(this._UpdateHighContrast),
						new SystemParameters2._SystemMetricUpdate(this._UpdateWindowNonClientFrameThickness),
						new SystemParameters2._SystemMetricUpdate(this._UpdateCaptionButtonLocation)
					}
				},
				{
					WM.DWMNCRENDERINGCHANGED,
					new List<SystemParameters2._SystemMetricUpdate>
					{
						new SystemParameters2._SystemMetricUpdate(this._UpdateIsGlassEnabled)
					}
				},
				{
					WM.DWMCOMPOSITIONCHANGED,
					new List<SystemParameters2._SystemMetricUpdate>
					{
						new SystemParameters2._SystemMetricUpdate(this._UpdateIsGlassEnabled)
					}
				},
				{
					WM.DWMCOLORIZATIONCOLORCHANGED,
					new List<SystemParameters2._SystemMetricUpdate>
					{
						new SystemParameters2._SystemMetricUpdate(this._UpdateGlassColor)
					}
				}
			};
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000408D File Offset: 0x0000228D
		public static SystemParameters2 Current
		{
			get
			{
				if (SystemParameters2._threadLocalSingleton == null)
				{
					SystemParameters2._threadLocalSingleton = new SystemParameters2();
				}
				return SystemParameters2._threadLocalSingleton;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000040A8 File Offset: 0x000022A8
		private IntPtr _WndProc(IntPtr hwnd, WM msg, IntPtr wParam, IntPtr lParam)
		{
			List<SystemParameters2._SystemMetricUpdate> list;
			if (this._UpdateTable != null && this._UpdateTable.TryGetValue(msg, out list))
			{
				foreach (SystemParameters2._SystemMetricUpdate systemMetricUpdate in list)
				{
					systemMetricUpdate(wParam, lParam);
				}
			}
			return NativeMethods.DefWindowProc(hwnd, msg, wParam, lParam);
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00004118 File Offset: 0x00002318
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x0000411F File Offset: 0x0000231F
		public bool IsGlassEnabled
		{
			get
			{
				return NativeMethods.DwmIsCompositionEnabled();
			}
			private set
			{
				if (value != this._isGlassEnabled)
				{
					this._isGlassEnabled = value;
					this._NotifyPropertyChanged("IsGlassEnabled");
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000413C File Offset: 0x0000233C
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00004144 File Offset: 0x00002344
		public Color WindowGlassColor
		{
			get
			{
				return this._glassColor;
			}
			private set
			{
				if (value != this._glassColor)
				{
					this._glassColor = value;
					this._NotifyPropertyChanged("WindowGlassColor");
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00004166 File Offset: 0x00002366
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x0000416E File Offset: 0x0000236E
		public SolidColorBrush WindowGlassBrush
		{
			get
			{
				return this._glassColorBrush;
			}
			private set
			{
				if (this._glassColorBrush == null || value.Color != this._glassColorBrush.Color)
				{
					this._glassColorBrush = value;
					this._NotifyPropertyChanged("WindowGlassBrush");
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000041A2 File Offset: 0x000023A2
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000041AA File Offset: 0x000023AA
		public Thickness WindowResizeBorderThickness
		{
			get
			{
				return this._windowResizeBorderThickness;
			}
			private set
			{
				if (value != this._windowResizeBorderThickness)
				{
					this._windowResizeBorderThickness = value;
					this._NotifyPropertyChanged("WindowResizeBorderThickness");
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000041CC File Offset: 0x000023CC
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000041D4 File Offset: 0x000023D4
		public Thickness WindowNonClientFrameThickness
		{
			get
			{
				return this._windowNonClientFrameThickness;
			}
			private set
			{
				if (value != this._windowNonClientFrameThickness)
				{
					this._windowNonClientFrameThickness = value;
					this._NotifyPropertyChanged("WindowNonClientFrameThickness");
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000041F6 File Offset: 0x000023F6
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000041FE File Offset: 0x000023FE
		public double WindowCaptionHeight
		{
			get
			{
				return this._captionHeight;
			}
			private set
			{
				if (value != this._captionHeight)
				{
					this._captionHeight = value;
					this._NotifyPropertyChanged("WindowCaptionHeight");
				}
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000421B File Offset: 0x0000241B
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00004238 File Offset: 0x00002438
		public Size SmallIconSize
		{
			get
			{
				return new Size(this._smallIconSize.Width, this._smallIconSize.Height);
			}
			private set
			{
				if (value != this._smallIconSize)
				{
					this._smallIconSize = value;
					this._NotifyPropertyChanged("SmallIconSize");
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000425A File Offset: 0x0000245A
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00004262 File Offset: 0x00002462
		public string UxThemeName
		{
			get
			{
				return this._uxThemeName;
			}
			private set
			{
				if (value != this._uxThemeName)
				{
					this._uxThemeName = value;
					this._NotifyPropertyChanged("UxThemeName");
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00004284 File Offset: 0x00002484
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000428C File Offset: 0x0000248C
		public string UxThemeColor
		{
			get
			{
				return this._uxThemeColor;
			}
			private set
			{
				if (value != this._uxThemeColor)
				{
					this._uxThemeColor = value;
					this._NotifyPropertyChanged("UxThemeColor");
				}
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000042AE File Offset: 0x000024AE
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000042B6 File Offset: 0x000024B6
		public bool HighContrast
		{
			get
			{
				return this._isHighContrast;
			}
			private set
			{
				if (value != this._isHighContrast)
				{
					this._isHighContrast = value;
					this._NotifyPropertyChanged("HighContrast");
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000042D3 File Offset: 0x000024D3
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x000042DB File Offset: 0x000024DB
		public CornerRadius WindowCornerRadius
		{
			get
			{
				return this._windowCornerRadius;
			}
			private set
			{
				if (value != this._windowCornerRadius)
				{
					this._windowCornerRadius = value;
					this._NotifyPropertyChanged("WindowCornerRadius");
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x000042FD File Offset: 0x000024FD
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00004305 File Offset: 0x00002505
		public Rect WindowCaptionButtonsLocation
		{
			get
			{
				return this._captionButtonLocation;
			}
			private set
			{
				if (value != this._captionButtonLocation)
				{
					this._captionButtonLocation = value;
					this._NotifyPropertyChanged("WindowCaptionButtonsLocation");
				}
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00004328 File Offset: 0x00002528
		internal static int Dpi
		{
			[SecurityCritical]
			[SecurityTreatAsSafe]
			get
			{
				if (!SystemParameters2._dpiInitialized)
				{
					object dpiLock = SystemParameters2._dpiLock;
					lock (dpiLock)
					{
						if (!SystemParameters2._dpiInitialized)
						{
							using (SafeDC desktop = SafeDC.GetDesktop())
							{
								if (desktop.DangerousGetHandle() == IntPtr.Zero)
								{
									throw new Win32Exception();
								}
								SystemParameters2._dpi = NativeMethods.GetDeviceCaps(desktop, DeviceCap.LOGPIXELSY);
								SystemParameters2._dpiInitialized = true;
							}
						}
					}
				}
				return SystemParameters2._dpi;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000043C0 File Offset: 0x000025C0
		internal static int DpiX
		{
			[SecurityCritical]
			[SecurityTreatAsSafe]
			get
			{
				if (SystemParameters2._setDpiX)
				{
					BitArray cacheValid = SystemParameters2._cacheValid;
					lock (cacheValid)
					{
						if (SystemParameters2._setDpiX)
						{
							SystemParameters2._setDpiX = false;
							using (SafeDC desktop = SafeDC.GetDesktop())
							{
								if (desktop.DangerousGetHandle() == IntPtr.Zero)
								{
									throw new Win32Exception();
								}
								SystemParameters2._dpiX = NativeMethods.GetDeviceCaps(desktop, DeviceCap.LOGPIXELSX);
								SystemParameters2._cacheValid[0] = true;
							}
						}
					}
				}
				return SystemParameters2._dpiX;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004464 File Offset: 0x00002664
		private void _NotifyPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000BB RID: 187 RVA: 0x00004488 File Offset: 0x00002688
		// (remove) Token: 0x060000BC RID: 188 RVA: 0x000044C0 File Offset: 0x000026C0
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x04000046 RID: 70
		[ThreadStatic]
		private static SystemParameters2 _threadLocalSingleton;

		// Token: 0x04000047 RID: 71
		private MessageWindow _messageHwnd;

		// Token: 0x04000048 RID: 72
		private bool _isGlassEnabled;

		// Token: 0x04000049 RID: 73
		private Color _glassColor;

		// Token: 0x0400004A RID: 74
		private SolidColorBrush _glassColorBrush;

		// Token: 0x0400004B RID: 75
		private Thickness _windowResizeBorderThickness;

		// Token: 0x0400004C RID: 76
		private Thickness _windowNonClientFrameThickness;

		// Token: 0x0400004D RID: 77
		private double _captionHeight;

		// Token: 0x0400004E RID: 78
		private Size _smallIconSize;

		// Token: 0x0400004F RID: 79
		private string _uxThemeName;

		// Token: 0x04000050 RID: 80
		private string _uxThemeColor;

		// Token: 0x04000051 RID: 81
		private bool _isHighContrast;

		// Token: 0x04000052 RID: 82
		private CornerRadius _windowCornerRadius;

		// Token: 0x04000053 RID: 83
		private Rect _captionButtonLocation;

		// Token: 0x04000054 RID: 84
		private readonly Dictionary<WM, List<SystemParameters2._SystemMetricUpdate>> _UpdateTable;

		// Token: 0x04000055 RID: 85
		private static int _dpi;

		// Token: 0x04000056 RID: 86
		private static bool _dpiInitialized;

		// Token: 0x04000057 RID: 87
		private static readonly object _dpiLock = new object();

		// Token: 0x04000058 RID: 88
		private static bool _setDpiX = true;

		// Token: 0x04000059 RID: 89
		private static BitArray _cacheValid = new BitArray(1);

		// Token: 0x0400005A RID: 90
		private static int _dpiX;

		// Token: 0x020000CA RID: 202
		// (Invoke) Token: 0x06000427 RID: 1063
		private delegate void _SystemMetricUpdate(IntPtr wParam, IntPtr lParam);

		// Token: 0x020000CB RID: 203
		private enum CacheSlot
		{
			// Token: 0x04000704 RID: 1796
			DpiX,
			// Token: 0x04000705 RID: 1797
			NumSlots
		}
	}
}
