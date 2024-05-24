using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001FA RID: 506
	public class SystemInfoClient : DevToolsDomainBase
	{
		// Token: 0x06000E8B RID: 3723 RVA: 0x000139B9 File Offset: 0x00011BB9
		public SystemInfoClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x000139C8 File Offset: 0x00011BC8
		public Task<GetInfoResponse> GetInfoAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetInfoResponse>("SystemInfo.getInfo", parameters);
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x000139E8 File Offset: 0x00011BE8
		public Task<GetProcessInfoResponse> GetProcessInfoAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetProcessInfoResponse>("SystemInfo.getProcessInfo", parameters);
		}

		// Token: 0x0400076D RID: 1901
		private IDevToolsClient _client;
	}
}
