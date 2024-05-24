using System;
using System.Threading.Tasks;

namespace CefSharp
{
	// Token: 0x02000067 RID: 103
	public interface IChromiumWebBrowserBase : IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600020F RID: 527
		// (remove) Token: 0x06000210 RID: 528
		event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000211 RID: 529
		// (remove) Token: 0x06000212 RID: 530
		event EventHandler<StatusMessageEventArgs> StatusMessage;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000213 RID: 531
		// (remove) Token: 0x06000214 RID: 532
		event EventHandler<FrameLoadStartEventArgs> FrameLoadStart;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000215 RID: 533
		// (remove) Token: 0x06000216 RID: 534
		event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000217 RID: 535
		// (remove) Token: 0x06000218 RID: 536
		event EventHandler<LoadErrorEventArgs> LoadError;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000219 RID: 537
		// (remove) Token: 0x0600021A RID: 538
		event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;

		// Token: 0x0600021B RID: 539
		void LoadUrl(string url);

		// Token: 0x0600021C RID: 540
		Task<LoadUrlAsyncResponse> LoadUrlAsync(string url);

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600021D RID: 541
		bool IsBrowserInitialized { get; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600021E RID: 542
		bool IsDisposed { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600021F RID: 543
		bool IsLoading { get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000220 RID: 544
		bool CanGoBack { get; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000221 RID: 545
		bool CanGoForward { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000222 RID: 546
		string Address { get; }

		// Token: 0x06000223 RID: 547
		bool Focus();

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000224 RID: 548
		IBrowser BrowserCore { get; }
	}
}
