using System;

namespace CefSharp.Handler
{
	// Token: 0x02000105 RID: 261
	public class LifeSpanHandler : ILifeSpanHandler
	{
		// Token: 0x060007B7 RID: 1975 RVA: 0x0000C595 File Offset: 0x0000A795
		bool ILifeSpanHandler.DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			return this.DoClose(chromiumWebBrowser, browser);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0000C59F File Offset: 0x0000A79F
		protected virtual bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			return !browser.IsPopup;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0000C5AC File Offset: 0x0000A7AC
		void ILifeSpanHandler.OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnAfterCreated(chromiumWebBrowser, browser);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0000C5B6 File Offset: 0x0000A7B6
		protected virtual void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0000C5B8 File Offset: 0x0000A7B8
		void ILifeSpanHandler.OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnBeforeClose(chromiumWebBrowser, browser);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0000C5C2 File Offset: 0x0000A7C2
		protected virtual void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0000C5C4 File Offset: 0x0000A7C4
		bool ILifeSpanHandler.OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
		{
			return this.OnBeforePopup(chromiumWebBrowser, browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, browserSettings, ref noJavascriptAccess, out newBrowser);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0000C5EC File Offset: 0x0000A7EC
		protected virtual bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
		{
			newBrowser = null;
			return false;
		}
	}
}
