using System;

namespace CefSharp.Handler
{
	// Token: 0x020000FA RID: 250
	public class CookieAccessFilter : ICookieAccessFilter
	{
		// Token: 0x0600075A RID: 1882 RVA: 0x0000C201 File Offset: 0x0000A401
		bool ICookieAccessFilter.CanSendCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
		{
			return this.CanSendCookie(chromiumWebBrowser, browser, frame, request, cookie);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0000C210 File Offset: 0x0000A410
		protected virtual bool CanSendCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
		{
			return false;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0000C213 File Offset: 0x0000A413
		bool ICookieAccessFilter.CanSaveCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, Cookie cookie)
		{
			return this.CanSaveCookie(chromiumWebBrowser, browser, frame, request, response, cookie);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0000C224 File Offset: 0x0000A424
		protected virtual bool CanSaveCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, Cookie cookie)
		{
			return false;
		}
	}
}
