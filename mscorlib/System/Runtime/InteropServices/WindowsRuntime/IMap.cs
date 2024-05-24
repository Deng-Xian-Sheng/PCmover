using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A1D RID: 2589
	[Guid("3c2925fe-8519-45c1-aa79-197b6718c1c1")]
	[ComImport]
	internal interface IMap<K, V> : IIterable<IKeyValuePair<K, V>>, IEnumerable<IKeyValuePair<K, V>>, IEnumerable
	{
		// Token: 0x060065ED RID: 26093
		V Lookup(K key);

		// Token: 0x17001184 RID: 4484
		// (get) Token: 0x060065EE RID: 26094
		uint Size { get; }

		// Token: 0x060065EF RID: 26095
		bool HasKey(K key);

		// Token: 0x060065F0 RID: 26096
		IReadOnlyDictionary<K, V> GetView();

		// Token: 0x060065F1 RID: 26097
		bool Insert(K key, V value);

		// Token: 0x060065F2 RID: 26098
		void Remove(K key);

		// Token: 0x060065F3 RID: 26099
		void Clear();
	}
}
