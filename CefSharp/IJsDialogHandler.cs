using System;

namespace CefSharp
{
	// Token: 0x0200005A RID: 90
	public interface IJsDialogHandler
	{
		// Token: 0x06000156 RID: 342
		bool OnJSDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage);

		// Token: 0x06000157 RID: 343
		bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback);

		// Token: 0x06000158 RID: 344
		void OnResetDialogState(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x06000159 RID: 345
		void OnDialogClosed(IWebBrowser chromiumWebBrowser, IBrowser browser);
	}
}
