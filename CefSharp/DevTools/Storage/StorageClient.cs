using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x0200020B RID: 523
	public class StorageClient : DevToolsDomainBase
	{
		// Token: 0x06000EF2 RID: 3826 RVA: 0x00013D8B File Offset: 0x00011F8B
		public StorageClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06000EF3 RID: 3827 RVA: 0x00013D9A File Offset: 0x00011F9A
		// (remove) Token: 0x06000EF4 RID: 3828 RVA: 0x00013DAD File Offset: 0x00011FAD
		public event EventHandler<CacheStorageContentUpdatedEventArgs> CacheStorageContentUpdated
		{
			add
			{
				this._client.AddEventHandler<CacheStorageContentUpdatedEventArgs>("Storage.cacheStorageContentUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<CacheStorageContentUpdatedEventArgs>("Storage.cacheStorageContentUpdated", value);
			}
		}

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06000EF5 RID: 3829 RVA: 0x00013DC1 File Offset: 0x00011FC1
		// (remove) Token: 0x06000EF6 RID: 3830 RVA: 0x00013DD4 File Offset: 0x00011FD4
		public event EventHandler<CacheStorageListUpdatedEventArgs> CacheStorageListUpdated
		{
			add
			{
				this._client.AddEventHandler<CacheStorageListUpdatedEventArgs>("Storage.cacheStorageListUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<CacheStorageListUpdatedEventArgs>("Storage.cacheStorageListUpdated", value);
			}
		}

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06000EF7 RID: 3831 RVA: 0x00013DE8 File Offset: 0x00011FE8
		// (remove) Token: 0x06000EF8 RID: 3832 RVA: 0x00013DFB File Offset: 0x00011FFB
		public event EventHandler<IndexedDBContentUpdatedEventArgs> IndexedDBContentUpdated
		{
			add
			{
				this._client.AddEventHandler<IndexedDBContentUpdatedEventArgs>("Storage.indexedDBContentUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<IndexedDBContentUpdatedEventArgs>("Storage.indexedDBContentUpdated", value);
			}
		}

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x06000EF9 RID: 3833 RVA: 0x00013E0F File Offset: 0x0001200F
		// (remove) Token: 0x06000EFA RID: 3834 RVA: 0x00013E22 File Offset: 0x00012022
		public event EventHandler<IndexedDBListUpdatedEventArgs> IndexedDBListUpdated
		{
			add
			{
				this._client.AddEventHandler<IndexedDBListUpdatedEventArgs>("Storage.indexedDBListUpdated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<IndexedDBListUpdatedEventArgs>("Storage.indexedDBListUpdated", value);
			}
		}

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x06000EFB RID: 3835 RVA: 0x00013E36 File Offset: 0x00012036
		// (remove) Token: 0x06000EFC RID: 3836 RVA: 0x00013E49 File Offset: 0x00012049
		public event EventHandler<InterestGroupAccessedEventArgs> InterestGroupAccessed
		{
			add
			{
				this._client.AddEventHandler<InterestGroupAccessedEventArgs>("Storage.interestGroupAccessed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<InterestGroupAccessedEventArgs>("Storage.interestGroupAccessed", value);
			}
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00013E60 File Offset: 0x00012060
		public Task<DevToolsMethodResponse> ClearDataForOriginAsync(string origin, string storageTypes)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			dictionary.Add("storageTypes", storageTypes);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.clearDataForOrigin", dictionary);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x00013E9C File Offset: 0x0001209C
		public Task<GetCookiesResponse> GetCookiesAsync(string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetCookiesResponse>("Storage.getCookies", dictionary);
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00013ED4 File Offset: 0x000120D4
		public Task<DevToolsMethodResponse> SetCookiesAsync(IList<CookieParam> cookies, string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("cookies", from x in cookies
			select x.ToDictionary());
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.setCookies", dictionary);
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00013F3C File Offset: 0x0001213C
		public Task<DevToolsMethodResponse> ClearCookiesAsync(string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.clearCookies", dictionary);
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00013F74 File Offset: 0x00012174
		public Task<GetUsageAndQuotaResponse> GetUsageAndQuotaAsync(string origin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			return this._client.ExecuteDevToolsMethodAsync<GetUsageAndQuotaResponse>("Storage.getUsageAndQuota", dictionary);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x00013FA4 File Offset: 0x000121A4
		public Task<DevToolsMethodResponse> OverrideQuotaForOriginAsync(string origin, double? quotaSize = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			if (quotaSize != null)
			{
				dictionary.Add("quotaSize", quotaSize.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.overrideQuotaForOrigin", dictionary);
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x00013FF4 File Offset: 0x000121F4
		public Task<DevToolsMethodResponse> TrackCacheStorageForOriginAsync(string origin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.trackCacheStorageForOrigin", dictionary);
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00014024 File Offset: 0x00012224
		public Task<DevToolsMethodResponse> TrackIndexedDBForOriginAsync(string origin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.trackIndexedDBForOrigin", dictionary);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00014054 File Offset: 0x00012254
		public Task<DevToolsMethodResponse> UntrackCacheStorageForOriginAsync(string origin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.untrackCacheStorageForOrigin", dictionary);
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x00014084 File Offset: 0x00012284
		public Task<DevToolsMethodResponse> UntrackIndexedDBForOriginAsync(string origin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("origin", origin);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.untrackIndexedDBForOrigin", dictionary);
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x000140B4 File Offset: 0x000122B4
		public Task<GetTrustTokensResponse> GetTrustTokensAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetTrustTokensResponse>("Storage.getTrustTokens", parameters);
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x000140D4 File Offset: 0x000122D4
		public Task<ClearTrustTokensResponse> ClearTrustTokensAsync(string issuerOrigin)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("issuerOrigin", issuerOrigin);
			return this._client.ExecuteDevToolsMethodAsync<ClearTrustTokensResponse>("Storage.clearTrustTokens", dictionary);
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x00014104 File Offset: 0x00012304
		public Task<GetInterestGroupDetailsResponse> GetInterestGroupDetailsAsync(string ownerOrigin, string name)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("ownerOrigin", ownerOrigin);
			dictionary.Add("name", name);
			return this._client.ExecuteDevToolsMethodAsync<GetInterestGroupDetailsResponse>("Storage.getInterestGroupDetails", dictionary);
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x00014140 File Offset: 0x00012340
		public Task<DevToolsMethodResponse> SetInterestGroupTrackingAsync(bool enable)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("enable", enable);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Storage.setInterestGroupTracking", dictionary);
		}

		// Token: 0x040007A6 RID: 1958
		private IDevToolsClient _client;
	}
}
