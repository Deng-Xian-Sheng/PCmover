using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CefSharp.DevTools;
using CefSharp.Internals;
using CefSharp.Web;

namespace CefSharp
{
	// Token: 0x02000020 RID: 32
	public static class DevToolsExtensions
	{
		// Token: 0x060000AA RID: 170 RVA: 0x00002DFC File Offset: 0x00000FFC
		public static int ExecuteDevToolsMethod(this IBrowserHost browserHost, int messageId, string method, JsonString parameters)
		{
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(browserHost);
			string paramsAsJson = (parameters == null) ? null : parameters.Json;
			return browserHost.ExecuteDevToolsMethod(messageId, method, paramsAsJson);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00002E28 File Offset: 0x00001028
		public static Task<int> ExecuteDevToolsMethodAsync(this IBrowser browser, int messageId, string method, IDictionary<string, object> parameters = null)
		{
			browser.ThrowExceptionIfBrowserNull();
			IBrowserHost browserHost = browser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(browserHost);
			if (CefThread.CurrentlyOnUiThread)
			{
				return Task.FromResult<int>(browserHost.ExecuteDevToolsMethod(messageId, method, parameters));
			}
			if (CefThread.CanExecuteOnUiThread)
			{
				return CefThread.ExecuteOnUiThread<int>(() => browserHost.ExecuteDevToolsMethod(messageId, method, parameters));
			}
			return Task.FromResult<int>(0);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002EB8 File Offset: 0x000010B8
		public static Task<int> ExecuteDevToolsMethodAsync(this IChromiumWebBrowserBase chromiumWebBrowser, int messageId, string method, IDictionary<string, object> parameters = null)
		{
			IBrowser browserCore = chromiumWebBrowser.BrowserCore;
			return browserCore.ExecuteDevToolsMethodAsync(messageId, method, parameters);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00002ED8 File Offset: 0x000010D8
		public static DevToolsClient GetDevToolsClient(this IChromiumWebBrowserBase chromiumWebBrowser)
		{
			IBrowser browserCore = chromiumWebBrowser.BrowserCore;
			return browserCore.GetDevToolsClient();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002EF4 File Offset: 0x000010F4
		public static DevToolsClient GetDevToolsClient(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			IBrowserHost host = browser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			DevToolsClient devToolsClient = new DevToolsClient(browser);
			IRegistration devToolsObserverRegistration = host.AddDevToolsMessageObserver(devToolsClient);
			devToolsClient.SetDevToolsObserverRegistration(devToolsObserverRegistration);
			return devToolsClient;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002F2C File Offset: 0x0000112C
		public static Task<bool> SetMainFrameDocumentContentAsync(this IChromiumWebBrowserBase chromiumWebBrowser, string html)
		{
			IBrowser browserCore = chromiumWebBrowser.BrowserCore;
			return browserCore.SetMainFrameDocumentContentAsync(html);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002F48 File Offset: 0x00001148
		public static Task<bool> SetMainFrameDocumentContentAsync(this IBrowser browser, string html)
		{
			DevToolsExtensions.<SetMainFrameDocumentContentAsync>d__6 <SetMainFrameDocumentContentAsync>d__;
			<SetMainFrameDocumentContentAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<SetMainFrameDocumentContentAsync>d__.browser = browser;
			<SetMainFrameDocumentContentAsync>d__.html = html;
			<SetMainFrameDocumentContentAsync>d__.<>1__state = -1;
			<SetMainFrameDocumentContentAsync>d__.<>t__builder.Start<DevToolsExtensions.<SetMainFrameDocumentContentAsync>d__6>(ref <SetMainFrameDocumentContentAsync>d__);
			return <SetMainFrameDocumentContentAsync>d__.<>t__builder.Task;
		}
	}
}
