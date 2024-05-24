using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using ControlzEx;
using ControlzEx.Native;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000037 RID: 55
	public partial class GlowWindow : Window
	{
		// Token: 0x06000210 RID: 528 RVA: 0x00009CD4 File Offset: 0x00007ED4
		public GlowWindow(Window owner, GlowDirection direction)
		{
			this.InitializeComponent();
			base.Owner = owner;
			this._owner = owner;
			this.IsGlowing = true;
			base.AllowsTransparency = true;
			base.Closing += delegate(object sender, CancelEventArgs e)
			{
				e.Cancel = !this.closing;
			};
			base.ShowInTaskbar = false;
			this.glow.Visibility = Visibility.Collapsed;
			Binding binding = new Binding("GlowBrush");
			binding.Source = owner;
			this.glow.SetBinding(Glow.GlowBrushProperty, binding);
			binding = new Binding("NonActiveGlowBrush");
			binding.Source = owner;
			this.glow.SetBinding(Glow.NonActiveGlowBrushProperty, binding);
			binding = new Binding("BorderThickness");
			binding.Source = owner;
			this.glow.SetBinding(Control.BorderThicknessProperty, binding);
			this.glow.Direction = direction;
			switch (direction)
			{
			case GlowDirection.Left:
				this.glow.Orientation = Orientation.Vertical;
				this.glow.HorizontalAlignment = HorizontalAlignment.Right;
				this.getLeft = ((RECT rect) => (double)rect.Left - 6.0 + 1.0);
				this.getTop = ((RECT rect) => (double)(rect.Top - 2));
				this.getWidth = ((RECT rect) => 6.0);
				this.getHeight = ((RECT rect) => (double)(rect.Height + 4));
				this.getHitTestValue = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, (double)rect.Width, 20.0).Contains(p))
					{
						return HT.TOPLEFT;
					}
					if (!new Rect(0.0, (double)(rect.Height + 4) - 20.0, (double)rect.Width, 20.0).Contains(p))
					{
						return HT.LEFT;
					}
					return HT.BOTTOMLEFT;
				};
				this.getCursor = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, (double)rect.Width, 20.0).Contains(p))
					{
						return Cursors.SizeNWSE;
					}
					if (!new Rect(0.0, (double)(rect.Height + 4) - 20.0, (double)rect.Width, 20.0).Contains(p))
					{
						return Cursors.SizeWE;
					}
					return Cursors.SizeNESW;
				};
				break;
			case GlowDirection.Right:
				this.glow.Orientation = Orientation.Vertical;
				this.glow.HorizontalAlignment = HorizontalAlignment.Left;
				this.getLeft = ((RECT rect) => (double)(rect.Right - 1));
				this.getTop = ((RECT rect) => (double)(rect.Top - 2));
				this.getWidth = ((RECT rect) => 6.0);
				this.getHeight = ((RECT rect) => (double)(rect.Height + 4));
				this.getHitTestValue = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, (double)rect.Width, 20.0).Contains(p))
					{
						return HT.TOPRIGHT;
					}
					if (!new Rect(0.0, (double)(rect.Height + 4) - 20.0, (double)rect.Width, 20.0).Contains(p))
					{
						return HT.RIGHT;
					}
					return HT.BOTTOMRIGHT;
				};
				this.getCursor = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, (double)rect.Width, 20.0).Contains(p))
					{
						return Cursors.SizeNESW;
					}
					if (!new Rect(0.0, (double)(rect.Height + 4) - 20.0, (double)rect.Width, 20.0).Contains(p))
					{
						return Cursors.SizeWE;
					}
					return Cursors.SizeNWSE;
				};
				break;
			case GlowDirection.Top:
				base.PreviewMouseDoubleClick += delegate(object sender, MouseButtonEventArgs e)
				{
					if (this.ownerHandle != IntPtr.Zero)
					{
						NativeMethods.SendMessage(this.ownerHandle, WM.NCLBUTTONDBLCLK, (IntPtr)12, IntPtr.Zero);
					}
				};
				this.glow.Orientation = Orientation.Horizontal;
				this.glow.VerticalAlignment = VerticalAlignment.Bottom;
				this.getLeft = ((RECT rect) => (double)(rect.Left - 2));
				this.getTop = ((RECT rect) => (double)rect.Top - 6.0 + 1.0);
				this.getWidth = ((RECT rect) => (double)(rect.Width + 4));
				this.getHeight = ((RECT rect) => 6.0);
				this.getHitTestValue = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return HT.TOPLEFT;
					}
					if (!new Rect((double)(rect.Width + 4) - 20.0 + 6.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return HT.TOP;
					}
					return HT.TOPRIGHT;
				};
				this.getCursor = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return Cursors.SizeNWSE;
					}
					if (!new Rect((double)(rect.Width + 4) - 20.0 + 6.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return Cursors.SizeNS;
					}
					return Cursors.SizeNESW;
				};
				break;
			case GlowDirection.Bottom:
				base.PreviewMouseDoubleClick += delegate(object sender, MouseButtonEventArgs e)
				{
					if (this.ownerHandle != IntPtr.Zero)
					{
						NativeMethods.SendMessage(this.ownerHandle, WM.NCLBUTTONDBLCLK, (IntPtr)15, IntPtr.Zero);
					}
				};
				this.glow.Orientation = Orientation.Horizontal;
				this.glow.VerticalAlignment = VerticalAlignment.Top;
				this.getLeft = ((RECT rect) => (double)(rect.Left - 2));
				this.getTop = ((RECT rect) => (double)(rect.Bottom - 1));
				this.getWidth = ((RECT rect) => (double)(rect.Width + 4));
				this.getHeight = ((RECT rect) => 6.0);
				this.getHitTestValue = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return HT.BOTTOMLEFT;
					}
					if (!new Rect((double)(rect.Width + 4) - 20.0 + 6.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return HT.BOTTOM;
					}
					return HT.BOTTOMRIGHT;
				};
				this.getCursor = delegate(Point p, RECT rect)
				{
					if (new Rect(0.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return Cursors.SizeNESW;
					}
					if (!new Rect((double)(rect.Width + 4) - 20.0 + 6.0, 0.0, 14.0, (double)rect.Height).Contains(p))
					{
						return Cursors.SizeNS;
					}
					return Cursors.SizeNWSE;
				};
				break;
			}
			owner.ContentRendered += delegate(object sender, EventArgs e)
			{
				this.glow.Visibility = Visibility.Visible;
			};
			owner.Activated += delegate(object sender, EventArgs e)
			{
				this.Update();
				this.glow.IsGlow = true;
			};
			owner.Deactivated += delegate(object sender, EventArgs e)
			{
				this.glow.IsGlow = false;
			};
			owner.StateChanged += delegate(object sender, EventArgs e)
			{
				this.Update();
			};
			owner.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
			{
				this.Update();
			};
			owner.Closed += delegate(object sender, EventArgs e)
			{
				this.closing = true;
				base.Close();
			};
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000A238 File Offset: 0x00008438
		// (set) Token: 0x06000212 RID: 530 RVA: 0x0000A240 File Offset: 0x00008440
		public Storyboard OpacityStoryboard { get; set; }

		// Token: 0x06000213 RID: 531 RVA: 0x0000A249 File Offset: 0x00008449
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.OpacityStoryboard = (base.TryFindResource("OpacityStoryboard") as Storyboard);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000A268 File Offset: 0x00008468
		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			this.hwndSource = (HwndSource)PresentationSource.FromVisual(this);
			if (this.hwndSource == null)
			{
				return;
			}
			WS ws = NativeMethods.GetWindowStyle(this.hwndSource.Handle);
			WS_EX ws_EX = NativeMethods.GetWindowStyleEx(this.hwndSource.Handle);
			ws |= (WS)2147483648U;
			ws_EX &= ~WS_EX.APPWINDOW;
			ws_EX |= WS_EX.TOOLWINDOW;
			if (this._owner.ResizeMode == ResizeMode.NoResize || this._owner.ResizeMode == ResizeMode.CanMinimize)
			{
				ws_EX |= WS_EX.TRANSPARENT;
			}
			NativeMethods.SetWindowStyle(this.hwndSource.Handle, ws);
			NativeMethods.SetWindowStyleEx(this.hwndSource.Handle, ws_EX);
			this.hwndSource.AddHook(new HwndSourceHook(this.WndProc));
			this.handle = this.hwndSource.Handle;
			this.ownerHandle = new WindowInteropHelper(this._owner).Handle;
			this.resizeModeChangeNotifier = new PropertyChangeNotifier(this._owner, Window.ResizeModeProperty);
			this.resizeModeChangeNotifier.ValueChanged += this.ResizeModeChanged;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000A380 File Offset: 0x00008580
		private void ResizeModeChanged(object sender, EventArgs e)
		{
			WS_EX ws_EX = NativeMethods.GetWindowStyleEx(this.hwndSource.Handle);
			if (this._owner.ResizeMode == ResizeMode.NoResize || this._owner.ResizeMode == ResizeMode.CanMinimize)
			{
				ws_EX |= WS_EX.TRANSPARENT;
			}
			else
			{
				ws_EX ^= WS_EX.TRANSPARENT;
			}
			NativeMethods.SetWindowStyleEx(this.hwndSource.Handle, ws_EX);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000A3D8 File Offset: 0x000085D8
		public void Update()
		{
			if (this.closing)
			{
				return;
			}
			if (this._owner.Visibility == Visibility.Hidden)
			{
				this.Invoke(() => this.glow.Visibility = Visibility.Collapsed);
				this.Invoke(() => base.Visibility = Visibility.Collapsed);
				RECT rect;
				if (this.IsGlowing && this.ownerHandle != IntPtr.Zero && UnsafeNativeMethods.GetWindowRect(this.ownerHandle, out rect))
				{
					this.UpdateCore(rect);
					return;
				}
			}
			else if (this._owner.WindowState == WindowState.Normal)
			{
				this.Invoke(() => this.glow.Visibility = (this.IsGlowing ? Visibility.Visible : Visibility.Collapsed));
				this.Invoke(() => base.Visibility = (this.IsGlowing ? Visibility.Visible : Visibility.Collapsed));
				RECT rect;
				if (this.IsGlowing && this.ownerHandle != IntPtr.Zero && UnsafeNativeMethods.GetWindowRect(this.ownerHandle, out rect))
				{
					this.UpdateCore(rect);
					return;
				}
			}
			else
			{
				this.Invoke(() => this.glow.Visibility = Visibility.Collapsed);
				this.Invoke(() => base.Visibility = Visibility.Collapsed);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000218 RID: 536 RVA: 0x0000A4EF File Offset: 0x000086EF
		// (set) Token: 0x06000217 RID: 535 RVA: 0x0000A4E6 File Offset: 0x000086E6
		public bool IsGlowing { get; set; }

		// Token: 0x06000219 RID: 537 RVA: 0x0000A4F7 File Offset: 0x000086F7
		internal bool CanUpdateCore()
		{
			return this.ownerHandle != IntPtr.Zero && this.handle != IntPtr.Zero;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000A520 File Offset: 0x00008720
		internal void UpdateCore(RECT rect)
		{
			NativeMethods.SetWindowPos(this.handle, this.ownerHandle, (int)this.getLeft(rect), (int)this.getTop(rect), (int)this.getWidth(rect), (int)this.getHeight(rect), SWP.NOACTIVATE | SWP.NOZORDER);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000A574 File Offset: 0x00008774
		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg <= 33)
			{
				if (msg != 24)
				{
					if (msg == 33)
					{
						handled = true;
						if (this.ownerHandle != IntPtr.Zero)
						{
							NativeMethods.SendMessage(this.ownerHandle, WM.ACTIVATE, wParam, lParam);
						}
						return new IntPtr(3);
					}
				}
				else if ((int)lParam == 3 && base.Visibility != Visibility.Visible)
				{
					handled = true;
				}
			}
			else if (msg != 132)
			{
				if (msg == 513)
				{
					RECT arg;
					Point arg2;
					if (this.ownerHandle != IntPtr.Zero && UnsafeNativeMethods.GetWindowRect(this.ownerHandle, out arg) && WinApiHelper.TryGetRelativeMousePosition(this.handle, out arg2))
					{
						NativeMethods.PostMessage(this.ownerHandle, WM.NCLBUTTONDOWN, (IntPtr)((int)this.getHitTestValue(arg2, arg)), IntPtr.Zero);
					}
				}
			}
			else
			{
				Cursor cursor = null;
				RECT arg;
				Point arg3;
				if (this._owner.ResizeMode == ResizeMode.NoResize || this._owner.ResizeMode == ResizeMode.CanMinimize)
				{
					cursor = this._owner.Cursor;
				}
				else if (this.ownerHandle != IntPtr.Zero && UnsafeNativeMethods.GetWindowRect(this.ownerHandle, out arg) && WinApiHelper.TryGetRelativeMousePosition(this.handle, out arg3))
				{
					cursor = this.getCursor(arg3, arg);
				}
				if (cursor != null && cursor != base.Cursor)
				{
					base.Cursor = cursor;
				}
			}
			return IntPtr.Zero;
		}

		// Token: 0x040000BC RID: 188
		private readonly Func<Point, RECT, Cursor> getCursor;

		// Token: 0x040000BD RID: 189
		private readonly Func<Point, RECT, HT> getHitTestValue;

		// Token: 0x040000BE RID: 190
		private readonly Func<RECT, double> getLeft;

		// Token: 0x040000BF RID: 191
		private readonly Func<RECT, double> getTop;

		// Token: 0x040000C0 RID: 192
		private readonly Func<RECT, double> getWidth;

		// Token: 0x040000C1 RID: 193
		private readonly Func<RECT, double> getHeight;

		// Token: 0x040000C2 RID: 194
		private const double edgeSize = 20.0;

		// Token: 0x040000C3 RID: 195
		private const double glowSize = 6.0;

		// Token: 0x040000C4 RID: 196
		private IntPtr handle;

		// Token: 0x040000C5 RID: 197
		private IntPtr ownerHandle;

		// Token: 0x040000C6 RID: 198
		private bool closing;

		// Token: 0x040000C7 RID: 199
		private HwndSource hwndSource;

		// Token: 0x040000C8 RID: 200
		private PropertyChangeNotifier resizeModeChangeNotifier;

		// Token: 0x040000C9 RID: 201
		private Window _owner;
	}
}
