using System;

namespace System.Collections.Generic
{
	// Token: 0x020004BB RID: 1211
	[Serializable]
	internal class NullableComparer<T> : Comparer<T?> where T : struct, IComparable<T>
	{
		// Token: 0x06003A2A RID: 14890 RVA: 0x000DDD6A File Offset: 0x000DBF6A
		public override int Compare(T? x, T? y)
		{
			if (x != null)
			{
				if (y != null)
				{
					return x.value.CompareTo(y.value);
				}
				return 1;
			}
			else
			{
				if (y != null)
				{
					return -1;
				}
				return 0;
			}
		}

		// Token: 0x06003A2B RID: 14891 RVA: 0x000DDDA8 File Offset: 0x000DBFA8
		public override bool Equals(object obj)
		{
			NullableComparer<T> nullableComparer = obj as NullableComparer<T>;
			return nullableComparer != null;
		}

		// Token: 0x06003A2C RID: 14892 RVA: 0x000DDDC0 File Offset: 0x000DBFC0
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
