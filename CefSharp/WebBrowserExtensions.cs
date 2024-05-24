using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CefSharp.Internals;
using CefSharp.JavascriptBinding;
using CefSharp.Web;

namespace CefSharp
{
	// Token: 0x020000A0 RID: 160
	public static class WebBrowserExtensions
	{
		// Token: 0x0600049A RID: 1178 RVA: 0x00006FC7 File Offset: 0x000051C7
		[Obsolete("This method has been removed, see https://github.com/cefsharp/CefSharp/issues/2990 for details on migrating your code.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RegisterJsObject(this IWebBrowser webBrowser, string name, object objectToBind, BindingOptions options = null)
		{
			throw new NotImplementedException("This method has been removed, see https://github.com/cefsharp/CefSharp/issues/2990 for details on migrating your code.");
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00006FD3 File Offset: 0x000051D3
		[Obsolete("This method has been removed, see https://github.com/cefsharp/CefSharp/issues/2990 for details on migrating your code.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RegisterAsyncJsObject(this IWebBrowser webBrowser, string name, object objectToBind, BindingOptions options = null)
		{
			throw new NotImplementedException("This method has been removed, see https://github.com/cefsharp/CefSharp/issues/2990 for details on migrating your code.");
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00006FE0 File Offset: 0x000051E0
		public static IFrame GetMainFrame(this IChromiumWebBrowserBase browser)
		{
			IBrowser browserCore = browser.BrowserCore;
			browserCore.ThrowExceptionIfBrowserNull();
			return browserCore.MainFrame;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00007000 File Offset: 0x00005200
		public static IFrame GetFocusedFrame(this IChromiumWebBrowserBase browser)
		{
			IBrowser browserCore = browser.BrowserCore;
			browserCore.ThrowExceptionIfBrowserNull();
			return browserCore.FocusedFrame;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00007020 File Offset: 0x00005220
		public static void Undo(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Undo();
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00007030 File Offset: 0x00005230
		public static void Undo(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.Undo();
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00007074 File Offset: 0x00005274
		public static void Redo(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Redo();
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00007084 File Offset: 0x00005284
		public static void Redo(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.Redo();
			}
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x000070C8 File Offset: 0x000052C8
		public static void Cut(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Cut();
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x000070D8 File Offset: 0x000052D8
		public static void Cut(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.Cut();
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000711C File Offset: 0x0000531C
		public static void Copy(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Copy();
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0000712C File Offset: 0x0000532C
		public static void Copy(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.Copy();
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00007170 File Offset: 0x00005370
		public static void Paste(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Paste();
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00007180 File Offset: 0x00005380
		public static void Paste(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.Paste();
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x000071C4 File Offset: 0x000053C4
		public static void Delete(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Delete();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000071D4 File Offset: 0x000053D4
		public static void Delete(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.Delete();
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00007218 File Offset: 0x00005418
		public static void SelectAll(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.SelectAll();
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00007228 File Offset: 0x00005428
		public static void SelectAll(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				focusedFrame.SelectAll();
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000726C File Offset: 0x0000546C
		public static void ViewSource(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.ViewSource();
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000727C File Offset: 0x0000547C
		public static void ViewSource(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame mainFrame = browser.MainFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(mainFrame);
				mainFrame.ViewSource();
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000072C0 File Offset: 0x000054C0
		public static Task<string> GetSourceAsync(this IChromiumWebBrowserBase browser)
		{
			return browser.BrowserCore.GetSourceAsync();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000072D0 File Offset: 0x000054D0
		public static Task<string> GetSourceAsync(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			Task<string> sourceAsync;
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				sourceAsync = focusedFrame.GetSourceAsync();
			}
			return sourceAsync;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00007314 File Offset: 0x00005514
		public static Task<string> GetTextAsync(this IChromiumWebBrowserBase browser)
		{
			return browser.BrowserCore.GetTextAsync();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00007324 File Offset: 0x00005524
		public static Task<string> GetTextAsync(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			Task<string> textAsync;
			using (IFrame focusedFrame = browser.FocusedFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(focusedFrame);
				textAsync = focusedFrame.GetTextAsync();
			}
			return textAsync;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00007368 File Offset: 0x00005568
		public static void StartDownload(this IChromiumWebBrowserBase browser, string url)
		{
			browser.BrowserCore.StartDownload(url);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00007378 File Offset: 0x00005578
		public static void StartDownload(this IBrowser browser, string url)
		{
			browser.ThrowExceptionIfBrowserNull();
			IBrowserHost host = browser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.StartDownload(url);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000073A0 File Offset: 0x000055A0
		public static Task<LoadUrlAsyncResponse> LoadUrlAsync(IChromiumWebBrowserBase chromiumWebBrowser, string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException("url");
			}
			TaskCompletionSource<LoadUrlAsyncResponse> tcs = new TaskCompletionSource<LoadUrlAsyncResponse>();
			EventHandler<LoadErrorEventArgs> loadErrorHandler = null;
			EventHandler<LoadingStateChangedEventArgs> loadingStateChangeHandler = null;
			loadErrorHandler = delegate(object sender, LoadErrorEventArgs args)
			{
				if (args.ErrorCode == CefErrorCode.Aborted)
				{
					return;
				}
				chromiumWebBrowser.LoadError -= loadErrorHandler;
				chromiumWebBrowser.LoadingStateChanged -= loadingStateChangeHandler;
				tcs.TrySetResultAsync(new LoadUrlAsyncResponse(args.ErrorCode, -1));
			};
			loadingStateChangeHandler = delegate(object sender, LoadingStateChangedEventArgs args)
			{
				if (!args.IsLoading)
				{
					chromiumWebBrowser.LoadError -= loadErrorHandler;
					chromiumWebBrowser.LoadingStateChanged -= loadingStateChangeHandler;
					IBrowserHost host = args.Browser.GetHost();
					NavigationEntry navigationEntry = (host != null) ? host.GetVisibleNavigationEntry() : null;
					int num = (navigationEntry != null) ? navigationEntry.HttpStatusCode : -1;
					if (num == 0)
					{
						num = -1;
					}
					tcs.TrySetResultAsync(new LoadUrlAsyncResponse(CefErrorCode.None, num));
				}
			};
			chromiumWebBrowser.LoadError += loadErrorHandler;
			chromiumWebBrowser.LoadingStateChanged += loadingStateChangeHandler;
			chromiumWebBrowser.LoadUrl(url);
			return tcs.Task;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00007443 File Offset: 0x00005643
		public static void ExecuteScriptAsync(this IChromiumWebBrowserBase browser, string methodName, params object[] args)
		{
			browser.BrowserCore.ExecuteScriptAsync(methodName, args);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00007454 File Offset: 0x00005654
		public static void ExecuteScriptAsync(this IBrowser browser, string methodName, params object[] args)
		{
			string scriptForJavascriptMethodWithArgs = WebBrowserExtensions.GetScriptForJavascriptMethodWithArgs(methodName, args);
			browser.ExecuteScriptAsync(scriptForJavascriptMethodWithArgs);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00007470 File Offset: 0x00005670
		public static void ExecuteScriptAsync(this IChromiumWebBrowserBase browser, string script)
		{
			using (IFrame mainFrame = browser.GetMainFrame())
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(mainFrame);
				mainFrame.ExecuteJavaScriptAsync(script, "about:blank", 1);
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x000074B4 File Offset: 0x000056B4
		public static void ExecuteScriptAsync(this IBrowser browser, string script)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame mainFrame = browser.MainFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(mainFrame);
				mainFrame.ExecuteJavaScriptAsync(script, "about:blank", 1);
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00007500 File Offset: 0x00005700
		public static void ExecuteScriptAsyncWhenPageLoaded(this IChromiumWebBrowserBase webBrowser, string script, bool oneTime = true)
		{
			bool flag = !webBrowser.IsBrowserInitialized || !oneTime;
			if (webBrowser.IsBrowserInitialized)
			{
				IBrowser browserCore = webBrowser.BrowserCore;
				if (browserCore.HasDocument && !browserCore.IsLoading)
				{
					webBrowser.ExecuteScriptAsync(script);
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				EventHandler<LoadingStateChangedEventArgs> handler = null;
				handler = delegate(object sender, LoadingStateChangedEventArgs args)
				{
					if (!args.IsLoading)
					{
						if (oneTime)
						{
							webBrowser.LoadingStateChanged -= handler;
						}
						webBrowser.ExecuteScriptAsync(script);
					}
				};
				webBrowser.LoadingStateChanged += handler;
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000075AD File Offset: 0x000057AD
		public static void LoadUrlWithPostData(this IChromiumWebBrowserBase browser, string url, byte[] postDataBytes, string contentType = null)
		{
			browser.BrowserCore.LoadUrlWithPostData(url, postDataBytes, contentType);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000075C0 File Offset: 0x000057C0
		public static void LoadUrlWithPostData(this IBrowser browser, string url, byte[] postDataBytes, string contentType = null)
		{
			browser.ThrowExceptionIfBrowserNull();
			using (IFrame mainFrame = browser.MainFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(mainFrame);
				IRequest request = mainFrame.CreateRequest(true);
				request.Url = url;
				request.Method = "POST";
				request.Flags = UrlRequestFlags.AllowStoredCredentials;
				request.PostData.AddData(postDataBytes);
				if (!string.IsNullOrEmpty(contentType))
				{
					request.Headers = new NameValueCollection
					{
						{
							"Content-Type",
							contentType
						}
					};
				}
				mainFrame.LoadRequest(request);
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00007654 File Offset: 0x00005854
		public static bool LoadHtml(this IWebBrowser browser, string html, string url)
		{
			return browser.LoadHtml(html, url, Encoding.UTF8, false);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00007664 File Offset: 0x00005864
		public static void LoadHtml(this IChromiumWebBrowserBase browser, string html, bool base64Encode = false)
		{
			HtmlString htmlString = new HtmlString(html, base64Encode, null);
			browser.LoadUrl(htmlString.ToDataUriString());
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00007688 File Offset: 0x00005888
		public static void LoadHtml(this IFrame frame, string html, bool base64Encode = false)
		{
			HtmlString htmlString = new HtmlString(html, base64Encode, null);
			frame.LoadUrl(htmlString.ToDataUriString());
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000076AC File Offset: 0x000058AC
		public static bool LoadHtml(this IWebBrowser browser, string html, string url, Encoding encoding, bool oneTimeUse = false)
		{
			if (browser.ResourceRequestHandlerFactory == null)
			{
				browser.ResourceRequestHandlerFactory = new ResourceRequestHandlerFactory(null);
			}
			ResourceRequestHandlerFactory resourceRequestHandlerFactory = browser.ResourceRequestHandlerFactory as ResourceRequestHandlerFactory;
			if (resourceRequestHandlerFactory == null)
			{
				throw new Exception("LoadHtml can only be used with the default IResourceRequestHandlerFactory(DefaultResourceRequestHandlerFactory) implementation");
			}
			if (resourceRequestHandlerFactory.RegisterHandler(url, ResourceHandler.GetByteArray(html, encoding, true), "text/html", oneTimeUse))
			{
				browser.Load(url);
				return true;
			}
			return false;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000770C File Offset: 0x0000590C
		public static void RegisterResourceHandler(this IWebBrowser browser, string url, Stream stream, string mimeType = "text/html", bool oneTimeUse = false)
		{
			if (browser.ResourceRequestHandlerFactory == null)
			{
				browser.ResourceRequestHandlerFactory = new ResourceRequestHandlerFactory(null);
			}
			ResourceRequestHandlerFactory resourceRequestHandlerFactory = browser.ResourceRequestHandlerFactory as ResourceRequestHandlerFactory;
			if (resourceRequestHandlerFactory == null)
			{
				throw new Exception("RegisterResourceHandler can only be used with the default IResourceRequestHandlerFactory(DefaultResourceRequestHandlerFactory) implementation");
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);
				resourceRequestHandlerFactory.RegisterHandler(url, memoryStream.ToArray(), mimeType, oneTimeUse);
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00007784 File Offset: 0x00005984
		public static void UnRegisterResourceHandler(this IWebBrowser browser, string url)
		{
			ResourceRequestHandlerFactory resourceRequestHandlerFactory = browser.ResourceRequestHandlerFactory as ResourceRequestHandlerFactory;
			if (resourceRequestHandlerFactory == null)
			{
				throw new Exception("UnRegisterResourceHandler can only be used with the default IResourceRequestHandlerFactory(DefaultResourceRequestHandlerFactory) implementation");
			}
			resourceRequestHandlerFactory.UnregisterHandler(url);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000077B3 File Offset: 0x000059B3
		public static void Stop(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Stop();
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000077C0 File Offset: 0x000059C0
		public static void Stop(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			browser.StopLoad();
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000077CE File Offset: 0x000059CE
		public static void Back(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Back();
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x000077DB File Offset: 0x000059DB
		public static void Back(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			browser.GoBack();
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000077E9 File Offset: 0x000059E9
		public static void Forward(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.Forward();
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x000077F6 File Offset: 0x000059F6
		public static void Forward(this IBrowser browser)
		{
			browser.ThrowExceptionIfBrowserNull();
			browser.GoForward();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00007804 File Offset: 0x00005A04
		public static void Reload(this IChromiumWebBrowserBase browser)
		{
			browser.Reload(false);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000780D File Offset: 0x00005A0D
		public static void Reload(this IChromiumWebBrowserBase browser, bool ignoreCache)
		{
			browser.BrowserCore.Reload(ignoreCache);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000781B File Offset: 0x00005A1B
		public static void Reload(this IBrowser browser, bool ignoreCache = false)
		{
			browser.ThrowExceptionIfBrowserNull();
			browser.Reload(ignoreCache);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000782C File Offset: 0x00005A2C
		public static ICookieManager GetCookieManager(this IChromiumWebBrowserBase browser, ICompletionCallback callback = null)
		{
			IBrowserHost browserHost = browser.GetBrowserHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(browserHost);
			IRequestContext requestContext = browserHost.RequestContext;
			if (requestContext == null)
			{
				throw new Exception("RequestContext is null, unable to obtain cookie manager");
			}
			return requestContext.GetCookieManager(callback);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00007864 File Offset: 0x00005A64
		public static Task<double> GetZoomLevelAsync(this IBrowser cefBrowser)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			return host.GetZoomLevelAsync();
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00007884 File Offset: 0x00005A84
		public static Task<double> GetZoomLevelAsync(this IChromiumWebBrowserBase browser)
		{
			return browser.BrowserCore.GetZoomLevelAsync();
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00007894 File Offset: 0x00005A94
		public static void SetZoomLevel(this IBrowser cefBrowser, double zoomLevel)
		{
			cefBrowser.ThrowExceptionIfBrowserNull();
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.SetZoomLevel(zoomLevel);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x000078BB File Offset: 0x00005ABB
		public static void SetZoomLevel(this IChromiumWebBrowserBase browser, double zoomLevel)
		{
			browser.BrowserCore.SetZoomLevel(zoomLevel);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000078CC File Offset: 0x00005ACC
		public static void Find(this IBrowser cefBrowser, string searchText, bool forward, bool matchCase, bool findNext)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.Find(searchText, forward, matchCase, findNext);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000078F4 File Offset: 0x00005AF4
		public static void Find(this IChromiumWebBrowserBase browser, string searchText, bool forward, bool matchCase, bool findNext)
		{
			IBrowser browserCore = browser.BrowserCore;
			browserCore.ThrowExceptionIfBrowserNull();
			browserCore.Find(searchText, forward, matchCase, findNext);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000791C File Offset: 0x00005B1C
		public static void StopFinding(this IBrowser cefBrowser, bool clearSelection)
		{
			cefBrowser.ThrowExceptionIfBrowserNull();
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.StopFinding(clearSelection);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00007943 File Offset: 0x00005B43
		public static void StopFinding(this IChromiumWebBrowserBase browser, bool clearSelection)
		{
			browser.BrowserCore.StopFinding(clearSelection);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00007954 File Offset: 0x00005B54
		public static void Print(this IBrowser cefBrowser)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.Print();
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00007974 File Offset: 0x00005B74
		public static Task<bool> PrintToPdfAsync(this IBrowser cefBrowser, string path, PdfPrintSettings settings = null)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			TaskPrintToPdfCallback taskPrintToPdfCallback = new TaskPrintToPdfCallback();
			host.PrintToPdf(path, settings, taskPrintToPdfCallback);
			return taskPrintToPdfCallback.Task;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000079A4 File Offset: 0x00005BA4
		public static void Print(this IChromiumWebBrowserBase browser)
		{
			IBrowser browserCore = browser.BrowserCore;
			browserCore.ThrowExceptionIfBrowserNull();
			browserCore.Print();
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x000079C4 File Offset: 0x00005BC4
		public static Task<bool> PrintToPdfAsync(this IChromiumWebBrowserBase browser, string path, PdfPrintSettings settings = null)
		{
			return browser.BrowserCore.PrintToPdfAsync(path, settings);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000079D4 File Offset: 0x00005BD4
		public static void ShowDevTools(this IBrowser cefBrowser, IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.ShowDevTools(windowInfo, inspectElementAtX, inspectElementAtY);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x000079F7 File Offset: 0x00005BF7
		public static void ShowDevTools(this IChromiumWebBrowserBase browser, IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0)
		{
			browser.BrowserCore.ShowDevTools(windowInfo, inspectElementAtX, inspectElementAtY);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00007A08 File Offset: 0x00005C08
		public static void CloseDevTools(this IBrowser cefBrowser)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.CloseDevTools();
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00007A28 File Offset: 0x00005C28
		public static void CloseDevTools(this IChromiumWebBrowserBase browser)
		{
			browser.BrowserCore.CloseDevTools();
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00007A38 File Offset: 0x00005C38
		public static void ReplaceMisspelling(this IBrowser cefBrowser, string word)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.ReplaceMisspelling(word);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00007A59 File Offset: 0x00005C59
		public static void ReplaceMisspelling(this IChromiumWebBrowserBase browser, string word)
		{
			browser.BrowserCore.ReplaceMisspelling(word);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00007A68 File Offset: 0x00005C68
		public static void AddWordToDictionary(this IBrowser cefBrowser, string word)
		{
			IBrowserHost host = cefBrowser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.AddWordToDictionary(word);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00007A8C File Offset: 0x00005C8C
		public static IBrowserHost GetBrowserHost(this IChromiumWebBrowserBase browser)
		{
			IBrowser browserCore = browser.BrowserCore;
			if (browserCore != null)
			{
				return browserCore.GetHost();
			}
			return null;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00007AAB File Offset: 0x00005CAB
		public static void AddWordToDictionary(this IChromiumWebBrowserBase browser, string word)
		{
			browser.BrowserCore.AddWordToDictionary(word);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00007AB9 File Offset: 0x00005CB9
		public static void SendMouseWheelEvent(this IChromiumWebBrowserBase browser, int x, int y, int deltaX, int deltaY, CefEventFlags modifiers)
		{
			browser.BrowserCore.SendMouseWheelEvent(x, y, deltaX, deltaY, modifiers);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00007AD0 File Offset: 0x00005CD0
		public static void SendMouseWheelEvent(this IBrowser browser, int x, int y, int deltaX, int deltaY, CefEventFlags modifiers)
		{
			browser.ThrowExceptionIfBrowserNull();
			IBrowserHost host = browser.GetHost();
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.SendMouseWheelEvent(new MouseEvent(x, y, modifiers), deltaX, deltaY);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00007B02 File Offset: 0x00005D02
		public static void SendMouseWheelEvent(this IBrowserHost host, int x, int y, int deltaX, int deltaY, CefEventFlags modifiers)
		{
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.SendMouseWheelEvent(new MouseEvent(x, y, modifiers), deltaX, deltaY);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00007B1C File Offset: 0x00005D1C
		public static void SendMouseClickEvent(this IBrowserHost host, int x, int y, MouseButtonType mouseButtonType, bool mouseUp, int clickCount, CefEventFlags modifiers)
		{
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.SendMouseClickEvent(new MouseEvent(x, y, modifiers), mouseButtonType, mouseUp, clickCount);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00007B38 File Offset: 0x00005D38
		public static void SendMouseMoveEvent(this IBrowserHost host, int x, int y, bool mouseLeave, CefEventFlags modifiers)
		{
			WebBrowserExtensions.ThrowExceptionIfBrowserHostNull(host);
			host.SendMouseMoveEvent(new MouseEvent(x, y, modifiers), mouseLeave);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00007B50 File Offset: 0x00005D50
		public static Task<JavascriptResponse> EvaluateScriptAsPromiseAsync(this IWebBrowser chromiumWebBrowser, string script, TimeSpan? timeout = null)
		{
			JavascriptBindingSettings settings = chromiumWebBrowser.JavascriptObjectRepository.Settings;
			string promiseHandlerScript = WebBrowserExtensions.GetPromiseHandlerScript(script, settings.JavascriptBindingApiGlobalObjectName);
			return chromiumWebBrowser.EvaluateScriptAsync(promiseHandlerScript, timeout, true);
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00007B80 File Offset: 0x00005D80
		public static Task<JavascriptResponse> EvaluateScriptAsPromiseAsync(this IBrowser browser, string script, TimeSpan? timeout = null)
		{
			string promiseHandlerScript = WebBrowserExtensions.GetPromiseHandlerScript(script, null);
			return browser.EvaluateScriptAsync(promiseHandlerScript, timeout, true);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00007BA0 File Offset: 0x00005DA0
		public static Task<JavascriptResponse> EvaluateScriptAsPromiseAsync(this IFrame frame, string script, TimeSpan? timeout = null, string javascriptBindingApiGlobalObjectName = null)
		{
			string promiseHandlerScript = WebBrowserExtensions.GetPromiseHandlerScript(script, javascriptBindingApiGlobalObjectName);
			return frame.EvaluateScriptAsync(promiseHandlerScript, "about:blank", 1, timeout, true);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00007BC4 File Offset: 0x00005DC4
		private static string GetPromiseHandlerScript(string script, string javascriptBindingApiGlobalObjectName)
		{
			string text = "cefSharp.sendEvalScriptResponse";
			if (!string.IsNullOrWhiteSpace(javascriptBindingApiGlobalObjectName))
			{
				if (char.IsLower(javascriptBindingApiGlobalObjectName[0]))
				{
					text = javascriptBindingApiGlobalObjectName + ".sendEvalScriptResponse";
				}
				else
				{
					text = javascriptBindingApiGlobalObjectName + ".SendEvalScriptResponse";
				}
			}
			return string.Concat(new string[]
			{
				"let innerImmediatelyInvokedFuncExpression = (async function() { ",
				script,
				" })(); Promise.resolve(innerImmediatelyInvokedFuncExpression).then((val) => ",
				text,
				"(cefSharpInternalCallbackId, true, val, false)).catch ((reason) => ",
				text,
				"(cefSharpInternalCallbackId, false, String(reason), false)); return 'CefSharpDefEvalScriptRes';"
			});
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00007C44 File Offset: 0x00005E44
		public static Task<JavascriptResponse> EvaluateScriptAsync(this IChromiumWebBrowserBase browser, string script, TimeSpan? timeout = null, bool useImmediatelyInvokedFuncExpression = false)
		{
			IWebBrowser webBrowser = browser as IWebBrowser;
			if (webBrowser != null && !webBrowser.CanExecuteJavascriptInMainFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfCanExecuteJavascriptInMainFrameFalse();
			}
			return browser.BrowserCore.EvaluateScriptAsync(script, timeout, useImmediatelyInvokedFuncExpression);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00007C78 File Offset: 0x00005E78
		public static Task<JavascriptResponse> EvaluateScriptAsync(this IBrowser browser, string script, TimeSpan? timeout = null, bool useImmediatelyInvokedFuncExpression = false)
		{
			if (timeout != null && timeout.Value.TotalMilliseconds > 4294967295.0)
			{
				throw new ArgumentOutOfRangeException("timeout", "Timeout greater than Maximum allowable value of " + uint.MaxValue.ToString());
			}
			browser.ThrowExceptionIfBrowserNull();
			Task<JavascriptResponse> result;
			using (IFrame mainFrame = browser.MainFrame)
			{
				WebBrowserExtensions.ThrowExceptionIfFrameNull(mainFrame);
				result = mainFrame.EvaluateScriptAsync(script, "about:blank", 1, timeout, useImmediatelyInvokedFuncExpression);
			}
			return result;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00007D08 File Offset: 0x00005F08
		public static Task<JavascriptResponse> EvaluateScriptAsync(this IChromiumWebBrowserBase browser, string methodName, params object[] args)
		{
			return browser.EvaluateScriptAsync(null, methodName, args);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00007D28 File Offset: 0x00005F28
		public static Task<JavascriptResponse> EvaluateScriptAsync(this IChromiumWebBrowserBase browser, TimeSpan? timeout, string methodName, params object[] args)
		{
			string scriptForJavascriptMethodWithArgs = WebBrowserExtensions.GetScriptForJavascriptMethodWithArgs(methodName, args);
			return browser.EvaluateScriptAsync(scriptForJavascriptMethodWithArgs, timeout, false);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00007D48 File Offset: 0x00005F48
		public static void SetAsPopup(this IWebBrowser browser)
		{
			IWebBrowserInternal webBrowserInternal = (IWebBrowserInternal)browser;
			webBrowserInternal.HasParent = true;
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00007D63 File Offset: 0x00005F63
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x00007D6A File Offset: 0x00005F6A
		public static Func<string, string> EncodeScriptParam { get; set; } = (string str) => str.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n");

		// Token: 0x060004F1 RID: 1265 RVA: 0x00007D74 File Offset: 0x00005F74
		private static bool IsNumeric(this object value)
		{
			return value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong || value is float || value is double || value is decimal;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00007DDC File Offset: 0x00005FDC
		public static string GetScriptForJavascriptMethodWithArgs(string methodName, object[] args)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(methodName);
			stringBuilder.Append("(");
			if (args.Length != 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					object obj = args[i];
					if (obj == null)
					{
						stringBuilder.Append("null");
					}
					else if (obj.IsNumeric())
					{
						stringBuilder.Append(Convert.ToString(args[i], CultureInfo.InvariantCulture));
					}
					else if (obj is bool)
					{
						stringBuilder.Append(args[i].ToString().ToLowerInvariant());
					}
					else
					{
						stringBuilder.Append("'");
						stringBuilder.Append(WebBrowserExtensions.EncodeScriptParam(obj.ToString()));
						stringBuilder.Append("'");
					}
					stringBuilder.Append(", ");
				}
				stringBuilder.Remove(stringBuilder.Length - 2, 2);
			}
			stringBuilder.Append(");");
			return stringBuilder.ToString();
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00007ECC File Offset: 0x000060CC
		private static void ThrowExceptionIfFrameNull(IFrame frame)
		{
			if (frame == null)
			{
				throw new Exception("IFrame instance is null. Browser has likely not finished initializing or is in the process of disposing.");
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00007EDC File Offset: 0x000060DC
		internal static void ThrowExceptionIfBrowserNull(this IBrowser browser)
		{
			if (browser == null)
			{
				throw new Exception("IBrowser instance is null. Browser has likely not finished initializing or is in the process of disposing.");
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00007EEC File Offset: 0x000060EC
		public static void ThrowExceptionIfBrowserHostNull(IBrowserHost browserHost)
		{
			if (browserHost == null)
			{
				throw new Exception("IBrowserHost instance is null. Browser has likely not finished initializing or is in the process of disposing.");
			}
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00007EFC File Offset: 0x000060FC
		private static void ThrowExceptionIfCanExecuteJavascriptInMainFrameFalse()
		{
			throw new Exception("Unable to execute javascript at this time, scripts can only be executed within a V8Context. Use the IWebBrowser.CanExecuteJavascriptInMainFrame property to guard against this exception. See https://github.com/cefsharp/CefSharp/wiki/General-Usage#when-can-i-start-executing-javascript for more details on when you can execute javascript. For frames that do not contain Javascript then no V8Context will be created. Executing a script once the frame has loaded it's possible to create a V8Context. You can use browser.GetMainFrame().ExecuteJavaScriptAsync(script) or browser.GetMainFrame().EvaluateScriptAsync to bypass these checks (advanced users only).");
		}

		// Token: 0x040002D9 RID: 729
		public const string BrowserNullExceptionString = "IBrowser instance is null. Browser has likely not finished initializing or is in the process of disposing.";

		// Token: 0x040002DA RID: 730
		public const string BrowserHostNullExceptionString = "IBrowserHost instance is null. Browser has likely not finished initializing or is in the process of disposing.";

		// Token: 0x040002DB RID: 731
		public const string FrameNullExceptionString = "IFrame instance is null. Browser has likely not finished initializing or is in the process of disposing.";
	}
}
