using System;

namespace System.Collections.Generic
{
	// Token: 0x020004D8 RID: 1240
	[__DynamicallyInvokable]
	public interface IReadOnlyDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		// Token: 0x06003AD9 RID: 15065
		[__DynamicallyInvokable]
		bool ContainsKey(TKey key);

		// Token: 0x06003ADA RID: 15066
		[__DynamicallyInvokable]
		bool TryGetValue(TKey key, out TValue value);

		// Token: 0x170008EF RID: 2287
		[__DynamicallyInvokable]
		TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get;
		}

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06003ADC RID: 15068
		[__DynamicallyInvokable]
		IEnumerable<TKey> Keys { [__DynamicallyInvokable] get; }

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x06003ADD RID: 15069
		[__DynamicallyInvokable]
		IEnumerable<TValue> Values { [__DynamicallyInvokable] get; }
	}
}
