using System;

namespace CefSharp.Internals
{
	// Token: 0x020000E3 RID: 227
	public class NoFocusHandler : IFocusHandler
	{
		// Token: 0x060006DB RID: 1755 RVA: 0x0000B314 File Offset: 0x00009514
		void IFocusHandler.OnGotFocus(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0000B316 File Offset: 0x00009516
		bool IFocusHandler.OnSetFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFocusSource source)
		{
			return !browser.IsPopup;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0000B323 File Offset: 0x00009523
		void IFocusHandler.OnTakeFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, bool next)
		{
		}
	}
}
