using System;
using System.Runtime.CompilerServices;
using RestSharp.Validation;

namespace RestSharp.Authenticators
{
	// Token: 0x02000055 RID: 85
	[NullableContext(1)]
	[Nullable(0)]
	public class JwtAuthenticator : IAuthenticator
	{
		// Token: 0x06000503 RID: 1283 RVA: 0x0000C779 File Offset: 0x0000A979
		public JwtAuthenticator(string accessToken)
		{
			this.SetBearerToken(accessToken);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0000C788 File Offset: 0x0000A988
		public void SetBearerToken(string accessToken)
		{
			Ensure.NotEmpty(accessToken, "accessToken");
			this._authHeader = "Bearer " + accessToken;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0000C7A6 File Offset: 0x0000A9A6
		public void Authenticate(IRestClient client, IRestRequest request)
		{
			request.AddOrUpdateParameter("Authorization", this._authHeader, ParameterType.HttpHeader);
		}

		// Token: 0x04000138 RID: 312
		private string _authHeader;
	}
}
