using System;
using Newtonsoft.Json;

namespace RestSharp.Serializers.NewtonsoftJson
{
	// Token: 0x02000004 RID: 4
	public static class RestRequestExtensions
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002290 File Offset: 0x00000490
		public static IRestRequest UseNewtonsoftJson(this IRestRequest request)
		{
			request.JsonSerializer = new JsonNetSerializer();
			return request;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000229E File Offset: 0x0000049E
		public static IRestRequest UseNewtonsoftJson(this IRestRequest request, JsonSerializerSettings settings)
		{
			request.JsonSerializer = new JsonNetSerializer(settings);
			return request;
		}
	}
}
