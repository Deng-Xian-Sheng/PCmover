using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Collections.Concurrent
{
	// Token: 0x020004B1 RID: 1201
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public abstract class OrderablePartitioner<TSource> : Partitioner<TSource>
	{
		// Token: 0x0600398D RID: 14733 RVA: 0x000DC776 File Offset: 0x000DA976
		[__DynamicallyInvokable]
		protected OrderablePartitioner(bool keysOrderedInEachPartition, bool keysOrderedAcrossPartitions, bool keysNormalized)
		{
			this.KeysOrderedInEachPartition = keysOrderedInEachPartition;
			this.KeysOrderedAcrossPartitions = keysOrderedAcrossPartitions;
			this.KeysNormalized = keysNormalized;
		}

		// Token: 0x0600398E RID: 14734
		[__DynamicallyInvokable]
		public abstract IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount);

		// Token: 0x0600398F RID: 14735 RVA: 0x000DC793 File Offset: 0x000DA993
		[__DynamicallyInvokable]
		public virtual IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions()
		{
			throw new NotSupportedException(Environment.GetResourceString("Partitioner_DynamicPartitionsNotSupported"));
		}

		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x06003990 RID: 14736 RVA: 0x000DC7A4 File Offset: 0x000DA9A4
		// (set) Token: 0x06003991 RID: 14737 RVA: 0x000DC7AC File Offset: 0x000DA9AC
		[__DynamicallyInvokable]
		public bool KeysOrderedInEachPartition { [__DynamicallyInvokable] get; private set; }

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06003992 RID: 14738 RVA: 0x000DC7B5 File Offset: 0x000DA9B5
		// (set) Token: 0x06003993 RID: 14739 RVA: 0x000DC7BD File Offset: 0x000DA9BD
		[__DynamicallyInvokable]
		public bool KeysOrderedAcrossPartitions { [__DynamicallyInvokable] get; private set; }

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x06003994 RID: 14740 RVA: 0x000DC7C6 File Offset: 0x000DA9C6
		// (set) Token: 0x06003995 RID: 14741 RVA: 0x000DC7CE File Offset: 0x000DA9CE
		[__DynamicallyInvokable]
		public bool KeysNormalized { [__DynamicallyInvokable] get; private set; }

		// Token: 0x06003996 RID: 14742 RVA: 0x000DC7D8 File Offset: 0x000DA9D8
		[__DynamicallyInvokable]
		public override IList<IEnumerator<TSource>> GetPartitions(int partitionCount)
		{
			IList<IEnumerator<KeyValuePair<long, TSource>>> orderablePartitions = this.GetOrderablePartitions(partitionCount);
			if (orderablePartitions.Count != partitionCount)
			{
				throw new InvalidOperationException("OrderablePartitioner_GetPartitions_WrongNumberOfPartitions");
			}
			IEnumerator<TSource>[] array = new IEnumerator<!0>[partitionCount];
			for (int i = 0; i < partitionCount; i++)
			{
				array[i] = new OrderablePartitioner<TSource>.EnumeratorDropIndices(orderablePartitions[i]);
			}
			return array;
		}

		// Token: 0x06003997 RID: 14743 RVA: 0x000DC824 File Offset: 0x000DAA24
		[__DynamicallyInvokable]
		public override IEnumerable<TSource> GetDynamicPartitions()
		{
			IEnumerable<KeyValuePair<long, TSource>> orderableDynamicPartitions = this.GetOrderableDynamicPartitions();
			return new OrderablePartitioner<TSource>.EnumerableDropIndices(orderableDynamicPartitions);
		}

		// Token: 0x02000BC8 RID: 3016
		private class EnumerableDropIndices : IEnumerable<!0>, IEnumerable, IDisposable
		{
			// Token: 0x06006E8D RID: 28301 RVA: 0x0017D96B File Offset: 0x0017BB6B
			public EnumerableDropIndices(IEnumerable<KeyValuePair<long, TSource>> source)
			{
				this.m_source = source;
			}

			// Token: 0x06006E8E RID: 28302 RVA: 0x0017D97A File Offset: 0x0017BB7A
			public IEnumerator<TSource> GetEnumerator()
			{
				return new OrderablePartitioner<TSource>.EnumeratorDropIndices(this.m_source.GetEnumerator());
			}

			// Token: 0x06006E8F RID: 28303 RVA: 0x0017D98C File Offset: 0x0017BB8C
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06006E90 RID: 28304 RVA: 0x0017D994 File Offset: 0x0017BB94
			public void Dispose()
			{
				IDisposable disposable = this.m_source as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			// Token: 0x040035B1 RID: 13745
			private readonly IEnumerable<KeyValuePair<long, TSource>> m_source;
		}

		// Token: 0x02000BC9 RID: 3017
		private class EnumeratorDropIndices : IEnumerator<!0>, IDisposable, IEnumerator
		{
			// Token: 0x06006E91 RID: 28305 RVA: 0x0017D9B6 File Offset: 0x0017BBB6
			public EnumeratorDropIndices(IEnumerator<KeyValuePair<long, TSource>> source)
			{
				this.m_source = source;
			}

			// Token: 0x06006E92 RID: 28306 RVA: 0x0017D9C5 File Offset: 0x0017BBC5
			public bool MoveNext()
			{
				return this.m_source.MoveNext();
			}

			// Token: 0x170012E9 RID: 4841
			// (get) Token: 0x06006E93 RID: 28307 RVA: 0x0017D9D4 File Offset: 0x0017BBD4
			public TSource Current
			{
				get
				{
					KeyValuePair<long, TSource> keyValuePair = this.m_source.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x170012EA RID: 4842
			// (get) Token: 0x06006E94 RID: 28308 RVA: 0x0017D9F4 File Offset: 0x0017BBF4
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06006E95 RID: 28309 RVA: 0x0017DA01 File Offset: 0x0017BC01
			public void Dispose()
			{
				this.m_source.Dispose();
			}

			// Token: 0x06006E96 RID: 28310 RVA: 0x0017DA0E File Offset: 0x0017BC0E
			public void Reset()
			{
				this.m_source.Reset();
			}

			// Token: 0x040035B2 RID: 13746
			private readonly IEnumerator<KeyValuePair<long, TSource>> m_source;
		}
	}
}
