using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.DOMDebugger
{
	// Token: 0x0200037C RID: 892
	public class DOMDebuggerClient : DevToolsDomainBase
	{
		// Token: 0x06001A1C RID: 6684 RVA: 0x0001E863 File Offset: 0x0001CA63
		public DOMDebuggerClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x0001E874 File Offset: 0x0001CA74
		public Task<GetEventListenersResponse> GetEventListenersAsync(string objectId, int? depth = null, bool? pierce = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			if (depth != null)
			{
				dictionary.Add("depth", depth.Value);
			}
			if (pierce != null)
			{
				dictionary.Add("pierce", pierce.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetEventListenersResponse>("DOMDebugger.getEventListeners", dictionary);
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x0001E8E4 File Offset: 0x0001CAE4
		public Task<DevToolsMethodResponse> RemoveDOMBreakpointAsync(int nodeId, DOMBreakpointType type)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("type", base.EnumToString(type));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.removeDOMBreakpoint", dictionary);
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x0001E930 File Offset: 0x0001CB30
		public Task<DevToolsMethodResponse> RemoveEventListenerBreakpointAsync(string eventName, string targetName = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventName", eventName);
			if (!string.IsNullOrEmpty(targetName))
			{
				dictionary.Add("targetName", targetName);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.removeEventListenerBreakpoint", dictionary);
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x0001E974 File Offset: 0x0001CB74
		public Task<DevToolsMethodResponse> RemoveInstrumentationBreakpointAsync(string eventName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventName", eventName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.removeInstrumentationBreakpoint", dictionary);
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
		public Task<DevToolsMethodResponse> RemoveXHRBreakpointAsync(string url)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("url", url);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.removeXHRBreakpoint", dictionary);
		}

		// Token: 0x06001A22 RID: 6690 RVA: 0x0001E9D4 File Offset: 0x0001CBD4
		public Task<DevToolsMethodResponse> SetBreakOnCSPViolationAsync(CSPViolationType[] violationTypes)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("violationTypes", base.EnumToString(violationTypes));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.setBreakOnCSPViolation", dictionary);
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x0001EA0C File Offset: 0x0001CC0C
		public Task<DevToolsMethodResponse> SetDOMBreakpointAsync(int nodeId, DOMBreakpointType type)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("nodeId", nodeId);
			dictionary.Add("type", base.EnumToString(type));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.setDOMBreakpoint", dictionary);
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x0001EA58 File Offset: 0x0001CC58
		public Task<DevToolsMethodResponse> SetEventListenerBreakpointAsync(string eventName, string targetName = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventName", eventName);
			if (!string.IsNullOrEmpty(targetName))
			{
				dictionary.Add("targetName", targetName);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.setEventListenerBreakpoint", dictionary);
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x0001EA9C File Offset: 0x0001CC9C
		public Task<DevToolsMethodResponse> SetInstrumentationBreakpointAsync(string eventName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventName", eventName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.setInstrumentationBreakpoint", dictionary);
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x0001EACC File Offset: 0x0001CCCC
		public Task<DevToolsMethodResponse> SetXHRBreakpointAsync(string url)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("url", url);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMDebugger.setXHRBreakpoint", dictionary);
		}

		// Token: 0x04000E4C RID: 3660
		private IDevToolsClient _client;
	}
}
