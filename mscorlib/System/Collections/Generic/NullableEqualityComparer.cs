using System;

namespace System.Collections.Generic
{
	// Token: 0x020004C1 RID: 1217
	[Serializable]
	internal class NullableEqualityComparer<T> : EqualityComparer<T?> where T : struct, IEquatable<T>
	{
		// Token: 0x06003A7B RID: 14971 RVA: 0x000DF10A File Offset: 0x000DD30A
		public override bool Equals(T? x, T? y)
		{
			if (x != null)
			{
				return y != null && x.value.Equals(y.value);
			}
			return y == null;
		}

		// Token: 0x06003A7C RID: 14972 RVA: 0x000DF145 File Offset: 0x000DD345
		public override int GetHashCode(T? obj)
		{
			return obj.GetHashCode();
		}

		// Token: 0x06003A7D RID: 14973 RVA: 0x000DF154 File Offset: 0x000DD354
		internal override int IndexOf(T?[] array, T? value, int startIndex, int count)
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
					if (array[j] != null && array[j].value.Equals(value.value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003A7E RID: 14974 RVA: 0x000DF1CC File Offset: 0x000DD3CC
		internal override int LastIndexOf(T?[] array, T? value, int startIndex, int count)
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
					if (array[j] != null && array[j].value.Equals(value.value))
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003A7F RID: 14975 RVA: 0x000DF244 File Offset: 0x000DD444
		public override bool Equals(object obj)
		{
			NullableEqualityComparer<T> nullableEqualityComparer = obj as NullableEqualityComparer<T>;
			return nullableEqualityComparer != null;
		}

		// Token: 0x06003A80 RID: 14976 RVA: 0x000DF25C File Offset: 0x000DD45C
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
