using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators
{
	// Token: 0x02000054 RID: 84
	[NullableContext(1)]
	public interface IAuthenticator
	{
		// Token: 0x06000502 RID: 1282
		void Authenticate(IRestClient client, IRestRequest request);
	}
}
