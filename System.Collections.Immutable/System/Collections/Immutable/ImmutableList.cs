using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000033 RID: 51
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableList
	{
		// Token: 0x0600020E RID: 526 RVA: 0x00006B0E File Offset: 0x00004D0E
		public static ImmutableList<T> Create<[Nullable(2)] T>()
		{
			return ImmutableList<T>.Empty;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00006B15 File Offset: 0x00004D15
		public static ImmutableList<T> Create<[Nullable(2)] T>(T item)
		{
			return ImmutableList<T>.Empty.Add(item);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00006B22 File Offset: 0x00004D22
		public static ImmutableList<T> CreateRange<[Nullable(2)] T>(IEnumerable<T> items)
		{
			return ImmutableList<T>.Empty.AddRange(items);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00006B2F File Offset: 0x00004D2F
		public static ImmutableList<T> Create<[Nullable(2)] T>(params T[] items)
		{
			return ImmutableList<T>.Empty.AddRange(items);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00006B3C File Offset: 0x00004D3C
		public static ImmutableList<T>.Builder CreateBuilder<[Nullable(2)] T>()
		{
			return ImmutableList.Create<T>().ToBuilder();
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00006B48 File Offset: 0x00004D48
		public static ImmutableList<TSource> ToImmutableList<[Nullable(2)] TSource>(this IEnumerable<TSource> source)
		{
			ImmutableList<TSource> immutableList = source as ImmutableList<TSource>;
			if (immutableList != null)
			{
				return immutableList;
			}
			return ImmutableList<TSource>.Empty.AddRange(source);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00006B6C File Offset: 0x00004D6C
		public static ImmutableList<TSource> ToImmutableList<[Nullable(2)] TSource>(this ImmutableList<TSource>.Builder builder)
		{
			Requires.NotNull<ImmutableList<TSource>.Builder>(builder, "builder");
			return builder.ToImmutable();
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00006B7F File Offset: 0x00004D7F
		public static IImmutableList<T> Replace<[Nullable(2)] T>(this IImmutableList<T> list, T oldValue, T newValue)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.Replace(oldValue, newValue, EqualityComparer<T>.Default);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00006B99 File Offset: 0x00004D99
		public static IImmutableList<T> Remove<[Nullable(2)] T>(this IImmutableList<T> list, T value)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.Remove(value, EqualityComparer<T>.Default);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00006BB2 File Offset: 0x00004DB2
		public static IImmutableList<T> RemoveRange<[Nullable(2)] T>(this IImmutableList<T> list, IEnumerable<T> items)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.RemoveRange(items, EqualityComparer<T>.Default);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00006BCB File Offset: 0x00004DCB
		public static int IndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, 0, list.Count, EqualityComparer<T>.Default);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00006BEB File Offset: 0x00004DEB
		public static int IndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, 0, list.Count, equalityComparer);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00006C07 File Offset: 0x00004E07
		public static int IndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item, int startIndex)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, startIndex, list.Count - startIndex, EqualityComparer<T>.Default);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00006C29 File Offset: 0x00004E29
		public static int IndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item, int startIndex, int count)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, startIndex, count, EqualityComparer<T>.Default);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00006C44 File Offset: 0x00004E44
		public static int LastIndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			if (list.Count == 0)
			{
				return -1;
			}
			return list.LastIndexOf(item, list.Count - 1, list.Count, EqualityComparer<T>.Default);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00006C75 File Offset: 0x00004E75
		public static int LastIndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<T> equalityComparer)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			if (list.Count == 0)
			{
				return -1;
			}
			return list.LastIndexOf(item, list.Count - 1, list.Count, equalityComparer);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00006CA2 File Offset: 0x00004EA2
		public static int LastIndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item, int startIndex)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			if (list.Count == 0 && startIndex == 0)
			{
				return -1;
			}
			return list.LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00006CCC File Offset: 0x00004ECC
		public static int LastIndexOf<[Nullable(2)] T>(this IImmutableList<T> list, T item, int startIndex, int count)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);
		}
	}
}
