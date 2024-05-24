using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000031 RID: 49
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableHashSet
	{
		// Token: 0x060001EE RID: 494 RVA: 0x000064B4 File Offset: 0x000046B4
		public static ImmutableHashSet<T> Create<[Nullable(2)] T>()
		{
			return ImmutableHashSet<T>.Empty;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000064BB File Offset: 0x000046BB
		public static ImmutableHashSet<T> Create<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000064C8 File Offset: 0x000046C8
		public static ImmutableHashSet<T> Create<[Nullable(2)] T>(T item)
		{
			return ImmutableHashSet<T>.Empty.Add(item);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x000064D5 File Offset: 0x000046D5
		public static ImmutableHashSet<T> Create<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer, T item)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer).Add(item);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000064E8 File Offset: 0x000046E8
		public static ImmutableHashSet<T> CreateRange<[Nullable(2)] T>(IEnumerable<T> items)
		{
			return ImmutableHashSet<T>.Empty.Union(items);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000064F5 File Offset: 0x000046F5
		public static ImmutableHashSet<T> CreateRange<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer, IEnumerable<T> items)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer).Union(items);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00006508 File Offset: 0x00004708
		public static ImmutableHashSet<T> Create<[Nullable(2)] T>(params T[] items)
		{
			return ImmutableHashSet<T>.Empty.Union(items);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00006515 File Offset: 0x00004715
		public static ImmutableHashSet<T> Create<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer, params T[] items)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer).Union(items);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00006528 File Offset: 0x00004728
		public static ImmutableHashSet<T>.Builder CreateBuilder<[Nullable(2)] T>()
		{
			return ImmutableHashSet.Create<T>().ToBuilder();
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00006534 File Offset: 0x00004734
		public static ImmutableHashSet<T>.Builder CreateBuilder<[Nullable(2)] T>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			return ImmutableHashSet.Create<T>(equalityComparer).ToBuilder();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00006544 File Offset: 0x00004744
		public static ImmutableHashSet<TSource> ToImmutableHashSet<[Nullable(2)] TSource>(this IEnumerable<TSource> source, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TSource> equalityComparer)
		{
			ImmutableHashSet<TSource> immutableHashSet = source as ImmutableHashSet<TSource>;
			if (immutableHashSet != null)
			{
				return immutableHashSet.WithComparer(equalityComparer);
			}
			return ImmutableHashSet<TSource>.Empty.WithComparer(equalityComparer).Union(source);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00006574 File Offset: 0x00004774
		public static ImmutableHashSet<TSource> ToImmutableHashSet<[Nullable(2)] TSource>(this ImmutableHashSet<TSource>.Builder builder)
		{
			Requires.NotNull<ImmutableHashSet<TSource>.Builder>(builder, "builder");
			return builder.ToImmutable();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00006587 File Offset: 0x00004787
		public static ImmutableHashSet<TSource> ToImmutableHashSet<[Nullable(2)] TSource>(this IEnumerable<TSource> source)
		{
			return source.ToImmutableHashSet(null);
		}
	}
}
