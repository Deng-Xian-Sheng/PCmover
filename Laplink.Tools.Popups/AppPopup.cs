using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using Laplink.Tools.NativeMethods;

namespace Laplink.Tools.Popups
{
	// Token: 0x02000002 RID: 2
	public class AppPopup : Popup
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public bool DisablePopupRoot { get; set; } = true;

		// Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
		protected override void OnOpened(EventArgs e)
		{
			Application.Current.MainWindow.Activated += this.MainWindow_Activated;
			PresentationSource presentationSource = PresentationSource.FromVisual(base.Child);
			this.popupHandle = ((HwndSource)presentationSource).Handle;
			if (this.DisablePopupRoot)
			{
				this._popupRoot = this.FindPopupRoot();
			}
			User32.RECT rect;
			if (User32.GetWindowRect(this.popupHandle, out rect))
			{
				if (this.DisablePopupRoot)
				{
					this._popupRoot.DisablePopupRoot();
				}
				User32.SetWindowPos(this.popupHandle, -2, rect.Left, rect.Top, (int)base.Width, (int)base.Height, 0);
			}
			base.OnOpened(e);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002110 File Offset: 0x00000310
		private IPopupRoot FindPopupRoot()
		{
			IPopupRoot popupRoot = null;
			FrameworkElement frameworkElement = this;
			while (frameworkElement != null && popupRoot == null)
			{
				popupRoot = (frameworkElement as IPopupRoot);
				if (popupRoot == null)
				{
					popupRoot = (frameworkElement.DataContext as IPopupRoot);
					if (popupRoot == null)
					{
						frameworkElement = (frameworkElement.Parent as FrameworkElement);
					}
				}
			}
			if (popupRoot == null)
			{
				popupRoot = new DefaultPopupRoot(Application.Current.MainWindow);
			}
			return popupRoot;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002164 File Offset: 0x00000364
		private void MainWindow_Activated(object sender, EventArgs e)
		{
			AppPopup.<MainWindow_Activated>d__8 <MainWindow_Activated>d__;
			<MainWindow_Activated>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<MainWindow_Activated>d__.<>4__this = this;
			<MainWindow_Activated>d__.<>1__state = -1;
			<MainWindow_Activated>d__.<>t__builder.Start<AppPopup.<MainWindow_Activated>d__8>(ref <MainWindow_Activated>d__);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000219B File Offset: 0x0000039B
		protected override void OnClosed(EventArgs e)
		{
			Application.Current.MainWindow.Activated -= this.MainWindow_Activated;
			if (this.DisablePopupRoot)
			{
				IPopupRoot popupRoot = this._popupRoot;
				if (popupRoot != null)
				{
					popupRoot.EnablePopupRoot();
				}
			}
			base.OnClosed(e);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021D8 File Offset: 0x000003D8
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			Application.Current.MainWindow.Activate();
			base.OnMouseDown(e);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021F1 File Offset: 0x000003F1
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			Application.Current.MainWindow.Activate();
			base.OnMouseUp(e);
		}

		// Token: 0x04000001 RID: 1
		private IPopupRoot _popupRoot;

		// Token: 0x04000003 RID: 3
		private IntPtr popupHandle;
	}
}
