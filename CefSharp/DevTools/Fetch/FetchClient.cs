using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001CC RID: 460
	public class FetchClient : DevToolsDomainBase
	{
		// Token: 0x06000D5D RID: 3421 RVA: 0x00012456 File Offset: 0x00010656
		public FetchClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06000D5E RID: 3422 RVA: 0x00012465 File Offset: 0x00010665
		// (remove) Token: 0x06000D5F RID: 3423 RVA: 0x00012478 File Offset: 0x00010678
		public event EventHandler<RequestPausedEventArgs> RequestPaused
		{
			add
			{
				this._client.AddEventHandler<RequestPausedEventArgs>("Fetch.requestPaused", value);
			}
			remove
			{
				this._client.RemoveEventHandler<RequestPausedEventArgs>("Fetch.requestPaused", value);
			}
		}

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06000D60 RID: 3424 RVA: 0x0001248C File Offset: 0x0001068C
		// (remove) Token: 0x06000D61 RID: 3425 RVA: 0x0001249F File Offset: 0x0001069F
		public event EventHandler<AuthRequiredEventArgs> AuthRequired
		{
			add
			{
				this._client.AddEventHandler<AuthRequiredEventArgs>("Fetch.authRequired", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AuthRequiredEventArgs>("Fetch.authRequired", value);
			}
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x000124B4 File Offset: 0x000106B4
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.disable", parameters);
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000124D4 File Offset: 0x000106D4
		public Task<DevToolsMethodResponse> EnableAsync(IList<RequestPattern> patterns = null, bool? handleAuthRequests = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (patterns != null)
			{
				dictionary.Add("patterns", from x in patterns
				select x.ToDictionary());
			}
			if (handleAuthRequests != null)
			{
				dictionary.Add("handleAuthRequests", handleAuthRequests.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.enable", dictionary);
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x0001254C File Offset: 0x0001074C
		public Task<DevToolsMethodResponse> FailRequestAsync(string requestId, ErrorReason errorReason)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			dictionary.Add("errorReason", base.EnumToString(errorReason));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.failRequest", dictionary);
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x00012594 File Offset: 0x00010794
		public Task<DevToolsMethodResponse> FulfillRequestAsync(string requestId, int responseCode, IList<HeaderEntry> responseHeaders = null, byte[] binaryResponseHeaders = null, byte[] body = null, string responsePhrase = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			dictionary.Add("responseCode", responseCode);
			if (responseHeaders != null)
			{
				dictionary.Add("responseHeaders", from x in responseHeaders
				select x.ToDictionary());
			}
			if (binaryResponseHeaders != null)
			{
				dictionary.Add("binaryResponseHeaders", base.ToBase64String(binaryResponseHeaders));
			}
			if (body != null)
			{
				dictionary.Add("body", base.ToBase64String(body));
			}
			if (!string.IsNullOrEmpty(responsePhrase))
			{
				dictionary.Add("responsePhrase", responsePhrase);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.fulfillRequest", dictionary);
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x0001264C File Offset: 0x0001084C
		public Task<DevToolsMethodResponse> ContinueRequestAsync(string requestId, string url = null, string method = null, byte[] postData = null, IList<HeaderEntry> headers = null, bool? interceptResponse = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			if (!string.IsNullOrEmpty(url))
			{
				dictionary.Add("url", url);
			}
			if (!string.IsNullOrEmpty(method))
			{
				dictionary.Add("method", method);
			}
			if (postData != null)
			{
				dictionary.Add("postData", base.ToBase64String(postData));
			}
			if (headers != null)
			{
				dictionary.Add("headers", from x in headers
				select x.ToDictionary());
			}
			if (interceptResponse != null)
			{
				dictionary.Add("interceptResponse", interceptResponse.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.continueRequest", dictionary);
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x00012710 File Offset: 0x00010910
		public Task<DevToolsMethodResponse> ContinueWithAuthAsync(string requestId, AuthChallengeResponse authChallengeResponse)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			dictionary.Add("authChallengeResponse", authChallengeResponse.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.continueWithAuth", dictionary);
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00012754 File Offset: 0x00010954
		public Task<DevToolsMethodResponse> ContinueResponseAsync(string requestId, int? responseCode = null, string responsePhrase = null, IList<HeaderEntry> responseHeaders = null, byte[] binaryResponseHeaders = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			if (responseCode != null)
			{
				dictionary.Add("responseCode", responseCode.Value);
			}
			if (!string.IsNullOrEmpty(responsePhrase))
			{
				dictionary.Add("responsePhrase", responsePhrase);
			}
			if (responseHeaders != null)
			{
				dictionary.Add("responseHeaders", from x in responseHeaders
				select x.ToDictionary());
			}
			if (binaryResponseHeaders != null)
			{
				dictionary.Add("binaryResponseHeaders", base.ToBase64String(binaryResponseHeaders));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Fetch.continueResponse", dictionary);
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00012804 File Offset: 0x00010A04
		public Task<GetResponseBodyResponse> GetResponseBodyAsync(string requestId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			return this._client.ExecuteDevToolsMethodAsync<GetResponseBodyResponse>("Fetch.getResponseBody", dictionary);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00012834 File Offset: 0x00010A34
		public Task<TakeResponseBodyAsStreamResponse> TakeResponseBodyAsStreamAsync(string requestId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			return this._client.ExecuteDevToolsMethodAsync<TakeResponseBodyAsStreamResponse>("Fetch.takeResponseBodyAsStream", dictionary);
		}

		// Token: 0x040006F1 RID: 1777
		private IDevToolsClient _client;
	}
}
