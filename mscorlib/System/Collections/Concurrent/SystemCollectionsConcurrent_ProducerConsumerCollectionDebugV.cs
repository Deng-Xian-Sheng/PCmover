using System;
using System.Diagnostics;

namespace System.Collections.Concurrent
{
	// Token: 0x020004AB RID: 1195
	internal sealed class SystemCollectionsConcurrent_ProducerConsumerCollectionDebugView<T>
	{
		// Token: 0x06003921 RID: 14625 RVA: 0x000DAACC File Offset: 0x000D8CCC
		public SystemCollectionsConcurrent_ProducerConsumerCollectionDebugView(IProducerConsumerCollection<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			this.m_collection = collection;
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06003922 RID: 14626 RVA: 0x000DAAE9 File Offset: 0x000D8CE9
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items
		{
			get
			{
				return this.m_collection.ToArray();
			}
		}

		// Token: 0x0400190C RID: 6412
		private IProducerConsumerCollection<T> m_collection;
	}
}
