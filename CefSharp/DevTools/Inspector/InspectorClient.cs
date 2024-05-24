using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Inspector
{
	// Token: 0x0200032E RID: 814
	public class InspectorClient : DevToolsDomainBase
	{
		// Token: 0x060017D5 RID: 6101 RVA: 0x0001BD51 File Offset: 0x00019F51
		public InspectorClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000090 RID: 144
		// (add) Token: 0x060017D6 RID: 6102 RVA: 0x0001BD60 File Offset: 0x00019F60
		// (remove) Token: 0x060017D7 RID: 6103 RVA: 0x0001BD73 File Offset: 0x00019F73
		public event EventHandler<DetachedEventArgs> Detached
		{
			add
			{
				this._client.AddEventHandler<DetachedEventArgs>("Inspector.detached", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DetachedEventArgs>("Inspector.detached", value);
			}
		}

		// Token: 0x14000091 RID: 145
		// (add) Token: 0x060017D8 RID: 6104 RVA: 0x0001BD87 File Offset: 0x00019F87
		// (remove) Token: 0x060017D9 RID: 6105 RVA: 0x0001BD9A File Offset: 0x00019F9A
		public event EventHandler<EventArgs> TargetCrashed
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Inspector.targetCrashed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Inspector.targetCrashed", value);
			}
		}

		// Token: 0x14000092 RID: 146
		// (add) Token: 0x060017DA RID: 6106 RVA: 0x0001BDAE File Offset: 0x00019FAE
		// (remove) Token: 0x060017DB RID: 6107 RVA: 0x0001BDC1 File Offset: 0x00019FC1
		public event EventHandler<EventArgs> TargetReloadedAfterCrash
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("Inspector.targetReloadedAfterCrash", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("Inspector.targetReloadedAfterCrash", value);
			}
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x0001BDD8 File Offset: 0x00019FD8
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Inspector.disable", parameters);
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x0001BDF8 File Offset: 0x00019FF8
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Inspector.enable", parameters);
		}

		// Token: 0x04000D24 RID: 3364
		private IDevToolsClient _client;
	}
}
