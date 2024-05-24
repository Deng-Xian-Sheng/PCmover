using System;

namespace System.Collections
{
	// Token: 0x020004A8 RID: 1192
	[Serializable]
	internal class StructuralComparer : IComparer
	{
		// Token: 0x060038FC RID: 14588 RVA: 0x000DA4C8 File Offset: 0x000D86C8
		public int Compare(object x, object y)
		{
			if (x == null)
			{
				if (y != null)
				{
					return -1;
				}
				return 0;
			}
			else
			{
				if (y == null)
				{
					return 1;
				}
				IStructuralComparable structuralComparable = x as IStructuralComparable;
				if (structuralComparable != null)
				{
					return structuralComparable.CompareTo(y, this);
				}
				return Comparer.Default.Compare(x, y);
			}
		}
	}
}
