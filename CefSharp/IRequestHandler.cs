using System;
using System.Security.Cryptography.X509Certificates;

namespace CefSharp
{
	// Token: 0x02000060 RID: 96
	public interface IRequestHandler
	{
		// Token: 0x0600016A RID: 362
		bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect);

		// Token: 0x0600016B RID: 363
		void OnDocumentAvailableInMainFrame(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x0600016C RID: 364
		bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture);

		// Token: 0x0600016D RID: 365
		IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling);

		// Token: 0x0600016E RID: 366
		bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback);

		// Token: 0x0600016F RID: 367
		bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback);

		// Token: 0x06000170 RID: 368
		bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback);

		// Token: 0x06000171 RID: 369
		bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback);

		// Token: 0x06000172 RID: 370
		void OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser);

		// Token: 0x06000173 RID: 371
		void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status);
	}
}
