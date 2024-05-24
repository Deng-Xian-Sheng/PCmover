using System;
using System.Security.Cryptography.X509Certificates;

namespace CefSharp.Handler
{
	// Token: 0x02000108 RID: 264
	public class RequestHandler : IRequestHandler
	{
		// Token: 0x060007D2 RID: 2002 RVA: 0x0000C75D File Offset: 0x0000A95D
		bool IRequestHandler.OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
		{
			return this.OnBeforeBrowse(chromiumWebBrowser, browser, frame, request, userGesture, isRedirect);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0000C76E File Offset: 0x0000A96E
		protected virtual bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
		{
			return false;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0000C771 File Offset: 0x0000A971
		bool IRequestHandler.OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
		{
			return this.OnOpenUrlFromTab(chromiumWebBrowser, browser, frame, targetUrl, targetDisposition, userGesture);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0000C782 File Offset: 0x0000A982
		protected virtual bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
		{
			return false;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0000C788 File Offset: 0x0000A988
		IResourceRequestHandler IRequestHandler.GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			return this.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0000C7A8 File Offset: 0x0000A9A8
		protected virtual IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			return null;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0000C7AC File Offset: 0x0000A9AC
		bool IRequestHandler.GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
		{
			return this.GetAuthCredentials(chromiumWebBrowser, browser, originUrl, isProxy, host, port, realm, scheme, callback);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0000C7CE File Offset: 0x0000A9CE
		protected virtual bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
		{
			callback.Dispose();
			return false;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0000C7D8 File Offset: 0x0000A9D8
		bool IRequestHandler.OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
		{
			return this.OnQuotaRequest(chromiumWebBrowser, browser, originUrl, newSize, callback);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0000C7E7 File Offset: 0x0000A9E7
		protected virtual bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
		{
			callback.Dispose();
			return false;
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0000C7F1 File Offset: 0x0000A9F1
		bool IRequestHandler.OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
		{
			return this.OnCertificateError(chromiumWebBrowser, browser, errorCode, requestUrl, sslInfo, callback);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0000C802 File Offset: 0x0000AA02
		protected virtual bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
		{
			callback.Dispose();
			return false;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0000C80C File Offset: 0x0000AA0C
		bool IRequestHandler.OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
		{
			return this.OnSelectClientCertificate(chromiumWebBrowser, browser, isProxy, host, port, certificates, callback);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0000C81F File Offset: 0x0000AA1F
		protected virtual bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
		{
			callback.Dispose();
			return false;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0000C829 File Offset: 0x0000AA29
		void IRequestHandler.OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnRenderViewReady(chromiumWebBrowser, browser);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0000C833 File Offset: 0x0000AA33
		protected virtual void OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0000C835 File Offset: 0x0000AA35
		void IRequestHandler.OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status)
		{
			this.OnRenderProcessTerminated(chromiumWebBrowser, browser, status);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0000C840 File Offset: 0x0000AA40
		protected virtual void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status)
		{
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0000C842 File Offset: 0x0000AA42
		void IRequestHandler.OnDocumentAvailableInMainFrame(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnDocumentAvailableInMainFrame(chromiumWebBrowser, browser);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0000C84C File Offset: 0x0000AA4C
		protected virtual void OnDocumentAvailableInMainFrame(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}
	}
}
