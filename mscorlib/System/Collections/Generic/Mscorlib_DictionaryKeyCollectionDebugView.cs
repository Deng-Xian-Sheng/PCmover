using System;
using System.Diagnostics;

namespace System.Collections.Generic
{
	// Token: 0x020004CB RID: 1227
	internal sealed class Mscorlib_DictionaryKeyCollectionDebugView<TKey, TValue>
	{
		// Token: 0x06003AB6 RID: 15030 RVA: 0x000DF878 File Offset: 0x000DDA78
		public Mscorlib_DictionaryKeyCollectionDebugView(ICollection<TKey> collection)
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
			}
			this.collection = collection;
		}

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x06003AB7 RID: 15031 RVA: 0x000DF890 File Offset: 0x000DDA90
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public TKey[] Items
		{
			get
			{
				TKey[] array = new TKey[this.collection.Count];
				this.collection.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x0400194D RID: 6477
		private ICollection<TKey> collection;
	}
}
