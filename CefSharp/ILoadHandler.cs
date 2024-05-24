using System;

namespace CefSharp
{
	// Token: 0x0200005D RID: 93
	public interface ILoadHandler
	{
		// Token: 0x06000160 RID: 352
		void OnLoadingStateChange(IWebBrowser chromiumWebBrowser, LoadingStateChangedEventArgs loadingStateChangedArgs);

		// Token: 0x06000161 RID: 353
		void OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs frameLoadStartArgs);

		// Token: 0x06000162 RID: 354
		void OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs frameLoadEndArgs);

		// Token: 0x06000163 RID: 355
		void OnLoadError(IWebBrowser chromiumWebBrowser, LoadErrorEventArgs loadErrorArgs);
	}
}
