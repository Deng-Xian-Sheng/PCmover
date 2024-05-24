using System;

namespace CefSharp
{
	// Token: 0x02000062 RID: 98
	public interface IResourceRequestHandler : IDisposable
	{
		// Token: 0x0600017B RID: 379
		ICookieAccessFilter GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request);

		// Token: 0x0600017C RID: 380
		CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback);

		// Token: 0x0600017D RID: 381
		IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request);

		// Token: 0x0600017E RID: 382
		void OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl);

		// Token: 0x0600017F RID: 383
		bool OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response);

		// Token: 0x06000180 RID: 384
		IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response);

		// Token: 0x06000181 RID: 385
		void OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength);

		// Token: 0x06000182 RID: 386
		bool OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request);
	}
}
