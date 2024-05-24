using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000023 RID: 35
	[NullableContext(1)]
	public interface IImmutableStack<[Nullable(2)] T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000B1 RID: 177
		bool IsEmpty { get; }

		// Token: 0x060000B2 RID: 178
		IImmutableStack<T> Clear();

		// Token: 0x060000B3 RID: 179
		IImmutableStack<T> Push(T value);

		// Token: 0x060000B4 RID: 180
		IImmutableStack<T> Pop();

		// Token: 0x060000B5 RID: 181
		T Peek();
	}
}
