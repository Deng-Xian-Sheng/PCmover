using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using ControlzEx.Native;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200002B RID: 43
	public class CustomValidationPopup : Popup
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00005526 File Offset: 0x00003726
		public CustomValidationPopup()
		{
			base.Loaded += this.CustomValidationPopup_Loaded;
			base.Opened += this.CustomValidationPopup_Opened;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005552 File Offset: 0x00003752
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00005564 File Offset: 0x00003764
		public bool CloseOnMouseLeftButtonDown
		{
			get
			{
				return (bool)base.GetValue(CustomValidationPopup.CloseOnMouseLeftButtonDownProperty);
			}
			set
			{
				base.SetValue(CustomValidationPopup.CloseOnMouseLeftButtonDownProperty, value);
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005577 File Offset: 0x00003777
		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (this.CloseOnMouseLeftButtonDown)
			{
				base.SetCurrentValue(Popup.IsOpenProperty, false);
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00005594 File Offset: 0x00003794
		private void CustomValidationPopup_Loaded(object sender, RoutedEventArgs e)
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
			base.Unloaded -= this.CustomValidationPopup_Unloaded;
			base.Unloaded += this.CustomValidationPopup_Unloaded;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000056F4 File Offset: 0x000038F4
		private void CustomValidationPopup_Opened(object sender, EventArgs e)
		{
			this.SetTopmostState(true);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000056FD File Offset: 0x000038FD
		private void hostWindow_Activated(object sender, EventArgs e)
		{
			this.SetTopmostState(true);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005706 File Offset: 0x00003906
		private void hostWindow_Deactivated(object sender, EventArgs e)
		{
			this.SetTopmostState(false);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005710 File Offset: 0x00003910
		private void CustomValidationPopup_Unloaded(object sender, RoutedEventArgs e)
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
			base.Unloaded -= this.CustomValidationPopup_Unloaded;
			base.Opened -= this.CustomValidationPopup_Opened;
			this.hostWindow = null;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000057E4 File Offset: 0x000039E4
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

		// Token: 0x06000108 RID: 264 RVA: 0x00005874 File Offset: 0x00003A74
		private void hostWindow_SizeOrLocationChanged(object sender, EventArgs e)
		{
			double horizontalOffset = base.HorizontalOffset;
			base.HorizontalOffset = horizontalOffset + 1.0;
			base.HorizontalOffset = horizontalOffset;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000058A0 File Offset: 0x00003AA0
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
			RECT rect;
			if (!UnsafeNativeMethods.GetWindowRect(handle, out rect))
			{
				return;
			}
			int left = rect.Left;
			int top = rect.Top;
			int width = rect.Width;
			int height = rect.Height;
			if (isTop)
			{
				NativeMethods.SetWindowPos(handle, Constants.HWND_TOPMOST, left, top, width, height, SWP.TOPMOST);
			}
			else
			{
				NativeMethods.SetWindowPos(handle, Constants.HWND_BOTTOM, left, top, width, height, SWP.TOPMOST);
				NativeMethods.SetWindowPos(handle, Constants.HWND_TOP, left, top, width, height, SWP.TOPMOST);
				NativeMethods.SetWindowPos(handle, Constants.HWND_NOTOPMOST, left, top, width, height, SWP.TOPMOST);
			}
			this.appliedTopMost = new bool?(isTop);
		}

		// Token: 0x04000040 RID: 64
		public static readonly DependencyProperty CloseOnMouseLeftButtonDownProperty = DependencyProperty.Register("CloseOnMouseLeftButtonDown", typeof(bool), typeof(CustomValidationPopup), new PropertyMetadata(true));

		// Token: 0x04000041 RID: 65
		private Window hostWindow;

		// Token: 0x04000042 RID: 66
		private bool? appliedTopMost;
	}
}
