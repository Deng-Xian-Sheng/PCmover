using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000024 RID: 36
	public class GlassWindow : Window
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600012B RID: 299 RVA: 0x0000646C File Offset: 0x0000466C
		// (set) Token: 0x0600012A RID: 298 RVA: 0x0000645A File Offset: 0x0000465A
		public static bool AeroGlassCompositionEnabled
		{
			get
			{
				return DesktopWindowManagerNativeMethods.DwmIsCompositionEnabled();
			}
			set
			{
				DesktopWindowManagerNativeMethods.DwmEnableComposition(value ? CompositionEnable.Enable : CompositionEnable.Disable);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600012C RID: 300 RVA: 0x00006484 File Offset: 0x00004684
		// (remove) Token: 0x0600012D RID: 301 RVA: 0x000064C0 File Offset: 0x000046C0
		public event EventHandler<AeroGlassCompositionChangedEventArgs> AeroGlassCompositionChanged;

		// Token: 0x0600012E RID: 302 RVA: 0x000064FC File Offset: 0x000046FC
		public void SetAeroGlassTransparency()
		{
			HwndSource.FromHwnd(this.windowHandle).CompositionTarget.BackgroundColor = Colors.Transparent;
			base.Background = Brushes.Transparent;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00006528 File Offset: 0x00004728
		public void ExcludeElementFromAeroGlass(FrameworkElement element)
		{
			if (GlassWindow.AeroGlassCompositionEnabled && element != null)
			{
				HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
				NativeRect nativeRect;
				DesktopWindowManagerNativeMethods.GetWindowRect(hwndSource.Handle, out nativeRect);
				NativeRect nativeRect2;
				DesktopWindowManagerNativeMethods.GetClientRect(hwndSource.Handle, out nativeRect2);
				Size size = new Size((double)(nativeRect.Right - nativeRect.Left) - (double)(nativeRect2.Right - nativeRect2.Left), (double)(nativeRect.Bottom - nativeRect.Top) - (double)(nativeRect2.Bottom - nativeRect2.Top));
				GeneralTransform generalTransform = element.TransformToAncestor(this);
				Point point = generalTransform.Transform(new Point(0.0, 0.0));
				Point point2 = generalTransform.Transform(new Point(element.ActualWidth + size.Width, element.ActualHeight + size.Height));
				Margins margins = default(Margins);
				margins.LeftWidth = (int)point.X;
				margins.RightWidth = (int)(base.ActualWidth - point2.X);
				margins.TopHeight = (int)point.Y;
				margins.BottomHeight = (int)(base.ActualHeight - point2.Y);
				DesktopWindowManagerNativeMethods.DwmExtendFrameIntoClientArea(this.windowHandle, ref margins);
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00006678 File Offset: 0x00004878
		public void ResetAeroGlass()
		{
			Margins margins = new Margins(true);
			DesktopWindowManagerNativeMethods.DwmExtendFrameIntoClientArea(this.windowHandle, ref margins);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000066A4 File Offset: 0x000048A4
		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == 798 || msg == 799)
			{
				if (this.AeroGlassCompositionChanged != null)
				{
					this.AeroGlassCompositionChanged(this, new AeroGlassCompositionChangedEventArgs(GlassWindow.AeroGlassCompositionEnabled));
				}
				handled = true;
			}
			return IntPtr.Zero;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00006704 File Offset: 0x00004904
		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);
			this.windowHandle = windowInteropHelper.Handle;
			HwndSource hwndSource = HwndSource.FromHwnd(this.windowHandle);
			hwndSource.AddHook(new HwndSourceHook(this.WndProc));
			this.ResetAeroGlass();
		}

		// Token: 0x04000052 RID: 82
		private IntPtr windowHandle;
	}
}
