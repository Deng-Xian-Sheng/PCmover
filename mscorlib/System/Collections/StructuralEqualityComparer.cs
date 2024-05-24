using System;

namespace System.Collections
{
	// Token: 0x020004A7 RID: 1191
	[Serializable]
	internal class StructuralEqualityComparer : IEqualityComparer
	{
		// Token: 0x060038F9 RID: 14585 RVA: 0x000DA45C File Offset: 0x000D865C
		public bool Equals(object x, object y)
		{
			if (x == null)
			{
				return y == null;
			}
			IStructuralEquatable structuralEquatable = x as IStructuralEquatable;
			if (structuralEquatable != null)
			{
				return structuralEquatable.Equals(y, this);
			}
			return y != null && x.Equals(y);
		}

		// Token: 0x060038FA RID: 14586 RVA: 0x000DA494 File Offset: 0x000D8694
		public int GetHashCode(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			IStructuralEquatable structuralEquatable = obj as IStructuralEquatable;
			if (structuralEquatable != null)
			{
				return structuralEquatable.GetHashCode(this);
			}
			return obj.GetHashCode();
		}
	}
}
