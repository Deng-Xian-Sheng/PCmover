using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace System.Collections.Generic
{
	// Token: 0x020004CE RID: 1230
	internal sealed class Mscorlib_KeyedCollectionDebugView<K, T>
	{
		// Token: 0x06003ABC RID: 15036 RVA: 0x000DF944 File Offset: 0x000DDB44
		public Mscorlib_KeyedCollectionDebugView(KeyedCollection<K, T> keyedCollection)
		{
			if (keyedCollection == null)
			{
				throw new ArgumentNullException("keyedCollection");
			}
			this.kc = keyedCollection;
		}

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x06003ABD RID: 15037 RVA: 0x000DF964 File Offset: 0x000DDB64
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items
		{
			get
			{
				T[] array = new T[this.kc.Count];
				this.kc.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x04001950 RID: 6480
		private KeyedCollection<K, T> kc;
	}
}
