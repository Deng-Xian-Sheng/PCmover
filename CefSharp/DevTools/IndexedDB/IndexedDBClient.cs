using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000349 RID: 841
	public class IndexedDBClient : DevToolsDomainBase
	{
		// Token: 0x0600186C RID: 6252 RVA: 0x0001CCBD File Offset: 0x0001AEBD
		public IndexedDBClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x0001CCCC File Offset: 0x0001AECC
		public Task<DevToolsMethodResponse> ClearObjectStoreAsync(string securityOrigin, string databaseName, string objectStoreName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			dictionary.Add("databaseName", databaseName);
			dictionary.Add("objectStoreName", objectStoreName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("IndexedDB.clearObjectStore", dictionary);
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0001CD14 File Offset: 0x0001AF14
		public Task<DevToolsMethodResponse> DeleteDatabaseAsync(string securityOrigin, string databaseName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			dictionary.Add("databaseName", databaseName);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("IndexedDB.deleteDatabase", dictionary);
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x0001CD50 File Offset: 0x0001AF50
		public Task<DevToolsMethodResponse> DeleteObjectStoreEntriesAsync(string securityOrigin, string databaseName, string objectStoreName, KeyRange keyRange)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			dictionary.Add("databaseName", databaseName);
			dictionary.Add("objectStoreName", objectStoreName);
			dictionary.Add("keyRange", keyRange.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("IndexedDB.deleteObjectStoreEntries", dictionary);
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0001CDAC File Offset: 0x0001AFAC
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("IndexedDB.disable", parameters);
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x0001CDCC File Offset: 0x0001AFCC
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("IndexedDB.enable", parameters);
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x0001CDEC File Offset: 0x0001AFEC
		public Task<RequestDataResponse> RequestDataAsync(string securityOrigin, string databaseName, string objectStoreName, string indexName, int skipCount, int pageSize, KeyRange keyRange = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			dictionary.Add("databaseName", databaseName);
			dictionary.Add("objectStoreName", objectStoreName);
			dictionary.Add("indexName", indexName);
			dictionary.Add("skipCount", skipCount);
			dictionary.Add("pageSize", pageSize);
			if (keyRange != null)
			{
				dictionary.Add("keyRange", keyRange.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<RequestDataResponse>("IndexedDB.requestData", dictionary);
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x0001CE7C File Offset: 0x0001B07C
		public Task<GetMetadataResponse> GetMetadataAsync(string securityOrigin, string databaseName, string objectStoreName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			dictionary.Add("databaseName", databaseName);
			dictionary.Add("objectStoreName", objectStoreName);
			return this._client.ExecuteDevToolsMethodAsync<GetMetadataResponse>("IndexedDB.getMetadata", dictionary);
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x0001CEC4 File Offset: 0x0001B0C4
		public Task<RequestDatabaseResponse> RequestDatabaseAsync(string securityOrigin, string databaseName)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			dictionary.Add("databaseName", databaseName);
			return this._client.ExecuteDevToolsMethodAsync<RequestDatabaseResponse>("IndexedDB.requestDatabase", dictionary);
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x0001CF00 File Offset: 0x0001B100
		public Task<RequestDatabaseNamesResponse> RequestDatabaseNamesAsync(string securityOrigin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("securityOrigin", securityOrigin);
			return this._client.ExecuteDevToolsMethodAsync<RequestDatabaseNamesResponse>("IndexedDB.requestDatabaseNames", dictionary);
		}

		// Token: 0x04000D89 RID: 3465
		private IDevToolsClient _client;
	}
}
