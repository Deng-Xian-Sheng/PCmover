using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200043B RID: 1083
	internal abstract class ConcurrentSetItem<KeyType, ItemType> where ItemType : ConcurrentSetItem<KeyType, ItemType>
	{
		// Token: 0x060035DA RID: 13786
		public abstract int Compare(ItemType other);

		// Token: 0x060035DB RID: 13787
		public abstract int Compare(KeyType key);
	}
}
