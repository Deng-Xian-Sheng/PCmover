using System;

namespace CefSharp.Internals
{
	// Token: 0x020000D7 RID: 215
	public interface IWebBrowserInternal : IWebBrowser, IChromiumWebBrowserBase, IDisposable
	{
		// Token: 0x06000638 RID: 1592
		void OnAfterBrowserCreated(IBrowser browser);

		// Token: 0x06000639 RID: 1593
		void SetAddress(AddressChangedEventArgs args);

		// Token: 0x0600063A RID: 1594
		void SetLoadingStateChange(LoadingStateChangedEventArgs args);

		// Token: 0x0600063B RID: 1595
		void SetTitle(TitleChangedEventArgs args);

		// Token: 0x0600063C RID: 1596
		void SetTooltipText(string tooltipText);

		// Token: 0x0600063D RID: 1597
		void SetCanExecuteJavascriptOnMainFrame(long frameId, bool canExecute);

		// Token: 0x0600063E RID: 1598
		void SetJavascriptMessageReceived(JavascriptMessageReceivedEventArgs args);

		// Token: 0x0600063F RID: 1599
		void OnFrameLoadStart(FrameLoadStartEventArgs args);

		// Token: 0x06000640 RID: 1600
		void OnFrameLoadEnd(FrameLoadEndEventArgs args);

		// Token: 0x06000641 RID: 1601
		void OnConsoleMessage(ConsoleMessageEventArgs args);

		// Token: 0x06000642 RID: 1602
		void OnStatusMessage(StatusMessageEventArgs args);

		// Token: 0x06000643 RID: 1603
		void OnLoadError(LoadErrorEventArgs args);

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000644 RID: 1604
		IBrowserAdapter BrowserAdapter { get; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000645 RID: 1605
		// (set) Token: 0x06000646 RID: 1606
		bool HasParent { get; set; }
	}
}
