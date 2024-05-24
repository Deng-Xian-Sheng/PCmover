using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Log
{
	// Token: 0x0200031E RID: 798
	public class LogClient : DevToolsDomainBase
	{
		// Token: 0x06001761 RID: 5985 RVA: 0x0001B64A File Offset: 0x0001984A
		public LogClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400008D RID: 141
		// (add) Token: 0x06001762 RID: 5986 RVA: 0x0001B659 File Offset: 0x00019859
		// (remove) Token: 0x06001763 RID: 5987 RVA: 0x0001B66C File Offset: 0x0001986C
		public event EventHandler<EntryAddedEventArgs> EntryAdded
		{
			add
			{
				this._client.AddEventHandler<EntryAddedEventArgs>("Log.entryAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EntryAddedEventArgs>("Log.entryAdded", value);
			}
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x0001B680 File Offset: 0x00019880
		public Task<DevToolsMethodResponse> ClearAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Log.clear", parameters);
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x0001B6A0 File Offset: 0x000198A0
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Log.disable", parameters);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0001B6C0 File Offset: 0x000198C0
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Log.enable", parameters);
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0001B6E0 File Offset: 0x000198E0
		public Task<DevToolsMethodResponse> StartViolationsReportAsync(IList<ViolationSetting> config)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("config", from x in config
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Log.startViolationsReport", dictionary);
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x0001B734 File Offset: 0x00019934
		public Task<DevToolsMethodResponse> StopViolationsReportAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Log.stopViolationsReport", parameters);
		}

		// Token: 0x04000CFA RID: 3322
		private IDevToolsClient _client;
	}
}
