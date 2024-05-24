using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000006 RID: 6
	[NullableContext(1)]
	[Nullable(0)]
	public class DeserializationException : Exception
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000021A0 File Offset: 0x000003A0
		public DeserializationException(IRestResponse response, Exception innerException) : base("Error occured while deserializing the response", innerException)
		{
			this.Response = response;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021B5 File Offset: 0x000003B5
		public IRestResponse Response { get; }
	}
}
