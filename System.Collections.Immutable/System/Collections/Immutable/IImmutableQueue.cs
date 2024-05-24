using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000021 RID: 33
	[NullableContext(1)]
	public interface IImmutableQueue<[Nullable(2)] T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600009D RID: 157
		bool IsEmpty { get; }

		// Token: 0x0600009E RID: 158
		IImmutableQueue<T> Clear();

		// Token: 0x0600009F RID: 159
		T Peek();

		// Token: 0x060000A0 RID: 160
		IImmutableQueue<T> Enqueue(T value);

		// Token: 0x060000A1 RID: 161
		IImmutableQueue<T> Dequeue();
	}
}
