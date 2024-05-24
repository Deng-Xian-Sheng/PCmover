using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003EF RID: 1007
	public class CSSClient : DevToolsDomainBase
	{
		// Token: 0x06001D5B RID: 7515 RVA: 0x00021754 File Offset: 0x0001F954
		public CSSClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000AA RID: 170
		// (add) Token: 0x06001D5C RID: 7516 RVA: 0x00021763 File Offset: 0x0001F963
		// (remove) Token: 0x06001D5D RID: 7517 RVA: 0x00021776 File Offset: 0x0001F976
		public event EventHandler<FontsUpdatedEventArgs> FontsUpdated
		{
			add
			{
				this._client.AddEventHandler<FontsUpdatedEventArgs>("CSS.fontsUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<FontsUpdatedEventArgs>("CSS.fontsUpdated", value);
			}
		}

		// Token: 0x140000AB RID: 171
		// (add) Token: 0x06001D5E RID: 7518 RVA: 0x0002178A File Offset: 0x0001F98A
		// (remove) Token: 0x06001D5F RID: 7519 RVA: 0x0002179D File Offset: 0x0001F99D
		public event EventHandler<EventArgs> MediaQueryResultChanged
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("CSS.mediaQueryResultChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("CSS.mediaQueryResultChanged", value);
			}
		}

		// Token: 0x140000AC RID: 172
		// (add) Token: 0x06001D60 RID: 7520 RVA: 0x000217B1 File Offset: 0x0001F9B1
		// (remove) Token: 0x06001D61 RID: 7521 RVA: 0x000217C4 File Offset: 0x0001F9C4
		public event EventHandler<StyleSheetAddedEventArgs> StyleSheetAdded
		{
			add
			{
				this._client.AddEventHandler<StyleSheetAddedEventArgs>("CSS.styleSheetAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<StyleSheetAddedEventArgs>("CSS.styleSheetAdded", value);
			}
		}

		// Token: 0x140000AD RID: 173
		// (add) Token: 0x06001D62 RID: 7522 RVA: 0x000217D8 File Offset: 0x0001F9D8
		// (remove) Token: 0x06001D63 RID: 7523 RVA: 0x000217EB File Offset: 0x0001F9EB
		public event EventHandler<StyleSheetChangedEventArgs> StyleSheetChanged
		{
			add
			{
				this._client.AddEventHandler<StyleSheetChangedEventArgs>("CSS.styleSheetChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<StyleSheetChangedEventArgs>("CSS.styleSheetChanged", value);
			}
		}

		// Token: 0x140000AE RID: 174
		// (add) Token: 0x06001D64 RID: 7524 RVA: 0x000217FF File Offset: 0x0001F9FF
		// (remove) Token: 0x06001D65 RID: 7525 RVA: 0x00021812 File Offset: 0x0001FA12
		public event EventHandler<StyleSheetRemovedEventArgs> StyleSheetRemoved
		{
			add
			{
				this._client.AddEventHandler<StyleSheetRemovedEventArgs>("CSS.styleSheetRemoved", value);
			}
			remove
			{
				this._client.RemoveEventHandler<StyleSheetRemovedEventArgs>("CSS.styleSheetRemoved", value);
			}
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x00021828 File Offset: 0x0001FA28
		public Task<AddRuleResponse> AddRuleAsync(string styleSheetId, string ruleText, SourceRange location)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("ruleText", ruleText);
			dictionary.Add("location", location.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<AddRuleResponse>("CSS.addRule", dictionary);
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x00021878 File Offset: 0x0001FA78
		public Task<CollectClassNamesResponse> CollectClassNamesAsync(string styleSheetId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			return this._client.ExecuteDevToolsMethodAsync<CollectClassNamesResponse>("CSS.collectClassNames", dictionary);
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x000218A8 File Offset: 0x0001FAA8
		public Task<CreateStyleSheetResponse> CreateStyleSheetAsync(string frameId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			return this._client.ExecuteDevToolsMethodAsync<CreateStyleSheetResponse>("CSS.createStyleSheet", dictionary);
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x000218D8 File Offset: 0x0001FAD8
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.disable", parameters);
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x000218F8 File Offset: 0x0001FAF8
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.enable", parameters);
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x00021918 File Offset: 0x0001FB18
		public Task<DevToolsMethodResponse> ForcePseudoStateAsync(int nodeId, string[] forcedPseudoClasses)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("forcedPseudoClasses", forcedPseudoClasses);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.forcePseudoState", dictionary);
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x0002195C File Offset: 0x0001FB5C
		public Task<GetBackgroundColorsResponse> GetBackgroundColorsAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetBackgroundColorsResponse>("CSS.getBackgroundColors", dictionary);
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x00021994 File Offset: 0x0001FB94
		public Task<GetComputedStyleForNodeResponse> GetComputedStyleForNodeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetComputedStyleForNodeResponse>("CSS.getComputedStyleForNode", dictionary);
		}

		// Token: 0x06001D6E RID: 7534 RVA: 0x000219CC File Offset: 0x0001FBCC
		public Task<GetInlineStylesForNodeResponse> GetInlineStylesForNodeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetInlineStylesForNodeResponse>("CSS.getInlineStylesForNode", dictionary);
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x00021A04 File Offset: 0x0001FC04
		public Task<GetMatchedStylesForNodeResponse> GetMatchedStylesForNodeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetMatchedStylesForNodeResponse>("CSS.getMatchedStylesForNode", dictionary);
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x00021A3C File Offset: 0x0001FC3C
		public Task<GetMediaQueriesResponse> GetMediaQueriesAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetMediaQueriesResponse>("CSS.getMediaQueries", parameters);
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x00021A5C File Offset: 0x0001FC5C
		public Task<GetPlatformFontsForNodeResponse> GetPlatformFontsForNodeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetPlatformFontsForNodeResponse>("CSS.getPlatformFontsForNode", dictionary);
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x00021A94 File Offset: 0x0001FC94
		public Task<GetStyleSheetTextResponse> GetStyleSheetTextAsync(string styleSheetId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			return this._client.ExecuteDevToolsMethodAsync<GetStyleSheetTextResponse>("CSS.getStyleSheetText", dictionary);
		}

		// Token: 0x06001D73 RID: 7539 RVA: 0x00021AC4 File Offset: 0x0001FCC4
		public Task<DevToolsMethodResponse> TrackComputedStyleUpdatesAsync(IList<CSSComputedStyleProperty> propertiesToTrack)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("propertiesToTrack", from x in propertiesToTrack
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.trackComputedStyleUpdates", dictionary);
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x00021B18 File Offset: 0x0001FD18
		public Task<TakeComputedStyleUpdatesResponse> TakeComputedStyleUpdatesAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<TakeComputedStyleUpdatesResponse>("CSS.takeComputedStyleUpdates", parameters);
		}

		// Token: 0x06001D75 RID: 7541 RVA: 0x00021B38 File Offset: 0x0001FD38
		public Task<DevToolsMethodResponse> SetEffectivePropertyValueForNodeAsync(int nodeId, string propertyName, string value)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("propertyName", propertyName);
			dictionary.Add("value", value);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.setEffectivePropertyValueForNode", dictionary);
		}

		// Token: 0x06001D76 RID: 7542 RVA: 0x00021B88 File Offset: 0x0001FD88
		public Task<SetKeyframeKeyResponse> SetKeyframeKeyAsync(string styleSheetId, SourceRange range, string keyText)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("range", range.ToDictionary());
			dictionary.Add("keyText", keyText);
			return this._client.ExecuteDevToolsMethodAsync<SetKeyframeKeyResponse>("CSS.setKeyframeKey", dictionary);
		}

		// Token: 0x06001D77 RID: 7543 RVA: 0x00021BD8 File Offset: 0x0001FDD8
		public Task<SetMediaTextResponse> SetMediaTextAsync(string styleSheetId, SourceRange range, string text)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("range", range.ToDictionary());
			dictionary.Add("text", text);
			return this._client.ExecuteDevToolsMethodAsync<SetMediaTextResponse>("CSS.setMediaText", dictionary);
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x00021C28 File Offset: 0x0001FE28
		public Task<SetContainerQueryTextResponse> SetContainerQueryTextAsync(string styleSheetId, SourceRange range, string text)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("range", range.ToDictionary());
			dictionary.Add("text", text);
			return this._client.ExecuteDevToolsMethodAsync<SetContainerQueryTextResponse>("CSS.setContainerQueryText", dictionary);
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x00021C78 File Offset: 0x0001FE78
		public Task<SetSupportsTextResponse> SetSupportsTextAsync(string styleSheetId, SourceRange range, string text)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("range", range.ToDictionary());
			dictionary.Add("text", text);
			return this._client.ExecuteDevToolsMethodAsync<SetSupportsTextResponse>("CSS.setSupportsText", dictionary);
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x00021CC8 File Offset: 0x0001FEC8
		public Task<SetRuleSelectorResponse> SetRuleSelectorAsync(string styleSheetId, SourceRange range, string selector)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("range", range.ToDictionary());
			dictionary.Add("selector", selector);
			return this._client.ExecuteDevToolsMethodAsync<SetRuleSelectorResponse>("CSS.setRuleSelector", dictionary);
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x00021D18 File Offset: 0x0001FF18
		public Task<SetStyleSheetTextResponse> SetStyleSheetTextAsync(string styleSheetId, string text)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("styleSheetId", styleSheetId);
			dictionary.Add("text", text);
			return this._client.ExecuteDevToolsMethodAsync<SetStyleSheetTextResponse>("CSS.setStyleSheetText", dictionary);
		}

		// Token: 0x06001D7C RID: 7548 RVA: 0x00021D54 File Offset: 0x0001FF54
		public Task<SetStyleTextsResponse> SetStyleTextsAsync(IList<StyleDeclarationEdit> edits)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("edits", from x in edits
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<SetStyleTextsResponse>("CSS.setStyleTexts", dictionary);
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x00021DA8 File Offset: 0x0001FFA8
		public Task<DevToolsMethodResponse> StartRuleUsageTrackingAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.startRuleUsageTracking", parameters);
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x00021DC8 File Offset: 0x0001FFC8
		public Task<StopRuleUsageTrackingResponse> StopRuleUsageTrackingAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<StopRuleUsageTrackingResponse>("CSS.stopRuleUsageTracking", parameters);
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x00021DE8 File Offset: 0x0001FFE8
		public Task<TakeCoverageDeltaResponse> TakeCoverageDeltaAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<TakeCoverageDeltaResponse>("CSS.takeCoverageDelta", parameters);
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x00021E08 File Offset: 0x00020008
		public Task<DevToolsMethodResponse> SetLocalFontsEnabledAsync(bool enabled)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enabled", enabled);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CSS.setLocalFontsEnabled", dictionary);
		}

		// Token: 0x04000F94 RID: 3988
		private IDevToolsClient _client;
	}
}
