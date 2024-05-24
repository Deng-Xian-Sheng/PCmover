using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x02000056 RID: 86
	[NullableContext(1)]
	[Nullable(0)]
	public class NtlmAuthenticator : IAuthenticator
	{
		// Token: 0x06000506 RID: 1286 RVA: 0x0000C7BB File Offset: 0x0000A9BB
		public NtlmAuthenticator() : this(CredentialCache.DefaultCredentials)
		{
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0000C7C8 File Offset: 0x0000A9C8
		public NtlmAuthenticator(string username, string password) : this(new NetworkCredential(username, password))
		{
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0000C7D7 File Offset: 0x0000A9D7
		public NtlmAuthenticator(ICredentials credentials)
		{
			if (credentials == null)
			{
				throw new ArgumentNullException("credentials");
			}
			this._credentials = credentials;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000C7F5 File Offset: 0x0000A9F5
		public void Authenticate(IRestClient client, IRestRequest request)
		{
			request.Credentials = this._credentials;
		}

		// Token: 0x04000139 RID: 313
		private readonly ICredentials _credentials;
	}
}
