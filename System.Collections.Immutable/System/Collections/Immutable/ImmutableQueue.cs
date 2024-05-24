using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x02000036 RID: 54
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableQueue
	{
		// Token: 0x06000283 RID: 643 RVA: 0x000075C8 File Offset: 0x000057C8
		public static ImmutableQueue<T> Create<[Nullable(2)] T>()
		{
			return ImmutableQueue<T>.Empty;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x000075CF File Offset: 0x000057CF
		public static ImmutableQueue<T> Create<[Nullable(2)] T>(T item)
		{
			return ImmutableQueue<T>.Empty.Enqueue(item);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000075DC File Offset: 0x000057DC
		public static ImmutableQueue<T> CreateRange<[Nullable(2)] T>(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			T[] array = items as T[];
			if (array != null)
			{
				return ImmutableQueue.Create<T>(array);
			}
			ImmutableQueue<T> result;
			using (IEnumerator<T> enumerator = items.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					result = ImmutableQueue<T>.Empty;
				}
				else
				{
					ImmutableStack<T> forwards = ImmutableStack.Create<T>(enumerator.Current);
					ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
					while (enumerator.MoveNext())
					{
						T value = enumerator.Current;
						immutableStack = immutableStack.Push(value);
					}
					result = new ImmutableQueue<T>(forwards, immutableStack);
				}
			}
			return result;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00007670 File Offset: 0x00005870
		public static ImmutableQueue<T> Create<[Nullable(2)] T>(params T[] items)
		{
			Requires.NotNull<T[]>(items, "items");
			if (items.Length == 0)
			{
				return ImmutableQueue<T>.Empty;
			}
			ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
			for (int i = items.Length - 1; i >= 0; i--)
			{
				immutableStack = immutableStack.Push(items[i]);
			}
			return new ImmutableQueue<T>(immutableStack, ImmutableStack<T>.Empty);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x000076C1 File Offset: 0x000058C1
		public static IImmutableQueue<T> Dequeue<[Nullable(2)] T>(this IImmutableQueue<T> queue, out T value)
		{
			Requires.NotNull<IImmutableQueue<T>>(queue, "queue");
			value = queue.Peek();
			return queue.Dequeue();
		}
	}
}
