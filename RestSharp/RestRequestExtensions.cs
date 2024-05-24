using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using RestSharp.Serialization;
using RestSharp.Serializers;

namespace RestSharp
{
	// Token: 0x02000024 RID: 36
	[NullableContext(1)]
	[Nullable(0)]
	internal static class RestRequestExtensions
	{
		// Token: 0x0600036D RID: 877 RVA: 0x00006BF8 File Offset: 0x00004DF8
		internal static void SerializeRequestBody(this IRestRequest request, IDictionary<DataFormat, IRestSerializer> restSerializers, params ISerializer[] serializers)
		{
			Parameter parameter = request.Parameters.FirstOrDefault((Parameter p) => p.Type == ParameterType.RequestBody);
			if (parameter == null)
			{
				return;
			}
			if (parameter.DataFormat == DataFormat.None)
			{
				request.Body = new RequestBody(parameter.ContentType, parameter.Name, parameter.Value);
				return;
			}
			string contentType = parameter.ContentType ?? ContentType.FromDataFormat[parameter.DataFormat];
			ISerializer serializer = serializers.FirstOrDefault((ISerializer x) => x != null && x.ContentType == contentType);
			if (serializer != null)
			{
				request.Body = new RequestBody(serializer.ContentType, serializer.ContentType, serializer.Serialize(parameter.Value));
				return;
			}
			IRestSerializer restSerializer;
			if (!restSerializers.TryGetValue(parameter.DataFormat, out restSerializer))
			{
				throw new InvalidDataContractException(string.Format("Can't find serializer for content type {0}", parameter.DataFormat));
			}
			request.Body = new RequestBody(restSerializer.ContentType, restSerializer.ContentType, restSerializer.Serialize(parameter));
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00006D04 File Offset: 0x00004F04
		internal static void AddBody(this IHttp http, RequestBody requestBody)
		{
			if (requestBody.Value == null)
			{
				return;
			}
			http.RequestContentType = (string.IsNullOrWhiteSpace(requestBody.Name) ? requestBody.ContentType : requestBody.Name);
			if (http.AlwaysMultipartFormData || http.Files.Any<HttpFile>())
			{
				http.Parameters.Add(new HttpParameter(requestBody.Name, requestBody.Value, requestBody.ContentType));
				return;
			}
			byte[] array = requestBody.Value as byte[];
			if (array != null)
			{
				http.RequestBodyBytes = array;
				return;
			}
			http.RequestBody = requestBody.Value.ToString();
		}
	}
}
