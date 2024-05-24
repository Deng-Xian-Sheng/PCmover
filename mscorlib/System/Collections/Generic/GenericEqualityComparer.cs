using System;

namespace System.Collections.Generic
{
	// Token: 0x020004C0 RID: 1216
	[Serializable]
	internal class GenericEqualityComparer<T> : EqualityComparer<T> where T : IEquatable<T>
	{
		// Token: 0x06003A74 RID: 14964 RVA: 0x000DEFB4 File Offset: 0x000DD1B4
		public override bool Equals(T x, T y)
		{
			if (x != null)
			{
				return y != null && x.Equals(y);
			}
			return y == null;
		}

		// Token: 0x06003A75 RID: 14965 RVA: 0x000DEFE2 File Offset: 0x000DD1E2
		public override int GetHashCode(T obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return obj.GetHashCode();
		}

		// Token: 0x06003A76 RID: 14966 RVA: 0x000DEFFC File Offset: 0x000DD1FC
		internal override int IndexOf(T[] array, T value, int startIndex, int count)
		{
			int num = startIndex + count;
			if (value == null)
			{
				for (int i = startIndex; i < num; i++)
				{
					if (array[i] == null)
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = startIndex; j < num; j++)
				{
					if (array[j] != null && array[j].Equals(value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003A77 RID: 14967 RVA: 0x000DF068 File Offset: 0x000DD268
		internal override int LastIndexOf(T[] array, T value, int startIndex, int count)
		{
			int num = startIndex - count + 1;
			if (value == null)
			{
				for (int i = startIndex; i >= num; i--)
				{
					if (array[i] == null)
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = startIndex; j >= num; j--)
				{
					if (array[j] != null && array[j].Equals(value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003A78 RID: 14968 RVA: 0x000DF0D8 File Offset: 0x000DD2D8
		public override bool Equals(object obj)
		{
			GenericEqualityComparer<T> genericEqualityComparer = obj as GenericEqualityComparer<T>;
			return genericEqualityComparer != null;
		}

		// Token: 0x06003A79 RID: 14969 RVA: 0x000DF0F0 File Offset: 0x000DD2F0
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
