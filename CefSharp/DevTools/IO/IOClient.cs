using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.IO
{
	// Token: 0x0200012A RID: 298
	public class IOClient : DevToolsDomainBase
	{
		// Token: 0x060008A6 RID: 2214 RVA: 0x0000DD92 File Offset: 0x0000BF92
		public IOClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0000DDA4 File Offset: 0x0000BFA4
		public Task<DevToolsMethodResponse> CloseAsync(string handle)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("handle", handle);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("IO.close", dictionary);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0000DDD4 File Offset: 0x0000BFD4
		public Task<ReadResponse> ReadAsync(string handle, int? offset = null, int? size = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("handle", handle);
			if (offset != null)
			{
				dictionary.Add("offset", offset.Value);
			}
			if (size != null)
			{
				dictionary.Add("size", size.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<ReadResponse>("IO.read", dictionary);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0000DE44 File Offset: 0x0000C044
		public Task<ResolveBlobResponse> ResolveBlobAsync(string objectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			return this._client.ExecuteDevToolsMethodAsync<ResolveBlobResponse>("IO.resolveBlob", dictionary);
		}

		// Token: 0x04000498 RID: 1176
		private IDevToolsClient _client;
	}
}
