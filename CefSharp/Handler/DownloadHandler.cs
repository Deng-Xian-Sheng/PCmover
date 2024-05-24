using System;

namespace CefSharp.Handler
{
	// Token: 0x020000FD RID: 253
	public class DownloadHandler : IDownloadHandler
	{
		// Token: 0x06000777 RID: 1911 RVA: 0x0000C2E2 File Offset: 0x0000A4E2
		void IDownloadHandler.OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
		{
			this.OnBeforeDownload(chromiumWebBrowser, browser, downloadItem, callback);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0000C2EF File Offset: 0x0000A4EF
		protected virtual void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
		{
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0000C2F1 File Offset: 0x0000A4F1
		void IDownloadHandler.OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
		{
			this.OnDownloadUpdated(chromiumWebBrowser, browser, downloadItem, callback);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0000C2FE File Offset: 0x0000A4FE
		protected virtual void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
		{
		}
	}
}
