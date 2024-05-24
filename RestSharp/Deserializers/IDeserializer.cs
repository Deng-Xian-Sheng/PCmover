using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Deserializers
{
	// Token: 0x02000038 RID: 56
	[NullableContext(1)]
	public interface IDeserializer
	{
		// Token: 0x0600046A RID: 1130
		T Deserialize<[Nullable(2)] T>(IRestResponse response);
	}
}
