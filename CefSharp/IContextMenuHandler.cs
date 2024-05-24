using System;

namespace CefSharp
{
	// Token: 0x02000050 RID: 80
	public interface IContextMenuHandler
	{
		// Token: 0x06000131 RID: 305
		void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model);

		// Token: 0x06000132 RID: 306
		bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags);

		// Token: 0x06000133 RID: 307
		void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame);

		// Token: 0x06000134 RID: 308
		bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback);
	}
}
