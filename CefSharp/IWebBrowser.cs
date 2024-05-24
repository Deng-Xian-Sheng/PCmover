using System;
using System.Threading.Tasks;

namespace CefSharp
{
	// Token: 0x02000081 RID: 129
	public interface IWebBrowser : IChromiumWebBrowserBase, IDisposable
	{
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000352 RID: 850
		// (remove) Token: 0x06000353 RID: 851
		event EventHandler<JavascriptMessageReceivedEventArgs> JavascriptMessageReceived;

		// Token: 0x06000354 RID: 852
		void Load(string url);

		// Token: 0x06000355 RID: 853
		Task<LoadUrlAsyncResponse> WaitForInitialLoadAsync();

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000356 RID: 854
		IJavascriptObjectRepository JavascriptObjectRepository { get; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000357 RID: 855
		// (set) Token: 0x06000358 RID: 856
		IDialogHandler DialogHandler { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000359 RID: 857
		// (set) Token: 0x0600035A RID: 858
		IRequestHandler RequestHandler { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600035B RID: 859
		// (set) Token: 0x0600035C RID: 860
		IDisplayHandler DisplayHandler { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600035D RID: 861
		// (set) Token: 0x0600035E RID: 862
		ILoadHandler LoadHandler { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600035F RID: 863
		// (set) Token: 0x06000360 RID: 864
		ILifeSpanHandler LifeSpanHandler { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000361 RID: 865
		// (set) Token: 0x06000362 RID: 866
		IKeyboardHandler KeyboardHandler { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000363 RID: 867
		// (set) Token: 0x06000364 RID: 868
		IJsDialogHandler JsDialogHandler { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000365 RID: 869
		// (set) Token: 0x06000366 RID: 870
		IDragHandler DragHandler { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000367 RID: 871
		// (set) Token: 0x06000368 RID: 872
		IDownloadHandler DownloadHandler { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000369 RID: 873
		// (set) Token: 0x0600036A RID: 874
		IContextMenuHandler MenuHandler { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600036B RID: 875
		// (set) Token: 0x0600036C RID: 876
		IFocusHandler FocusHandler { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600036D RID: 877
		// (set) Token: 0x0600036E RID: 878
		IResourceRequestHandlerFactory ResourceRequestHandlerFactory { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600036F RID: 879
		// (set) Token: 0x06000370 RID: 880
		IRenderProcessMessageHandler RenderProcessMessageHandler { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000371 RID: 881
		// (set) Token: 0x06000372 RID: 882
		IFindHandler FindHandler { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000373 RID: 883
		// (set) Token: 0x06000374 RID: 884
		IAudioHandler AudioHandler { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000375 RID: 885
		// (set) Token: 0x06000376 RID: 886
		IFrameHandler FrameHandler { get; set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000377 RID: 887
		string TooltipText { get; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000378 RID: 888
		bool CanExecuteJavascriptInMainFrame { get; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000379 RID: 889
		IRequestContext RequestContext { get; }

		// Token: 0x0600037A RID: 890
		IBrowser GetBrowser();

		// Token: 0x0600037B RID: 891
		bool TryGetBrowserCoreById(int browserId, out IBrowser browser);
	}
}
