using System;

namespace System.Collections.Generic
{
	// Token: 0x020004BC RID: 1212
	[Serializable]
	internal class ObjectComparer<T> : Comparer<T>
	{
		// Token: 0x06003A2E RID: 14894 RVA: 0x000DDDDA File Offset: 0x000DBFDA
		public override int Compare(T x, T y)
		{
			return Comparer.Default.Compare(x, y);
		}

		// Token: 0x06003A2F RID: 14895 RVA: 0x000DDDF4 File Offset: 0x000DBFF4
		public override bool Equals(object obj)
		{
			ObjectComparer<T> objectComparer = obj as ObjectComparer<T>;
			return objectComparer != null;
		}

		// Token: 0x06003A30 RID: 14896 RVA: 0x000DDE0C File Offset: 0x000DC00C
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
