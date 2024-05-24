using System;

namespace CefSharp
{
	// Token: 0x02000054 RID: 84
	public interface IDownloadHandler
	{
		// Token: 0x06000142 RID: 322
		void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback);

		// Token: 0x06000143 RID: 323
		void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback);
	}
}
