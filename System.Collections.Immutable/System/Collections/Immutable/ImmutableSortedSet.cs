using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x0200003B RID: 59
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableSortedSet
	{
		// Token: 0x060002EE RID: 750 RVA: 0x000082A0 File Offset: 0x000064A0
		public static ImmutableSortedSet<T> Create<[Nullable(2)] T>()
		{
			return ImmutableSortedSet<T>.Empty;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000082A7 File Offset: 0x000064A7
		public static ImmutableSortedSet<T> Create<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000082B4 File Offset: 0x000064B4
		public static ImmutableSortedSet<T> Create<[Nullable(2)] T>(T item)
		{
			return ImmutableSortedSet<T>.Empty.Add(item);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000082C1 File Offset: 0x000064C1
		public static ImmutableSortedSet<T> Create<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer, T item)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Add(item);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000082D4 File Offset: 0x000064D4
		public static ImmutableSortedSet<T> CreateRange<[Nullable(2)] T>(IEnumerable<T> items)
		{
			return ImmutableSortedSet<T>.Empty.Union(items);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x000082E1 File Offset: 0x000064E1
		public static ImmutableSortedSet<T> CreateRange<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer, IEnumerable<T> items)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Union(items);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000082F4 File Offset: 0x000064F4
		public static ImmutableSortedSet<T> Create<[Nullable(2)] T>(params T[] items)
		{
			return ImmutableSortedSet<T>.Empty.Union(items);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00008301 File Offset: 0x00006501
		public static ImmutableSortedSet<T> Create<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer, params T[] items)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Union(items);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00008314 File Offset: 0x00006514
		public static ImmutableSortedSet<T>.Builder CreateBuilder<[Nullable(2)] T>()
		{
			return ImmutableSortedSet.Create<T>().ToBuilder();
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00008320 File Offset: 0x00006520
		public static ImmutableSortedSet<T>.Builder CreateBuilder<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return ImmutableSortedSet.Create<T>(comparer).ToBuilder();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00008330 File Offset: 0x00006530
		public static ImmutableSortedSet<TSource> ToImmutableSortedSet<[Nullable(2)] TSource>(this IEnumerable<TSource> source, [Nullable(new byte[]
		{
			2,
			1
		})] IComparer<TSource> comparer)
		{
			ImmutableSortedSet<TSource> immutableSortedSet = source as ImmutableSortedSet<TSource>;
			if (immutableSortedSet != null)
			{
				return immutableSortedSet.WithComparer(comparer);
			}
			return ImmutableSortedSet<TSource>.Empty.WithComparer(comparer).Union(source);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00008360 File Offset: 0x00006560
		public static ImmutableSortedSet<TSource> ToImmutableSortedSet<[Nullable(2)] TSource>(this IEnumerable<TSource> source)
		{
			return source.ToImmutableSortedSet(null);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00008369 File Offset: 0x00006569
		public static ImmutableSortedSet<TSource> ToImmutableSortedSet<[Nullable(2)] TSource>(this ImmutableSortedSet<TSource>.Builder builder)
		{
			Requires.NotNull<ImmutableSortedSet<TSource>.Builder>(builder, "builder");
			return builder.ToImmutable();
		}
	}
}
