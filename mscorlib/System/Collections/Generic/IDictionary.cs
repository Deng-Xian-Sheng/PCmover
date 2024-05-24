using System;

namespace System.Collections.Generic
{
	// Token: 0x020004D1 RID: 1233
	[__DynamicallyInvokable]
	public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		// Token: 0x170008E8 RID: 2280
		[__DynamicallyInvokable]
		TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get;
			[__DynamicallyInvokable]
			set;
		}

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x06003AC8 RID: 15048
		[__DynamicallyInvokable]
		ICollection<TKey> Keys { [__DynamicallyInvokable] get; }

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x06003AC9 RID: 15049
		[__DynamicallyInvokable]
		ICollection<TValue> Values { [__DynamicallyInvokable] get; }

		// Token: 0x06003ACA RID: 15050
		[__DynamicallyInvokable]
		bool ContainsKey(TKey key);

		// Token: 0x06003ACB RID: 15051
		[__DynamicallyInvokable]
		void Add(TKey key, TValue value);

		// Token: 0x06003ACC RID: 15052
		[__DynamicallyInvokable]
		bool Remove(TKey key);

		// Token: 0x06003ACD RID: 15053
		[__DynamicallyInvokable]
		bool TryGetValue(TKey key, out TValue value);
	}
}
