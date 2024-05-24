using System;
using System.Windows;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000188 RID: 392
	internal class TaskbarWindow : IDisposable
	{
		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x0003571C File Offset: 0x0003391C
		// (set) Token: 0x06000F42 RID: 3906 RVA: 0x00035733 File Offset: 0x00033933
		internal TabbedThumbnailProxyWindow TabbedThumbnailProxyWindow { get; set; }

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x0003573C File Offset: 0x0003393C
		// (set) Token: 0x06000F44 RID: 3908 RVA: 0x00035753 File Offset: 0x00033953
		internal ThumbnailToolbarProxyWindow ThumbnailToolbarProxyWindow { get; set; }

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0003575C File Offset: 0x0003395C
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x00035773 File Offset: 0x00033973
		internal bool EnableTabbedThumbnails { get; set; }

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x0003577C File Offset: 0x0003397C
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x00035793 File Offset: 0x00033993
		internal bool EnableThumbnailToolbars { get; set; }

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x0003579C File Offset: 0x0003399C
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x000357B3 File Offset: 0x000339B3
		internal IntPtr UserWindowHandle { get; set; }

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x000357BC File Offset: 0x000339BC
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x000357D3 File Offset: 0x000339D3
		internal UIElement WindowsControl { get; set; }

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x000357DC File Offset: 0x000339DC
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x000357F4 File Offset: 0x000339F4
		internal TabbedThumbnail TabbedThumbnail
		{
			get
			{
				return this._tabbedThumbnailPreview;
			}
			set
			{
				if (this._tabbedThumbnailPreview != null)
				{
					throw new InvalidOperationException(LocalizedMessages.TaskbarWindowValueSet);
				}
				this.TabbedThumbnailProxyWindow = new TabbedThumbnailProxyWindow(value);
				this._tabbedThumbnailPreview = value;
				this._tabbedThumbnailPreview.TaskbarWindow = this;
			}
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x0003583C File Offset: 0x00033A3C
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x00035854 File Offset: 0x00033A54
		internal ThumbnailToolBarButton[] ThumbnailButtons
		{
			get
			{
				return this._thumbnailButtons;
			}
			set
			{
				this._thumbnailButtons = value;
				this.UpdateHandles();
			}
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00035868 File Offset: 0x00033A68
		private void UpdateHandles()
		{
			foreach (ThumbnailToolBarButton thumbnailToolBarButton in this._thumbnailButtons)
			{
				thumbnailToolBarButton.WindowHandle = this.WindowToTellTaskbarAbout;
				thumbnailToolBarButton.AddedToTaskbar = false;
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06000F52 RID: 3922 RVA: 0x000358AC File Offset: 0x00033AAC
		internal IntPtr WindowToTellTaskbarAbout
		{
			get
			{
				IntPtr windowToTellTaskbarAbout;
				if (this.EnableThumbnailToolbars && !this.EnableTabbedThumbnails && this.ThumbnailToolbarProxyWindow != null)
				{
					windowToTellTaskbarAbout = this.ThumbnailToolbarProxyWindow.WindowToTellTaskbarAbout;
				}
				else if (!this.EnableThumbnailToolbars && this.EnableTabbedThumbnails && this.TabbedThumbnailProxyWindow != null)
				{
					windowToTellTaskbarAbout = this.TabbedThumbnailProxyWindow.WindowToTellTaskbarAbout;
				}
				else
				{
					if (!this.EnableTabbedThumbnails || !this.EnableThumbnailToolbars || this.TabbedThumbnailProxyWindow == null)
					{
						throw new InvalidOperationException();
					}
					windowToTellTaskbarAbout = this.TabbedThumbnailProxyWindow.WindowToTellTaskbarAbout;
				}
				return windowToTellTaskbarAbout;
			}
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x00035954 File Offset: 0x00033B54
		internal void SetTitle(string title)
		{
			if (this.TabbedThumbnailProxyWindow == null)
			{
				throw new InvalidOperationException(LocalizedMessages.TasbarWindowProxyWindowSet);
			}
			this.TabbedThumbnailProxyWindow.Text = title;
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x0003598C File Offset: 0x00033B8C
		internal TaskbarWindow(IntPtr userWindowHandle, params ThumbnailToolBarButton[] buttons)
		{
			if (userWindowHandle == IntPtr.Zero)
			{
				throw new ArgumentException(LocalizedMessages.CommonFileDialogInvalidHandle, "userWindowHandle");
			}
			if (buttons == null || buttons.Length == 0)
			{
				throw new ArgumentException(LocalizedMessages.TaskbarWindowEmptyButtonArray, "buttons");
			}
			this.ThumbnailToolbarProxyWindow = new ThumbnailToolbarProxyWindow(userWindowHandle, buttons);
			this.ThumbnailToolbarProxyWindow.TaskbarWindow = this;
			this.EnableThumbnailToolbars = true;
			this.EnableTabbedThumbnails = false;
			this.ThumbnailButtons = buttons;
			this.UserWindowHandle = userWindowHandle;
			this.WindowsControl = null;
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x00035A30 File Offset: 0x00033C30
		internal TaskbarWindow(UIElement windowsControl, params ThumbnailToolBarButton[] buttons)
		{
			if (windowsControl == null)
			{
				throw new ArgumentNullException("windowsControl");
			}
			if (buttons == null || buttons.Length == 0)
			{
				throw new ArgumentException(LocalizedMessages.TaskbarWindowEmptyButtonArray, "buttons");
			}
			this.ThumbnailToolbarProxyWindow = new ThumbnailToolbarProxyWindow(windowsControl, buttons);
			this.ThumbnailToolbarProxyWindow.TaskbarWindow = this;
			this.EnableThumbnailToolbars = true;
			this.EnableTabbedThumbnails = false;
			this.ThumbnailButtons = buttons;
			this.UserWindowHandle = IntPtr.Zero;
			this.WindowsControl = windowsControl;
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x00035ACC File Offset: 0x00033CCC
		internal TaskbarWindow(TabbedThumbnail preview)
		{
			if (preview == null)
			{
				throw new ArgumentNullException("preview");
			}
			this.TabbedThumbnailProxyWindow = new TabbedThumbnailProxyWindow(preview);
			this.EnableThumbnailToolbars = false;
			this.EnableTabbedThumbnails = true;
			this.UserWindowHandle = preview.WindowHandle;
			this.WindowsControl = preview.WindowsControl;
			this.TabbedThumbnail = preview;
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x00035B38 File Offset: 0x00033D38
		~TaskbarWindow()
		{
			this.Dispose(false);
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00035B6C File Offset: 0x00033D6C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00035B80 File Offset: 0x00033D80
		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._tabbedThumbnailPreview != null)
				{
					this._tabbedThumbnailPreview.Dispose();
				}
				this._tabbedThumbnailPreview = null;
				if (this.ThumbnailToolbarProxyWindow != null)
				{
					this.ThumbnailToolbarProxyWindow.Dispose();
				}
				this.ThumbnailToolbarProxyWindow = null;
				if (this.TabbedThumbnailProxyWindow != null)
				{
					this.TabbedThumbnailProxyWindow.Dispose();
				}
				this.TabbedThumbnailProxyWindow = null;
				this._thumbnailButtons = null;
			}
		}

		// Token: 0x04000678 RID: 1656
		private TabbedThumbnail _tabbedThumbnailPreview;

		// Token: 0x04000679 RID: 1657
		private ThumbnailToolBarButton[] _thumbnailButtons;
	}
}
