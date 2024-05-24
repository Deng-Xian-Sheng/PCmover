using System;

namespace CefSharp
{
	// Token: 0x0200005C RID: 92
	public interface ILifeSpanHandler
	{
		// Token: 0x0600015C RID: 348
		bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser);

		// Token: 0x0600015D RID: 349
		void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x0600015E RID: 350
		bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x0600015F RID: 351
		void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser);
	}
}
