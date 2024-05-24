using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003BC RID: 956
	public class CacheStorageClient : DevToolsDomainBase
	{
		// Token: 0x06001BE8 RID: 7144 RVA: 0x00020929 File Offset: 0x0001EB29
		public CacheStorageClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x00020938 File Offset: 0x0001EB38
		public Task<DevToolsMethodResponse> DeleteCacheAsync(string cacheId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cacheId", cacheId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CacheStorage.deleteCache", dictionary);
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x00020968 File Offset: 0x0001EB68
		public Task<DevToolsMethodResponse> DeleteEntryAsync(string cacheId, string request)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cacheId", cacheId);
			dictionary.Add("request", request);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("CacheStorage.deleteEntry", dictionary);
		}

		// Token: 0x06001BEB RID: 7147 RVA: 0x000209A4 File Offset: 0x0001EBA4
		public Task<RequestCacheNamesResponse> RequestCacheNamesAsync(string securityOrigin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			return this._client.ExecuteDevToolsMethodAsync<RequestCacheNamesResponse>("CacheStorage.requestCacheNames", dictionary);
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x000209D4 File Offset: 0x0001EBD4
		public Task<RequestCachedResponseResponse> RequestCachedResponseAsync(string cacheId, string requestURL, IList<Header> requestHeaders)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cacheId", cacheId);
			dictionary.Add("requestURL", requestURL);
			dictionary.Add("requestHeaders", from x in requestHeaders
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<RequestCachedResponseResponse>("CacheStorage.requestCachedResponse", dictionary);
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x00020A40 File Offset: 0x0001EC40
		public Task<RequestEntriesResponse> RequestEntriesAsync(string cacheId, int? skipCount = null, int? pageSize = null, string pathFilter = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cacheId", cacheId);
			if (skipCount != null)
			{
				dictionary.Add("skipCount", skipCount.Value);
			}
			if (pageSize != null)
			{
				dictionary.Add("pageSize", pageSize.Value);
			}
			if (!string.IsNullOrEmpty(pathFilter))
			{
				dictionary.Add("pathFilter", pathFilter);
			}
			return this._client.ExecuteDevToolsMethodAsync<RequestEntriesResponse>("CacheStorage.requestEntries", dictionary);
		}

		// Token: 0x04000EFE RID: 3838
		private IDevToolsClient _client;
	}
}
