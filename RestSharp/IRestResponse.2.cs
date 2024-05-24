using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000018 RID: 24
	[NullableContext(1)]
	public interface IRestResponse<[Nullable(2)] T> : IRestResponse
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000227 RID: 551
		// (set) Token: 0x06000228 RID: 552
		T Data { get; set; }
	}
}
