using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using RestSharp.Authenticators.OAuth.Extensions;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace RestSharp.Authenticators.OAuth
{
	// Token: 0x02000062 RID: 98
	[NullableContext(1)]
	[Nullable(0)]
	internal sealed class OAuthWorkflow
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		// (set) Token: 0x06000553 RID: 1363 RVA: 0x0000D3E0 File Offset: 0x0000B5E0
		public string Version { get; set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x0000D3E9 File Offset: 0x0000B5E9
		// (set) Token: 0x06000555 RID: 1365 RVA: 0x0000D3F1 File Offset: 0x0000B5F1
		public string ConsumerKey { get; set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x0000D3FA File Offset: 0x0000B5FA
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x0000D402 File Offset: 0x0000B602
		public string ConsumerSecret { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x0000D40B File Offset: 0x0000B60B
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x0000D413 File Offset: 0x0000B613
		public string Token { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0000D41C File Offset: 0x0000B61C
		// (set) Token: 0x0600055B RID: 1371 RVA: 0x0000D424 File Offset: 0x0000B624
		public string TokenSecret { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x0000D42D File Offset: 0x0000B62D
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x0000D435 File Offset: 0x0000B635
		public string CallbackUrl { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0000D43E File Offset: 0x0000B63E
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x0000D446 File Offset: 0x0000B646
		public string Verifier { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0000D44F File Offset: 0x0000B64F
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x0000D457 File Offset: 0x0000B657
		public string SessionHandle { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0000D460 File Offset: 0x0000B660
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0000D468 File Offset: 0x0000B668
		public OAuthSignatureMethod SignatureMethod { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0000D471 File Offset: 0x0000B671
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0000D479 File Offset: 0x0000B679
		public OAuthSignatureTreatment SignatureTreatment { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0000D482 File Offset: 0x0000B682
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x0000D48A File Offset: 0x0000B68A
		public OAuthParameterHandling ParameterHandling { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0000D493 File Offset: 0x0000B693
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0000D49B File Offset: 0x0000B69B
		public string ClientUsername { get; set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0000D4A4 File Offset: 0x0000B6A4
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x0000D4AC File Offset: 0x0000B6AC
		public string ClientPassword { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0000D4B5 File Offset: 0x0000B6B5
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0000D4BD File Offset: 0x0000B6BD
		public string RequestTokenUrl { get; set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0000D4C6 File Offset: 0x0000B6C6
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x0000D4CE File Offset: 0x0000B6CE
		public string AccessTokenUrl { get; set; }

		// Token: 0x06000570 RID: 1392 RVA: 0x0000D4D8 File Offset: 0x0000B6D8
		public OAuthWorkflow.OAuthParameters BuildRequestTokenInfo(string method, WebPairCollection parameters)
		{
			this.ValidateTokenRequestState();
			WebPairCollection webPairCollection = new WebPairCollection();
			webPairCollection.AddRange(parameters);
			string timestamp = OAuthTools.GetTimestamp();
			string nonce = OAuthTools.GetNonce();
			WebPairCollection webPairCollection2 = this.GenerateAuthParameters(timestamp, nonce);
			webPairCollection.AddRange(webPairCollection2);
			string signatureBase = OAuthTools.ConcatenateRequestElements(method, this.RequestTokenUrl, webPairCollection);
			return new OAuthWorkflow.OAuthParameters
			{
				Signature = OAuthTools.GetSignature(this.SignatureMethod, this.SignatureTreatment, signatureBase, this.ConsumerSecret),
				Parameters = webPairCollection2
			};
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0000D550 File Offset: 0x0000B750
		public OAuthWorkflow.OAuthParameters BuildAccessTokenSignature(string method, WebPairCollection parameters)
		{
			this.ValidateAccessRequestState();
			WebPairCollection webPairCollection = new WebPairCollection();
			webPairCollection.AddRange(parameters);
			Uri uri = new Uri(this.AccessTokenUrl);
			string timestamp = OAuthTools.GetTimestamp();
			string nonce = OAuthTools.GetNonce();
			WebPairCollection webPairCollection2 = this.GenerateAuthParameters(timestamp, nonce);
			webPairCollection.AddRange(webPairCollection2);
			string signatureBase = OAuthTools.ConcatenateRequestElements(method, uri.ToString(), webPairCollection);
			return new OAuthWorkflow.OAuthParameters
			{
				Signature = OAuthTools.GetSignature(this.SignatureMethod, this.SignatureTreatment, signatureBase, this.ConsumerSecret, this.TokenSecret),
				Parameters = webPairCollection2
			};
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		public OAuthWorkflow.OAuthParameters BuildClientAuthAccessTokenSignature(string method, WebPairCollection parameters)
		{
			this.ValidateClientAuthAccessRequestState();
			WebPairCollection webPairCollection = new WebPairCollection();
			webPairCollection.AddRange(parameters);
			Uri uri = new Uri(this.AccessTokenUrl);
			string timestamp = OAuthTools.GetTimestamp();
			string nonce = OAuthTools.GetNonce();
			WebPairCollection webPairCollection2 = this.GenerateXAuthParameters(timestamp, nonce);
			webPairCollection.AddRange(webPairCollection2);
			string signatureBase = OAuthTools.ConcatenateRequestElements(method, uri.ToString(), webPairCollection);
			return new OAuthWorkflow.OAuthParameters
			{
				Signature = OAuthTools.GetSignature(this.SignatureMethod, this.SignatureTreatment, signatureBase, this.ConsumerSecret),
				Parameters = webPairCollection2
			};
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0000D664 File Offset: 0x0000B864
		public OAuthWorkflow.OAuthParameters BuildProtectedResourceSignature(string method, WebPairCollection parameters, string url)
		{
			this.ValidateProtectedResourceState();
			WebPairCollection webPairCollection = new WebPairCollection();
			webPairCollection.AddRange(parameters);
			Uri uri = new Uri(url);
			NameValueCollection urlParameters = HttpUtility.ParseQueryString(uri.Query);
			webPairCollection.AddRange(from x in urlParameters.AllKeys
			select new WebPair(x, urlParameters[x], false));
			string timestamp = OAuthTools.GetTimestamp();
			string nonce = OAuthTools.GetNonce();
			WebPairCollection webPairCollection2 = this.GenerateAuthParameters(timestamp, nonce);
			webPairCollection.AddRange(webPairCollection2);
			string signatureBase = OAuthTools.ConcatenateRequestElements(method, url, webPairCollection);
			return new OAuthWorkflow.OAuthParameters
			{
				Signature = OAuthTools.GetSignature(this.SignatureMethod, this.SignatureTreatment, signatureBase, this.ConsumerSecret, this.TokenSecret),
				Parameters = webPairCollection2
			};
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0000D720 File Offset: 0x0000B920
		private void ValidateTokenRequestState()
		{
			Ensure.NotEmpty(this.RequestTokenUrl, "RequestTokenUrl");
			Ensure.NotEmpty(this.ConsumerKey, "ConsumerKey");
			Ensure.NotEmpty(this.ConsumerSecret, "ConsumerSecret");
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0000D754 File Offset: 0x0000B954
		private void ValidateAccessRequestState()
		{
			Ensure.NotEmpty(this.AccessTokenUrl, "AccessTokenUrl");
			Ensure.NotEmpty(this.ConsumerKey, "ConsumerKey");
			Ensure.NotEmpty(this.ConsumerSecret, "ConsumerSecret");
			Ensure.NotEmpty(this.Token, "Token");
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
		private void ValidateClientAuthAccessRequestState()
		{
			Ensure.NotEmpty(this.AccessTokenUrl, "AccessTokenUrl");
			Ensure.NotEmpty(this.ConsumerKey, "ConsumerKey");
			Ensure.NotEmpty(this.ConsumerSecret, "ConsumerSecret");
			Ensure.NotEmpty(this.ClientUsername, "ClientUsername");
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000D7F1 File Offset: 0x0000B9F1
		private void ValidateProtectedResourceState()
		{
			Ensure.NotEmpty(this.ConsumerKey, "ConsumerKey");
			Ensure.NotEmpty(this.ConsumerSecret, "ConsumerSecret");
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0000D814 File Offset: 0x0000BA14
		private WebPairCollection GenerateAuthParameters(string timestamp, string nonce)
		{
			WebPairCollection webPairCollection = new WebPairCollection
			{
				new WebPair("oauth_consumer_key", this.ConsumerKey, false),
				new WebPair("oauth_nonce", nonce, false),
				new WebPair("oauth_signature_method", this.SignatureMethod.ToRequestValue(), false),
				new WebPair("oauth_timestamp", timestamp, false),
				new WebPair("oauth_version", this.Version ?? "1.0", false)
			};
			if (!this.Token.IsEmpty())
			{
				webPairCollection.Add(new WebPair("oauth_token", this.Token, true));
			}
			if (!this.CallbackUrl.IsEmpty())
			{
				webPairCollection.Add(new WebPair("oauth_callback", this.CallbackUrl, true));
			}
			if (!this.Verifier.IsEmpty())
			{
				webPairCollection.Add(new WebPair("oauth_verifier", this.Verifier, false));
			}
			if (!this.SessionHandle.IsEmpty())
			{
				webPairCollection.Add(new WebPair("oauth_session_handle", this.SessionHandle, false));
			}
			return webPairCollection;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000D930 File Offset: 0x0000BB30
		private WebPairCollection GenerateXAuthParameters(string timestamp, string nonce)
		{
			return new WebPairCollection
			{
				new WebPair("x_auth_username", this.ClientUsername, false),
				new WebPair("x_auth_password", this.ClientPassword, false),
				new WebPair("x_auth_mode", "client_auth", false),
				new WebPair("oauth_consumer_key", this.ConsumerKey, false),
				new WebPair("oauth_signature_method", this.SignatureMethod.ToRequestValue(), false),
				new WebPair("oauth_timestamp", timestamp, false),
				new WebPair("oauth_nonce", nonce, false),
				new WebPair("oauth_version", this.Version ?? "1.0", false)
			};
		}

		// Token: 0x020000D0 RID: 208
		[Nullable(0)]
		internal class OAuthParameters
		{
			// Token: 0x1700019A RID: 410
			// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0000FD88 File Offset: 0x0000DF88
			// (set) Token: 0x060006E5 RID: 1765 RVA: 0x0000FD90 File Offset: 0x0000DF90
			public WebPairCollection Parameters { get; set; }

			// Token: 0x1700019B RID: 411
			// (get) Token: 0x060006E6 RID: 1766 RVA: 0x0000FD99 File Offset: 0x0000DF99
			// (set) Token: 0x060006E7 RID: 1767 RVA: 0x0000FDA1 File Offset: 0x0000DFA1
			public string Signature { get; set; }
		}
	}
}
