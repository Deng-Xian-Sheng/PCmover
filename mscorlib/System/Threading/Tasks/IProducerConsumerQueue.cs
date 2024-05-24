using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Threading.Tasks
{
	// Token: 0x02000581 RID: 1409
	internal interface IProducerConsumerQueue<T> : IEnumerable<!0>, IEnumerable
	{
		// Token: 0x0600425C RID: 16988
		void Enqueue(T item);

		// Token: 0x0600425D RID: 16989
		bool TryDequeue(out T result);

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x0600425E RID: 16990
		bool IsEmpty { get; }

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x0600425F RID: 16991
		int Count { get; }

		// Token: 0x06004260 RID: 16992
		int GetCountSafe(object syncObj);
	}
}
