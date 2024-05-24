using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000022 RID: 34
	[NullableContext(1)]
	public interface IImmutableSet<[Nullable(2)] T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x060000A2 RID: 162
		IImmutableSet<T> Clear();

		// Token: 0x060000A3 RID: 163
		bool Contains(T value);

		// Token: 0x060000A4 RID: 164
		IImmutableSet<T> Add(T value);

		// Token: 0x060000A5 RID: 165
		IImmutableSet<T> Remove(T value);

		// Token: 0x060000A6 RID: 166
		bool TryGetValue(T equalValue, out T actualValue);

		// Token: 0x060000A7 RID: 167
		IImmutableSet<T> Intersect(IEnumerable<T> other);

		// Token: 0x060000A8 RID: 168
		IImmutableSet<T> Except(IEnumerable<T> other);

		// Token: 0x060000A9 RID: 169
		IImmutableSet<T> SymmetricExcept(IEnumerable<T> other);

		// Token: 0x060000AA RID: 170
		IImmutableSet<T> Union(IEnumerable<T> other);

		// Token: 0x060000AB RID: 171
		bool SetEquals(IEnumerable<T> other);

		// Token: 0x060000AC RID: 172
		bool IsProperSubsetOf(IEnumerable<T> other);

		// Token: 0x060000AD RID: 173
		bool IsProperSupersetOf(IEnumerable<T> other);

		// Token: 0x060000AE RID: 174
		bool IsSubsetOf(IEnumerable<T> other);

		// Token: 0x060000AF RID: 175
		bool IsSupersetOf(IEnumerable<T> other);

		// Token: 0x060000B0 RID: 176
		bool Overlaps(IEnumerable<T> other);
	}
}
