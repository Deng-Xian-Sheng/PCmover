using System;
using System.Windows;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200018D RID: 397
	internal class ThumbnailToolbarProxyWindow : NativeWindow, IDisposable
	{
		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x06000F9B RID: 3995 RVA: 0x00037768 File Offset: 0x00035968
		// (set) Token: 0x06000F9C RID: 3996 RVA: 0x0003777F File Offset: 0x0003597F
		internal UIElement WindowsControl { get; set; }

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06000F9D RID: 3997 RVA: 0x00037788 File Offset: 0x00035988
		internal IntPtr WindowToTellTaskbarAbout
		{
			get
			{
				return (this._internalWindowHandle != IntPtr.Zero) ? this._internalWindowHandle : base.Handle;
			}
		}

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x06000F9E RID: 3998 RVA: 0x000377BC File Offset: 0x000359BC
		// (set) Token: 0x06000F9F RID: 3999 RVA: 0x000377D3 File Offset: 0x000359D3
		internal TaskbarWindow TaskbarWindow { get; set; }

		// Token: 0x06000FA0 RID: 4000 RVA: 0x000377DC File Offset: 0x000359DC
		internal ThumbnailToolbarProxyWindow(IntPtr windowHandle, ThumbnailToolBarButton[] buttons)
		{
			if (windowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.CommonFileDialogInvalidHandle, "windowHandle");
			}
			if (buttons != null && buttons.Length == 0)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailToolbarManagerNullEmptyArray, "buttons");
			}
			this._internalWindowHandle = windowHandle;
			this._thumbnailButtons = buttons;
			Array.ForEach<ThumbnailToolBarButton>(this._thumbnailButtons, new Action<ThumbnailToolBarButton>(this.UpdateHandle));
			base.AssignHandle(windowHandle);
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x00037868 File Offset: 0x00035A68
		internal ThumbnailToolbarProxyWindow(UIElement windowsControl, ThumbnailToolBarButton[] buttons)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			if (buttons != null && buttons.Length == 0)
			{
				throw new ArgumentException(LocalizedMessages.ThumbnailToolbarManagerNullEmptyArray, "buttons");
			}
			this._internalWindowHandle = IntPtr.Zero;
			this.WindowsControl = windowsControl;
			this._thumbnailButtons = buttons;
			Array.ForEach<ThumbnailToolBarButton>(this._thumbnailButtons, new Action<ThumbnailToolBarButton>(this.UpdateHandle));
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x000378EC File Offset: 0x00035AEC
		private void UpdateHandle(ThumbnailToolBarButton button)
		{
			button.WindowHandle = this._internalWindowHandle;
			button.AddedToTaskbar = false;
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x00037904 File Offset: 0x00035B04
		protected override void WndProc(ref Message m)
		{
			bool flag = TaskbarWindowManager.DispatchMessage(ref m, this.TaskbarWindow);
			if (m.Msg == 2 || m.Msg == 130 || (m.Msg == 274 && (int)m.WParam == 61536))
			{
				base.WndProc(ref m);
			}
			else if (!flag)
			{
				base.WndProc(ref m);
			}
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x00037980 File Offset: 0x00035B80
		~ThumbnailToolbarProxyWindow()
		{
			this.Dispose(false);
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x000379B4 File Offset: 0x00035BB4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x000379C8 File Offset: 0x00035BC8
		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._thumbnailButtons = null;
			}
		}

		// Token: 0x04000694 RID: 1684
		private ThumbnailToolBarButton[] _thumbnailButtons;

		// Token: 0x04000695 RID: 1685
		private IntPtr _internalWindowHandle;
	}
}
