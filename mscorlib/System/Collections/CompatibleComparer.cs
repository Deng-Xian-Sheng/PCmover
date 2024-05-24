using System;

namespace System.Collections
{
	// Token: 0x02000493 RID: 1171
	[Serializable]
	internal class CompatibleComparer : IEqualityComparer
	{
		// Token: 0x06003832 RID: 14386 RVA: 0x000D7CE4 File Offset: 0x000D5EE4
		internal CompatibleComparer(IComparer comparer, IHashCodeProvider hashCodeProvider)
		{
			this._comparer = comparer;
			this._hcp = hashCodeProvider;
		}

		// Token: 0x06003833 RID: 14387 RVA: 0x000D7CFC File Offset: 0x000D5EFC
		public int Compare(object a, object b)
		{
			if (a == b)
			{
				return 0;
			}
			if (a == null)
			{
				return -1;
			}
			if (b == null)
			{
				return 1;
			}
			if (this._comparer != null)
			{
				return this._comparer.Compare(a, b);
			}
			IComparable comparable = a as IComparable;
			if (comparable != null)
			{
				return comparable.CompareTo(b);
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_ImplementIComparable"));
		}

		// Token: 0x06003834 RID: 14388 RVA: 0x000D7D50 File Offset: 0x000D5F50
		public bool Equals(object a, object b)
		{
			return this.Compare(a, b) == 0;
		}

		// Token: 0x06003835 RID: 14389 RVA: 0x000D7D5D File Offset: 0x000D5F5D
		public int GetHashCode(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (this._hcp != null)
			{
				return this._hcp.GetHashCode(obj);
			}
			return obj.GetHashCode();
		}

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06003836 RID: 14390 RVA: 0x000D7D88 File Offset: 0x000D5F88
		internal IComparer Comparer
		{
			get
			{
				return this._comparer;
			}
		}

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06003837 RID: 14391 RVA: 0x000D7D90 File Offset: 0x000D5F90
		internal IHashCodeProvider HashCodeProvider
		{
			get
			{
				return this._hcp;
			}
		}

		// Token: 0x040018D4 RID: 6356
		private IComparer _comparer;

		// Token: 0x040018D5 RID: 6357
		private IHashCodeProvider _hcp;
	}
}
