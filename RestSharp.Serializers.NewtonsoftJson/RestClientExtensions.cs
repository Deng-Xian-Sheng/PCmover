using System;
using Newtonsoft.Json;

namespace RestSharp.Serializers.NewtonsoftJson
{
	// Token: 0x02000003 RID: 3
	public static class RestClientExtensions
	{
		// Token: 0x0600000B RID: 11 RVA: 0x0000223B File Offset: 0x0000043B
		public static IRestClient UseNewtonsoftJson(this IRestClient client)
		{
			return client.UseSerializer(() => new JsonNetSerializer());
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002264 File Offset: 0x00000464
		public static IRestClient UseNewtonsoftJson(this IRestClient client, JsonSerializerSettings settings)
		{
			return client.UseSerializer(() => new JsonNetSerializer(settings));
		}
	}
}
