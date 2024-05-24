using System;
using System.Collections.Generic;

namespace System.Collections.Concurrent
{
	// Token: 0x020004AA RID: 1194
	[__DynamicallyInvokable]
	public interface IProducerConsumerCollection<T> : IEnumerable<!0>, IEnumerable, ICollection
	{
		// Token: 0x0600391D RID: 14621
		[__DynamicallyInvokable]
		void CopyTo(T[] array, int index);

		// Token: 0x0600391E RID: 14622
		[__DynamicallyInvokable]
		bool TryAdd(T item);

		// Token: 0x0600391F RID: 14623
		[__DynamicallyInvokable]
		bool TryTake(out T item);

		// Token: 0x06003920 RID: 14624
		[__DynamicallyInvokable]
		T[] ToArray();
	}
}
