using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Cast
{
	// Token: 0x020003B3 RID: 947
	public class CastClient : DevToolsDomainBase
	{
		// Token: 0x06001BAC RID: 7084 RVA: 0x000205FA File Offset: 0x0001E7FA
		public CastClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000A8 RID: 168
		// (add) Token: 0x06001BAD RID: 7085 RVA: 0x00020609 File Offset: 0x0001E809
		// (remove) Token: 0x06001BAE RID: 7086 RVA: 0x0002061C File Offset: 0x0001E81C
		public event EventHandler<SinksUpdatedEventArgs> SinksUpdated
		{
			add
			{
				this._client.AddEventHandler<SinksUpdatedEventArgs>("Cast.sinksUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<SinksUpdatedEventArgs>("Cast.sinksUpdated", value);
			}
		}

		// Token: 0x140000A9 RID: 169
		// (add) Token: 0x06001BAF RID: 7087 RVA: 0x00020630 File Offset: 0x0001E830
		// (remove) Token: 0x06001BB0 RID: 7088 RVA: 0x00020643 File Offset: 0x0001E843
		public event EventHandler<IssueUpdatedEventArgs> IssueUpdated
		{
			add
			{
				this._client.AddEventHandler<IssueUpdatedEventArgs>("Cast.issueUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<IssueUpdatedEventArgs>("Cast.issueUpdated", value);
			}
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x00020658 File Offset: 0x0001E858
		public Task<DevToolsMethodResponse> EnableAsync(string presentationUrl = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(presentationUrl))
			{
				dictionary.Add("presentationUrl", presentationUrl);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Cast.enable", dictionary);
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x00020690 File Offset: 0x0001E890
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Cast.disable", parameters);
		}

		// Token: 0x06001BB3 RID: 7091 RVA: 0x000206B0 File Offset: 0x0001E8B0
		public Task<DevToolsMethodResponse> SetSinkToUseAsync(string sinkName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("sinkName", sinkName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Cast.setSinkToUse", dictionary);
		}

		// Token: 0x06001BB4 RID: 7092 RVA: 0x000206E0 File Offset: 0x0001E8E0
		public Task<DevToolsMethodResponse> StartDesktopMirroringAsync(string sinkName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("sinkName", sinkName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Cast.startDesktopMirroring", dictionary);
		}

		// Token: 0x06001BB5 RID: 7093 RVA: 0x00020710 File Offset: 0x0001E910
		public Task<DevToolsMethodResponse> StartTabMirroringAsync(string sinkName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("sinkName", sinkName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Cast.startTabMirroring", dictionary);
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x00020740 File Offset: 0x0001E940
		public Task<DevToolsMethodResponse> StopCastingAsync(string sinkName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("sinkName", sinkName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Cast.stopCasting", dictionary);
		}

		// Token: 0x04000EE4 RID: 3812
		private IDevToolsClient _client;
	}
}
