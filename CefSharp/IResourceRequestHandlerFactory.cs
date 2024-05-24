using System;

namespace CefSharp
{
	// Token: 0x02000079 RID: 121
	public interface IResourceRequestHandlerFactory
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600032C RID: 812
		bool HasHandlers { get; }

		// Token: 0x0600032D RID: 813
		IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling);
	}
}
