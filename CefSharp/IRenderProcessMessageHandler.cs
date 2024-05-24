using System;

namespace CefSharp
{
	// Token: 0x0200005E RID: 94
	public interface IRenderProcessMessageHandler
	{
		// Token: 0x06000164 RID: 356
		void OnContextCreated(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame);

		// Token: 0x06000165 RID: 357
		void OnContextReleased(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame);

		// Token: 0x06000166 RID: 358
		void OnFocusedNodeChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IDomNode node);

		// Token: 0x06000167 RID: 359
		void OnUncaughtException(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, JavascriptException exception);
	}
}
