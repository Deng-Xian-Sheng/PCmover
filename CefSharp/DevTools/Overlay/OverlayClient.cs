using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x020002A5 RID: 677
	public class OverlayClient : DevToolsDomainBase
	{
		// Token: 0x06001344 RID: 4932 RVA: 0x00017A1E File Offset: 0x00015C1E
		public OverlayClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x06001345 RID: 4933 RVA: 0x00017A2D File Offset: 0x00015C2D
		// (remove) Token: 0x06001346 RID: 4934 RVA: 0x00017A40 File Offset: 0x00015C40
		public event EventHandler<InspectNodeRequestedEventArgs> InspectNodeRequested
		{
			add
			{
				this._client.AddEventHandler<InspectNodeRequestedEventArgs>("Overlay.inspectNodeRequested", value);
			}
			remove
			{
				this._client.RemoveEventHandler<InspectNodeRequestedEventArgs>("Overlay.inspectNodeRequested", value);
			}
		}

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x06001347 RID: 4935 RVA: 0x00017A54 File Offset: 0x00015C54
		// (remove) Token: 0x06001348 RID: 4936 RVA: 0x00017A67 File Offset: 0x00015C67
		public event EventHandler<NodeHighlightRequestedEventArgs> NodeHighlightRequested
		{
			add
			{
				this._client.AddEventHandler<NodeHighlightRequestedEventArgs>("Overlay.nodeHighlightRequested", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NodeHighlightRequestedEventArgs>("Overlay.nodeHighlightRequested", value);
			}
		}

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x06001349 RID: 4937 RVA: 0x00017A7B File Offset: 0x00015C7B
		// (remove) Token: 0x0600134A RID: 4938 RVA: 0x00017A8E File Offset: 0x00015C8E
		public event EventHandler<ScreenshotRequestedEventArgs> ScreenshotRequested
		{
			add
			{
				this._client.AddEventHandler<ScreenshotRequestedEventArgs>("Overlay.screenshotRequested", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ScreenshotRequestedEventArgs>("Overlay.screenshotRequested", value);
			}
		}

		// Token: 0x1400006F RID: 111
		// (add) Token: 0x0600134B RID: 4939 RVA: 0x00017AA2 File Offset: 0x00015CA2
		// (remove) Token: 0x0600134C RID: 4940 RVA: 0x00017AB5 File Offset: 0x00015CB5
		public event EventHandler<EventArgs> InspectModeCanceled
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Overlay.inspectModeCanceled", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Overlay.inspectModeCanceled", value);
			}
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x00017ACC File Offset: 0x00015CCC
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.disable", parameters);
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x00017AEC File Offset: 0x00015CEC
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.enable", parameters);
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x00017B0C File Offset: 0x00015D0C
		public Task<GetHighlightObjectForTestResponse> GetHighlightObjectForTestAsync(int nodeId, bool? includeDistance = null, bool? includeStyle = null, ColorFormat? colorFormat = null, bool? showAccessibilityInfo = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			if (includeDistance != null)
			{
				dictionary.Add("includeDistance", includeDistance.Value);
			}
			if (includeStyle != null)
			{
				dictionary.Add("includeStyle", includeStyle.Value);
			}
			if (colorFormat != null)
			{
				dictionary.Add("colorFormat", base.EnumToString(colorFormat));
			}
			if (showAccessibilityInfo != null)
			{
				dictionary.Add("showAccessibilityInfo", showAccessibilityInfo.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetHighlightObjectForTestResponse>("Overlay.getHighlightObjectForTest", dictionary);
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x00017BC4 File Offset: 0x00015DC4
		public Task<GetGridHighlightObjectsForTestResponse> GetGridHighlightObjectsForTestAsync(int[] nodeIds)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeIds", nodeIds);
			return this._client.ExecuteDevToolsMethodAsync<GetGridHighlightObjectsForTestResponse>("Overlay.getGridHighlightObjectsForTest", dictionary);
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x00017BF4 File Offset: 0x00015DF4
		public Task<GetSourceOrderHighlightObjectForTestResponse> GetSourceOrderHighlightObjectForTestAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetSourceOrderHighlightObjectForTestResponse>("Overlay.getSourceOrderHighlightObjectForTest", dictionary);
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x00017C2C File Offset: 0x00015E2C
		public Task<DevToolsMethodResponse> HideHighlightAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.hideHighlight", parameters);
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x00017C4C File Offset: 0x00015E4C
		public Task<DevToolsMethodResponse> HighlightNodeAsync(HighlightConfig highlightConfig, int? nodeId = null, int? backendNodeId = null, string objectId = null, string selector = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("highlightConfig", highlightConfig.ToDictionary());
			if (nodeId != null)
			{
				dictionary.Add("nodeId", nodeId.Value);
			}
			if (backendNodeId != null)
			{
				dictionary.Add("backendNodeId", backendNodeId.Value);
			}
			if (!string.IsNullOrEmpty(objectId))
			{
				dictionary.Add("objectId", objectId);
			}
			if (!string.IsNullOrEmpty(selector))
			{
				dictionary.Add("selector", selector);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.highlightNode", dictionary);
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x00017CF0 File Offset: 0x00015EF0
		public Task<DevToolsMethodResponse> HighlightQuadAsync(double[] quad, RGBA color = null, RGBA outlineColor = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("quad", quad);
			if (color != null)
			{
				dictionary.Add("color", color.ToDictionary());
			}
			if (outlineColor != null)
			{
				dictionary.Add("outlineColor", outlineColor.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.highlightQuad", dictionary);
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x00017D48 File Offset: 0x00015F48
		public Task<DevToolsMethodResponse> HighlightRectAsync(int x, int y, int width, int height, RGBA color = null, RGBA outlineColor = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			dictionary.Add("width", width);
			dictionary.Add("height", height);
			if (color != null)
			{
				dictionary.Add("color", color.ToDictionary());
			}
			if (outlineColor != null)
			{
				dictionary.Add("outlineColor", outlineColor.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.highlightRect", dictionary);
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x00017DE0 File Offset: 0x00015FE0
		public Task<DevToolsMethodResponse> HighlightSourceOrderAsync(SourceOrderConfig sourceOrderConfig, int? nodeId = null, int? backendNodeId = null, string objectId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("sourceOrderConfig", sourceOrderConfig.ToDictionary());
			if (nodeId != null)
			{
				dictionary.Add("nodeId", nodeId.Value);
			}
			if (backendNodeId != null)
			{
				dictionary.Add("backendNodeId", backendNodeId.Value);
			}
			if (!string.IsNullOrEmpty(objectId))
			{
				dictionary.Add("objectId", objectId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.highlightSourceOrder", dictionary);
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x00017E6C File Offset: 0x0001606C
		public Task<DevToolsMethodResponse> SetInspectModeAsync(InspectMode mode, HighlightConfig highlightConfig = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("mode", base.EnumToString(mode));
			if (highlightConfig != null)
			{
				dictionary.Add("highlightConfig", highlightConfig.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setInspectMode", dictionary);
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x00017EBC File Offset: 0x000160BC
		public Task<DevToolsMethodResponse> SetShowAdHighlightsAsync(bool show)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("show", show);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowAdHighlights", dictionary);
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x00017EF4 File Offset: 0x000160F4
		public Task<DevToolsMethodResponse> SetPausedInDebuggerMessageAsync(string message = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(message))
			{
				dictionary.Add("message", message);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setPausedInDebuggerMessage", dictionary);
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x00017F2C File Offset: 0x0001612C
		public Task<DevToolsMethodResponse> SetShowDebugBordersAsync(bool show)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("show", show);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowDebugBorders", dictionary);
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x00017F64 File Offset: 0x00016164
		public Task<DevToolsMethodResponse> SetShowFPSCounterAsync(bool show)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("show", show);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowFPSCounter", dictionary);
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x00017F9C File Offset: 0x0001619C
		public Task<DevToolsMethodResponse> SetShowGridOverlaysAsync(IList<GridNodeHighlightConfig> gridNodeHighlightConfigs)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("gridNodeHighlightConfigs", from x in gridNodeHighlightConfigs
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowGridOverlays", dictionary);
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00017FF0 File Offset: 0x000161F0
		public Task<DevToolsMethodResponse> SetShowFlexOverlaysAsync(IList<FlexNodeHighlightConfig> flexNodeHighlightConfigs)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("flexNodeHighlightConfigs", from x in flexNodeHighlightConfigs
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowFlexOverlays", dictionary);
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x00018044 File Offset: 0x00016244
		public Task<DevToolsMethodResponse> SetShowScrollSnapOverlaysAsync(IList<ScrollSnapHighlightConfig> scrollSnapHighlightConfigs)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("scrollSnapHighlightConfigs", from x in scrollSnapHighlightConfigs
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowScrollSnapOverlays", dictionary);
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x00018098 File Offset: 0x00016298
		public Task<DevToolsMethodResponse> SetShowContainerQueryOverlaysAsync(IList<ContainerQueryHighlightConfig> containerQueryHighlightConfigs)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("containerQueryHighlightConfigs", from x in containerQueryHighlightConfigs
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowContainerQueryOverlays", dictionary);
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x000180EC File Offset: 0x000162EC
		public Task<DevToolsMethodResponse> SetShowPaintRectsAsync(bool result)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("result", result);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowPaintRects", dictionary);
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x00018124 File Offset: 0x00016324
		public Task<DevToolsMethodResponse> SetShowLayoutShiftRegionsAsync(bool result)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("result", result);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowLayoutShiftRegions", dictionary);
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x0001815C File Offset: 0x0001635C
		public Task<DevToolsMethodResponse> SetShowScrollBottleneckRectsAsync(bool show)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("show", show);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowScrollBottleneckRects", dictionary);
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x00018194 File Offset: 0x00016394
		public Task<DevToolsMethodResponse> SetShowWebVitalsAsync(bool show)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("show", show);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowWebVitals", dictionary);
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x000181CC File Offset: 0x000163CC
		public Task<DevToolsMethodResponse> SetShowViewportSizeOnResizeAsync(bool show)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("show", show);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowViewportSizeOnResize", dictionary);
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x00018204 File Offset: 0x00016404
		public Task<DevToolsMethodResponse> SetShowHingeAsync(HingeConfig hingeConfig = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (hingeConfig != null)
			{
				dictionary.Add("hingeConfig", hingeConfig.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowHinge", dictionary);
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x0001823C File Offset: 0x0001643C
		public Task<DevToolsMethodResponse> SetShowIsolatedElementsAsync(IList<IsolatedElementHighlightConfig> isolatedElementHighlightConfigs)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("isolatedElementHighlightConfigs", from x in isolatedElementHighlightConfigs
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Overlay.setShowIsolatedElements", dictionary);
		}

		// Token: 0x04000A8A RID: 2698
		private IDevToolsClient _client;
	}
}
