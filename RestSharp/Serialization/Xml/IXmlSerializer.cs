using System;
using System.Runtime.CompilerServices;
using RestSharp.Serializers;

namespace RestSharp.Serialization.Xml
{
	// Token: 0x02000040 RID: 64
	[NullableContext(1)]
	public interface IXmlSerializer : ISerializer, IWithRootElement
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000493 RID: 1171
		// (set) Token: 0x06000494 RID: 1172
		string Namespace { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000495 RID: 1173
		// (set) Token: 0x06000496 RID: 1174
		string DateFormat { get; set; }
	}
}
