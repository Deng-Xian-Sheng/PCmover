using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x0200005C RID: 92
	[NullableContext(1)]
	[Nullable(0)]
	public class SimpleAuthenticator : IAuthenticator
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x0000CE95 File Offset: 0x0000B095
		public SimpleAuthenticator(string usernameKey, string username, string passwordKey, string password)
		{
			this._usernameKey = usernameKey;
			this._username = username;
			this._passwordKey = passwordKey;
			this._password = password;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0000CEBA File Offset: 0x0000B0BA
		public void Authenticate(IRestClient client, IRestRequest request)
		{
			request.AddParameter(this._usernameKey, this._username).AddParameter(this._passwordKey, this._password);
		}

		// Token: 0x0400014B RID: 331
		private readonly string _password;

		// Token: 0x0400014C RID: 332
		private readonly string _passwordKey;

		// Token: 0x0400014D RID: 333
		private readonly string _username;

		// Token: 0x0400014E RID: 334
		private readonly string _usernameKey;
	}
}
