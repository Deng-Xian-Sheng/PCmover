using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RestSharp.Extensions
{
	// Token: 0x02000046 RID: 70
	internal static class CollectionExtensions
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x0000BA30 File Offset: 0x00009C30
		[NullableContext(1)]
		public static void ForEach<[Nullable(2)] T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (T obj in items)
			{
				action(obj);
			}
		}
	}
}
