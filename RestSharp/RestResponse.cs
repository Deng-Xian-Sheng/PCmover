using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000026 RID: 38
	[NullableContext(1)]
	[Nullable(0)]
	[DebuggerDisplay("{DebuggerDisplay()}")]
	public class RestResponse<[Nullable(2)] T> : RestResponseBase, IRestResponse<T>, IRestResponse
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00006F48 File Offset: 0x00005148
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00006F50 File Offset: 0x00005150
		public T Data { get; set; }

		// Token: 0x06000394 RID: 916 RVA: 0x00006F5C File Offset: 0x0000515C
		public static explicit operator RestResponse<T>(RestResponse response)
		{
			return new RestResponse<T>
			{
				ContentEncoding = response.ContentEncoding,
				ContentLength = response.ContentLength,
				ContentType = response.ContentType,
				Cookies = response.Cookies,
				ErrorMessage = response.ErrorMessage,
				ErrorException = response.ErrorException,
				Headers = response.Headers,
				RawBytes = response.RawBytes,
				ResponseStatus = response.ResponseStatus,
				ResponseUri = response.ResponseUri,
				ProtocolVersion = response.ProtocolVersion,
				Server = response.Server,
				StatusCode = response.StatusCode,
				StatusDescription = response.StatusDescription,
				Request = response.Request
			};
		}
	}
}
