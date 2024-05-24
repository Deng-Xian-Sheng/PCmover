using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Collections.Concurrent
{
	// Token: 0x020004B0 RID: 1200
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public abstract class Partitioner<TSource>
	{
		// Token: 0x06003989 RID: 14729
		[__DynamicallyInvokable]
		public abstract IList<IEnumerator<TSource>> GetPartitions(int partitionCount);

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x0600398A RID: 14730 RVA: 0x000DC75A File Offset: 0x000DA95A
		[__DynamicallyInvokable]
		public virtual bool SupportsDynamicPartitions
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x0600398B RID: 14731 RVA: 0x000DC75D File Offset: 0x000DA95D
		[__DynamicallyInvokable]
		public virtual IEnumerable<TSource> GetDynamicPartitions()
		{
			throw new NotSupportedException(Environment.GetResourceString("Partitioner_DynamicPartitionsNotSupported"));
		}

		// Token: 0x0600398C RID: 14732 RVA: 0x000DC76E File Offset: 0x000DA96E
		[__DynamicallyInvokable]
		protected Partitioner()
		{
		}
	}
}
