namespace Laplink.Pcmover.CloudAuthentication
{
	// Token: 0x02000008 RID: 8
	[global::System.Runtime.InteropServices.ComVisible(true)]
	public partial class AuthenticationDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003C RID: 60 RVA: 0x0000253C File Offset: 0x0000073C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.StopWebBrowser();
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000025B4 File Offset: 0x000007B4
		private void InitializeComponent()
		{
			int height = (int)((double)global::System.Math.Max(((this.ownerWindow != null) ? global::System.Windows.Forms.Screen.FromHandle(this.ownerWindow.Handle) : global::System.Windows.Forms.Screen.PrimaryScreen).WorkingArea.Height, 160) * 70.0 / (double)global::Laplink.Pcmover.CloudAuthentication.AuthenticationDialog.DpiHelper.ZoomPercent);
			this.webBrowserPanel = new global::System.Windows.Forms.Panel();
			this.webBrowserPanel.SuspendLayout();
			base.SuspendLayout();
			this.webBrowser.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser.Location = new global::System.Drawing.Point(0, 0);
			this.webBrowser.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new global::System.Drawing.Size(566, 665);
			this.webBrowser.TabIndex = 1;
			this.webBrowserPanel.Controls.Add(this.webBrowser);
			this.webBrowserPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.webBrowserPanel.Location = new global::System.Drawing.Point(0, 0);
			this.webBrowserPanel.Name = "webBrowserPanel";
			this.webBrowserPanel.Size = new global::System.Drawing.Size(566, height);
			this.webBrowserPanel.TabIndex = 2;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(566, height);
			base.Controls.Add(this.webBrowserPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AuthenticationDialog";
			base.ShowIcon = false;
			base.StartPosition = ((this.ownerWindow != null) ? global::System.Windows.Forms.FormStartPosition.CenterParent : global::System.Windows.Forms.FormStartPosition.CenterScreen);
			this.webBrowserPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Panel webBrowserPanel;

		// Token: 0x04000009 RID: 9
		private global::Laplink.Pcmover.CloudAuthentication.LLWebBrowser webBrowser;

		// Token: 0x0400000B RID: 11
		private global::System.ComponentModel.IContainer components;
	}
}
