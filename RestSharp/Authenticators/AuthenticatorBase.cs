using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x02000052 RID: 82
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class AuthenticatorBase : IAuthenticator
	{
		// Token: 0x060004FA RID: 1274 RVA: 0x0000C6FD File Offset: 0x0000A8FD
		protected AuthenticatorBase(string token)
		{
			this.Token = token;
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000C70C File Offset: 0x0000A90C
		protected string Token { get; }

		// Token: 0x060004FC RID: 1276
		protected abstract Parameter GetAuthenticationParameter(string accessToken);

		// Token: 0x060004FD RID: 1277 RVA: 0x0000C714 File Offset: 0x0000A914
		public void Authenticate(IRestClient client, IRestRequest request)
		{
			request.AddOrUpdateParameter(this.GetAuthenticationParameter(this.Token));
		}
	}
}
