using System;

namespace System.Collections.Generic
{
	// Token: 0x020004BA RID: 1210
	[Serializable]
	internal class GenericComparer<T> : Comparer<T> where T : IComparable<T>
	{
		// Token: 0x06003A26 RID: 14886 RVA: 0x000DDD07 File Offset: 0x000DBF07
		public override int Compare(T x, T y)
		{
			if (x != null)
			{
				if (y != null)
				{
					return x.CompareTo(y);
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

		// Token: 0x06003A27 RID: 14887 RVA: 0x000DDD38 File Offset: 0x000DBF38
		public override bool Equals(object obj)
		{
			GenericComparer<T> genericComparer = obj as GenericComparer<T>;
			return genericComparer != null;
		}

		// Token: 0x06003A28 RID: 14888 RVA: 0x000DDD50 File Offset: 0x000DBF50
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
