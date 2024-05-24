using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Effects;
using Laplink.Tools.NativeMethods;

namespace WizardModule.Views.Controls
{
	// Token: 0x02000058 RID: 88
	public class WPFPopup : Popup
	{
		// Token: 0x060004EF RID: 1263 RVA: 0x0000B4FC File Offset: 0x000096FC
		protected override void OnOpened(EventArgs e)
		{
			Application.Current.MainWindow.Activated += this.MainWindow_Activated;
			this.popupHandle = ((HwndSource)PresentationSource.FromVisual(base.Child)).Handle;
			User32.RECT rect;
			if (User32.GetWindowRect(this.popupHandle, out rect))
			{
				Application.Current.MainWindow.Opacity = 0.5;
				Application.Current.MainWindow.Effect = new BlurEffect();
				Application.Current.MainWindow.IsEnabled = false;
				User32.SetWindowPos(this.popupHandle, -2, rect.Left, rect.Top, (int)base.Width, (int)base.Height, 0);
			}
			base.OnOpened(e);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000B5BC File Offset: 0x000097BC
		private void MainWindow_Activated(object sender, EventArgs e)
		{
			WPFPopup.<MainWindow_Activated>d__2 <MainWindow_Activated>d__;
			<MainWindow_Activated>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<MainWindow_Activated>d__.<>4__this = this;
			<MainWindow_Activated>d__.<>1__state = -1;
			<MainWindow_Activated>d__.<>t__builder.Start<WPFPopup.<MainWindow_Activated>d__2>(ref <MainWindow_Activated>d__);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0000B5F4 File Offset: 0x000097F4
		protected override void OnClosed(EventArgs e)
		{
			Application.Current.MainWindow.Activated -= this.MainWindow_Activated;
			Application.Current.MainWindow.Opacity = 1.0;
			Application.Current.MainWindow.Effect = null;
			Application.Current.MainWindow.IsEnabled = true;
			base.OnClosed(e);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000B65B File Offset: 0x0000985B
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			Application.Current.MainWindow.Activate();
			base.OnMouseDown(e);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000B674 File Offset: 0x00009874
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			Application.Current.MainWindow.Activate();
			base.OnMouseUp(e);
		}

		// Token: 0x040000CC RID: 204
		private IntPtr popupHandle;
	}
}
