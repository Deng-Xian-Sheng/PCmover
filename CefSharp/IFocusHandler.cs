using System;

namespace CefSharp
{
	// Token: 0x02000058 RID: 88
	public interface IFocusHandler
	{
		// Token: 0x0600014F RID: 335
		void OnGotFocus(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x06000150 RID: 336
		bool OnSetFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFocusSource source);

		// Token: 0x06000151 RID: 337
		void OnTakeFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, bool next);
	}
}
