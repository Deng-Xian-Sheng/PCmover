using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using RestSharp.Authenticators.OAuth;
using RestSharp.Extensions;

namespace RestSharp.Authenticators
{
	// Token: 0x0200005A RID: 90
	[NullableContext(1)]
	[Nullable(0)]
	public class OAuth1Authenticator : IAuthenticator
	{
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x0000C882 File Offset: 0x0000AA82
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x0000C88A File Offset: 0x0000AA8A
		public virtual string Realm { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x0000C893 File Offset: 0x0000AA93
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x0000C89B File Offset: 0x0000AA9B
		public virtual OAuthParameterHandling ParameterHandling { get; set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0000C8A4 File Offset: 0x0000AAA4
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		public virtual OAuthSignatureMethod SignatureMethod { get; set; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0000C8B5 File Offset: 0x0000AAB5
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x0000C8BD File Offset: 0x0000AABD
		public virtual OAuthSignatureTreatment SignatureTreatment { get; set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0000C8C6 File Offset: 0x0000AAC6
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x0000C8CE File Offset: 0x0000AACE
		internal virtual OAuthType Type { get; set; }

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000C8D7 File Offset: 0x0000AAD7
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x0000C8DF File Offset: 0x0000AADF
		internal virtual string ConsumerKey { get; set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000C8E8 File Offset: 0x0000AAE8
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x0000C8F0 File Offset: 0x0000AAF0
		internal virtual string ConsumerSecret { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000C8F9 File Offset: 0x0000AAF9
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x0000C901 File Offset: 0x0000AB01
		internal virtual string Token { get; set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x0000C90A File Offset: 0x0000AB0A
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x0000C912 File Offset: 0x0000AB12
		internal virtual string TokenSecret { get; set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x0000C91B File Offset: 0x0000AB1B
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x0000C923 File Offset: 0x0000AB23
		internal virtual string Verifier { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0000C92C File Offset: 0x0000AB2C
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0000C934 File Offset: 0x0000AB34
		internal virtual string Version { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000C93D File Offset: 0x0000AB3D
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000C945 File Offset: 0x0000AB45
		internal virtual string CallbackUrl { get; set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0000C94E File Offset: 0x0000AB4E
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x0000C956 File Offset: 0x0000AB56
		internal virtual string SessionHandle { get; set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x0000C95F File Offset: 0x0000AB5F
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x0000C967 File Offset: 0x0000AB67
		internal virtual string ClientUsername { get; set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000C970 File Offset: 0x0000AB70
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0000C978 File Offset: 0x0000AB78
		internal virtual string ClientPassword { get; set; }

		// Token: 0x06000531 RID: 1329 RVA: 0x0000C984 File Offset: 0x0000AB84
		public void Authenticate(IRestClient client, IRestRequest request)
		{
			OAuthWorkflow workflow = new OAuthWorkflow
			{
				ConsumerKey = this.ConsumerKey,
				ConsumerSecret = this.ConsumerSecret,
				ParameterHandling = this.ParameterHandling,
				SignatureMethod = this.SignatureMethod,
				SignatureTreatment = this.SignatureTreatment,
				Verifier = this.Verifier,
				Version = this.Version,
				CallbackUrl = this.CallbackUrl,
				SessionHandle = this.SessionHandle,
				Token = this.Token,
				TokenSecret = this.TokenSecret,
				ClientUsername = this.ClientUsername,
				ClientPassword = this.ClientPassword
			};
			this.AddOAuthData(client, request, workflow);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0000CA3C File Offset: 0x0000AC3C
		public static OAuth1Authenticator ForRequestToken(string consumerKey, string consumerSecret, OAuthSignatureMethod signatureMethod = OAuthSignatureMethod.HmacSha1)
		{
			return new OAuth1Authenticator
			{
				ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
				SignatureMethod = signatureMethod,
				SignatureTreatment = OAuthSignatureTreatment.Escaped,
				ConsumerKey = consumerKey,
				ConsumerSecret = consumerSecret,
				Type = OAuthType.RequestToken
			};
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0000CA6D File Offset: 0x0000AC6D
		public static OAuth1Authenticator ForRequestToken(string consumerKey, string consumerSecret, string callbackUrl)
		{
			OAuth1Authenticator oauth1Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret, OAuthSignatureMethod.HmacSha1);
			oauth1Authenticator.CallbackUrl = callbackUrl;
			return oauth1Authenticator;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0000CA7E File Offset: 0x0000AC7E
		public static OAuth1Authenticator ForAccessToken(string consumerKey, string consumerSecret, string token, string tokenSecret, OAuthSignatureMethod signatureMethod = OAuthSignatureMethod.HmacSha1)
		{
			return new OAuth1Authenticator
			{
				ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
				SignatureMethod = signatureMethod,
				SignatureTreatment = OAuthSignatureTreatment.Escaped,
				ConsumerKey = consumerKey,
				ConsumerSecret = consumerSecret,
				Token = token,
				TokenSecret = tokenSecret,
				Type = OAuthType.AccessToken
			};
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0000CABE File Offset: 0x0000ACBE
		public static OAuth1Authenticator ForAccessToken(string consumerKey, string consumerSecret, string token, string tokenSecret, string verifier)
		{
			OAuth1Authenticator oauth1Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, token, tokenSecret, OAuthSignatureMethod.HmacSha1);
			oauth1Authenticator.Verifier = verifier;
			return oauth1Authenticator;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000CAD2 File Offset: 0x0000ACD2
		public static OAuth1Authenticator ForAccessTokenRefresh(string consumerKey, string consumerSecret, string token, string tokenSecret, string sessionHandle)
		{
			OAuth1Authenticator oauth1Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, token, tokenSecret, OAuthSignatureMethod.HmacSha1);
			oauth1Authenticator.SessionHandle = sessionHandle;
			return oauth1Authenticator;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0000CAE6 File Offset: 0x0000ACE6
		public static OAuth1Authenticator ForAccessTokenRefresh(string consumerKey, string consumerSecret, string token, string tokenSecret, string verifier, string sessionHandle)
		{
			OAuth1Authenticator oauth1Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, token, tokenSecret, OAuthSignatureMethod.HmacSha1);
			oauth1Authenticator.SessionHandle = sessionHandle;
			oauth1Authenticator.Verifier = verifier;
			return oauth1Authenticator;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0000CB02 File Offset: 0x0000AD02
		public static OAuth1Authenticator ForClientAuthentication(string consumerKey, string consumerSecret, string username, string password, OAuthSignatureMethod signatureMethod = OAuthSignatureMethod.HmacSha1)
		{
			return new OAuth1Authenticator
			{
				ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
				SignatureMethod = signatureMethod,
				SignatureTreatment = OAuthSignatureTreatment.Escaped,
				ConsumerKey = consumerKey,
				ConsumerSecret = consumerSecret,
				ClientUsername = username,
				ClientPassword = password,
				Type = OAuthType.ClientAuthentication
			};
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0000CB42 File Offset: 0x0000AD42
		public static OAuth1Authenticator ForProtectedResource(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, OAuthSignatureMethod signatureMethod = OAuthSignatureMethod.HmacSha1)
		{
			return new OAuth1Authenticator
			{
				Type = OAuthType.ProtectedResource,
				ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
				SignatureMethod = signatureMethod,
				SignatureTreatment = OAuthSignatureTreatment.Escaped,
				ConsumerKey = consumerKey,
				ConsumerSecret = consumerSecret,
				Token = accessToken,
				TokenSecret = accessTokenSecret
			};
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0000CB84 File Offset: 0x0000AD84
		private void AddOAuthData(IRestClient client, IRestRequest request, OAuthWorkflow workflow)
		{
			OAuth1Authenticator.<>c__DisplayClass69_0 CS$<>8__locals1;
			CS$<>8__locals1.<>4__this = this;
			if (client.BuildUriWithoutQueryParameters(request).Contains('?'))
			{
				throw new ApplicationException("Using query parameters in the base URL is not supported for OAuth calls. Consider using AddDefaultQueryParameter instead.");
			}
			string text = client.BuildUri(request).ToString();
			int num = text.IndexOf('?');
			if (num != -1)
			{
				text = text.Substring(0, num);
			}
			string method = request.Method.ToString().ToUpperInvariant();
			WebPairCollection webPairCollection = new WebPairCollection();
			Func<Parameter, bool> func;
			if (!request.AlwaysMultipartFormData && request.Files.Count <= 0)
			{
				func = new Func<Parameter, bool>(OAuth1Authenticator.<AddOAuthData>g__BaseQuery|69_0);
			}
			else
			{
				func = ((Parameter x) => OAuth1Authenticator.<AddOAuthData>g__BaseQuery|69_0(x) && x.Name.StartsWith("oauth_"));
			}
			Func<Parameter, bool> predicate = func;
			webPairCollection.AddRange(client.DefaultParameters.Where(predicate).ToWebParameters());
			webPairCollection.AddRange(request.Parameters.Where(predicate).ToWebParameters());
			if (this.Type == OAuthType.RequestToken)
			{
				workflow.RequestTokenUrl = text;
			}
			else
			{
				workflow.AccessTokenUrl = text;
			}
			OAuthWorkflow.OAuthParameters oauth;
			switch (this.Type)
			{
			case OAuthType.RequestToken:
				oauth = workflow.BuildRequestTokenInfo(method, webPairCollection);
				break;
			case OAuthType.AccessToken:
				oauth = workflow.BuildAccessTokenSignature(method, webPairCollection);
				break;
			case OAuthType.ProtectedResource:
				oauth = workflow.BuildProtectedResourceSignature(method, webPairCollection, text);
				break;
			case OAuthType.ClientAuthentication:
				oauth = workflow.BuildClientAuthAccessTokenSignature(method, webPairCollection);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			CS$<>8__locals1.oauth = oauth;
			CS$<>8__locals1.oauth.Parameters.Add("oauth_signature", CS$<>8__locals1.oauth.Signature);
			OAuthParameterHandling parameterHandling = this.ParameterHandling;
			IEnumerable<Parameter> enumerable;
			if (parameterHandling != OAuthParameterHandling.HttpAuthorizationHeader)
			{
				if (parameterHandling != OAuthParameterHandling.UrlOrPostParameters)
				{
					throw new ArgumentOutOfRangeException();
				}
				enumerable = this.<AddOAuthData>g__CreateUrlParameters|69_3(ref CS$<>8__locals1);
			}
			else
			{
				enumerable = this.<AddOAuthData>g__CreateHeaderParameters|69_2(ref CS$<>8__locals1);
			}
			IEnumerable<Parameter> parameters = enumerable;
			request.AddOrUpdateParameters(parameters);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0000CD53 File Offset: 0x0000AF53
		[CompilerGenerated]
		internal static bool <AddOAuthData>g__BaseQuery|69_0(Parameter x)
		{
			return x.Type == ParameterType.GetOrPost || x.Type == ParameterType.QueryString || x.Type == ParameterType.QueryStringWithoutEncode;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0000CD72 File Offset: 0x0000AF72
		[CompilerGenerated]
		private IEnumerable<Parameter> <AddOAuthData>g__CreateHeaderParameters|69_2(ref OAuth1Authenticator.<>c__DisplayClass69_0 A_1)
		{
			return new Parameter[]
			{
				new Parameter("Authorization", this.<AddOAuthData>g__GetAuthorizationHeader|69_4(ref A_1), ParameterType.HttpHeader)
			};
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0000CD8F File Offset: 0x0000AF8F
		[CompilerGenerated]
		private IEnumerable<Parameter> <AddOAuthData>g__CreateUrlParameters|69_3(ref OAuth1Authenticator.<>c__DisplayClass69_0 A_1)
		{
			return from p in A_1.oauth.Parameters
			select new Parameter(p.Name, HttpUtility.UrlDecode(p.Value), ParameterType.GetOrPost);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0000CDC0 File Offset: 0x0000AFC0
		[CompilerGenerated]
		private string <AddOAuthData>g__GetAuthorizationHeader|69_4(ref OAuth1Authenticator.<>c__DisplayClass69_0 A_1)
		{
			List<string> list = (from x in A_1.oauth.Parameters.OrderBy((WebPair x) => x, WebPair.Comparer)
			select x.Name + "=\"" + x.WebValue + "\"").ToList<string>();
			if (!this.Realm.IsEmpty())
			{
				list.Insert(0, "realm=\"" + OAuthTools.UrlEncodeRelaxed(this.Realm) + "\"");
			}
			return "OAuth " + string.Join(",", list);
		}
	}
}
