using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200012E RID: 302
	internal sealed partial class TabbedThumbnailProxyWindow : Form, IDisposable
	{
		// Token: 0x06000D97 RID: 3479 RVA: 0x00032CE0 File Offset: 0x00030EE0
		internal TabbedThumbnailProxyWindow(TabbedThumbnail preview)
		{
			this.TabbedThumbnail = preview;
			base.Size = new System.Drawing.Size(1, 1);
			if (!string.IsNullOrEmpty(preview.Title))
			{
				this.Text = preview.Title;
			}
			if (preview.WindowsControl != null)
			{
				this.WindowsControl = preview.WindowsControl;
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06000D98 RID: 3480 RVA: 0x00032D48 File Offset: 0x00030F48
		// (set) Token: 0x06000D99 RID: 3481 RVA: 0x00032D5F File Offset: 0x00030F5F
		internal TabbedThumbnail TabbedThumbnail { get; private set; }

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06000D9A RID: 3482 RVA: 0x00032D68 File Offset: 0x00030F68
		// (set) Token: 0x06000D9B RID: 3483 RVA: 0x00032D7F File Offset: 0x00030F7F
		internal UIElement WindowsControl { get; private set; }

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06000D9C RID: 3484 RVA: 0x00032D88 File Offset: 0x00030F88
		internal IntPtr WindowToTellTaskbarAbout
		{
			get
			{
				return base.Handle;
			}
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x00032DA0 File Offset: 0x00030FA0
		protected override void WndProc(ref Message m)
		{
			bool flag = false;
			if (this.TabbedThumbnail != null)
			{
				flag = TaskbarWindowManager.DispatchMessage(ref m, this.TabbedThumbnail.TaskbarWindow);
			}
			if (m.Msg == 2 || m.Msg == 130 || (m.Msg == 274 && (int)m.WParam == 61536))
			{
				base.WndProc(ref m);
			}
			else if (!flag)
			{
				base.WndProc(ref m);
			}
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00032E30 File Offset: 0x00031030
		~TabbedThumbnailProxyWindow()
		{
			this.Dispose(false);
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x00032E64 File Offset: 0x00031064
		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
