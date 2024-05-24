using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Windows.Threading;
using ControlzEx.Native;
using ControlzEx.Standard;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B6 RID: 182
	public class GlowWindowBehavior : Behavior<Window>
	{
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x000262E8 File Offset: 0x000244E8
		private bool IsGlowDisabled
		{
			get
			{
				MetroWindow metroWindow = base.AssociatedObject as MetroWindow;
				return metroWindow != null && metroWindow.GlowBrush == null;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00026310 File Offset: 0x00024510
		private bool IsWindowTransitionsEnabled
		{
			get
			{
				MetroWindow metroWindow = base.AssociatedObject as MetroWindow;
				return metroWindow != null && metroWindow.WindowTransitionsEnabled;
			}
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00026334 File Offset: 0x00024534
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.SourceInitialized += delegate(object o, EventArgs args)
			{
				this.handle = new WindowInteropHelper(base.AssociatedObject).Handle;
				this.hwndSource = HwndSource.FromHwnd(this.handle);
				HwndSource hwndSource = this.hwndSource;
				if (hwndSource == null)
				{
					return;
				}
				hwndSource.AddHook(new HwndSourceHook(this.AssociatedObjectWindowProc));
			};
			base.AssociatedObject.Loaded += this.AssociatedObjectOnLoaded;
			base.AssociatedObject.Unloaded += this.AssociatedObjectUnloaded;
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0002638C File Offset: 0x0002458C
		private void AssociatedObjectStateChanged(object sender, EventArgs e)
		{
			DispatcherTimer dispatcherTimer = this.makeGlowVisibleTimer;
			if (dispatcherTimer != null)
			{
				dispatcherTimer.Stop();
			}
			if (base.AssociatedObject.WindowState != WindowState.Normal)
			{
				this.HideGlow();
				return;
			}
			MetroWindow metroWindow = base.AssociatedObject as MetroWindow;
			bool flag = metroWindow != null && metroWindow.IgnoreTaskbarOnMaximize;
			if (this.makeGlowVisibleTimer != null && SystemParameters.MinimizeAnimation && !flag)
			{
				this.makeGlowVisibleTimer.Start();
				return;
			}
			this.RestoreGlow();
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000263FB File Offset: 0x000245FB
		private void AssociatedObjectUnloaded(object sender, RoutedEventArgs e)
		{
			if (this.makeGlowVisibleTimer == null)
			{
				return;
			}
			this.makeGlowVisibleTimer.Stop();
			this.makeGlowVisibleTimer.Tick -= this.GlowVisibleTimerOnTick;
			this.makeGlowVisibleTimer = null;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0002642F File Offset: 0x0002462F
		private void GlowVisibleTimerOnTick(object sender, EventArgs e)
		{
			DispatcherTimer dispatcherTimer = this.makeGlowVisibleTimer;
			if (dispatcherTimer != null)
			{
				dispatcherTimer.Stop();
			}
			this.RestoreGlow();
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x00026448 File Offset: 0x00024648
		private void RestoreGlow()
		{
			if (this.left != null)
			{
				this.left.IsGlowing = true;
			}
			if (this.top != null)
			{
				this.top.IsGlowing = true;
			}
			if (this.right != null)
			{
				this.right.IsGlowing = true;
			}
			if (this.bottom != null)
			{
				this.bottom.IsGlowing = true;
			}
			this.Update();
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x000264AC File Offset: 0x000246AC
		private void HideGlow()
		{
			if (this.left != null)
			{
				this.left.IsGlowing = false;
			}
			if (this.top != null)
			{
				this.top.IsGlowing = false;
			}
			if (this.right != null)
			{
				this.right.IsGlowing = false;
			}
			if (this.bottom != null)
			{
				this.bottom.IsGlowing = false;
			}
			this.Update();
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00026510 File Offset: 0x00024710
		private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			if (this.IsGlowDisabled)
			{
				return;
			}
			base.AssociatedObject.StateChanged -= this.AssociatedObjectStateChanged;
			base.AssociatedObject.StateChanged += this.AssociatedObjectStateChanged;
			if (this.makeGlowVisibleTimer == null)
			{
				this.makeGlowVisibleTimer = new DispatcherTimer
				{
					Interval = GlowWindowBehavior.GlowTimerDelay
				};
				this.makeGlowVisibleTimer.Tick += this.GlowVisibleTimerOnTick;
			}
			this.left = new GlowWindow(base.AssociatedObject, GlowDirection.Left);
			this.right = new GlowWindow(base.AssociatedObject, GlowDirection.Right);
			this.top = new GlowWindow(base.AssociatedObject, GlowDirection.Top);
			this.bottom = new GlowWindow(base.AssociatedObject, GlowDirection.Bottom);
			this.Show();
			this.Update();
			if (!this.IsWindowTransitionsEnabled)
			{
				base.AssociatedObject.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(delegate()
				{
					this.SetOpacityTo(1.0);
				}));
				return;
			}
			this.StartOpacityStoryboard();
			base.AssociatedObject.IsVisibleChanged += this.AssociatedObjectIsVisibleChanged;
			base.AssociatedObject.Closing += delegate(object o, CancelEventArgs args)
			{
				if (!args.Cancel)
				{
					base.AssociatedObject.IsVisibleChanged -= this.AssociatedObjectIsVisibleChanged;
				}
			};
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00026638 File Offset: 0x00024838
		private IntPtr AssociatedObjectWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			HwndSource hwndSource = this.hwndSource;
			if (((hwndSource != null) ? hwndSource.RootVisual : null) == null)
			{
				return IntPtr.Zero;
			}
			if (msg != 5)
			{
				if (msg - 70 <= 1)
				{
					WINDOWPOS windowpos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
					if (!windowpos.Equals(this.prevWindowPos))
					{
						this.UpdateCore();
					}
					this.prevWindowPos = windowpos;
					goto IL_77;
				}
				if (msg != 532)
				{
					goto IL_77;
				}
			}
			this.UpdateCore();
			IL_77:
			return IntPtr.Zero;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x000266C1 File Offset: 0x000248C1
		private void AssociatedObjectIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (!base.AssociatedObject.IsVisible)
			{
				this.SetOpacityTo(0.0);
				return;
			}
			this.StartOpacityStoryboard();
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x000266E8 File Offset: 0x000248E8
		private void Update()
		{
			if (this.left != null && this.right != null && this.top != null && this.bottom != null)
			{
				this.left.Update();
				this.right.Update();
				this.top.Update();
				this.bottom.Update();
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00026748 File Offset: 0x00024948
		private void UpdateCore()
		{
			RECT rect;
			if (this.left != null && this.right != null && this.top != null && this.bottom != null && this.left.CanUpdateCore() && this.right.CanUpdateCore() && this.top.CanUpdateCore() && this.bottom.CanUpdateCore() && this.handle != IntPtr.Zero && UnsafeNativeMethods.GetWindowRect(this.handle, out rect))
			{
				this.left.UpdateCore(rect);
				this.right.UpdateCore(rect);
				this.top.UpdateCore(rect);
				this.bottom.UpdateCore(rect);
			}
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00026800 File Offset: 0x00024A00
		private void SetOpacityTo(double newOpacity)
		{
			if (this.left != null && this.right != null && this.top != null && this.bottom != null)
			{
				this.left.Opacity = newOpacity;
				this.right.Opacity = newOpacity;
				this.top.Opacity = newOpacity;
				this.bottom.Opacity = newOpacity;
			}
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x00026864 File Offset: 0x00024A64
		private void StartOpacityStoryboard()
		{
			if (this.left != null && this.right != null && this.top != null && this.bottom != null && this.left.OpacityStoryboard != null && this.right.OpacityStoryboard != null && this.top.OpacityStoryboard != null && this.bottom.OpacityStoryboard != null)
			{
				this.left.BeginStoryboard(this.left.OpacityStoryboard);
				this.right.BeginStoryboard(this.right.OpacityStoryboard);
				this.top.BeginStoryboard(this.top.OpacityStoryboard);
				this.bottom.BeginStoryboard(this.bottom.OpacityStoryboard);
			}
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x00026924 File Offset: 0x00024B24
		private void Show()
		{
			GlowWindow glowWindow = this.left;
			if (glowWindow != null)
			{
				glowWindow.Show();
			}
			GlowWindow glowWindow2 = this.right;
			if (glowWindow2 != null)
			{
				glowWindow2.Show();
			}
			GlowWindow glowWindow3 = this.top;
			if (glowWindow3 != null)
			{
				glowWindow3.Show();
			}
			GlowWindow glowWindow4 = this.bottom;
			if (glowWindow4 == null)
			{
				return;
			}
			glowWindow4.Show();
		}

		// Token: 0x0400045D RID: 1117
		private static readonly TimeSpan GlowTimerDelay = TimeSpan.FromMilliseconds(200.0);

		// Token: 0x0400045E RID: 1118
		private GlowWindow left;

		// Token: 0x0400045F RID: 1119
		private GlowWindow right;

		// Token: 0x04000460 RID: 1120
		private GlowWindow top;

		// Token: 0x04000461 RID: 1121
		private GlowWindow bottom;

		// Token: 0x04000462 RID: 1122
		private DispatcherTimer makeGlowVisibleTimer;

		// Token: 0x04000463 RID: 1123
		private IntPtr handle;

		// Token: 0x04000464 RID: 1124
		private HwndSource hwndSource;

		// Token: 0x04000465 RID: 1125
		private WINDOWPOS prevWindowPos;
	}
}
