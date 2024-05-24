using System;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A20 RID: 2592
	internal sealed class CLRIKeyValuePairImpl<K, V> : IKeyValuePair<K, V>
	{
		// Token: 0x060065FA RID: 26106 RVA: 0x00159B48 File Offset: 0x00157D48
		public CLRIKeyValuePairImpl([In] ref KeyValuePair<K, V> pair)
		{
			this._pair = pair;
		}

		// Token: 0x17001188 RID: 4488
		// (get) Token: 0x060065FB RID: 26107 RVA: 0x00159B5C File Offset: 0x00157D5C
		public K Key
		{
			get
			{
				return this._pair.Key;
			}
		}

		// Token: 0x17001189 RID: 4489
		// (get) Token: 0x060065FC RID: 26108 RVA: 0x00159B78 File Offset: 0x00157D78
		public V Value
		{
			get
			{
				return this._pair.Value;
			}
		}

		// Token: 0x060065FD RID: 26109 RVA: 0x00159B94 File Offset: 0x00157D94
		internal static object BoxHelper(object pair)
		{
			KeyValuePair<K, V> keyValuePair = (KeyValuePair<K, V>)pair;
			return new CLRIKeyValuePairImpl<K, V>(ref keyValuePair);
		}

		// Token: 0x060065FE RID: 26110 RVA: 0x00159BB0 File Offset: 0x00157DB0
		internal static object UnboxHelper(object wrapper)
		{
			CLRIKeyValuePairImpl<K, V> clrikeyValuePairImpl = (CLRIKeyValuePairImpl<K, V>)wrapper;
			return clrikeyValuePairImpl._pair;
		}

		// Token: 0x060065FF RID: 26111 RVA: 0x00159BD0 File Offset: 0x00157DD0
		public override string ToString()
		{
			return this._pair.ToString();
		}

		// Token: 0x04002D3D RID: 11581
		private readonly KeyValuePair<K, V> _pair;
	}
}
