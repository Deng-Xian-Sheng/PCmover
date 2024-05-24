using System;
using System.Collections.Generic;
using CefSharp.Enums;
using CefSharp.Structs;

namespace CefSharp
{
	// Token: 0x02000053 RID: 83
	public interface IDisplayHandler
	{
		// Token: 0x06000138 RID: 312
		void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs);

		// Token: 0x06000139 RID: 313
		bool OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, Size newSize);

		// Token: 0x0600013A RID: 314
		bool OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo);

		// Token: 0x0600013B RID: 315
		void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs);

		// Token: 0x0600013C RID: 316
		void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls);

		// Token: 0x0600013D RID: 317
		void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen);

		// Token: 0x0600013E RID: 318
		void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress);

		// Token: 0x0600013F RID: 319
		bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text);

		// Token: 0x06000140 RID: 320
		void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs);

		// Token: 0x06000141 RID: 321
		bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs);
	}
}
