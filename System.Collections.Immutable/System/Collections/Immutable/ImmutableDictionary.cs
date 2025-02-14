﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x0200002B RID: 43
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableDictionary
	{
		// Token: 0x06000180 RID: 384 RVA: 0x000054A3 File Offset: 0x000036A3
		public static ImmutableDictionary<TKey, TValue> Create<TKey, [Nullable(2)] TValue>()
		{
			return ImmutableDictionary<TKey, TValue>.Empty;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000054AA File Offset: 0x000036AA
		public static ImmutableDictionary<TKey, TValue> Create<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000054B7 File Offset: 0x000036B7
		public static ImmutableDictionary<TKey, TValue> Create<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TValue> valueComparer)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000054C5 File Offset: 0x000036C5
		public static ImmutableDictionary<TKey, TValue> CreateRange<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.AddRange(items);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000054D2 File Offset: 0x000036D2
		public static ImmutableDictionary<TKey, TValue> CreateRange<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer).AddRange(items);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000054E5 File Offset: 0x000036E5
		public static ImmutableDictionary<TKey, TValue> CreateRange<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TValue> valueComparer, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(items);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000054F9 File Offset: 0x000036F9
		public static ImmutableDictionary<TKey, TValue>.Builder CreateBuilder<TKey, [Nullable(2)] TValue>()
		{
			return ImmutableDictionary.Create<TKey, TValue>().ToBuilder();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00005505 File Offset: 0x00003705
		public static ImmutableDictionary<TKey, TValue>.Builder CreateBuilder<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer)
		{
			return ImmutableDictionary.Create<TKey, TValue>(keyComparer).ToBuilder();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00005512 File Offset: 0x00003712
		public static ImmutableDictionary<TKey, TValue>.Builder CreateBuilder<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TValue> valueComparer)
		{
			return ImmutableDictionary.Create<TKey, TValue>(keyComparer, valueComparer).ToBuilder();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00005520 File Offset: 0x00003720
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<[Nullable(2)] TSource, TKey, [Nullable(2)] TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<IEnumerable<TSource>>(source, "source");
			Requires.NotNull<Func<TSource, TKey>>(keySelector, "keySelector");
			Requires.NotNull<Func<TSource, TValue>>(elementSelector, "elementSelector");
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(from element in source
			select new KeyValuePair<TKey, TValue>(keySelector(element), elementSelector(element)));
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00005590 File Offset: 0x00003790
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, [Nullable(2)] TValue>(this ImmutableDictionary<TKey, TValue>.Builder builder)
		{
			Requires.NotNull<ImmutableDictionary<TKey, TValue>.Builder>(builder, "builder");
			return builder.ToImmutable();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000055A3 File Offset: 0x000037A3
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<[Nullable(2)] TSource, TKey, [Nullable(2)] TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer)
		{
			return source.ToImmutableDictionary(keySelector, elementSelector, keyComparer, null);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000055AF File Offset: 0x000037AF
		public static ImmutableDictionary<TKey, TSource> ToImmutableDictionary<[Nullable(2)] TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.ToImmutableDictionary(keySelector, (TSource v) => v, null, null);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000055D9 File Offset: 0x000037D9
		public static ImmutableDictionary<TKey, TSource> ToImmutableDictionary<[Nullable(2)] TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer)
		{
			return source.ToImmutableDictionary(keySelector, (TSource v) => v, keyComparer, null);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00005603 File Offset: 0x00003803
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<[Nullable(2)] TSource, TKey, [Nullable(2)] TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
		{
			return source.ToImmutableDictionary(keySelector, elementSelector, null, null);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005610 File Offset: 0x00003810
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] this IEnumerable<KeyValuePair<TKey, TValue>> source, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(source, "source");
			ImmutableDictionary<TKey, TValue> immutableDictionary = source as ImmutableDictionary<TKey, TValue>;
			if (immutableDictionary != null)
			{
				return immutableDictionary.WithComparers(keyComparer, valueComparer);
			}
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(source);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000564D File Offset: 0x0000384D
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] this IEnumerable<KeyValuePair<TKey, TValue>> source, [Nullable(new byte[]
		{
			2,
			1
		})] IEqualityComparer<TKey> keyComparer)
		{
			return source.ToImmutableDictionary(keyComparer, null);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005657 File Offset: 0x00003857
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, [Nullable(2)] TValue>([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return source.ToImmutableDictionary(null, null);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00005661 File Offset: 0x00003861
		public static bool Contains<TKey, [Nullable(2)] TValue>(this IImmutableDictionary<TKey, TValue> map, TKey key, TValue value)
		{
			Requires.NotNull<IImmutableDictionary<TKey, TValue>>(map, "map");
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return map.Contains(new KeyValuePair<TKey, TValue>(key, value));
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00005688 File Offset: 0x00003888
		[return: Nullable(2)]
		public static TValue GetValueOrDefault<TKey, [Nullable(2)] TValue>(this IImmutableDictionary<TKey, TValue> dictionary, TKey key)
		{
			return dictionary.GetValueOrDefault(key, default(TValue));
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000056A8 File Offset: 0x000038A8
		public static TValue GetValueOrDefault<TKey, [Nullable(2)] TValue>(this IImmutableDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
		{
			Requires.NotNull<IImmutableDictionary<TKey, TValue>>(dictionary, "dictionary");
			Requires.NotNullAllowStructs<TKey>(key, "key");
			TValue result;
			if (dictionary.TryGetValue(key, out result))
			{
				return result;
			}
			return defaultValue;
		}
	}
}
