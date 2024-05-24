using System;
using System.Collections.Generic;
using CefSharp.Enums;
using CefSharp.Structs;

namespace CefSharp.Handler
{
	// Token: 0x020000FC RID: 252
	public class DisplayHandler : IDisplayHandler
	{
		// Token: 0x06000762 RID: 1890 RVA: 0x0000C25D File Offset: 0x0000A45D
		void IDisplayHandler.OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
		{
			this.OnAddressChanged(chromiumWebBrowser, addressChangedArgs);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0000C267 File Offset: 0x0000A467
		protected virtual void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
		{
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0000C269 File Offset: 0x0000A469
		bool IDisplayHandler.OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, Size newSize)
		{
			return this.OnAutoResize(chromiumWebBrowser, browser, newSize);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0000C274 File Offset: 0x0000A474
		protected virtual bool OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, Size newSize)
		{
			return false;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0000C277 File Offset: 0x0000A477
		bool IDisplayHandler.OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
		{
			return this.OnCursorChange(chromiumWebBrowser, browser, cursor, type, customCursorInfo);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0000C286 File Offset: 0x0000A486
		protected virtual bool OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
		{
			return false;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0000C289 File Offset: 0x0000A489
		void IDisplayHandler.OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
		{
			this.OnTitleChanged(chromiumWebBrowser, titleChangedArgs);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0000C293 File Offset: 0x0000A493
		protected virtual void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
		{
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0000C295 File Offset: 0x0000A495
		void IDisplayHandler.OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
		{
			this.OnFaviconUrlChange(chromiumWebBrowser, browser, urls);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		protected virtual void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
		{
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0000C2A2 File Offset: 0x0000A4A2
		void IDisplayHandler.OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
		{
			this.OnFullscreenModeChange(chromiumWebBrowser, browser, fullscreen);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0000C2AD File Offset: 0x0000A4AD
		protected virtual void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
		{
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0000C2AF File Offset: 0x0000A4AF
		void IDisplayHandler.OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
		{
			this.OnLoadingProgressChange(chromiumWebBrowser, browser, progress);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0000C2BA File Offset: 0x0000A4BA
		protected virtual void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
		{
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0000C2BC File Offset: 0x0000A4BC
		bool IDisplayHandler.OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
		{
			return this.OnTooltipChanged(chromiumWebBrowser, ref text);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0000C2C6 File Offset: 0x0000A4C6
		protected virtual bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
		{
			return false;
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0000C2C9 File Offset: 0x0000A4C9
		void IDisplayHandler.OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
		{
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0000C2CB File Offset: 0x0000A4CB
		protected virtual void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
		{
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0000C2CD File Offset: 0x0000A4CD
		bool IDisplayHandler.OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
		{
			return this.OnConsoleMessage(chromiumWebBrowser, consoleMessageArgs);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0000C2D7 File Offset: 0x0000A4D7
		protected virtual bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
		{
			return false;
		}
	}
}
