using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A1E RID: 2590
	[Guid("e480ce40-a338-4ada-adcf-272272e48cb9")]
	[ComImport]
	internal interface IMapView<K, V> : IIterable<IKeyValuePair<K, V>>, IEnumerable<IKeyValuePair<K, V>>, IEnumerable
	{
		// Token: 0x060065F4 RID: 26100
		V Lookup(K key);

		// Token: 0x17001185 RID: 4485
		// (get) Token: 0x060065F5 RID: 26101
		uint Size { get; }

		// Token: 0x060065F6 RID: 26102
		bool HasKey(K key);

		// Token: 0x060065F7 RID: 26103
		void Split(out IMapView<K, V> first, out IMapView<K, V> second);
	}
}
