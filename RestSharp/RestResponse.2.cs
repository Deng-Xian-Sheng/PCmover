using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using RestSharp.Extensions;

namespace RestSharp
{
	// Token: 0x02000027 RID: 39
	[NullableContext(1)]
	[Nullable(0)]
	[DebuggerDisplay("{DebuggerDisplay()}")]
	public class RestResponse : RestResponseBase, IRestResponse
	{
		// Token: 0x06000396 RID: 918 RVA: 0x0000702C File Offset: 0x0000522C
		private RestResponse SetHeaders(IEnumerable<HttpHeader> headers)
		{
			return this.With(delegate(RestResponse x)
			{
				x.Headers = (from p in headers
				select new Parameter(p.Name, p.Value, ParameterType.HttpHeader)).ToList<Parameter>();
			});
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00007058 File Offset: 0x00005258
		private RestResponse SetCookies(IEnumerable<HttpCookie> cookies)
		{
			return this.With(delegate(RestResponse x)
			{
				x.Cookies = cookies.Select(new Func<HttpCookie, RestResponseCookie>(RestResponseCookie.FromHttpCookie)).ToList<RestResponseCookie>();
			});
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00007084 File Offset: 0x00005284
		internal static RestResponse FromHttpResponse(IHttpResponse httpResponse, IRestRequest request)
		{
			return new RestResponse
			{
				Content = httpResponse.Content,
				ContentEncoding = httpResponse.ContentEncoding,
				ContentLength = httpResponse.ContentLength,
				ContentType = httpResponse.ContentType,
				ErrorException = httpResponse.ErrorException,
				ErrorMessage = httpResponse.ErrorMessage,
				RawBytes = httpResponse.RawBytes,
				ResponseStatus = httpResponse.ResponseStatus,
				ResponseUri = httpResponse.ResponseUri,
				ProtocolVersion = httpResponse.ProtocolVersion,
				Server = httpResponse.Server,
				StatusCode = httpResponse.StatusCode,
				StatusDescription = httpResponse.StatusDescription,
				Request = request
			}.SetHeaders(httpResponse.Headers).SetCookies(httpResponse.Cookies);
		}
	}
}
