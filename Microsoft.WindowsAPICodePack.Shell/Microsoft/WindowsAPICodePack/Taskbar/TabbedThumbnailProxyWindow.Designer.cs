namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200012E RID: 302
	internal sealed partial class TabbedThumbnailProxyWindow : global::System.Windows.Forms.Form, global::System.IDisposable
	{
		// Token: 0x06000DA0 RID: 3488 RVA: 0x00032E78 File Offset: 0x00031078
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.TabbedThumbnail != null)
				{
					this.TabbedThumbnail.Dispose();
				}
				this.TabbedThumbnail = null;
				this.WindowsControl = null;
			}
			base.Dispose(disposing);
		}
	}
}
