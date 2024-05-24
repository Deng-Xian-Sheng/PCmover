using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x02000032 RID: 50
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableInterlocked
	{
		// Token: 0x060001FB RID: 507 RVA: 0x00006590 File Offset: 0x00004790
		public static bool Update<[Nullable(2)] T>(ref T location, Func<T, T> transformer) where T : class
		{
			Requires.NotNull<Func<T, T>>(transformer, "transformer");
			T t = Volatile.Read<T>(ref location);
			for (;;)
			{
				T t2 = transformer(t);
				if (t == t2)
				{
					break;
				}
				T t3 = Interlocked.CompareExchange<T>(ref location, t2, t);
				bool flag = t == t3;
				t = t3;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000065E8 File Offset: 0x000047E8
		public static bool Update<[Nullable(2)] T, [Nullable(2)] TArg>(ref T location, Func<T, TArg, T> transformer, TArg transformerArgument) where T : class
		{
			Requires.NotNull<Func<T, TArg, T>>(transformer, "transformer");
			T t = Volatile.Read<T>(ref location);
			for (;;)
			{
				T t2 = transformer(t, transformerArgument);
				if (t == t2)
				{
					break;
				}
				T t3 = Interlocked.CompareExchange<T>(ref location, t2, t);
				bool flag = t == t3;
				t = t3;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00006640 File Offset: 0x00004840
		[NullableContext(2)]
		public static bool Update<T>([Nullable(new byte[]
		{
			0,
			1
		})] ref ImmutableArray<T> location, [Nullable(new byte[]
		{
			1,
			0,
			1,
			0,
			1
		})] Func<ImmutableArray<T>, ImmutableArray<T>> transformer)
		{
			Requires.NotNull<Func<ImmutableArray<T>, ImmutableArray<T>>>(transformer, "transformer");
			T[] array = Volatile.Read<T[]>(ref location.array);
			for (;;)
			{
				ImmutableArray<T> immutableArray = transformer(new ImmutableArray<T>(array));
				if (array == immutableArray.array)
				{
					break;
				}
				T[] array2 = Interlocked.CompareExchange<T[]>(ref location.array, immutableArray.array, array);
				bool flag = array == array2;
				array = array2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000669C File Offset: 0x0000489C
		[NullableContext(2)]
		public static bool Update<T, TArg>([Nullable(new byte[]
		{
			0,
			1
		})] ref ImmutableArray<T> location, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1,
			0,
			1
		})] Func<ImmutableArray<T>, TArg, ImmutableArray<T>> transformer, [Nullable(1)] TArg transformerArgument)
		{
			Requires.NotNull<Func<ImmutableArray<T>, TArg, ImmutableArray<T>>>(transformer, "transformer");
			T[] array = Volatile.Read<T[]>(ref location.array);
			for (;;)
			{
				ImmutableArray<T> immutableArray = transformer(new ImmutableArray<T>(array), transformerArgument);
				if (array == immutableArray.array)
				{
					break;
				}
				T[] array2 = Interlocked.CompareExchange<T[]>(ref location.array, immutableArray.array, array);
				bool flag = array == array2;
				array = array2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000066F7 File Offset: 0x000048F7
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> InterlockedExchange<T>([Nullable(new byte[]
		{
			0,
			1
		})] ref ImmutableArray<T> location, [Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<T> value)
		{
			return new ImmutableArray<T>(Interlocked.Exchange<T[]>(ref location.array, value.array));
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000670F File Offset: 0x0000490F
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static ImmutableArray<T> InterlockedCompareExchange<T>([Nullable(new byte[]
		{
			0,
			1
		})] ref ImmutableArray<T> location, [Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<T> value, [Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<T> comparand)
		{
			return new ImmutableArray<T>(Interlocked.CompareExchange<T[]>(ref location.array, value.array, comparand.array));
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00006730 File Offset: 0x00004930
		[NullableContext(2)]
		public static bool InterlockedInitialize<T>([Nullable(new byte[]
		{
			0,
			1
		})] ref ImmutableArray<T> location, [Nullable(new byte[]
		{
			0,
			1
		})] ImmutableArray<T> value)
		{
			return ImmutableInterlocked.InterlockedCompareExchange<T>(ref location, value, default(ImmutableArray<T>)).IsDefault;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00006758 File Offset: 0x00004958
		public static TValue GetOrAdd<TKey, [Nullable(2)] TValue, [Nullable(2)] TArg>(ref ImmutableDictionary<TKey, TValue> location, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)
		{
			Requires.NotNull<Func<TKey, TArg, TValue>>(valueFactory, "valueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
			TValue tvalue;
			if (immutableDictionary.TryGetValue(key, out tvalue))
			{
				return tvalue;
			}
			tvalue = valueFactory(key, factoryArgument);
			return ImmutableInterlocked.GetOrAdd<TKey, TValue>(ref location, key, tvalue);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000067A0 File Offset: 0x000049A0
		public static TValue GetOrAdd<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, Func<TKey, TValue> valueFactory)
		{
			Requires.NotNull<Func<TKey, TValue>>(valueFactory, "valueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
			TValue tvalue;
			if (immutableDictionary.TryGetValue(key, out tvalue))
			{
				return tvalue;
			}
			tvalue = valueFactory(key);
			return ImmutableInterlocked.GetOrAdd<TKey, TValue>(ref location, key, tvalue);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x000067E8 File Offset: 0x000049E8
		public static TValue GetOrAdd<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue value)
		{
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			TValue result;
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				if (immutableDictionary.TryGetValue(key, out result))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value2 = immutableDictionary.Add(key, value);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value2, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return value;
				}
			}
			return result;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00006834 File Offset: 0x00004A34
		public static TValue AddOrUpdate<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
		{
			Requires.NotNull<Func<TKey, TValue>>(addValueFactory, "addValueFactory");
			Requires.NotNull<Func<TKey, TValue, TValue>>(updateValueFactory, "updateValueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			TValue tvalue;
			bool flag;
			do
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				TValue arg;
				if (immutableDictionary.TryGetValue(key, out arg))
				{
					tvalue = updateValueFactory(key, arg);
				}
				else
				{
					tvalue = addValueFactory(key);
				}
				ImmutableDictionary<TKey, TValue> value = immutableDictionary.SetItem(key, tvalue);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value, immutableDictionary);
				flag = (immutableDictionary == immutableDictionary2);
				immutableDictionary = immutableDictionary2;
			}
			while (!flag);
			return tvalue;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000068AC File Offset: 0x00004AAC
		public static TValue AddOrUpdate<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
		{
			Requires.NotNull<Func<TKey, TValue, TValue>>(updateValueFactory, "updateValueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			TValue tvalue;
			bool flag;
			do
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				TValue arg;
				if (immutableDictionary.TryGetValue(key, out arg))
				{
					tvalue = updateValueFactory(key, arg);
				}
				else
				{
					tvalue = addValue;
				}
				ImmutableDictionary<TKey, TValue> value = immutableDictionary.SetItem(key, tvalue);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value, immutableDictionary);
				flag = (immutableDictionary == immutableDictionary2);
				immutableDictionary = immutableDictionary2;
			}
			while (!flag);
			return tvalue;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00006910 File Offset: 0x00004B10
		public static bool TryAdd<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue value)
		{
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				if (immutableDictionary.ContainsKey(key))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value2 = immutableDictionary.Add(key, value);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value2, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00006958 File Offset: 0x00004B58
		public static bool TryUpdate<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue newValue, TValue comparisonValue)
		{
			EqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				TValue x;
				if (!immutableDictionary.TryGetValue(key, out x) || !@default.Equals(x, comparisonValue))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value = immutableDictionary.SetItem(key, newValue);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x000069B8 File Offset: 0x00004BB8
		public static bool TryRemove<TKey, [Nullable(2)] TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, [MaybeNullWhen(false)] out TValue value)
		{
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				if (!immutableDictionary.TryGetValue(key, out value))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value2 = immutableDictionary.Remove(key);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value2, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00006A00 File Offset: 0x00004C00
		public static bool TryPop<[Nullable(2)] T>(ref ImmutableStack<T> location, [MaybeNullWhen(false)] out T value)
		{
			ImmutableStack<T> immutableStack = Volatile.Read<ImmutableStack<T>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableStack<T>>(immutableStack, "location");
				if (immutableStack.IsEmpty)
				{
					break;
				}
				ImmutableStack<T> value2 = immutableStack.Pop(out value);
				ImmutableStack<T> immutableStack2 = Interlocked.CompareExchange<ImmutableStack<T>>(ref location, value2, immutableStack);
				bool flag = immutableStack == immutableStack2;
				immutableStack = immutableStack2;
				if (flag)
				{
					return true;
				}
			}
			value = default(T);
			return false;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00006A4C File Offset: 0x00004C4C
		public static void Push<[Nullable(2)] T>(ref ImmutableStack<T> location, T value)
		{
			ImmutableStack<T> immutableStack = Volatile.Read<ImmutableStack<T>>(ref location);
			bool flag;
			do
			{
				Requires.NotNull<ImmutableStack<T>>(immutableStack, "location");
				ImmutableStack<T> value2 = immutableStack.Push(value);
				ImmutableStack<T> immutableStack2 = Interlocked.CompareExchange<ImmutableStack<T>>(ref location, value2, immutableStack);
				flag = (immutableStack == immutableStack2);
				immutableStack = immutableStack2;
			}
			while (!flag);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00006A88 File Offset: 0x00004C88
		public static bool TryDequeue<[Nullable(2)] T>(ref ImmutableQueue<T> location, [MaybeNullWhen(false)] out T value)
		{
			ImmutableQueue<T> immutableQueue = Volatile.Read<ImmutableQueue<T>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableQueue<T>>(immutableQueue, "location");
				if (immutableQueue.IsEmpty)
				{
					break;
				}
				ImmutableQueue<T> value2 = immutableQueue.Dequeue(out value);
				ImmutableQueue<T> immutableQueue2 = Interlocked.CompareExchange<ImmutableQueue<T>>(ref location, value2, immutableQueue);
				bool flag = immutableQueue == immutableQueue2;
				immutableQueue = immutableQueue2;
				if (flag)
				{
					return true;
				}
			}
			value = default(T);
			return false;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00006AD4 File Offset: 0x00004CD4
		public static void Enqueue<[Nullable(2)] T>(ref ImmutableQueue<T> location, T value)
		{
			ImmutableQueue<T> immutableQueue = Volatile.Read<ImmutableQueue<T>>(ref location);
			bool flag;
			do
			{
				Requires.NotNull<ImmutableQueue<T>>(immutableQueue, "location");
				ImmutableQueue<T> value2 = immutableQueue.Enqueue(value);
				ImmutableQueue<T> immutableQueue2 = Interlocked.CompareExchange<ImmutableQueue<T>>(ref location, value2, immutableQueue);
				flag = (immutableQueue == immutableQueue2);
				immutableQueue = immutableQueue2;
			}
			while (!flag);
		}
	}
}
