using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace ControlzEx
{
	// Token: 0x02000008 RID: 8
	public class PopupEx : Popup
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000026DF File Offset: 0x000008DF
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000026F1 File Offset: 0x000008F1
		public bool CloseOnMouseLeftButtonDown
		{
			get
			{
				return (bool)base.GetValue(PopupEx.CloseOnMouseLeftButtonDownProperty);
			}
			set
			{
				base.SetValue(PopupEx.CloseOnMouseLeftButtonDownProperty, value);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002704 File Offset: 0x00000904
		public PopupEx()
		{
			base.Loaded += this.PopupEx_Loaded;
			base.Opened += this.PopupEx_Opened;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002730 File Offset: 0x00000930
		public void RefreshPosition()
		{
			double horizontalOffset = base.HorizontalOffset;
			base.SetCurrentValue(Popup.HorizontalOffsetProperty, horizontalOffset + 1.0);
			base.SetCurrentValue(Popup.HorizontalOffsetProperty, horizontalOffset);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002770 File Offset: 0x00000970
		private void PopupEx_Loaded(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = base.PlacementTarget as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			this.hostWindow = Window.GetWindow(frameworkElement);
			if (this.hostWindow == null)
			{
				return;
			}
			this.hostWindow.LocationChanged -= this.hostWindow_SizeOrLocationChanged;
			this.hostWindow.LocationChanged += this.hostWindow_SizeOrLocationChanged;
			this.hostWindow.SizeChanged -= new SizeChangedEventHandler(this.hostWindow_SizeOrLocationChanged);
			this.hostWindow.SizeChanged += new SizeChangedEventHandler(this.hostWindow_SizeOrLocationChanged);
			frameworkElement.SizeChanged -= new SizeChangedEventHandler(this.hostWindow_SizeOrLocationChanged);
			frameworkElement.SizeChanged += new SizeChangedEventHandler(this.hostWindow_SizeOrLocationChanged);
			this.hostWindow.StateChanged -= this.hostWindow_StateChanged;
			this.hostWindow.StateChanged += this.hostWindow_StateChanged;
			this.hostWindow.Activated -= this.hostWindow_Activated;
			this.hostWindow.Activated += this.hostWindow_Activated;
			this.hostWindow.Deactivated -= this.hostWindow_Deactivated;
			this.hostWindow.Deactivated += this.hostWindow_Deactivated;
			base.Unloaded -= this.PopupEx_Unloaded;
			base.Unloaded += this.PopupEx_Unloaded;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000028D0 File Offset: 0x00000AD0
		private void PopupEx_Opened(object sender, EventArgs e)
		{
			this.SetTopmostState(true);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000028D0 File Offset: 0x00000AD0
		private void hostWindow_Activated(object sender, EventArgs e)
		{
			this.SetTopmostState(true);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000028D9 File Offset: 0x00000AD9
		private void hostWindow_Deactivated(object sender, EventArgs e)
		{
			this.SetTopmostState(false);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000028E4 File Offset: 0x00000AE4
		private void PopupEx_Unloaded(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = base.PlacementTarget as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.SizeChanged -= new SizeChangedEventHandler(this.hostWindow_SizeOrLocationChanged);
			}
			if (this.hostWindow != null)
			{
				this.hostWindow.LocationChanged -= this.hostWindow_SizeOrLocationChanged;
				this.hostWindow.SizeChanged -= new SizeChangedEventHandler(this.hostWindow_SizeOrLocationChanged);
				this.hostWindow.StateChanged -= this.hostWindow_StateChanged;
				this.hostWindow.Activated -= this.hostWindow_Activated;
				this.hostWindow.Deactivated -= this.hostWindow_Deactivated;
			}
			base.Unloaded -= this.PopupEx_Unloaded;
			base.Opened -= this.PopupEx_Opened;
			this.hostWindow = null;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000029B8 File Offset: 0x00000BB8
		private void hostWindow_StateChanged(object sender, EventArgs e)
		{
			if (this.hostWindow != null && this.hostWindow.WindowState != WindowState.Minimized)
			{
				FrameworkElement frameworkElement = base.PlacementTarget as FrameworkElement;
				AdornedElementPlaceholder adornedElementPlaceholder = (frameworkElement != null) ? (frameworkElement.DataContext as AdornedElementPlaceholder) : null;
				if (adornedElementPlaceholder != null && adornedElementPlaceholder.AdornedElement != null)
				{
					base.PopupAnimation = PopupAnimation.None;
					base.IsOpen = false;
					object value = adornedElementPlaceholder.AdornedElement.GetValue(Validation.ErrorTemplateProperty);
					adornedElementPlaceholder.AdornedElement.SetValue(Validation.ErrorTemplateProperty, null);
					adornedElementPlaceholder.AdornedElement.SetValue(Validation.ErrorTemplateProperty, value);
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002A45 File Offset: 0x00000C45
		private void hostWindow_SizeOrLocationChanged(object sender, EventArgs e)
		{
			this.RefreshPosition();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002A50 File Offset: 0x00000C50
		private void SetTopmostState(bool isTop)
		{
			if (this.appliedTopMost != null && this.appliedTopMost == isTop)
			{
				return;
			}
			if (base.Child == null)
			{
				return;
			}
			HwndSource hwndSource = PresentationSource.FromVisual(base.Child) as HwndSource;
			if (hwndSource == null)
			{
				return;
			}
			IntPtr handle = hwndSource.Handle;
			PopupEx.RECT rect;
			if (!PopupEx.GetWindowRect(handle, out rect))
			{
				return;
			}
			int left = rect.Left;
			int top = rect.Top;
			int width = rect.Width;
			int height = rect.Height;
			if (isTop)
			{
				PopupEx.SetWindowPos(handle, PopupEx.HWND_TOPMOST, left, top, width, height, PopupEx.SWP.TOPMOST);
			}
			else
			{
				PopupEx.SetWindowPos(handle, PopupEx.HWND_BOTTOM, left, top, width, height, PopupEx.SWP.TOPMOST);
				PopupEx.SetWindowPos(handle, PopupEx.HWND_TOP, left, top, width, height, PopupEx.SWP.TOPMOST);
				PopupEx.SetWindowPos(handle, PopupEx.HWND_NOTOPMOST, left, top, width, height, PopupEx.SWP.TOPMOST);
			}
			this.appliedTopMost = new bool?(isTop);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002B51 File Offset: 0x00000D51
		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (this.CloseOnMouseLeftButtonDown)
			{
				base.IsOpen = false;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002B62 File Offset: 0x00000D62
		internal static int LOWORD(int i)
		{
			return (int)((short)(i & 65535));
		}

		// Token: 0x06000036 RID: 54
		[SecurityCritical]
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowRect(IntPtr hWnd, out PopupEx.RECT lpRect);

		// Token: 0x06000037 RID: 55
		[SecurityCritical]
		[DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool _SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, PopupEx.SWP uFlags);

		// Token: 0x06000038 RID: 56 RVA: 0x00002B6C File Offset: 0x00000D6C
		[SecurityCritical]
		private static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, PopupEx.SWP uFlags)
		{
			return PopupEx._SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, uFlags);
		}

		// Token: 0x0400001D RID: 29
		public static readonly DependencyProperty CloseOnMouseLeftButtonDownProperty = DependencyProperty.Register("CloseOnMouseLeftButtonDown", typeof(bool), typeof(PopupEx), new PropertyMetadata(false));

		// Token: 0x0400001E RID: 30
		private Window hostWindow;

		// Token: 0x0400001F RID: 31
		private bool? appliedTopMost;

		// Token: 0x04000020 RID: 32
		private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

		// Token: 0x04000021 RID: 33
		private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

		// Token: 0x04000022 RID: 34
		private static readonly IntPtr HWND_TOP = new IntPtr(0);

		// Token: 0x04000023 RID: 35
		private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

		// Token: 0x020000C5 RID: 197
		[Flags]
		internal enum SWP
		{
			// Token: 0x040006DE RID: 1758
			ASYNCWINDOWPOS = 16384,
			// Token: 0x040006DF RID: 1759
			DEFERERASE = 8192,
			// Token: 0x040006E0 RID: 1760
			DRAWFRAME = 32,
			// Token: 0x040006E1 RID: 1761
			FRAMECHANGED = 32,
			// Token: 0x040006E2 RID: 1762
			HIDEWINDOW = 128,
			// Token: 0x040006E3 RID: 1763
			NOACTIVATE = 16,
			// Token: 0x040006E4 RID: 1764
			NOCOPYBITS = 256,
			// Token: 0x040006E5 RID: 1765
			NOMOVE = 2,
			// Token: 0x040006E6 RID: 1766
			NOOWNERZORDER = 512,
			// Token: 0x040006E7 RID: 1767
			NOREDRAW = 8,
			// Token: 0x040006E8 RID: 1768
			NOREPOSITION = 512,
			// Token: 0x040006E9 RID: 1769
			NOSENDCHANGING = 1024,
			// Token: 0x040006EA RID: 1770
			NOSIZE = 1,
			// Token: 0x040006EB RID: 1771
			NOZORDER = 4,
			// Token: 0x040006EC RID: 1772
			SHOWWINDOW = 64,
			// Token: 0x040006ED RID: 1773
			TOPMOST = 1563
		}

		// Token: 0x020000C6 RID: 198
		internal struct POINT
		{
			// Token: 0x040006EE RID: 1774
			public int x;

			// Token: 0x040006EF RID: 1775
			public int y;
		}

		// Token: 0x020000C7 RID: 199
		internal struct SIZE
		{
			// Token: 0x040006F0 RID: 1776
			public int cx;

			// Token: 0x040006F1 RID: 1777
			public int cy;
		}

		// Token: 0x020000C8 RID: 200
		internal struct RECT
		{
			// Token: 0x06000416 RID: 1046 RVA: 0x0000C1E8 File Offset: 0x0000A3E8
			public void Offset(int dx, int dy)
			{
				this._left += dx;
				this._top += dy;
				this._right += dx;
				this._bottom += dy;
			}

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000C222 File Offset: 0x0000A422
			// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000C22A File Offset: 0x0000A42A
			public int Left
			{
				get
				{
					return this._left;
				}
				set
				{
					this._left = value;
				}
			}

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000C233 File Offset: 0x0000A433
			// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000C23B File Offset: 0x0000A43B
			public int Right
			{
				get
				{
					return this._right;
				}
				set
				{
					this._right = value;
				}
			}

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000C244 File Offset: 0x0000A444
			// (set) Token: 0x0600041C RID: 1052 RVA: 0x0000C24C File Offset: 0x0000A44C
			public int Top
			{
				get
				{
					return this._top;
				}
				set
				{
					this._top = value;
				}
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000C255 File Offset: 0x0000A455
			// (set) Token: 0x0600041E RID: 1054 RVA: 0x0000C25D File Offset: 0x0000A45D
			public int Bottom
			{
				get
				{
					return this._bottom;
				}
				set
				{
					this._bottom = value;
				}
			}

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000C266 File Offset: 0x0000A466
			public int Width
			{
				get
				{
					return this._right - this._left;
				}
			}

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x06000420 RID: 1056 RVA: 0x0000C275 File Offset: 0x0000A475
			public int Height
			{
				get
				{
					return this._bottom - this._top;
				}
			}

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000C284 File Offset: 0x0000A484
			public PopupEx.POINT Position
			{
				get
				{
					return new PopupEx.POINT
					{
						x = this._left,
						y = this._top
					};
				}
			}

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x06000422 RID: 1058 RVA: 0x0000C2B4 File Offset: 0x0000A4B4
			public PopupEx.SIZE Size
			{
				get
				{
					return new PopupEx.SIZE
					{
						cx = this.Width,
						cy = this.Height
					};
				}
			}

			// Token: 0x06000423 RID: 1059 RVA: 0x0000C2E4 File Offset: 0x0000A4E4
			public static PopupEx.RECT Union(PopupEx.RECT rect1, PopupEx.RECT rect2)
			{
				return new PopupEx.RECT
				{
					Left = Math.Min(rect1.Left, rect2.Left),
					Top = Math.Min(rect1.Top, rect2.Top),
					Right = Math.Max(rect1.Right, rect2.Right),
					Bottom = Math.Max(rect1.Bottom, rect2.Bottom)
				};
			}

			// Token: 0x06000424 RID: 1060 RVA: 0x0000C364 File Offset: 0x0000A564
			public override bool Equals(object obj)
			{
				bool result;
				try
				{
					PopupEx.RECT rect = (PopupEx.RECT)obj;
					result = (rect._bottom == this._bottom && rect._left == this._left && rect._right == this._right && rect._top == this._top);
				}
				catch (InvalidCastException)
				{
					result = false;
				}
				return result;
			}

			// Token: 0x06000425 RID: 1061 RVA: 0x0000C3CC File Offset: 0x0000A5CC
			public override int GetHashCode()
			{
				return (this._left << 16 | PopupEx.LOWORD(this._right)) ^ (this._top << 16 | PopupEx.LOWORD(this._bottom));
			}

			// Token: 0x040006F2 RID: 1778
			private int _left;

			// Token: 0x040006F3 RID: 1779
			private int _top;

			// Token: 0x040006F4 RID: 1780
			private int _right;

			// Token: 0x040006F5 RID: 1781
			private int _bottom;
		}
	}
}
