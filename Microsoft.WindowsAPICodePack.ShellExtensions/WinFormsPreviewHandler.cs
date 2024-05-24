using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Interop;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200000E RID: 14
	public abstract class WinFormsPreviewHandler : PreviewHandler, IDisposable
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002ACC File Offset: 0x00000CCC
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002AE3 File Offset: 0x00000CE3
		public UserControl Control { get; protected set; }

		// Token: 0x06000044 RID: 68 RVA: 0x00002AEC File Offset: 0x00000CEC
		protected void ThrowIfNoControl()
		{
			if (this.Control == null)
			{
				throw new InvalidOperationException(LocalizedMessages.PreviewHandlerControlNotInitialized);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002B18 File Offset: 0x00000D18
		protected override void HandleInitializeException(Exception caughtException)
		{
			if (caughtException == null)
			{
				throw new ArgumentNullException("caughtException");
			}
			this.Control = new UserControl();
			this.Control.Controls.Add(new TextBox
			{
				ReadOnly = true,
				Multiline = true,
				Dock = DockStyle.Fill,
				Text = caughtException.ToString(),
				BackColor = Color.OrangeRed
			});
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002B92 File Offset: 0x00000D92
		protected override void UpdateBounds(NativeRect bounds)
		{
			this.Control.Bounds = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right, bounds.Bottom);
			this.Control.Visible = true;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002BCF File Offset: 0x00000DCF
		protected override void SetFocus()
		{
			this.Control.Focus();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002BDE File Offset: 0x00000DDE
		protected override void SetBackground(int argb)
		{
			this.Control.BackColor = Color.FromArgb(argb);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002BF3 File Offset: 0x00000DF3
		protected override void SetForeground(int argb)
		{
			this.Control.ForeColor = Color.FromArgb(argb);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002C08 File Offset: 0x00000E08
		protected override void SetFont(LogFont font)
		{
			this.Control.Font = Font.FromLogFont(font);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002C20 File Offset: 0x00000E20
		protected override IntPtr Handle
		{
			get
			{
				return this.Control.Handle;
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002C3E File Offset: 0x00000E3E
		protected override void SetParentHandle(IntPtr handle)
		{
			HandlerNativeMethods.SetParent(this.Control.Handle, handle);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002C54 File Offset: 0x00000E54
		~WinFormsPreviewHandler()
		{
			this.Dispose(false);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002C88 File Offset: 0x00000E88
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002C9C File Offset: 0x00000E9C
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && this.Control != null)
			{
				this.Control.Dispose();
			}
		}
	}
}
