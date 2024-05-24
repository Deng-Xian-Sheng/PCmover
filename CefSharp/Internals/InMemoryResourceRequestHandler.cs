using System;

namespace CefSharp.Internals
{
	// Token: 0x020000D3 RID: 211
	public sealed class InMemoryResourceRequestHandler : IResourceRequestHandler, IDisposable
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x00009BF0 File Offset: 0x00007DF0
		public InMemoryResourceRequestHandler(byte[] data, string mimeType)
		{
			this.data = data;
			this.mimeType = mimeType;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00009C06 File Offset: 0x00007E06
		public void Dispose()
		{
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00009C08 File Offset: 0x00007E08
		ICookieAccessFilter IResourceRequestHandler.GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return null;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00009C0B File Offset: 0x00007E0B
		IResourceHandler IResourceRequestHandler.GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return ResourceHandler.FromByteArray(this.data, this.mimeType, null);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00009C1F File Offset: 0x00007E1F
		IResponseFilter IResourceRequestHandler.GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return null;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00009C22 File Offset: 0x00007E22
		CefReturnValue IResourceRequestHandler.OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
		{
			return CefReturnValue.Continue;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00009C25 File Offset: 0x00007E25
		bool IResourceRequestHandler.OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			return false;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00009C28 File Offset: 0x00007E28
		void IResourceRequestHandler.OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
		{
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00009C2A File Offset: 0x00007E2A
		void IResourceRequestHandler.OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
		{
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00009C2C File Offset: 0x00007E2C
		bool IResourceRequestHandler.OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return false;
		}

		// Token: 0x04000346 RID: 838
		private readonly byte[] data;

		// Token: 0x04000347 RID: 839
		private readonly string mimeType;
	}
}
