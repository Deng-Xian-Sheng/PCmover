using System;

namespace CefSharp
{
	// Token: 0x02000051 RID: 81
	public interface ICookieAccessFilter
	{
		// Token: 0x06000135 RID: 309
		bool CanSendCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, Cookie cookie);

		// Token: 0x06000136 RID: 310
		bool CanSaveCookie(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, Cookie cookie);
	}
}
