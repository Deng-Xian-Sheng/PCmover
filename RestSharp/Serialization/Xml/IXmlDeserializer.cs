using System;
using System.Runtime.CompilerServices;
using RestSharp.Deserializers;

namespace RestSharp.Serialization.Xml
{
	// Token: 0x0200003F RID: 63
	[NullableContext(1)]
	public interface IXmlDeserializer : IDeserializer, IWithRootElement
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600048F RID: 1167
		// (set) Token: 0x06000490 RID: 1168
		string Namespace { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000491 RID: 1169
		// (set) Token: 0x06000492 RID: 1170
		string DateFormat { get; set; }
	}
}
