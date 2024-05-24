using System;

namespace CefSharp.Handler
{
	// Token: 0x02000103 RID: 259
	public class JsDialogHandler : IJsDialogHandler
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x0000C4FC File Offset: 0x0000A6FC
		bool IJsDialogHandler.OnJSDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
		{
			return this.OnJSDialog(chromiumWebBrowser, browser, originUrl, dialogType, messageText, defaultPromptText, callback, ref suppressMessage);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0000C51C File Offset: 0x0000A71C
		protected virtual bool OnJSDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
		{
			return false;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0000C51F File Offset: 0x0000A71F
		bool IJsDialogHandler.OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
		{
			return this.OnBeforeUnloadDialog(chromiumWebBrowser, browser, messageText, isReload, callback);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0000C52E File Offset: 0x0000A72E
		protected virtual bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
		{
			return false;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0000C531 File Offset: 0x0000A731
		void IJsDialogHandler.OnResetDialogState(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnResetDialogState(chromiumWebBrowser, browser);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0000C53B File Offset: 0x0000A73B
		protected virtual void OnResetDialogState(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0000C53D File Offset: 0x0000A73D
		void IJsDialogHandler.OnDialogClosed(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			this.OnDialogClosed(chromiumWebBrowser, browser);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0000C547 File Offset: 0x0000A747
		protected virtual void OnDialogClosed(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}
	}
}
