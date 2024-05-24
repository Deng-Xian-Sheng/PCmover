using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestSharp.Authenticators
{
	// Token: 0x02000053 RID: 83
	[NullableContext(1)]
	[Nullable(0)]
	public class HttpBasicAuthenticator : AuthenticatorBase
	{
		// Token: 0x060004FE RID: 1278 RVA: 0x0000C729 File Offset: 0x0000A929
		public HttpBasicAuthenticator(string username, string password) : this(username, password, Encoding.UTF8)
		{
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0000C738 File Offset: 0x0000A938
		public HttpBasicAuthenticator(string username, string password, Encoding encoding) : base(HttpBasicAuthenticator.GetHeader(username, password, encoding))
		{
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000C748 File Offset: 0x0000A948
		private static string GetHeader(string username, string password, Encoding encoding)
		{
			return Convert.ToBase64String(encoding.GetBytes(username + ":" + password));
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000C761 File Offset: 0x0000A961
		protected override Parameter GetAuthenticationParameter(string accessToken)
		{
			return new Parameter("Authorization", "Basic " + accessToken, ParameterType.HttpHeader);
		}
	}
}
