using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.DOMStorage
{
	// Token: 0x02000369 RID: 873
	public class DOMStorageClient : DevToolsDomainBase
	{
		// Token: 0x06001921 RID: 6433 RVA: 0x0001DD91 File Offset: 0x0001BF91
		public DOMStorageClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000096 RID: 150
		// (add) Token: 0x06001922 RID: 6434 RVA: 0x0001DDA0 File Offset: 0x0001BFA0
		// (remove) Token: 0x06001923 RID: 6435 RVA: 0x0001DDB3 File Offset: 0x0001BFB3
		public event EventHandler<DomStorageItemAddedEventArgs> DomStorageItemAdded
		{
			add
			{
				this._client.AddEventHandler<DomStorageItemAddedEventArgs>("DOMStorage.domStorageItemAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DomStorageItemAddedEventArgs>("DOMStorage.domStorageItemAdded", value);
			}
		}

		// Token: 0x14000097 RID: 151
		// (add) Token: 0x06001924 RID: 6436 RVA: 0x0001DDC7 File Offset: 0x0001BFC7
		// (remove) Token: 0x06001925 RID: 6437 RVA: 0x0001DDDA File Offset: 0x0001BFDA
		public event EventHandler<DomStorageItemRemovedEventArgs> DomStorageItemRemoved
		{
			add
			{
				this._client.AddEventHandler<DomStorageItemRemovedEventArgs>("DOMStorage.domStorageItemRemoved", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DomStorageItemRemovedEventArgs>("DOMStorage.domStorageItemRemoved", value);
			}
		}

		// Token: 0x14000098 RID: 152
		// (add) Token: 0x06001926 RID: 6438 RVA: 0x0001DDEE File Offset: 0x0001BFEE
		// (remove) Token: 0x06001927 RID: 6439 RVA: 0x0001DE01 File Offset: 0x0001C001
		public event EventHandler<DomStorageItemUpdatedEventArgs> DomStorageItemUpdated
		{
			add
			{
				this._client.AddEventHandler<DomStorageItemUpdatedEventArgs>("DOMStorage.domStorageItemUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DomStorageItemUpdatedEventArgs>("DOMStorage.domStorageItemUpdated", value);
			}
		}

		// Token: 0x14000099 RID: 153
		// (add) Token: 0x06001928 RID: 6440 RVA: 0x0001DE15 File Offset: 0x0001C015
		// (remove) Token: 0x06001929 RID: 6441 RVA: 0x0001DE28 File Offset: 0x0001C028
		public event EventHandler<DomStorageItemsClearedEventArgs> DomStorageItemsCleared
		{
			add
			{
				this._client.AddEventHandler<DomStorageItemsClearedEventArgs>("DOMStorage.domStorageItemsCleared", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DomStorageItemsClearedEventArgs>("DOMStorage.domStorageItemsCleared", value);
			}
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x0001DE3C File Offset: 0x0001C03C
		public Task<DevToolsMethodResponse> ClearAsync(StorageId storageId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("storageId", storageId.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMStorage.clear", dictionary);
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x0001DE74 File Offset: 0x0001C074
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMStorage.disable", parameters);
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x0001DE94 File Offset: 0x0001C094
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMStorage.enable", parameters);
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x0001DEB4 File Offset: 0x0001C0B4
		public Task<GetDOMStorageItemsResponse> GetDOMStorageItemsAsync(StorageId storageId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("storageId", storageId.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<GetDOMStorageItemsResponse>("DOMStorage.getDOMStorageItems", dictionary);
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x0001DEEC File Offset: 0x0001C0EC
		public Task<DevToolsMethodResponse> RemoveDOMStorageItemAsync(StorageId storageId, string key)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("storageId", storageId.ToDictionary());
			dictionary.Add("key", key);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMStorage.removeDOMStorageItem", dictionary);
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x0001DF30 File Offset: 0x0001C130
		public Task<DevToolsMethodResponse> SetDOMStorageItemAsync(StorageId storageId, string key, string value)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("storageId", storageId.ToDictionary());
			dictionary.Add("key", key);
			dictionary.Add("value", value);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMStorage.setDOMStorageItem", dictionary);
		}

		// Token: 0x04000DDA RID: 3546
		private IDevToolsClient _client;
	}
}
