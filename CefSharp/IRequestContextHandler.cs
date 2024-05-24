using System;

namespace CefSharp
{
	// Token: 0x0200005F RID: 95
	public interface IRequestContextHandler
	{
		// Token: 0x06000168 RID: 360
		void OnRequestContextInitialized(IRequestContext requestContext);

		// Token: 0x06000169 RID: 361
		IResourceRequestHandler GetResourceRequestHandler(IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling);
	}
}
