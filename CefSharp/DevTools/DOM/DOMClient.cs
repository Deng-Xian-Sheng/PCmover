using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003AF RID: 943
	public class DOMClient : DevToolsDomainBase
	{
		// Token: 0x06001B53 RID: 6995 RVA: 0x0001F526 File Offset: 0x0001D726
		public DOMClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400009A RID: 154
		// (add) Token: 0x06001B54 RID: 6996 RVA: 0x0001F535 File Offset: 0x0001D735
		// (remove) Token: 0x06001B55 RID: 6997 RVA: 0x0001F548 File Offset: 0x0001D748
		public event EventHandler<AttributeModifiedEventArgs> AttributeModified
		{
			add
			{
				this._client.AddEventHandler<AttributeModifiedEventArgs>("DOM.attributeModified", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AttributeModifiedEventArgs>("DOM.attributeModified", value);
			}
		}

		// Token: 0x1400009B RID: 155
		// (add) Token: 0x06001B56 RID: 6998 RVA: 0x0001F55C File Offset: 0x0001D75C
		// (remove) Token: 0x06001B57 RID: 6999 RVA: 0x0001F56F File Offset: 0x0001D76F
		public event EventHandler<AttributeRemovedEventArgs> AttributeRemoved
		{
			add
			{
				this._client.AddEventHandler<AttributeRemovedEventArgs>("DOM.attributeRemoved", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AttributeRemovedEventArgs>("DOM.attributeRemoved", value);
			}
		}

		// Token: 0x1400009C RID: 156
		// (add) Token: 0x06001B58 RID: 7000 RVA: 0x0001F583 File Offset: 0x0001D783
		// (remove) Token: 0x06001B59 RID: 7001 RVA: 0x0001F596 File Offset: 0x0001D796
		public event EventHandler<CharacterDataModifiedEventArgs> CharacterDataModified
		{
			add
			{
				this._client.AddEventHandler<CharacterDataModifiedEventArgs>("DOM.characterDataModified", value);
			}
			remove
			{
				this._client.RemoveEventHandler<CharacterDataModifiedEventArgs>("DOM.characterDataModified", value);
			}
		}

		// Token: 0x1400009D RID: 157
		// (add) Token: 0x06001B5A RID: 7002 RVA: 0x0001F5AA File Offset: 0x0001D7AA
		// (remove) Token: 0x06001B5B RID: 7003 RVA: 0x0001F5BD File Offset: 0x0001D7BD
		public event EventHandler<ChildNodeCountUpdatedEventArgs> ChildNodeCountUpdated
		{
			add
			{
				this._client.AddEventHandler<ChildNodeCountUpdatedEventArgs>("DOM.childNodeCountUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ChildNodeCountUpdatedEventArgs>("DOM.childNodeCountUpdated", value);
			}
		}

		// Token: 0x1400009E RID: 158
		// (add) Token: 0x06001B5C RID: 7004 RVA: 0x0001F5D1 File Offset: 0x0001D7D1
		// (remove) Token: 0x06001B5D RID: 7005 RVA: 0x0001F5E4 File Offset: 0x0001D7E4
		public event EventHandler<ChildNodeInsertedEventArgs> ChildNodeInserted
		{
			add
			{
				this._client.AddEventHandler<ChildNodeInsertedEventArgs>("DOM.childNodeInserted", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ChildNodeInsertedEventArgs>("DOM.childNodeInserted", value);
			}
		}

		// Token: 0x1400009F RID: 159
		// (add) Token: 0x06001B5E RID: 7006 RVA: 0x0001F5F8 File Offset: 0x0001D7F8
		// (remove) Token: 0x06001B5F RID: 7007 RVA: 0x0001F60B File Offset: 0x0001D80B
		public event EventHandler<ChildNodeRemovedEventArgs> ChildNodeRemoved
		{
			add
			{
				this._client.AddEventHandler<ChildNodeRemovedEventArgs>("DOM.childNodeRemoved", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ChildNodeRemovedEventArgs>("DOM.childNodeRemoved", value);
			}
		}

		// Token: 0x140000A0 RID: 160
		// (add) Token: 0x06001B60 RID: 7008 RVA: 0x0001F61F File Offset: 0x0001D81F
		// (remove) Token: 0x06001B61 RID: 7009 RVA: 0x0001F632 File Offset: 0x0001D832
		public event EventHandler<DistributedNodesUpdatedEventArgs> DistributedNodesUpdated
		{
			add
			{
				this._client.AddEventHandler<DistributedNodesUpdatedEventArgs>("DOM.distributedNodesUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DistributedNodesUpdatedEventArgs>("DOM.distributedNodesUpdated", value);
			}
		}

		// Token: 0x140000A1 RID: 161
		// (add) Token: 0x06001B62 RID: 7010 RVA: 0x0001F646 File Offset: 0x0001D846
		// (remove) Token: 0x06001B63 RID: 7011 RVA: 0x0001F659 File Offset: 0x0001D859
		public event EventHandler<EventArgs> DocumentUpdated
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("DOM.documentUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("DOM.documentUpdated", value);
			}
		}

		// Token: 0x140000A2 RID: 162
		// (add) Token: 0x06001B64 RID: 7012 RVA: 0x0001F66D File Offset: 0x0001D86D
		// (remove) Token: 0x06001B65 RID: 7013 RVA: 0x0001F680 File Offset: 0x0001D880
		public event EventHandler<InlineStyleInvalidatedEventArgs> InlineStyleInvalidated
		{
			add
			{
				this._client.AddEventHandler<InlineStyleInvalidatedEventArgs>("DOM.inlineStyleInvalidated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<InlineStyleInvalidatedEventArgs>("DOM.inlineStyleInvalidated", value);
			}
		}

		// Token: 0x140000A3 RID: 163
		// (add) Token: 0x06001B66 RID: 7014 RVA: 0x0001F694 File Offset: 0x0001D894
		// (remove) Token: 0x06001B67 RID: 7015 RVA: 0x0001F6A7 File Offset: 0x0001D8A7
		public event EventHandler<PseudoElementAddedEventArgs> PseudoElementAdded
		{
			add
			{
				this._client.AddEventHandler<PseudoElementAddedEventArgs>("DOM.pseudoElementAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PseudoElementAddedEventArgs>("DOM.pseudoElementAdded", value);
			}
		}

		// Token: 0x140000A4 RID: 164
		// (add) Token: 0x06001B68 RID: 7016 RVA: 0x0001F6BB File Offset: 0x0001D8BB
		// (remove) Token: 0x06001B69 RID: 7017 RVA: 0x0001F6CE File Offset: 0x0001D8CE
		public event EventHandler<PseudoElementRemovedEventArgs> PseudoElementRemoved
		{
			add
			{
				this._client.AddEventHandler<PseudoElementRemovedEventArgs>("DOM.pseudoElementRemoved", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PseudoElementRemovedEventArgs>("DOM.pseudoElementRemoved", value);
			}
		}

		// Token: 0x140000A5 RID: 165
		// (add) Token: 0x06001B6A RID: 7018 RVA: 0x0001F6E2 File Offset: 0x0001D8E2
		// (remove) Token: 0x06001B6B RID: 7019 RVA: 0x0001F6F5 File Offset: 0x0001D8F5
		public event EventHandler<SetChildNodesEventArgs> SetChildNodes
		{
			add
			{
				this._client.AddEventHandler<SetChildNodesEventArgs>("DOM.setChildNodes", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SetChildNodesEventArgs>("DOM.setChildNodes", value);
			}
		}

		// Token: 0x140000A6 RID: 166
		// (add) Token: 0x06001B6C RID: 7020 RVA: 0x0001F709 File Offset: 0x0001D909
		// (remove) Token: 0x06001B6D RID: 7021 RVA: 0x0001F71C File Offset: 0x0001D91C
		public event EventHandler<ShadowRootPoppedEventArgs> ShadowRootPopped
		{
			add
			{
				this._client.AddEventHandler<ShadowRootPoppedEventArgs>("DOM.shadowRootPopped", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ShadowRootPoppedEventArgs>("DOM.shadowRootPopped", value);
			}
		}

		// Token: 0x140000A7 RID: 167
		// (add) Token: 0x06001B6E RID: 7022 RVA: 0x0001F730 File Offset: 0x0001D930
		// (remove) Token: 0x06001B6F RID: 7023 RVA: 0x0001F743 File Offset: 0x0001D943
		public event EventHandler<ShadowRootPushedEventArgs> ShadowRootPushed
		{
			add
			{
				this._client.AddEventHandler<ShadowRootPushedEventArgs>("DOM.shadowRootPushed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ShadowRootPushedEventArgs>("DOM.shadowRootPushed", value);
			}
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x0001F758 File Offset: 0x0001D958
		public Task<CollectClassNamesFromSubtreeResponse> CollectClassNamesFromSubtreeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<CollectClassNamesFromSubtreeResponse>("DOM.collectClassNamesFromSubtree", dictionary);
		}

		// Token: 0x06001B71 RID: 7025 RVA: 0x0001F790 File Offset: 0x0001D990
		public Task<CopyToResponse> CopyToAsync(int nodeId, int targetNodeId, int? insertBeforeNodeId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("targetNodeId", targetNodeId);
			if (insertBeforeNodeId != null)
			{
				dictionary.Add("insertBeforeNodeId", insertBeforeNodeId.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CopyToResponse>("DOM.copyTo", dictionary);
		}

		// Token: 0x06001B72 RID: 7026 RVA: 0x0001F7F8 File Offset: 0x0001D9F8
		public Task<DescribeNodeResponse> DescribeNodeAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null, int? depth = null, bool? pierce = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
			if (depth != null)
			{
				dictionary.Add("depth", depth.Value);
			}
			if (pierce != null)
			{
				dictionary.Add("pierce", pierce.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DescribeNodeResponse>("DOM.describeNode", dictionary);
		}

		// Token: 0x06001B73 RID: 7027 RVA: 0x0001F8B0 File Offset: 0x0001DAB0
		public Task<DevToolsMethodResponse> ScrollIntoViewIfNeededAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null, Rect rect = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
			if (rect != null)
			{
				dictionary.Add("rect", rect.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.scrollIntoViewIfNeeded", dictionary);
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x0001F940 File Offset: 0x0001DB40
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.disable", parameters);
		}

		// Token: 0x06001B75 RID: 7029 RVA: 0x0001F960 File Offset: 0x0001DB60
		public Task<DevToolsMethodResponse> DiscardSearchResultsAsync(string searchId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("searchId", searchId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.discardSearchResults", dictionary);
		}

		// Token: 0x06001B76 RID: 7030 RVA: 0x0001F990 File Offset: 0x0001DB90
		public Task<DevToolsMethodResponse> EnableAsync(EnableIncludeWhitespace? includeWhitespace = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (includeWhitespace != null)
			{
				dictionary.Add("includeWhitespace", base.EnumToString(includeWhitespace));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.enable", dictionary);
		}

		// Token: 0x06001B77 RID: 7031 RVA: 0x0001F9D4 File Offset: 0x0001DBD4
		public Task<DevToolsMethodResponse> FocusAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.focus", dictionary);
		}

		// Token: 0x06001B78 RID: 7032 RVA: 0x0001FA4C File Offset: 0x0001DC4C
		public Task<GetAttributesResponse> GetAttributesAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetAttributesResponse>("DOM.getAttributes", dictionary);
		}

		// Token: 0x06001B79 RID: 7033 RVA: 0x0001FA84 File Offset: 0x0001DC84
		public Task<GetBoxModelResponse> GetBoxModelAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
			return this._client.ExecuteDevToolsMethodAsync<GetBoxModelResponse>("DOM.getBoxModel", dictionary);
		}

		// Token: 0x06001B7A RID: 7034 RVA: 0x0001FAFC File Offset: 0x0001DCFC
		public Task<GetContentQuadsResponse> GetContentQuadsAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
			return this._client.ExecuteDevToolsMethodAsync<GetContentQuadsResponse>("DOM.getContentQuads", dictionary);
		}

		// Token: 0x06001B7B RID: 7035 RVA: 0x0001FB74 File Offset: 0x0001DD74
		public Task<GetDocumentResponse> GetDocumentAsync(int? depth = null, bool? pierce = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (depth != null)
			{
				dictionary.Add("depth", depth.Value);
			}
			if (pierce != null)
			{
				dictionary.Add("pierce", pierce.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetDocumentResponse>("DOM.getDocument", dictionary);
		}

		// Token: 0x06001B7C RID: 7036 RVA: 0x0001FBD8 File Offset: 0x0001DDD8
		public Task<GetNodesForSubtreeByStyleResponse> GetNodesForSubtreeByStyleAsync(int nodeId, IList<CSSComputedStyleProperty> computedStyles, bool? pierce = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("computedStyles", from x in computedStyles
			select x.ToDictionary());
			if (pierce != null)
			{
				dictionary.Add("pierce", pierce.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetNodesForSubtreeByStyleResponse>("DOM.getNodesForSubtreeByStyle", dictionary);
		}

		// Token: 0x06001B7D RID: 7037 RVA: 0x0001FC60 File Offset: 0x0001DE60
		public Task<GetNodeForLocationResponse> GetNodeForLocationAsync(int x, int y, bool? includeUserAgentShadowDOM = null, bool? ignorePointerEventsNone = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("x", x);
			dictionary.Add("y", y);
			if (includeUserAgentShadowDOM != null)
			{
				dictionary.Add("includeUserAgentShadowDOM", includeUserAgentShadowDOM.Value);
			}
			if (ignorePointerEventsNone != null)
			{
				dictionary.Add("ignorePointerEventsNone", ignorePointerEventsNone.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetNodeForLocationResponse>("DOM.getNodeForLocation", dictionary);
		}

		// Token: 0x06001B7E RID: 7038 RVA: 0x0001FCE8 File Offset: 0x0001DEE8
		public Task<GetOuterHTMLResponse> GetOuterHTMLAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
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
			return this._client.ExecuteDevToolsMethodAsync<GetOuterHTMLResponse>("DOM.getOuterHTML", dictionary);
		}

		// Token: 0x06001B7F RID: 7039 RVA: 0x0001FD60 File Offset: 0x0001DF60
		public Task<GetRelayoutBoundaryResponse> GetRelayoutBoundaryAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetRelayoutBoundaryResponse>("DOM.getRelayoutBoundary", dictionary);
		}

		// Token: 0x06001B80 RID: 7040 RVA: 0x0001FD98 File Offset: 0x0001DF98
		public Task<GetSearchResultsResponse> GetSearchResultsAsync(string searchId, int fromIndex, int toIndex)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("searchId", searchId);
			dictionary.Add("fromIndex", fromIndex);
			dictionary.Add("toIndex", toIndex);
			return this._client.ExecuteDevToolsMethodAsync<GetSearchResultsResponse>("DOM.getSearchResults", dictionary);
		}

		// Token: 0x06001B81 RID: 7041 RVA: 0x0001FDEC File Offset: 0x0001DFEC
		public Task<DevToolsMethodResponse> HideHighlightAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.hideHighlight", parameters);
		}

		// Token: 0x06001B82 RID: 7042 RVA: 0x0001FE0C File Offset: 0x0001E00C
		public Task<DevToolsMethodResponse> HighlightNodeAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.highlightNode", parameters);
		}

		// Token: 0x06001B83 RID: 7043 RVA: 0x0001FE2C File Offset: 0x0001E02C
		public Task<DevToolsMethodResponse> HighlightRectAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.highlightRect", parameters);
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x0001FE4C File Offset: 0x0001E04C
		public Task<DevToolsMethodResponse> MarkUndoableStateAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.markUndoableState", parameters);
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x0001FE6C File Offset: 0x0001E06C
		public Task<MoveToResponse> MoveToAsync(int nodeId, int targetNodeId, int? insertBeforeNodeId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("targetNodeId", targetNodeId);
			if (insertBeforeNodeId != null)
			{
				dictionary.Add("insertBeforeNodeId", insertBeforeNodeId.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<MoveToResponse>("DOM.moveTo", dictionary);
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x0001FED4 File Offset: 0x0001E0D4
		public Task<PerformSearchResponse> PerformSearchAsync(string query, bool? includeUserAgentShadowDOM = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("query", query);
			if (includeUserAgentShadowDOM != null)
			{
				dictionary.Add("includeUserAgentShadowDOM", includeUserAgentShadowDOM.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<PerformSearchResponse>("DOM.performSearch", dictionary);
		}

		// Token: 0x06001B87 RID: 7047 RVA: 0x0001FF24 File Offset: 0x0001E124
		public Task<PushNodeByPathToFrontendResponse> PushNodeByPathToFrontendAsync(string path)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("path", path);
			return this._client.ExecuteDevToolsMethodAsync<PushNodeByPathToFrontendResponse>("DOM.pushNodeByPathToFrontend", dictionary);
		}

		// Token: 0x06001B88 RID: 7048 RVA: 0x0001FF54 File Offset: 0x0001E154
		public Task<PushNodesByBackendIdsToFrontendResponse> PushNodesByBackendIdsToFrontendAsync(int[] backendNodeIds)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("backendNodeIds", backendNodeIds);
			return this._client.ExecuteDevToolsMethodAsync<PushNodesByBackendIdsToFrontendResponse>("DOM.pushNodesByBackendIdsToFrontend", dictionary);
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0001FF84 File Offset: 0x0001E184
		public Task<QuerySelectorResponse> QuerySelectorAsync(int nodeId, string selector)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("selector", selector);
			return this._client.ExecuteDevToolsMethodAsync<QuerySelectorResponse>("DOM.querySelector", dictionary);
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x0001FFC8 File Offset: 0x0001E1C8
		public Task<QuerySelectorAllResponse> QuerySelectorAllAsync(int nodeId, string selector)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("selector", selector);
			return this._client.ExecuteDevToolsMethodAsync<QuerySelectorAllResponse>("DOM.querySelectorAll", dictionary);
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x0002000C File Offset: 0x0001E20C
		public Task<DevToolsMethodResponse> RedoAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.redo", parameters);
		}

		// Token: 0x06001B8C RID: 7052 RVA: 0x0002002C File Offset: 0x0001E22C
		public Task<DevToolsMethodResponse> RemoveAttributeAsync(int nodeId, string name)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("name", name);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.removeAttribute", dictionary);
		}

		// Token: 0x06001B8D RID: 7053 RVA: 0x00020070 File Offset: 0x0001E270
		public Task<DevToolsMethodResponse> RemoveNodeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.removeNode", dictionary);
		}

		// Token: 0x06001B8E RID: 7054 RVA: 0x000200A8 File Offset: 0x0001E2A8
		public Task<DevToolsMethodResponse> RequestChildNodesAsync(int nodeId, int? depth = null, bool? pierce = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			if (depth != null)
			{
				dictionary.Add("depth", depth.Value);
			}
			if (pierce != null)
			{
				dictionary.Add("pierce", pierce.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.requestChildNodes", dictionary);
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x00020120 File Offset: 0x0001E320
		public Task<RequestNodeResponse> RequestNodeAsync(string objectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			return this._client.ExecuteDevToolsMethodAsync<RequestNodeResponse>("DOM.requestNode", dictionary);
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x00020150 File Offset: 0x0001E350
		public Task<ResolveNodeResponse> ResolveNodeAsync(int? nodeId = null, int? backendNodeId = null, string objectGroup = null, int? executionContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (nodeId != null)
			{
				dictionary.Add("nodeId", nodeId.Value);
			}
			if (backendNodeId != null)
			{
				dictionary.Add("backendNodeId", backendNodeId.Value);
			}
			if (!string.IsNullOrEmpty(objectGroup))
			{
				dictionary.Add("objectGroup", objectGroup);
			}
			if (executionContextId != null)
			{
				dictionary.Add("executionContextId", executionContextId.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<ResolveNodeResponse>("DOM.resolveNode", dictionary);
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x000201E8 File Offset: 0x0001E3E8
		public Task<DevToolsMethodResponse> SetAttributeValueAsync(int nodeId, string name, string value)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("name", name);
			dictionary.Add("value", value);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setAttributeValue", dictionary);
		}

		// Token: 0x06001B92 RID: 7058 RVA: 0x00020238 File Offset: 0x0001E438
		public Task<DevToolsMethodResponse> SetAttributesAsTextAsync(int nodeId, string text, string name = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("text", text);
			if (!string.IsNullOrEmpty(name))
			{
				dictionary.Add("name", name);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setAttributesAsText", dictionary);
		}

		// Token: 0x06001B93 RID: 7059 RVA: 0x00020290 File Offset: 0x0001E490
		public Task<DevToolsMethodResponse> SetFileInputFilesAsync(string[] files, int? nodeId = null, int? backendNodeId = null, string objectId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("files", files);
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
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setFileInputFiles", dictionary);
		}

		// Token: 0x06001B94 RID: 7060 RVA: 0x00020318 File Offset: 0x0001E518
		public Task<DevToolsMethodResponse> SetNodeStackTracesEnabledAsync(bool enable)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enable", enable);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setNodeStackTracesEnabled", dictionary);
		}

		// Token: 0x06001B95 RID: 7061 RVA: 0x00020350 File Offset: 0x0001E550
		public Task<GetNodeStackTracesResponse> GetNodeStackTracesAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetNodeStackTracesResponse>("DOM.getNodeStackTraces", dictionary);
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x00020388 File Offset: 0x0001E588
		public Task<GetFileInfoResponse> GetFileInfoAsync(string objectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			return this._client.ExecuteDevToolsMethodAsync<GetFileInfoResponse>("DOM.getFileInfo", dictionary);
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x000203B8 File Offset: 0x0001E5B8
		public Task<DevToolsMethodResponse> SetInspectedNodeAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setInspectedNode", dictionary);
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x000203F0 File Offset: 0x0001E5F0
		public Task<SetNodeNameResponse> SetNodeNameAsync(int nodeId, string name)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("name", name);
			return this._client.ExecuteDevToolsMethodAsync<SetNodeNameResponse>("DOM.setNodeName", dictionary);
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x00020434 File Offset: 0x0001E634
		public Task<DevToolsMethodResponse> SetNodeValueAsync(int nodeId, string value)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("value", value);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setNodeValue", dictionary);
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x00020478 File Offset: 0x0001E678
		public Task<DevToolsMethodResponse> SetOuterHTMLAsync(int nodeId, string outerHTML)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("outerHTML", outerHTML);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.setOuterHTML", dictionary);
		}

		// Token: 0x06001B9B RID: 7067 RVA: 0x000204BC File Offset: 0x0001E6BC
		public Task<DevToolsMethodResponse> UndoAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOM.undo", parameters);
		}

		// Token: 0x06001B9C RID: 7068 RVA: 0x000204DC File Offset: 0x0001E6DC
		public Task<GetFrameOwnerResponse> GetFrameOwnerAsync(string frameId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("frameId", frameId);
			return this._client.ExecuteDevToolsMethodAsync<GetFrameOwnerResponse>("DOM.getFrameOwner", dictionary);
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x0002050C File Offset: 0x0001E70C
		public Task<GetContainerForNodeResponse> GetContainerForNodeAsync(int nodeId, string containerName = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			if (!string.IsNullOrEmpty(containerName))
			{
				dictionary.Add("containerName", containerName);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetContainerForNodeResponse>("DOM.getContainerForNode", dictionary);
		}

		// Token: 0x06001B9E RID: 7070 RVA: 0x00020558 File Offset: 0x0001E758
		public Task<GetQueryingDescendantsForContainerResponse> GetQueryingDescendantsForContainerAsync(int nodeId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			return this._client.ExecuteDevToolsMethodAsync<GetQueryingDescendantsForContainerResponse>("DOM.getQueryingDescendantsForContainer", dictionary);
		}

		// Token: 0x04000EDE RID: 3806
		private IDevToolsClient _client;
	}
}
