using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008EB RID: 2283
	public interface ITuple
	{
		// Token: 0x17001026 RID: 4134
		// (get) Token: 0x06005E02 RID: 24066
		int Length { get; }

		// Token: 0x17001027 RID: 4135
		object this[int index]
		{
			get;
		}
	}
}
