using System;

namespace System.Collections.Generic
{
	// Token: 0x020004E0 RID: 1248
	internal interface IArraySortHelper<TKey, TValue>
	{
		// Token: 0x06003B4F RID: 15183
		void Sort(TKey[] keys, TValue[] values, int index, int length, IComparer<TKey> comparer);
	}
}
