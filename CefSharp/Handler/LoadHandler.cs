using System;

namespace CefSharp.Handler
{
	// Token: 0x02000106 RID: 262
	public class LoadHandler : ILoadHandler
	{
		// Token: 0x060007C0 RID: 1984 RVA: 0x0000C5FB File Offset: 0x0000A7FB
		void ILoadHandler.OnLoadingStateChange(IWebBrowser chromiumWebBrowser, LoadingStateChangedEventArgs loadingStateChangedArgs)
		{
			this.OnLoadingStateChange(chromiumWebBrowser, loadingStateChangedArgs);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0000C605 File Offset: 0x0000A805
		protected virtual void OnLoadingStateChange(IWebBrowser chromiumWebBrowser, LoadingStateChangedEventArgs loadingStateChangedArgs)
		{
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0000C607 File Offset: 0x0000A807
		void ILoadHandler.OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs frameLoadStartArgs)
		{
			this.OnFrameLoadStart(chromiumWebBrowser, frameLoadStartArgs);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0000C611 File Offset: 0x0000A811
		protected virtual void OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs frameLoadStartArgs)
		{
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0000C613 File Offset: 0x0000A813
		void ILoadHandler.OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs frameLoadEndArgs)
		{
			this.OnFrameLoadEnd(chromiumWebBrowser, frameLoadEndArgs);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0000C61D File Offset: 0x0000A81D
		protected virtual void OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs frameLoadEndArgs)
		{
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0000C61F File Offset: 0x0000A81F
		void ILoadHandler.OnLoadError(IWebBrowser chromiumWebBrowser, LoadErrorEventArgs loadErrorArgs)
		{
			this.OnLoadError(chromiumWebBrowser, loadErrorArgs);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0000C629 File Offset: 0x0000A829
		protected virtual void OnLoadError(IWebBrowser chromiumWebBrowser, LoadErrorEventArgs loadErrorArgs)
		{
		}
	}
}
