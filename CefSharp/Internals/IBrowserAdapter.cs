using System;

namespace CefSharp.Internals
{
	// Token: 0x020000CD RID: 205
	public interface IBrowserAdapter : IDisposable
	{
		// Token: 0x06000602 RID: 1538
		void CreateBrowser(IWindowInfo windowInfo, IBrowserSettings browserSettings, IRequestContext requestContext, string address);

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000603 RID: 1539
		IMethodRunnerQueue MethodRunnerQueue { get; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000604 RID: 1540
		IJavascriptObjectRepositoryInternal JavascriptObjectRepository { get; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000605 RID: 1541
		IJavascriptCallbackFactory JavascriptCallbackFactory { get; }

		// Token: 0x06000606 RID: 1542
		void OnAfterBrowserCreated(IBrowser browser);

		// Token: 0x06000607 RID: 1543
		IBrowser GetBrowser(int browserId);

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000608 RID: 1544
		bool IsDisposed { get; }

		// Token: 0x06000609 RID: 1545
		void Resize(int width, int height);
	}
}
