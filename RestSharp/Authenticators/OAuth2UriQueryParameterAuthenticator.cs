using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x02000059 RID: 89
	[NullableContext(1)]
	[Nullable(0)]
	public class OAuth2UriQueryParameterAuthenticator : AuthenticatorBase
	{
		// Token: 0x06000511 RID: 1297 RVA: 0x0000C86B File Offset: 0x0000AA6B
		public OAuth2UriQueryParameterAuthenticator(string accessToken) : base(accessToken)
		{
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000C874 File Offset: 0x0000AA74
		protected override Parameter GetAuthenticationParameter(string accessToken)
		{
			return new Parameter("oauth_token", accessToken, ParameterType.GetOrPost);
		}
	}
}
