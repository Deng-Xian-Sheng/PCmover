using System;
using System.Diagnostics;

namespace System.Collections.Generic
{
	// Token: 0x020004CA RID: 1226
	internal sealed class Mscorlib_CollectionDebugView<T>
	{
		// Token: 0x06003AB4 RID: 15028 RVA: 0x000DF832 File Offset: 0x000DDA32
		public Mscorlib_CollectionDebugView(ICollection<T> collection)
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
			}
			this.collection = collection;
		}

		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x06003AB5 RID: 15029 RVA: 0x000DF84C File Offset: 0x000DDA4C
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items
		{
			get
			{
				T[] array = new T[this.collection.Count];
				this.collection.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x0400194C RID: 6476
		private ICollection<T> collection;
	}
}
