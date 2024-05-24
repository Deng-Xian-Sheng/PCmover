using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Serialization
{
	// Token: 0x0200003D RID: 61
	[NullableContext(1)]
	public interface IWithRootElement
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600048C RID: 1164
		// (set) Token: 0x0600048D RID: 1165
		string RootElement { get; set; }
	}
}
