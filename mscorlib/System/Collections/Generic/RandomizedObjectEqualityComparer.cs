using System;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004C9 RID: 1225
	internal sealed class RandomizedObjectEqualityComparer : IEqualityComparer, IWellKnownStringEqualityComparer
	{
		// Token: 0x06003AAD RID: 15021 RVA: 0x000DF77A File Offset: 0x000DD97A
		public RandomizedObjectEqualityComparer()
		{
			this._entropy = HashHelpers.GetEntropy();
		}

		// Token: 0x06003AAE RID: 15022 RVA: 0x000DF78D File Offset: 0x000DD98D
		public bool Equals(object x, object y)
		{
			if (x != null)
			{
				return y != null && x.Equals(y);
			}
			return y == null;
		}

		// Token: 0x06003AAF RID: 15023 RVA: 0x000DF7A8 File Offset: 0x000DD9A8
		[SecuritySafeCritical]
		public int GetHashCode(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			string text = obj as string;
			if (text != null)
			{
				return string.InternalMarvin32HashString(text, text.Length, this._entropy);
			}
			return obj.GetHashCode();
		}

		// Token: 0x06003AB0 RID: 15024 RVA: 0x000DF7E0 File Offset: 0x000DD9E0
		public override bool Equals(object obj)
		{
			RandomizedObjectEqualityComparer randomizedObjectEqualityComparer = obj as RandomizedObjectEqualityComparer;
			return randomizedObjectEqualityComparer != null && this._entropy == randomizedObjectEqualityComparer._entropy;
		}

		// Token: 0x06003AB1 RID: 15025 RVA: 0x000DF807 File Offset: 0x000DDA07
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode() ^ (int)(this._entropy & 2147483647L);
		}

		// Token: 0x06003AB2 RID: 15026 RVA: 0x000DF828 File Offset: 0x000DDA28
		IEqualityComparer IWellKnownStringEqualityComparer.GetRandomizedEqualityComparer()
		{
			return new RandomizedObjectEqualityComparer();
		}

		// Token: 0x06003AB3 RID: 15027 RVA: 0x000DF82F File Offset: 0x000DDA2F
		IEqualityComparer IWellKnownStringEqualityComparer.GetEqualityComparerForSerialization()
		{
			return null;
		}

		// Token: 0x0400194B RID: 6475
		private long _entropy;
	}
}
