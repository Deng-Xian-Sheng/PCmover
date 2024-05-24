using System;

namespace CefSharp.Handler
{
	// Token: 0x02000109 RID: 265
	public class ResourceRequestHandler : IResourceRequestHandler, IDisposable
	{
		// Token: 0x060007E7 RID: 2023 RVA: 0x0000C856 File Offset: 0x0000AA56
		ICookieAccessFilter IResourceRequestHandler.GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return this.GetCookieAccessFilter(chromiumWebBrowser, browser, frame, request);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0000C863 File Offset: 0x0000AA63
		protected virtual ICookieAccessFilter GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return null;
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0000C866 File Offset: 0x0000AA66
		IResourceHandler IResourceRequestHandler.GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return this.GetResourceHandler(chromiumWebBrowser, browser, frame, request);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0000C873 File Offset: 0x0000AA73
		protected virtual IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return null;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0000C876 File Offset: 0x0000AA76
		IResponseFilter IResourceRequestHandler.GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return this.GetResourceResponseFilter(chromiumWebBrowser, browser, frame, request, response);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0000C885 File Offset: 0x0000AA85
		protected virtual IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return null;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0000C888 File Offset: 0x0000AA88
		CefReturnValue IResourceRequestHandler.OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
		{
			return this.OnBeforeResourceLoad(chromiumWebBrowser, browser, frame, request, callback);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0000C897 File Offset: 0x0000AA97
		protected virtual CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
		{
			return CefReturnValue.Continue;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0000C89A File Offset: 0x0000AA9A
		bool IResourceRequestHandler.OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return this.OnProtocolExecution(chromiumWebBrowser, browser, frame, request);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0000C8A7 File Offset: 0x0000AAA7
		protected virtual bool OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return false;
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0000C8AA File Offset: 0x0000AAAA
		void IResourceRequestHandler.OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
		{
			this.OnResourceLoadComplete(chromiumWebBrowser, browser, frame, request, response, status, receivedContentLength);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0000C8BD File Offset: 0x0000AABD
		protected virtual void OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
		{
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0000C8BF File Offset: 0x0000AABF
		void IResourceRequestHandler.OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
		{
			this.OnResourceRedirect(chromiumWebBrowser, browser, frame, request, response, ref newUrl);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0000C8D0 File Offset: 0x0000AAD0
		protected virtual void OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
		{
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0000C8D2 File Offset: 0x0000AAD2
		bool IResourceRequestHandler.OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return this.OnResourceResponse(chromiumWebBrowser, browser, frame, request, response);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0000C8E1 File Offset: 0x0000AAE1
		protected virtual bool OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return false;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
		protected virtual void Dispose()
		{
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0000C8E6 File Offset: 0x0000AAE6
		void IDisposable.Dispose()
		{
			this.Dispose();
		}
	}
}
