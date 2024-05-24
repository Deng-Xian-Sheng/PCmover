using System;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004C8 RID: 1224
	internal sealed class RandomizedStringEqualityComparer : IEqualityComparer<string>, IEqualityComparer, IWellKnownStringEqualityComparer
	{
		// Token: 0x06003AA4 RID: 15012 RVA: 0x000DF66C File Offset: 0x000DD86C
		public RandomizedStringEqualityComparer()
		{
			this._entropy = HashHelpers.GetEntropy();
		}

		// Token: 0x06003AA5 RID: 15013 RVA: 0x000DF67F File Offset: 0x000DD87F
		public bool Equals(object x, object y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x is string && y is string)
			{
				return this.Equals((string)x, (string)y);
			}
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
			return false;
		}

		// Token: 0x06003AA6 RID: 15014 RVA: 0x000DF6B9 File Offset: 0x000DD8B9
		public bool Equals(string x, string y)
		{
			if (x != null)
			{
				return y != null && x.Equals(y);
			}
			return y == null;
		}

		// Token: 0x06003AA7 RID: 15015 RVA: 0x000DF6D1 File Offset: 0x000DD8D1
		[SecuritySafeCritical]
		public int GetHashCode(string obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return string.InternalMarvin32HashString(obj, obj.Length, this._entropy);
		}

		// Token: 0x06003AA8 RID: 15016 RVA: 0x000DF6EC File Offset: 0x000DD8EC
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

		// Token: 0x06003AA9 RID: 15017 RVA: 0x000DF724 File Offset: 0x000DD924
		public override bool Equals(object obj)
		{
			RandomizedStringEqualityComparer randomizedStringEqualityComparer = obj as RandomizedStringEqualityComparer;
			return randomizedStringEqualityComparer != null && this._entropy == randomizedStringEqualityComparer._entropy;
		}

		// Token: 0x06003AAA RID: 15018 RVA: 0x000DF74B File Offset: 0x000DD94B
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode() ^ (int)(this._entropy & 2147483647L);
		}

		// Token: 0x06003AAB RID: 15019 RVA: 0x000DF76C File Offset: 0x000DD96C
		IEqualityComparer IWellKnownStringEqualityComparer.GetRandomizedEqualityComparer()
		{
			return new RandomizedStringEqualityComparer();
		}

		// Token: 0x06003AAC RID: 15020 RVA: 0x000DF773 File Offset: 0x000DD973
		IEqualityComparer IWellKnownStringEqualityComparer.GetEqualityComparerForSerialization()
		{
			return EqualityComparer<string>.Default;
		}

		// Token: 0x0400194A RID: 6474
		private long _entropy;
	}
}
