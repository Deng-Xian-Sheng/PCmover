using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x02000057 RID: 87
	[NullableContext(1)]
	[Nullable(0)]
	[Obsolete("Check the OAuth2 authenticators implementation on how to use the AuthenticatorBase instead")]
	public abstract class OAuth2Authenticator : IAuthenticator
	{
		// Token: 0x0600050A RID: 1290 RVA: 0x0000C803 File Offset: 0x0000AA03
		protected OAuth2Authenticator(string accessToken)
		{
			this.AccessToken = accessToken;
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0000C812 File Offset: 0x0000AA12
		public string AccessToken { get; }

		// Token: 0x0600050C RID: 1292 RVA: 0x0000C81A File Offset: 0x0000AA1A
		public void Authenticate(IRestClient client, IRestRequest request)
		{
			request.AddOrUpdateParameter(this.GetAuthenticationParameter(this.AccessToken));
		}

		// Token: 0x0600050D RID: 1293
		protected abstract Parameter GetAuthenticationParameter(string accessToken);
	}
}
