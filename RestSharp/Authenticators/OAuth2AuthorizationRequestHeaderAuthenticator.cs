using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x02000058 RID: 88
	[NullableContext(1)]
	[Nullable(0)]
	public class OAuth2AuthorizationRequestHeaderAuthenticator : AuthenticatorBase
	{
		// Token: 0x0600050E RID: 1294 RVA: 0x0000C82F File Offset: 0x0000AA2F
		public OAuth2AuthorizationRequestHeaderAuthenticator(string accessToken) : this(accessToken, "OAuth")
		{
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0000C83D File Offset: 0x0000AA3D
		public OAuth2AuthorizationRequestHeaderAuthenticator(string accessToken, string tokenType) : base(accessToken)
		{
			this._tokenType = tokenType;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0000C84D File Offset: 0x0000AA4D
		protected override Parameter GetAuthenticationParameter(string accessToken)
		{
			return new Parameter("Authorization", this._tokenType + " " + accessToken, ParameterType.HttpHeader);
		}

		// Token: 0x0400013B RID: 315
		private readonly string _tokenType;
	}
}
