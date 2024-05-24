using System;
using System.Collections.Generic;

namespace System.Collections.ObjectModel
{
	// Token: 0x02000004 RID: 4
	public static class CollectionExtensions
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002170 File Offset: 0x00000370
		public static Collection<T> AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			foreach (T item in items)
			{
				collection.Add(item);
			}
			return collection;
		}
	}
}
