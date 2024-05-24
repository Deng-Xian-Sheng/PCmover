using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x0200003E RID: 62
	[NullableContext(1)]
	[Nullable(0)]
	public static class ImmutableStack
	{
		// Token: 0x06000346 RID: 838 RVA: 0x00008E25 File Offset: 0x00007025
		public static ImmutableStack<T> Create<[Nullable(2)] T>()
		{
			return ImmutableStack<T>.Empty;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00008E2C File Offset: 0x0000702C
		public static ImmutableStack<T> Create<[Nullable(2)] T>(T item)
		{
			return ImmutableStack<T>.Empty.Push(item);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00008E3C File Offset: 0x0000703C
		public static ImmutableStack<T> CreateRange<[Nullable(2)] T>(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
			foreach (T value in items)
			{
				immutableStack = immutableStack.Push(value);
			}
			return immutableStack;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00008E98 File Offset: 0x00007098
		public static ImmutableStack<T> Create<[Nullable(2)] T>(params T[] items)
		{
			Requires.NotNull<T[]>(items, "items");
			ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
			foreach (T value in items)
			{
				immutableStack = immutableStack.Push(value);
			}
			return immutableStack;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00008ED7 File Offset: 0x000070D7
		public static IImmutableStack<T> Pop<[Nullable(2)] T>(this IImmutableStack<T> stack, out T value)
		{
			Requires.NotNull<IImmutableStack<T>>(stack, "stack");
			value = stack.Peek();
			return stack.Pop();
		}
	}
}
