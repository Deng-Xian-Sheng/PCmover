using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Serializers
{
	// Token: 0x02000032 RID: 50
	[NullableContext(1)]
	public interface ISerializer
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000436 RID: 1078
		// (set) Token: 0x06000437 RID: 1079
		string ContentType { get; set; }

		// Token: 0x06000438 RID: 1080
		string Serialize(object obj);
	}
}
