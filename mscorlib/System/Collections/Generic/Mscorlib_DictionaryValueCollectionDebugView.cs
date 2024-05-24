using System;
using System.Diagnostics;

namespace System.Collections.Generic
{
	// Token: 0x020004CC RID: 1228
	internal sealed class Mscorlib_DictionaryValueCollectionDebugView<TKey, TValue>
	{
		// Token: 0x06003AB8 RID: 15032 RVA: 0x000DF8BC File Offset: 0x000DDABC
		public Mscorlib_DictionaryValueCollectionDebugView(ICollection<TValue> collection)
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
			}
			this.collection = collection;
		}

		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x06003AB9 RID: 15033 RVA: 0x000DF8D4 File Offset: 0x000DDAD4
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public TValue[] Items
		{
			get
			{
				TValue[] array = new TValue[this.collection.Count];
				this.collection.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x0400194E RID: 6478
		private ICollection<TValue> collection;
	}
}
