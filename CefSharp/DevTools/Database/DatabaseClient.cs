using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Database
{
	// Token: 0x02000362 RID: 866
	public class DatabaseClient : DevToolsDomainBase
	{
		// Token: 0x060018F9 RID: 6393 RVA: 0x0001DB99 File Offset: 0x0001BD99
		public DatabaseClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000095 RID: 149
		// (add) Token: 0x060018FA RID: 6394 RVA: 0x0001DBA8 File Offset: 0x0001BDA8
		// (remove) Token: 0x060018FB RID: 6395 RVA: 0x0001DBBB File Offset: 0x0001BDBB
		public event EventHandler<AddDatabaseEventArgs> AddDatabase
		{
			add
			{
				this._client.AddEventHandler<AddDatabaseEventArgs>("Database.addDatabase", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AddDatabaseEventArgs>("Database.addDatabase", value);
			}
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x0001DBD0 File Offset: 0x0001BDD0
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Database.disable", parameters);
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x0001DBF0 File Offset: 0x0001BDF0
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Database.enable", parameters);
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x0001DC10 File Offset: 0x0001BE10
		public Task<ExecuteSQLResponse> ExecuteSQLAsync(string databaseId, string query)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("databaseId", databaseId);
			dictionary.Add("query", query);
			return this._client.ExecuteDevToolsMethodAsync<ExecuteSQLResponse>("Database.executeSQL", dictionary);
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x0001DC4C File Offset: 0x0001BE4C
		public Task<GetDatabaseTableNamesResponse> GetDatabaseTableNamesAsync(string databaseId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("databaseId", databaseId);
			return this._client.ExecuteDevToolsMethodAsync<GetDatabaseTableNamesResponse>("Database.getDatabaseTableNames", dictionary);
		}

		// Token: 0x04000DCC RID: 3532
		private IDevToolsClient _client;
	}
}
