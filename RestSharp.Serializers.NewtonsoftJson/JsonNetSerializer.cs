using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Deserializers;
using RestSharp.Serialization;

namespace RestSharp.Serializers.NewtonsoftJson
{
	// Token: 0x02000002 RID: 2
	public class JsonNetSerializer : IRestSerializer, ISerializer, IDeserializer
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public JsonNetSerializer()
		{
			this._serializer = JsonSerializer.Create(JsonNetSerializer.DefaultSettings);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B4 File Offset: 0x000002B4
		public JsonNetSerializer(JsonSerializerSettings settings)
		{
			this._serializer = JsonSerializer.Create(settings);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002114 File Offset: 0x00000314
		public string Serialize(object obj)
		{
			WriterBuffer writerBuffer;
			if ((writerBuffer = JsonNetSerializer.tWriterBuffer) == null)
			{
				writerBuffer = (JsonNetSerializer.tWriterBuffer = new WriterBuffer(this._serializer));
			}
			string result;
			using (WriterBuffer writerBuffer2 = writerBuffer)
			{
				this._serializer.Serialize(writerBuffer2.GetJsonTextWriter(), obj, obj.GetType());
				result = writerBuffer2.GetStringWriter().ToString();
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002180 File Offset: 0x00000380
		public string Serialize(Parameter bodyParameter)
		{
			return this.Serialize(bodyParameter.Value);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002190 File Offset: 0x00000390
		public T Deserialize<T>(IRestResponse response)
		{
			T result;
			using (JsonTextReader jsonTextReader = new JsonTextReader(new StringReader(response.Content))
			{
				CloseInput = true
			})
			{
				result = this._serializer.Deserialize<T>(jsonTextReader);
			}
			return result;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000021E0 File Offset: 0x000003E0
		public string[] SupportedContentTypes { get; } = new string[]
		{
			"application/json",
			"text/json",
			"text/x-json",
			"text/javascript",
			"*+json"
		};

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000021E8 File Offset: 0x000003E8
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000021F0 File Offset: 0x000003F0
		public string ContentType { get; set; } = "application/json";

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000021F9 File Offset: 0x000003F9
		public DataFormat DataFormat { get; }

		// Token: 0x04000001 RID: 1
		public static readonly JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			DefaultValueHandling = DefaultValueHandling.Include,
			TypeNameHandling = TypeNameHandling.None,
			NullValueHandling = NullValueHandling.Ignore,
			Formatting = Formatting.None,
			ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
		};

		// Token: 0x04000002 RID: 2
		[ThreadStatic]
		private static WriterBuffer tWriterBuffer;

		// Token: 0x04000003 RID: 3
		private readonly JsonSerializer _serializer;
	}
}
