using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.EventBreakpoints
{
	// Token: 0x0200012C RID: 300
	public class EventBreakpointsClient : DevToolsDomainBase
	{
		// Token: 0x060008AD RID: 2221 RVA: 0x0000DEFB File Offset: 0x0000C0FB
		public EventBreakpointsClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0000DF0C File Offset: 0x0000C10C
		public Task<DevToolsMethodResponse> SetInstrumentationBreakpointAsync(string eventName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventName", eventName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("EventBreakpoints.setInstrumentationBreakpoint", dictionary);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0000DF3C File Offset: 0x0000C13C
		public Task<DevToolsMethodResponse> RemoveInstrumentationBreakpointAsync(string eventName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventName", eventName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("EventBreakpoints.removeInstrumentationBreakpoint", dictionary);
		}

		// Token: 0x0400049A RID: 1178
		private IDevToolsClient _client;
	}
}
