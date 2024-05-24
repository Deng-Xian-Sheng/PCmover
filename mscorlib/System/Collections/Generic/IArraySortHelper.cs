using System;

namespace System.Collections.Generic
{
	// Token: 0x020004DC RID: 1244
	internal interface IArraySortHelper<TKey>
	{
		// Token: 0x06003B2F RID: 15151
		void Sort(TKey[] keys, int index, int length, IComparer<TKey> comparer);

		// Token: 0x06003B30 RID: 15152
		int BinarySearch(TKey[] keys, int index, int length, TKey value, IComparer<TKey> comparer);
	}
}
