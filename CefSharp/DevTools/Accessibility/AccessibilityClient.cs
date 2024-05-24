using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000450 RID: 1104
	public class AccessibilityClient : DevToolsDomainBase
	{
		// Token: 0x06001FFA RID: 8186 RVA: 0x00023E34 File Offset: 0x00022034
		public AccessibilityClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000B7 RID: 183
		// (add) Token: 0x06001FFB RID: 8187 RVA: 0x00023E43 File Offset: 0x00022043
		// (remove) Token: 0x06001FFC RID: 8188 RVA: 0x00023E56 File Offset: 0x00022056
		public event EventHandler<LoadCompleteEventArgs> LoadComplete
		{
			add
			{
				this._client.AddEventHandler<LoadCompleteEventArgs>("Accessibility.loadComplete", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LoadCompleteEventArgs>("Accessibility.loadComplete", value);
			}
		}

		// Token: 0x140000B8 RID: 184
		// (add) Token: 0x06001FFD RID: 8189 RVA: 0x00023E6A File Offset: 0x0002206A
		// (remove) Token: 0x06001FFE RID: 8190 RVA: 0x00023E7D File Offset: 0x0002207D
		public event EventHandler<NodesUpdatedEventArgs> NodesUpdated
		{
			add
			{
				this._client.AddEventHandler<NodesUpdatedEventArgs>("Accessibility.nodesUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NodesUpdatedEventArgs>("Accessibility.nodesUpdated", value);
			}
		}

		// Token: 0x06001FFF RID: 8191 RVA: 0x00023E94 File Offset: 0x00022094
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Accessibility.disable", parameters);
		}

		// Token: 0x06002000 RID: 8192 RVA: 0x00023EB4 File Offset: 0x000220B4
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Accessibility.enable", parameters);
		}

		// Token: 0x06002001 RID: 8193 RVA: 0x00023ED4 File Offset: 0x000220D4
		public Task<GetPartialAXTreeResponse> GetPartialAXTreeAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null, bool? fetchRelatives = null)
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
			if (fetchRelatives != null)
			{
				dictionary.Add("fetchRelatives", fetchRelatives.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetPartialAXTreeResponse>("Accessibility.getPartialAXTree", dictionary);
		}

		// Token: 0x06002002 RID: 8194 RVA: 0x00023F6C File Offset: 0x0002216C
		public Task<GetFullAXTreeResponse> GetFullAXTreeAsync(int? depth = null, int? max_depth = null, string frameId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (depth != null)
			{
				dictionary.Add("depth", depth.Value);
			}
			if (max_depth != null)
			{
				dictionary.Add("max_depth", max_depth.Value);
			}
			if (!string.IsNullOrEmpty(frameId))
			{
				dictionary.Add("frameId", frameId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetFullAXTreeResponse>("Accessibility.getFullAXTree", dictionary);
		}

		// Token: 0x06002003 RID: 8195 RVA: 0x00023FE4 File Offset: 0x000221E4
		public Task<GetRootAXNodeResponse> GetRootAXNodeAsync(string frameId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(frameId))
			{
				dictionary.Add("frameId", frameId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetRootAXNodeResponse>("Accessibility.getRootAXNode", dictionary);
		}

		// Token: 0x06002004 RID: 8196 RVA: 0x0002401C File Offset: 0x0002221C
		public Task<GetAXNodeAndAncestorsResponse> GetAXNodeAndAncestorsAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null)
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
			return this._client.ExecuteDevToolsMethodAsync<GetAXNodeAndAncestorsResponse>("Accessibility.getAXNodeAndAncestors", dictionary);
		}

		// Token: 0x06002005 RID: 8197 RVA: 0x00024094 File Offset: 0x00022294
		public Task<GetChildAXNodesResponse> GetChildAXNodesAsync(string id, string frameId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("id", id);
			if (!string.IsNullOrEmpty(frameId))
			{
				dictionary.Add("frameId", frameId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetChildAXNodesResponse>("Accessibility.getChildAXNodes", dictionary);
		}

		// Token: 0x06002006 RID: 8198 RVA: 0x000240D8 File Offset: 0x000222D8
		public Task<QueryAXTreeResponse> QueryAXTreeAsync(int? nodeId = null, int? backendNodeId = null, string objectId = null, string accessibleName = null, string role = null)
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
			if (!string.IsNullOrEmpty(accessibleName))
			{
				dictionary.Add("accessibleName", accessibleName);
			}
			if (!string.IsNullOrEmpty(role))
			{
				dictionary.Add("role", role);
			}
			return this._client.ExecuteDevToolsMethodAsync<QueryAXTreeResponse>("Accessibility.queryAXTree", dictionary);
		}

		// Token: 0x04001182 RID: 4482
		private IDevToolsClient _client;
	}
}
