using System;

namespace CefSharp
{
	// Token: 0x0200004A RID: 74
	public class LoadingStateChangedEventArgs : EventArgs
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000113 RID: 275 RVA: 0x0000350D File Offset: 0x0000170D
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00003515 File Offset: 0x00001715
		public bool CanGoForward { get; private set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000115 RID: 277 RVA: 0x0000351E File Offset: 0x0000171E
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00003526 File Offset: 0x00001726
		public bool CanGoBack { get; private set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000117 RID: 279 RVA: 0x0000352F File Offset: 0x0000172F
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00003537 File Offset: 0x00001737
		public bool CanReload { get; private set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00003540 File Offset: 0x00001740
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00003548 File Offset: 0x00001748
		public bool IsLoading { get; private set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00003551 File Offset: 0x00001751
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00003559 File Offset: 0x00001759
		public IBrowser Browser { get; private set; }

		// Token: 0x0600011D RID: 285 RVA: 0x00003562 File Offset: 0x00001762
		public LoadingStateChangedEventArgs(IBrowser browser, bool canGoBack, bool canGoForward, bool isLoading)
		{
			this.Browser = browser;
			this.CanGoBack = canGoBack;
			this.CanGoForward = canGoForward;
			this.IsLoading = isLoading;
			this.CanReload = !isLoading;
		}
	}
}
