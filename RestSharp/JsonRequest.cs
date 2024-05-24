using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using RestSharp.Extensions;

namespace RestSharp
{
	// Token: 0x02000019 RID: 25
	[NullableContext(1)]
	[Nullable(0)]
	public class JsonRequest<[Nullable(2)] TRequest, [Nullable(2)] TResponse> : RestRequest
	{
		// Token: 0x06000229 RID: 553 RVA: 0x00003B30 File Offset: 0x00001D30
		public JsonRequest(string resource, TRequest request) : base(resource)
		{
			base.AddJsonBody(request);
			this._changeResponse.Add(new Action<IRestResponse<TResponse>>(this.ApplyCustomResponse));
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003B80 File Offset: 0x00001D80
		public JsonRequest<TRequest, TResponse> ResponseForStatusCode(HttpStatusCode statusCode, TResponse response)
		{
			Func<TResponse> <>9__1;
			return this.With(delegate(JsonRequest<TRequest, TResponse> x)
			{
				Dictionary<HttpStatusCode, Func<TResponse>> customResponses = this._customResponses;
				HttpStatusCode statusCode2 = statusCode;
				Func<TResponse> value;
				if ((value = <>9__1) == null)
				{
					value = (<>9__1 = (() => response));
				}
				customResponses.Add(statusCode2, value);
			});
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00003BBC File Offset: 0x00001DBC
		public JsonRequest<TRequest, TResponse> ResponseForStatusCode(HttpStatusCode statusCode, Func<TResponse> getResponse)
		{
			return this.With(delegate(JsonRequest<TRequest, TResponse> x)
			{
				this._customResponses.Add(statusCode, getResponse);
			});
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00003BF8 File Offset: 0x00001DF8
		public JsonRequest<TRequest, TResponse> ChangeResponse(Action<IRestResponse<TResponse>> change)
		{
			return this.With(delegate(JsonRequest<TRequest, TResponse> x)
			{
				x._changeResponse.Add(change);
			});
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00003C24 File Offset: 0x00001E24
		private void ApplyCustomResponse(IRestResponse<TResponse> response)
		{
			Func<TResponse> func;
			if (this._customResponses.TryGetValue(response.StatusCode, out func))
			{
				response.Data = func();
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00003C54 File Offset: 0x00001E54
		internal IRestResponse<TResponse> UpdateResponse(IRestResponse<TResponse> response)
		{
			this._changeResponse.ForEach(delegate(Action<IRestResponse<TResponse>> x)
			{
				x(response);
			});
			return response;
		}

		// Token: 0x04000076 RID: 118
		private readonly List<Action<IRestResponse<TResponse>>> _changeResponse = new List<Action<IRestResponse<TResponse>>>();

		// Token: 0x04000077 RID: 119
		private readonly Dictionary<HttpStatusCode, Func<TResponse>> _customResponses = new Dictionary<HttpStatusCode, Func<TResponse>>();
	}
}
