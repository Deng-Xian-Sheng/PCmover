using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks
{
	// Token: 0x02000582 RID: 1410
	[DebuggerDisplay("Count = {Count}")]
	internal sealed class MultiProducerMultiConsumerQueue<T> : ConcurrentQueue<T>, IProducerConsumerQueue<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06004261 RID: 16993 RVA: 0x000F71EB File Offset: 0x000F53EB
		void IProducerConsumerQueue<!0>.Enqueue(T item)
		{
			base.Enqueue(item);
		}

		// Token: 0x06004262 RID: 16994 RVA: 0x000F71F4 File Offset: 0x000F53F4
		bool IProducerConsumerQueue<!0>.TryDequeue(out T result)
		{
			return base.TryDequeue(out result);
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06004263 RID: 16995 RVA: 0x000F71FD File Offset: 0x000F53FD
		bool IProducerConsumerQueue<!0>.IsEmpty
		{
			get
			{
				return base.IsEmpty;
			}
		}

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06004264 RID: 16996 RVA: 0x000F7205 File Offset: 0x000F5405
		int IProducerConsumerQueue<!0>.Count
		{
			get
			{
				return base.Count;
			}
		}

		// Token: 0x06004265 RID: 16997 RVA: 0x000F720D File Offset: 0x000F540D
		int IProducerConsumerQueue<!0>.GetCountSafe(object syncObj)
		{
			return base.Count;
		}
	}
}
