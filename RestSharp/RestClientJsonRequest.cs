using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000021 RID: 33
	[NullableContext(1)]
	[Nullable(0)]
	public static class RestClientJsonRequest
	{
		// Token: 0x0600030F RID: 783 RVA: 0x00006157 File Offset: 0x00004357
		public static IRestResponse<TResponse> Get<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.GET));
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00006167 File Offset: 0x00004367
		public static IRestResponse<TResponse> Post<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.POST));
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00006177 File Offset: 0x00004377
		public static IRestResponse<TResponse> Put<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.PUT));
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00006187 File Offset: 0x00004387
		public static IRestResponse<TResponse> Head<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.HEAD));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00006197 File Offset: 0x00004397
		public static IRestResponse<TResponse> Options<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.OPTIONS));
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000061A7 File Offset: 0x000043A7
		public static IRestResponse<TResponse> Patch<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.PATCH));
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000061B7 File Offset: 0x000043B7
		public static IRestResponse<TResponse> Delete<[Nullable(2)] TRequest, [Nullable(2)] TResponse>(this IRestClient client, JsonRequest<TRequest, TResponse> request) where TResponse : new()
		{
			return request.UpdateResponse(client.Execute<TResponse>(request, Method.DELETE));
		}
	}
}
