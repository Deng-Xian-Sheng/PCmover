using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Extensions
{
	// Token: 0x02000049 RID: 73
	public static class ResponseExtensions
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x0000BC3C File Offset: 0x00009E3C
		[NullableContext(1)]
		[Obsolete("This method will be removed soon. If you use it, please copy the code to your project.")]
		public static IRestResponse<T> ToAsyncResponse<[Nullable(2)] T>(this IRestResponse response)
		{
			return new RestResponse<T>
			{
				ContentEncoding = response.ContentEncoding,
				ContentLength = response.ContentLength,
				ContentType = response.ContentType,
				Cookies = response.Cookies,
				ErrorException = response.ErrorException,
				ErrorMessage = response.ErrorMessage,
				Headers = response.Headers,
				RawBytes = response.RawBytes,
				ResponseStatus = response.ResponseStatus,
				ResponseUri = response.ResponseUri,
				Server = response.Server,
				StatusCode = response.StatusCode,
				StatusDescription = response.StatusDescription
			};
		}
	}
}
