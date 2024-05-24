using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200028A RID: 650
	public class PageClient : DevToolsDomainBase
	{
		// Token: 0x06001222 RID: 4642 RVA: 0x000162EA File Offset: 0x000144EA
		public PageClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06001223 RID: 4643 RVA: 0x000162F9 File Offset: 0x000144F9
		// (remove) Token: 0x06001224 RID: 4644 RVA: 0x0001630C File Offset: 0x0001450C
		public event EventHandler<DomContentEventFiredEventArgs> DomContentEventFired
		{
			add
			{
				this._client.AddEventHandler<DomContentEventFiredEventArgs>("Page.domContentEventFired", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DomContentEventFiredEventArgs>("Page.domContentEventFired", value);
			}
		}

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x06001225 RID: 4645 RVA: 0x00016320 File Offset: 0x00014520
		// (remove) Token: 0x06001226 RID: 4646 RVA: 0x00016333 File Offset: 0x00014533
		public event EventHandler<FileChooserOpenedEventArgs> FileChooserOpened
		{
			add
			{
				this._client.AddEventHandler<FileChooserOpenedEventArgs>("Page.fileChooserOpened", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FileChooserOpenedEventArgs>("Page.fileChooserOpened", value);
			}
		}

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06001227 RID: 4647 RVA: 0x00016347 File Offset: 0x00014547
		// (remove) Token: 0x06001228 RID: 4648 RVA: 0x0001635A File Offset: 0x0001455A
		public event EventHandler<FrameAttachedEventArgs> FrameAttached
		{
			add
			{
				this._client.AddEventHandler<FrameAttachedEventArgs>("Page.frameAttached", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FrameAttachedEventArgs>("Page.frameAttached", value);
			}
		}

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06001229 RID: 4649 RVA: 0x0001636E File Offset: 0x0001456E
		// (remove) Token: 0x0600122A RID: 4650 RVA: 0x00016381 File Offset: 0x00014581
		public event EventHandler<FrameDetachedEventArgs> FrameDetached
		{
			add
			{
				this._client.AddEventHandler<FrameDetachedEventArgs>("Page.frameDetached", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FrameDetachedEventArgs>("Page.frameDetached", value);
			}
		}

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x0600122B RID: 4651 RVA: 0x00016395 File Offset: 0x00014595
		// (remove) Token: 0x0600122C RID: 4652 RVA: 0x000163A8 File Offset: 0x000145A8
		public event EventHandler<FrameNavigatedEventArgs> FrameNavigated
		{
			add
			{
				this._client.AddEventHandler<FrameNavigatedEventArgs>("Page.frameNavigated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FrameNavigatedEventArgs>("Page.frameNavigated", value);
			}
		}

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x0600122D RID: 4653 RVA: 0x000163BC File Offset: 0x000145BC
		// (remove) Token: 0x0600122E RID: 4654 RVA: 0x000163CF File Offset: 0x000145CF
		public event EventHandler<DocumentOpenedEventArgs> DocumentOpened
		{
			add
			{
				this._client.AddEventHandler<DocumentOpenedEventArgs>("Page.documentOpened", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DocumentOpenedEventArgs>("Page.documentOpened", value);
			}
		}

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x0600122F RID: 4655 RVA: 0x000163E3 File Offset: 0x000145E3
		// (remove) Token: 0x06001230 RID: 4656 RVA: 0x000163F6 File Offset: 0x000145F6
		public event EventHandler<EventArgs> FrameResized
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Page.frameResized", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Page.frameResized", value);
			}
		}

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06001231 RID: 4657 RVA: 0x0001640A File Offset: 0x0001460A
		// (remove) Token: 0x06001232 RID: 4658 RVA: 0x0001641D File Offset: 0x0001461D
		public event EventHandler<FrameRequestedNavigationEventArgs> FrameRequestedNavigation
		{
			add
			{
				this._client.AddEventHandler<FrameRequestedNavigationEventArgs>("Page.frameRequestedNavigation", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FrameRequestedNavigationEventArgs>("Page.frameRequestedNavigation", value);
			}
		}

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06001233 RID: 4659 RVA: 0x00016431 File Offset: 0x00014631
		// (remove) Token: 0x06001234 RID: 4660 RVA: 0x00016444 File Offset: 0x00014644
		public event EventHandler<FrameStartedLoadingEventArgs> FrameStartedLoading
		{
			add
			{
				this._client.AddEventHandler<FrameStartedLoadingEventArgs>("Page.frameStartedLoading", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FrameStartedLoadingEventArgs>("Page.frameStartedLoading", value);
			}
		}

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06001235 RID: 4661 RVA: 0x00016458 File Offset: 0x00014658
		// (remove) Token: 0x06001236 RID: 4662 RVA: 0x0001646B File Offset: 0x0001466B
		public event EventHandler<FrameStoppedLoadingEventArgs> FrameStoppedLoading
		{
			add
			{
				this._client.AddEventHandler<FrameStoppedLoadingEventArgs>("Page.frameStoppedLoading", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FrameStoppedLoadingEventArgs>("Page.frameStoppedLoading", value);
			}
		}

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06001237 RID: 4663 RVA: 0x0001647F File Offset: 0x0001467F
		// (remove) Token: 0x06001238 RID: 4664 RVA: 0x00016492 File Offset: 0x00014692
		public event EventHandler<EventArgs> InterstitialHidden
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Page.interstitialHidden", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Page.interstitialHidden", value);
			}
		}

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06001239 RID: 4665 RVA: 0x000164A6 File Offset: 0x000146A6
		// (remove) Token: 0x0600123A RID: 4666 RVA: 0x000164B9 File Offset: 0x000146B9
		public event EventHandler<EventArgs> InterstitialShown
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Page.interstitialShown", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Page.interstitialShown", value);
			}
		}

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x0600123B RID: 4667 RVA: 0x000164CD File Offset: 0x000146CD
		// (remove) Token: 0x0600123C RID: 4668 RVA: 0x000164E0 File Offset: 0x000146E0
		public event EventHandler<JavascriptDialogClosedEventArgs> JavascriptDialogClosed
		{
			add
			{
				this._client.AddEventHandler<JavascriptDialogClosedEventArgs>("Page.javascriptDialogClosed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<JavascriptDialogClosedEventArgs>("Page.javascriptDialogClosed", value);
			}
		}

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x0600123D RID: 4669 RVA: 0x000164F4 File Offset: 0x000146F4
		// (remove) Token: 0x0600123E RID: 4670 RVA: 0x00016507 File Offset: 0x00014707
		public event EventHandler<JavascriptDialogOpeningEventArgs> JavascriptDialogOpening
		{
			add
			{
				this._client.AddEventHandler<JavascriptDialogOpeningEventArgs>("Page.javascriptDialogOpening", value);
			}
			remove
			{
				this._client.RemoveEventHandler<JavascriptDialogOpeningEventArgs>("Page.javascriptDialogOpening", value);
			}
		}

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x0600123F RID: 4671 RVA: 0x0001651B File Offset: 0x0001471B
		// (remove) Token: 0x06001240 RID: 4672 RVA: 0x0001652E File Offset: 0x0001472E
		public event EventHandler<LifecycleEventEventArgs> LifecycleEvent
		{
			add
			{
				this._client.AddEventHandler<LifecycleEventEventArgs>("Page.lifecycleEvent", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LifecycleEventEventArgs>("Page.lifecycleEvent", value);
			}
		}

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x06001241 RID: 4673 RVA: 0x00016542 File Offset: 0x00014742
		// (remove) Token: 0x06001242 RID: 4674 RVA: 0x00016555 File Offset: 0x00014755
		public event EventHandler<BackForwardCacheNotUsedEventArgs> BackForwardCacheNotUsed
		{
			add
			{
				this._client.AddEventHandler<BackForwardCacheNotUsedEventArgs>("Page.backForwardCacheNotUsed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<BackForwardCacheNotUsedEventArgs>("Page.backForwardCacheNotUsed", value);
			}
		}

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x06001243 RID: 4675 RVA: 0x00016569 File Offset: 0x00014769
		// (remove) Token: 0x06001244 RID: 4676 RVA: 0x0001657C File Offset: 0x0001477C
		public event EventHandler<LoadEventFiredEventArgs> LoadEventFired
		{
			add
			{
				this._client.AddEventHandler<LoadEventFiredEventArgs>("Page.loadEventFired", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LoadEventFiredEventArgs>("Page.loadEventFired", value);
			}
		}

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x06001245 RID: 4677 RVA: 0x00016590 File Offset: 0x00014790
		// (remove) Token: 0x06001246 RID: 4678 RVA: 0x000165A3 File Offset: 0x000147A3
		public event EventHandler<NavigatedWithinDocumentEventArgs> NavigatedWithinDocument
		{
			add
			{
				this._client.AddEventHandler<NavigatedWithinDocumentEventArgs>("Page.navigatedWithinDocument", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NavigatedWithinDocumentEventArgs>("Page.navigatedWithinDocument", value);
			}
		}

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x06001247 RID: 4679 RVA: 0x000165B7 File Offset: 0x000147B7
		// (remove) Token: 0x06001248 RID: 4680 RVA: 0x000165CA File Offset: 0x000147CA
		public event EventHandler<ScreencastFrameEventArgs> ScreencastFrame
		{
			add
			{
				this._client.AddEventHandler<ScreencastFrameEventArgs>("Page.screencastFrame", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ScreencastFrameEventArgs>("Page.screencastFrame", value);
			}
		}

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x06001249 RID: 4681 RVA: 0x000165DE File Offset: 0x000147DE
		// (remove) Token: 0x0600124A RID: 4682 RVA: 0x000165F1 File Offset: 0x000147F1
		public event EventHandler<ScreencastVisibilityChangedEventArgs> ScreencastVisibilityChanged
		{
			add
			{
				this._client.AddEventHandler<ScreencastVisibilityChangedEventArgs>("Page.screencastVisibilityChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ScreencastVisibilityChangedEventArgs>("Page.screencastVisibilityChanged", value);
			}
		}

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x0600124B RID: 4683 RVA: 0x00016605 File Offset: 0x00014805
		// (remove) Token: 0x0600124C RID: 4684 RVA: 0x00016618 File Offset: 0x00014818
		public event EventHandler<WindowOpenEventArgs> WindowOpen
		{
			add
			{
				this._client.AddEventHandler<WindowOpenEventArgs>("Page.windowOpen", value);
			}
			remove
			{
				this._client.RemoveEventHandler<WindowOpenEventArgs>("Page.windowOpen", value);
			}
		}

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x0600124D RID: 4685 RVA: 0x0001662C File Offset: 0x0001482C
		// (remove) Token: 0x0600124E RID: 4686 RVA: 0x0001663F File Offset: 0x0001483F
		public event EventHandler<CompilationCacheProducedEventArgs> CompilationCacheProduced
		{
			add
			{
				this._client.AddEventHandler<CompilationCacheProducedEventArgs>("Page.compilationCacheProduced", value);
			}
			remove
			{
				this._client.RemoveEventHandler<CompilationCacheProducedEventArgs>("Page.compilationCacheProduced", value);
			}
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x00016654 File Offset: 0x00014854
		public Task<AddScriptToEvaluateOnNewDocumentResponse> AddScriptToEvaluateOnNewDocumentAsync(string source, string worldName = null, bool? includeCommandLineAPI = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("source", source);
			if (!string.IsNullOrEmpty(worldName))
			{
				dictionary.Add("worldName", worldName);
			}
			if (includeCommandLineAPI != null)
			{
				dictionary.Add("includeCommandLineAPI", includeCommandLineAPI.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<AddScriptToEvaluateOnNewDocumentResponse>("Page.addScriptToEvaluateOnNewDocument", dictionary);
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x000166B8 File Offset: 0x000148B8
		public Task<DevToolsMethodResponse> BringToFrontAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.bringToFront", parameters);
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x000166D8 File Offset: 0x000148D8
		public Task<CaptureScreenshotResponse> CaptureScreenshotAsync(CaptureScreenshotFormat? format = null, int? quality = null, Viewport clip = null, bool? fromSurface = null, bool? captureBeyondViewport = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (format != null)
			{
				dictionary.Add("format", base.EnumToString(format));
			}
			if (quality != null)
			{
				dictionary.Add("quality", quality.Value);
			}
			if (clip != null)
			{
				dictionary.Add("clip", clip.ToDictionary());
			}
			if (fromSurface != null)
			{
				dictionary.Add("fromSurface", fromSurface.Value);
			}
			if (captureBeyondViewport != null)
			{
				dictionary.Add("captureBeyondViewport", captureBeyondViewport.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CaptureScreenshotResponse>("Page.captureScreenshot", dictionary);
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x00016790 File Offset: 0x00014990
		public Task<CaptureSnapshotResponse> CaptureSnapshotAsync(CaptureSnapshotFormat? format = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (format != null)
			{
				dictionary.Add("format", base.EnumToString(format));
			}
			return this._client.ExecuteDevToolsMethodAsync<CaptureSnapshotResponse>("Page.captureSnapshot", dictionary);
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x000167D4 File Offset: 0x000149D4
		public Task<CreateIsolatedWorldResponse> CreateIsolatedWorldAsync(string frameId, string worldName = null, bool? grantUniveralAccess = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			if (!string.IsNullOrEmpty(worldName))
			{
				dictionary.Add("worldName", worldName);
			}
			if (grantUniveralAccess != null)
			{
				dictionary.Add("grantUniveralAccess", grantUniveralAccess.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CreateIsolatedWorldResponse>("Page.createIsolatedWorld", dictionary);
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x00016838 File Offset: 0x00014A38
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.disable", parameters);
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x00016858 File Offset: 0x00014A58
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.enable", parameters);
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x00016878 File Offset: 0x00014A78
		public Task<GetAppManifestResponse> GetAppManifestAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetAppManifestResponse>("Page.getAppManifest", parameters);
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x00016898 File Offset: 0x00014A98
		public Task<GetInstallabilityErrorsResponse> GetInstallabilityErrorsAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetInstallabilityErrorsResponse>("Page.getInstallabilityErrors", parameters);
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x000168B8 File Offset: 0x00014AB8
		public Task<GetManifestIconsResponse> GetManifestIconsAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetManifestIconsResponse>("Page.getManifestIcons", parameters);
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x000168D8 File Offset: 0x00014AD8
		public Task<GetAppIdResponse> GetAppIdAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetAppIdResponse>("Page.getAppId", parameters);
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x000168F8 File Offset: 0x00014AF8
		public Task<GetFrameTreeResponse> GetFrameTreeAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetFrameTreeResponse>("Page.getFrameTree", parameters);
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x00016918 File Offset: 0x00014B18
		public Task<GetLayoutMetricsResponse> GetLayoutMetricsAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetLayoutMetricsResponse>("Page.getLayoutMetrics", parameters);
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x00016938 File Offset: 0x00014B38
		public Task<GetNavigationHistoryResponse> GetNavigationHistoryAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetNavigationHistoryResponse>("Page.getNavigationHistory", parameters);
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x00016958 File Offset: 0x00014B58
		public Task<DevToolsMethodResponse> ResetNavigationHistoryAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.resetNavigationHistory", parameters);
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00016978 File Offset: 0x00014B78
		public Task<GetResourceContentResponse> GetResourceContentAsync(string frameId, string url)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			dictionary.Add("url", url);
			return this._client.ExecuteDevToolsMethodAsync<GetResourceContentResponse>("Page.getResourceContent", dictionary);
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000169B4 File Offset: 0x00014BB4
		public Task<GetResourceTreeResponse> GetResourceTreeAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetResourceTreeResponse>("Page.getResourceTree", parameters);
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x000169D4 File Offset: 0x00014BD4
		public Task<DevToolsMethodResponse> HandleJavaScriptDialogAsync(bool accept, string promptText = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("accept", accept);
			if (!string.IsNullOrEmpty(promptText))
			{
				dictionary.Add("promptText", promptText);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.handleJavaScriptDialog", dictionary);
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00016A20 File Offset: 0x00014C20
		public Task<NavigateResponse> NavigateAsync(string url, string referrer = null, TransitionType? transitionType = null, string frameId = null, ReferrerPolicy? referrerPolicy = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("url", url);
			if (!string.IsNullOrEmpty(referrer))
			{
				dictionary.Add("referrer", referrer);
			}
			if (transitionType != null)
			{
				dictionary.Add("transitionType", base.EnumToString(transitionType));
			}
			if (!string.IsNullOrEmpty(frameId))
			{
				dictionary.Add("frameId", frameId);
			}
			if (referrerPolicy != null)
			{
				dictionary.Add("referrerPolicy", base.EnumToString(referrerPolicy));
			}
			return this._client.ExecuteDevToolsMethodAsync<NavigateResponse>("Page.navigate", dictionary);
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00016ABC File Offset: 0x00014CBC
		public Task<DevToolsMethodResponse> NavigateToHistoryEntryAsync(int entryId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("entryId", entryId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.navigateToHistoryEntry", dictionary);
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00016AF4 File Offset: 0x00014CF4
		public Task<PrintToPDFResponse> PrintToPDFAsync(bool? landscape = null, bool? displayHeaderFooter = null, bool? printBackground = null, double? scale = null, double? paperWidth = null, double? paperHeight = null, double? marginTop = null, double? marginBottom = null, double? marginLeft = null, double? marginRight = null, string pageRanges = null, bool? ignoreInvalidPageRanges = null, string headerTemplate = null, string footerTemplate = null, bool? preferCSSPageSize = null, PrintToPDFTransferMode? transferMode = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (landscape != null)
			{
				dictionary.Add("landscape", landscape.Value);
			}
			if (displayHeaderFooter != null)
			{
				dictionary.Add("displayHeaderFooter", displayHeaderFooter.Value);
			}
			if (printBackground != null)
			{
				dictionary.Add("printBackground", printBackground.Value);
			}
			if (scale != null)
			{
				dictionary.Add("scale", scale.Value);
			}
			if (paperWidth != null)
			{
				dictionary.Add("paperWidth", paperWidth.Value);
			}
			if (paperHeight != null)
			{
				dictionary.Add("paperHeight", paperHeight.Value);
			}
			if (marginTop != null)
			{
				dictionary.Add("marginTop", marginTop.Value);
			}
			if (marginBottom != null)
			{
				dictionary.Add("marginBottom", marginBottom.Value);
			}
			if (marginLeft != null)
			{
				dictionary.Add("marginLeft", marginLeft.Value);
			}
			if (marginRight != null)
			{
				dictionary.Add("marginRight", marginRight.Value);
			}
			if (!string.IsNullOrEmpty(pageRanges))
			{
				dictionary.Add("pageRanges", pageRanges);
			}
			if (ignoreInvalidPageRanges != null)
			{
				dictionary.Add("ignoreInvalidPageRanges", ignoreInvalidPageRanges.Value);
			}
			if (!string.IsNullOrEmpty(headerTemplate))
			{
				dictionary.Add("headerTemplate", headerTemplate);
			}
			if (!string.IsNullOrEmpty(footerTemplate))
			{
				dictionary.Add("footerTemplate", footerTemplate);
			}
			if (preferCSSPageSize != null)
			{
				dictionary.Add("preferCSSPageSize", preferCSSPageSize.Value);
			}
			if (transferMode != null)
			{
				dictionary.Add("transferMode", base.EnumToString(transferMode));
			}
			return this._client.ExecuteDevToolsMethodAsync<PrintToPDFResponse>("Page.printToPDF", dictionary);
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x00016CFC File Offset: 0x00014EFC
		public Task<DevToolsMethodResponse> ReloadAsync(bool? ignoreCache = null, string scriptToEvaluateOnLoad = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (ignoreCache != null)
			{
				dictionary.Add("ignoreCache", ignoreCache.Value);
			}
			if (!string.IsNullOrEmpty(scriptToEvaluateOnLoad))
			{
				dictionary.Add("scriptToEvaluateOnLoad", scriptToEvaluateOnLoad);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.reload", dictionary);
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x00016D54 File Offset: 0x00014F54
		public Task<DevToolsMethodResponse> RemoveScriptToEvaluateOnNewDocumentAsync(string identifier)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("identifier", identifier);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.removeScriptToEvaluateOnNewDocument", dictionary);
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x00016D84 File Offset: 0x00014F84
		public Task<DevToolsMethodResponse> ScreencastFrameAckAsync(int sessionId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("sessionId", sessionId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.screencastFrameAck", dictionary);
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00016DBC File Offset: 0x00014FBC
		public Task<SearchInResourceResponse> SearchInResourceAsync(string frameId, string url, string query, bool? caseSensitive = null, bool? isRegex = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			dictionary.Add("url", url);
			dictionary.Add("query", query);
			if (caseSensitive != null)
			{
				dictionary.Add("caseSensitive", caseSensitive.Value);
			}
			if (isRegex != null)
			{
				dictionary.Add("isRegex", isRegex.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<SearchInResourceResponse>("Page.searchInResource", dictionary);
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x00016E44 File Offset: 0x00015044
		public Task<DevToolsMethodResponse> SetAdBlockingEnabledAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setAdBlockingEnabled", dictionary);
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00016E7C File Offset: 0x0001507C
		public Task<DevToolsMethodResponse> SetBypassCSPAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setBypassCSP", dictionary);
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00016EB4 File Offset: 0x000150B4
		public Task<GetPermissionsPolicyStateResponse> GetPermissionsPolicyStateAsync(string frameId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			return this._client.ExecuteDevToolsMethodAsync<GetPermissionsPolicyStateResponse>("Page.getPermissionsPolicyState", dictionary);
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x00016EE4 File Offset: 0x000150E4
		public Task<GetOriginTrialsResponse> GetOriginTrialsAsync(string frameId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			return this._client.ExecuteDevToolsMethodAsync<GetOriginTrialsResponse>("Page.getOriginTrials", dictionary);
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x00016F14 File Offset: 0x00015114
		public Task<DevToolsMethodResponse> SetFontFamiliesAsync(FontFamilies fontFamilies, IList<ScriptFontFamilies> forScripts = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("fontFamilies", fontFamilies.ToDictionary());
			if (forScripts != null)
			{
				dictionary.Add("forScripts", from x in forScripts
				select x.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setFontFamilies", dictionary);
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x00016F7C File Offset: 0x0001517C
		public Task<DevToolsMethodResponse> SetFontSizesAsync(FontSizes fontSizes)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("fontSizes", fontSizes.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setFontSizes", dictionary);
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x00016FB4 File Offset: 0x000151B4
		public Task<DevToolsMethodResponse> SetDocumentContentAsync(string frameId, string html)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			dictionary.Add("html", html);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setDocumentContent", dictionary);
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x00016FF0 File Offset: 0x000151F0
		public Task<DevToolsMethodResponse> SetLifecycleEventsEnabledAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setLifecycleEventsEnabled", dictionary);
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x00017028 File Offset: 0x00015228
		public Task<DevToolsMethodResponse> StartScreencastAsync(StartScreencastFormat? format = null, int? quality = null, int? maxWidth = null, int? maxHeight = null, int? everyNthFrame = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (format != null)
			{
				dictionary.Add("format", base.EnumToString(format));
			}
			if (quality != null)
			{
				dictionary.Add("quality", quality.Value);
			}
			if (maxWidth != null)
			{
				dictionary.Add("maxWidth", maxWidth.Value);
			}
			if (maxHeight != null)
			{
				dictionary.Add("maxHeight", maxHeight.Value);
			}
			if (everyNthFrame != null)
			{
				dictionary.Add("everyNthFrame", everyNthFrame.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.startScreencast", dictionary);
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x000170EC File Offset: 0x000152EC
		public Task<DevToolsMethodResponse> StopLoadingAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.stopLoading", parameters);
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x0001710C File Offset: 0x0001530C
		public Task<DevToolsMethodResponse> CrashAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.crash", parameters);
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x0001712C File Offset: 0x0001532C
		public Task<DevToolsMethodResponse> CloseAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.close", parameters);
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x0001714C File Offset: 0x0001534C
		public Task<DevToolsMethodResponse> SetWebLifecycleStateAsync(SetWebLifecycleStateState state)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("state", base.EnumToString(state));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setWebLifecycleState", dictionary);
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x00017188 File Offset: 0x00015388
		public Task<DevToolsMethodResponse> StopScreencastAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.stopScreencast", parameters);
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x000171A8 File Offset: 0x000153A8
		public Task<DevToolsMethodResponse> ProduceCompilationCacheAsync(IList<CompilationCacheParams> scripts)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scripts", from x in scripts
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.produceCompilationCache", dictionary);
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x000171FC File Offset: 0x000153FC
		public Task<DevToolsMethodResponse> AddCompilationCacheAsync(string url, byte[] data)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("url", url);
			dictionary.Add("data", base.ToBase64String(data));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.addCompilationCache", dictionary);
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x00017240 File Offset: 0x00015440
		public Task<DevToolsMethodResponse> ClearCompilationCacheAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.clearCompilationCache", parameters);
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00017260 File Offset: 0x00015460
		public Task<DevToolsMethodResponse> SetSPCTransactionModeAsync(SetSPCTransactionModeMode mode)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("mode", base.EnumToString(mode));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setSPCTransactionMode", dictionary);
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x0001729C File Offset: 0x0001549C
		public Task<DevToolsMethodResponse> GenerateTestReportAsync(string message, string group = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("message", message);
			if (!string.IsNullOrEmpty(group))
			{
				dictionary.Add("group", group);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.generateTestReport", dictionary);
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x000172E0 File Offset: 0x000154E0
		public Task<DevToolsMethodResponse> WaitForDebuggerAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.waitForDebugger", parameters);
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x00017300 File Offset: 0x00015500
		public Task<DevToolsMethodResponse> SetInterceptFileChooserDialogAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Page.setInterceptFileChooserDialog", dictionary);
		}

		// Token: 0x04000A24 RID: 2596
		private IDevToolsClient _client;
	}
}
