using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000028 RID: 40
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableArray
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00003C77 File Offset: 0x00001E77
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<T>()
		{
			return ImmutableArray<T>.Empty;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003C80 File Offset: 0x00001E80
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<[Nullable(2)] T>(T item)
		{
			T[] items = new T[]
			{
				item
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003CA4 File Offset: 0x00001EA4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<[Nullable(2)] T>(T item1, T item2)
		{
			T[] items = new T[]
			{
				item1,
				item2
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003CD0 File Offset: 0x00001ED0
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<[Nullable(2)] T>(T item1, T item2, T item3)
		{
			T[] items = new T[]
			{
				item1,
				item2,
				item3
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003D04 File Offset: 0x00001F04
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<[Nullable(2)] T>(T item1, T item2, T item3, T item4)
		{
			T[] items = new T[]
			{
				item1,
				item2,
				item3,
				item4
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003D40 File Offset: 0x00001F40
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> CreateRange<[Nullable(2)] T>(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			IImmutableArray immutableArray = items as IImmutableArray;
			if (immutableArray != null)
			{
				Array array = immutableArray.Array;
				if (array == null)
				{
					throw new InvalidOperationException(SR.InvalidOperationOnDefaultArray);
				}
				return new ImmutableArray<T>((T[])array);
			}
			else
			{
				int count;
				if (items.TryGetCount(out count))
				{
					return new ImmutableArray<T>(items.ToArray(count));
				}
				return new ImmutableArray<T>(items.ToArray<T>());
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00003DA8 File Offset: 0x00001FA8
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<T>([Nullable(new byte[]
		{
			2,
			1
		})] params T[] items)
		{
			if (items == null || items.Length == 0)
			{
				return ImmutableArray<T>.Empty;
			}
			T[] array = new T[items.Length];
			Array.Copy(items, array, items.Length);
			return new ImmutableArray<T>(array);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00003DDC File Offset: 0x00001FDC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<[Nullable(2)] T>(T[] items, int start, int length)
		{
			Requires.NotNull<T[]>(items, "items");
			Requires.Range(start >= 0 && start <= items.Length, "start", null);
			Requires.Range(length >= 0 && start + length <= items.Length, "length", null);
			if (length == 0)
			{
				return ImmutableArray.Create<T>();
			}
			T[] array = new T[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = items[start + i];
			}
			return new ImmutableArray<T>(array);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00003E60 File Offset: 0x00002060
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> Create<T>([Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<T> items, int start, int length)
		{
			Requires.Range(start >= 0 && start <= items.Length, "start", null);
			Requires.Range(length >= 0 && start + length <= items.Length, "length", null);
			if (length == 0)
			{
				return ImmutableArray.Create<T>();
			}
			if (start == 0 && length == items.Length)
			{
				return items;
			}
			T[] array = new T[length];
			Array.Copy(items.array, start, array, 0, length);
			return new ImmutableArray<T>(array);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00003EE4 File Offset: 0x000020E4
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<TResult> CreateRange<TSource, TResult>([Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<TSource> items, [Nullable(1)] Func<TSource, TResult> selector)
		{
			Requires.NotNull<Func<TSource, TResult>>(selector, "selector");
			int length = items.Length;
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i]);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00003F40 File Offset: 0x00002140
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<TResult> CreateRange<TSource, TResult>([Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<TSource> items, int start, int length, [Nullable(1)] Func<TSource, TResult> selector)
		{
			int length2 = items.Length;
			Requires.Range(start >= 0 && start <= length2, "start", null);
			Requires.Range(length >= 0 && start + length <= length2, "length", null);
			Requires.NotNull<Func<TSource, TResult>>(selector, "selector");
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i + start]);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00003FD0 File Offset: 0x000021D0
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<TResult> CreateRange<TSource, TArg, TResult>([Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<TSource> items, [Nullable(1)] Func<TSource, TArg, TResult> selector, [Nullable(1)] TArg arg)
		{
			Requires.NotNull<Func<TSource, TArg, TResult>>(selector, "selector");
			int length = items.Length;
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i], arg);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000402C File Offset: 0x0000222C
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<TResult> CreateRange<TSource, TArg, TResult>([Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<TSource> items, int start, int length, [Nullable(1)] Func<TSource, TArg, TResult> selector, [Nullable(1)] TArg arg)
		{
			int length2 = items.Length;
			Requires.Range(start >= 0 && start <= length2, "start", null);
			Requires.Range(length >= 0 && start + length <= length2, "length", null);
			Requires.NotNull<Func<TSource, TArg, TResult>>(selector, "selector");
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i + start], arg);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000040C0 File Offset: 0x000022C0
		public static ImmutableArray<T>.Builder CreateBuilder<[Nullable(2)] T>()
		{
			return ImmutableArray.Create<T>().ToBuilder();
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000040DA File Offset: 0x000022DA
		public static ImmutableArray<T>.Builder CreateBuilder<[Nullable(2)] T>(int initialCapacity)
		{
			return new ImmutableArray<T>.Builder(initialCapacity);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000040E2 File Offset: 0x000022E2
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<TSource> ToImmutableArray<[Nullable(2)] TSource>(this IEnumerable<TSource> items)
		{
			if (items is ImmutableArray<TSource>)
			{
				return (ImmutableArray<TSource>)items;
			}
			return ImmutableArray.CreateRange<TSource>(items);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000040F9 File Offset: 0x000022F9
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<TSource> ToImmutableArray<[Nullable(2)] TSource>(this ImmutableArray<TSource>.Builder builder)
		{
			Requires.NotNull<ImmutableArray<TSource>.Builder>(builder, "builder");
			return builder.ToImmutable();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000410C File Offset: 0x0000230C
		public static int BinarySearch<[Nullable(2)] T>([Nullable(new byte[]
		{
			0,
			1
		})] this ImmutableArray<T> array, T value)
		{
			return Array.BinarySearch<T>(array.array, value);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000411A File Offset: 0x0000231A
		public static int BinarySearch<[Nullable(2)] T>([Nullable(new byte[]
		{
			0,
			1
		})] this ImmutableArray<T> array, T value, [Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return Array.BinarySearch<T>(array.array, value, comparer);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004129 File Offset: 0x00002329
		public static int BinarySearch<[Nullable(2)] T>([Nullable(new byte[]
		{
			0,
			1
		})] this ImmutableArray<T> array, int index, int length, T value)
		{
			return Array.BinarySearch<T>(array.array, index, length, value);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00004139 File Offset: 0x00002339
		public static int BinarySearch<[Nullable(2)] T>([Nullable(new byte[]
		{
			0,
			1
		})] this ImmutableArray<T> array, int index, int length, T value, [Nullable(new byte[]
		{
			2,
			1
		})] IComparer<T> comparer)
		{
			return Array.BinarySearch<T>(array.array, index, length, value, comparer);
		}

		// Token: 0x04000019 RID: 25
		internal static readonly byte[] TwoElementArray = new byte[2];
	}
}
