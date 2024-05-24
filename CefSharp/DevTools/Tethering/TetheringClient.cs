using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Tethering
{
	// Token: 0x020001DC RID: 476
	public class TetheringClient : DevToolsDomainBase
	{
		// Token: 0x06000DB2 RID: 3506 RVA: 0x00012D23 File Offset: 0x00010F23
		public TetheringClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06000DB3 RID: 3507 RVA: 0x00012D32 File Offset: 0x00010F32
		// (remove) Token: 0x06000DB4 RID: 3508 RVA: 0x00012D45 File Offset: 0x00010F45
		public event EventHandler<AcceptedEventArgs> Accepted
		{
			add
			{
				this._client.AddEventHandler<AcceptedEventArgs>("Tethering.accepted", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AcceptedEventArgs>("Tethering.accepted", value);
			}
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00012D5C File Offset: 0x00010F5C
		public Task<DevToolsMethodResponse> BindAsync(int port)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("port", port);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Tethering.bind", dictionary);
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00012D94 File Offset: 0x00010F94
		public Task<DevToolsMethodResponse> UnbindAsync(int port)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("port", port);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Tethering.unbind", dictionary);
		}

		// Token: 0x0400071E RID: 1822
		private IDevToolsClient _client;
	}
}
