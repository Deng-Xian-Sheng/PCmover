using System;

namespace System.Collections.Generic
{
	// Token: 0x020004C2 RID: 1218
	[Serializable]
	internal class ObjectEqualityComparer<T> : EqualityComparer<T>
	{
		// Token: 0x06003A82 RID: 14978 RVA: 0x000DF276 File Offset: 0x000DD476
		public override bool Equals(T x, T y)
		{
			if (x != null)
			{
				return y != null && x.Equals(y);
			}
			return y == null;
		}

		// Token: 0x06003A83 RID: 14979 RVA: 0x000DF2A9 File Offset: 0x000DD4A9
		public override int GetHashCode(T obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return obj.GetHashCode();
		}

		// Token: 0x06003A84 RID: 14980 RVA: 0x000DF2C4 File Offset: 0x000DD4C4
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

		// Token: 0x06003A85 RID: 14981 RVA: 0x000DF338 File Offset: 0x000DD538
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

		// Token: 0x06003A86 RID: 14982 RVA: 0x000DF3AC File Offset: 0x000DD5AC
		public override bool Equals(object obj)
		{
			ObjectEqualityComparer<T> objectEqualityComparer = obj as ObjectEqualityComparer<T>;
			return objectEqualityComparer != null;
		}

		// Token: 0x06003A87 RID: 14983 RVA: 0x000DF3C4 File Offset: 0x000DD5C4
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
