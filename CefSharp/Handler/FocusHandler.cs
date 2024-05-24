using System;

namespace CefSharp.Handler
{
	// Token: 0x02000101 RID: 257
	public class FocusHandler : IFocusHandler
	{
		// Token: 0x06000798 RID: 1944 RVA: 0x0000C3F6 File Offset: 0x0000A5F6
		void IFocusHandler.OnGotFocus(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnGotFocus(chromiumWebBrowser, browser);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0000C400 File Offset: 0x0000A600
		protected virtual void OnGotFocus(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0000C402 File Offset: 0x0000A602
		bool IFocusHandler.OnSetFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFocusSource source)
		{
			return this.OnSetFocus(chromiumWebBrowser, browser, source);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0000C40D File Offset: 0x0000A60D
		protected virtual bool OnSetFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, CefFocusSource source)
		{
			return false;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0000C410 File Offset: 0x0000A610
		void IFocusHandler.OnTakeFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, bool next)
		{
			this.OnTakeFocus(chromiumWebBrowser, browser, next);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0000C41B File Offset: 0x0000A61B
		protected virtual void OnTakeFocus(IWebBrowser chromiumWebBrowser, IBrowser browser, bool next)
		{
		}
	}
}
