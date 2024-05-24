using System;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200002C RID: 44
	[NullableContext(1)]
	[GeneratedCode("simple-json", "1.0.0")]
	public interface IJsonSerializerStrategy
	{
		// Token: 0x060003FA RID: 1018
		bool TrySerializeNonPrimitiveObject(object input, out object output);

		// Token: 0x060003FB RID: 1019
		object DeserializeObject(object value, Type type);
	}
}
