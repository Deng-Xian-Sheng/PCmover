using System;

namespace System.Collections.Generic
{
	// Token: 0x020004BD RID: 1213
	[Serializable]
	internal class ComparisonComparer<T> : Comparer<T>
	{
		// Token: 0x06003A32 RID: 14898 RVA: 0x000DDE26 File Offset: 0x000DC026
		public ComparisonComparer(Comparison<T> comparison)
		{
			this._comparison = comparison;
		}

		// Token: 0x06003A33 RID: 14899 RVA: 0x000DDE35 File Offset: 0x000DC035
		public override int Compare(T x, T y)
		{
			return this._comparison(x, y);
		}

		// Token: 0x0400193A RID: 6458
		private readonly Comparison<T> _comparison;
	}
}
