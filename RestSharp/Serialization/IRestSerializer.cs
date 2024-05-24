using System;
using System.Runtime.CompilerServices;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace RestSharp.Serialization
{
	// Token: 0x0200003C RID: 60
	[NullableContext(1)]
	public interface IRestSerializer : ISerializer, IDeserializer
	{
		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000489 RID: 1161
		string[] SupportedContentTypes { get; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600048A RID: 1162
		DataFormat DataFormat { get; }

		// Token: 0x0600048B RID: 1163
		string Serialize(Parameter parameter);
	}
}
