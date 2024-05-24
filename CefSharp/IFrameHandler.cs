using System;

namespace CefSharp
{
	// Token: 0x02000059 RID: 89
	public interface IFrameHandler
	{
		// Token: 0x06000152 RID: 338
		void OnFrameAttached(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, bool reattached);

		// Token: 0x06000153 RID: 339
		void OnFrameCreated(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame);

		// Token: 0x06000154 RID: 340
		void OnFrameDetached(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame);

		// Token: 0x06000155 RID: 341
		void OnMainFrameChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame oldFrame, IFrame newFrame);
	}
}
