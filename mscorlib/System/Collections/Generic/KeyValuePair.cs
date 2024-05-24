using System;
using System.Text;

namespace System.Collections.Generic
{
	// Token: 0x020004DA RID: 1242
	[__DynamicallyInvokable]
	[Serializable]
	public struct KeyValuePair<TKey, TValue>
	{
		// Token: 0x06003AE2 RID: 15074 RVA: 0x000DF9E0 File Offset: 0x000DDBE0
		[__DynamicallyInvokable]
		public KeyValuePair(TKey key, TValue value)
		{
			this.key = key;
			this.value = value;
		}

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x06003AE3 RID: 15075 RVA: 0x000DF9F0 File Offset: 0x000DDBF0
		[__DynamicallyInvokable]
		public TKey Key
		{
			[__DynamicallyInvokable]
			get
			{
				return this.key;
			}
		}

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x06003AE4 RID: 15076 RVA: 0x000DF9F8 File Offset: 0x000DDBF8
		[__DynamicallyInvokable]
		public TValue Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this.value;
			}
		}

		// Token: 0x06003AE5 RID: 15077 RVA: 0x000DFA00 File Offset: 0x000DDC00
		[__DynamicallyInvokable]
		public override string ToString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
			stringBuilder.Append('[');
			if (this.Key != null)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				TKey tkey = this.Key;
				stringBuilder2.Append(tkey.ToString());
			}
			stringBuilder.Append(", ");
			if (this.Value != null)
			{
				StringBuilder stringBuilder3 = stringBuilder;
				TValue tvalue = this.Value;
				stringBuilder3.Append(tvalue.ToString());
			}
			stringBuilder.Append(']');
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		// Token: 0x04001951 RID: 6481
		private TKey key;

		// Token: 0x04001952 RID: 6482
		private TValue value;
	}
}
