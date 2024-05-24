using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections.Concurrent
{
	// Token: 0x020004AE RID: 1198
	[ComVisible(false)]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(SystemCollectionsConcurrent_ProducerConsumerCollectionDebugView<>))]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	[Serializable]
	public class ConcurrentQueue<T> : IProducerConsumerCollection<!0>, IEnumerable<!0>, IEnumerable, ICollection, IReadOnlyCollection<T>
	{
		// Token: 0x06003972 RID: 14706 RVA: 0x000DC2F0 File Offset: 0x000DA4F0
		[__DynamicallyInvokable]
		public ConcurrentQueue()
		{
			this.m_head = (this.m_tail = new ConcurrentQueue<T>.Segment(0L, this));
		}

		// Token: 0x06003973 RID: 14707 RVA: 0x000DC320 File Offset: 0x000DA520
		private void InitializeFromCollection(IEnumerable<T> collection)
		{
			ConcurrentQueue<T>.Segment segment = new ConcurrentQueue<T>.Segment(0L, this);
			this.m_head = segment;
			int num = 0;
			foreach (T value in collection)
			{
				segment.UnsafeAdd(value);
				num++;
				if (num >= 32)
				{
					segment = segment.UnsafeGrow();
					num = 0;
				}
			}
			this.m_tail = segment;
		}

		// Token: 0x06003974 RID: 14708 RVA: 0x000DC398 File Offset: 0x000DA598
		[__DynamicallyInvokable]
		public ConcurrentQueue(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			this.InitializeFromCollection(collection);
		}

		// Token: 0x06003975 RID: 14709 RVA: 0x000DC3B5 File Offset: 0x000DA5B5
		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			this.m_serializationArray = this.ToArray();
		}

		// Token: 0x06003976 RID: 14710 RVA: 0x000DC3C3 File Offset: 0x000DA5C3
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			this.InitializeFromCollection(this.m_serializationArray);
			this.m_serializationArray = null;
		}

		// Token: 0x06003977 RID: 14711 RVA: 0x000DC3D8 File Offset: 0x000DA5D8
		[__DynamicallyInvokable]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			((ICollection)this.ToList()).CopyTo(array, index);
		}

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x06003978 RID: 14712 RVA: 0x000DC3F5 File Offset: 0x000DA5F5
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x06003979 RID: 14713 RVA: 0x000DC3F8 File Offset: 0x000DA5F8
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("ConcurrentCollection_SyncRoot_NotSupported"));
			}
		}

		// Token: 0x0600397A RID: 14714 RVA: 0x000DC409 File Offset: 0x000DA609
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<!0>)this).GetEnumerator();
		}

		// Token: 0x0600397B RID: 14715 RVA: 0x000DC411 File Offset: 0x000DA611
		[__DynamicallyInvokable]
		bool IProducerConsumerCollection<!0>.TryAdd(T item)
		{
			this.Enqueue(item);
			return true;
		}

		// Token: 0x0600397C RID: 14716 RVA: 0x000DC41B File Offset: 0x000DA61B
		[__DynamicallyInvokable]
		bool IProducerConsumerCollection<!0>.TryTake(out T item)
		{
			return this.TryDequeue(out item);
		}

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x0600397D RID: 14717 RVA: 0x000DC424 File Offset: 0x000DA624
		[__DynamicallyInvokable]
		public bool IsEmpty
		{
			[__DynamicallyInvokable]
			get
			{
				ConcurrentQueue<T>.Segment head = this.m_head;
				if (!head.IsEmpty)
				{
					return false;
				}
				if (head.Next == null)
				{
					return true;
				}
				SpinWait spinWait = default(SpinWait);
				while (head.IsEmpty)
				{
					if (head.Next == null)
					{
						return true;
					}
					spinWait.SpinOnce();
					head = this.m_head;
				}
				return false;
			}
		}

		// Token: 0x0600397E RID: 14718 RVA: 0x000DC47B File Offset: 0x000DA67B
		[__DynamicallyInvokable]
		public T[] ToArray()
		{
			return this.ToList().ToArray();
		}

		// Token: 0x0600397F RID: 14719 RVA: 0x000DC488 File Offset: 0x000DA688
		private List<T> ToList()
		{
			Interlocked.Increment(ref this.m_numSnapshotTakers);
			List<T> list = new List<T>();
			try
			{
				ConcurrentQueue<T>.Segment segment;
				ConcurrentQueue<T>.Segment segment2;
				int start;
				int end;
				this.GetHeadTailPositions(out segment, out segment2, out start, out end);
				if (segment == segment2)
				{
					segment.AddToList(list, start, end);
				}
				else
				{
					segment.AddToList(list, start, 31);
					for (ConcurrentQueue<T>.Segment next = segment.Next; next != segment2; next = next.Next)
					{
						next.AddToList(list, 0, 31);
					}
					segment2.AddToList(list, 0, end);
				}
			}
			finally
			{
				Interlocked.Decrement(ref this.m_numSnapshotTakers);
			}
			return list;
		}

		// Token: 0x06003980 RID: 14720 RVA: 0x000DC51C File Offset: 0x000DA71C
		private void GetHeadTailPositions(out ConcurrentQueue<T>.Segment head, out ConcurrentQueue<T>.Segment tail, out int headLow, out int tailHigh)
		{
			head = this.m_head;
			tail = this.m_tail;
			headLow = head.Low;
			tailHigh = tail.High;
			SpinWait spinWait = default(SpinWait);
			while (head != this.m_head || tail != this.m_tail || headLow != head.Low || tailHigh != tail.High || head.m_index > tail.m_index)
			{
				spinWait.SpinOnce();
				head = this.m_head;
				tail = this.m_tail;
				headLow = head.Low;
				tailHigh = tail.High;
			}
		}

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x06003981 RID: 14721 RVA: 0x000DC5C8 File Offset: 0x000DA7C8
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				ConcurrentQueue<T>.Segment segment;
				ConcurrentQueue<T>.Segment segment2;
				int num;
				int num2;
				this.GetHeadTailPositions(out segment, out segment2, out num, out num2);
				if (segment == segment2)
				{
					return num2 - num + 1;
				}
				int num3 = 32 - num;
				num3 += 32 * (int)(segment2.m_index - segment.m_index - 1L);
				return num3 + (num2 + 1);
			}
		}

		// Token: 0x06003982 RID: 14722 RVA: 0x000DC616 File Offset: 0x000DA816
		[__DynamicallyInvokable]
		public void CopyTo(T[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			this.ToList().CopyTo(array, index);
		}

		// Token: 0x06003983 RID: 14723 RVA: 0x000DC634 File Offset: 0x000DA834
		[__DynamicallyInvokable]
		public IEnumerator<T> GetEnumerator()
		{
			Interlocked.Increment(ref this.m_numSnapshotTakers);
			ConcurrentQueue<T>.Segment head;
			ConcurrentQueue<T>.Segment tail;
			int headLow;
			int tailHigh;
			this.GetHeadTailPositions(out head, out tail, out headLow, out tailHigh);
			return this.GetEnumerator(head, tail, headLow, tailHigh);
		}

		// Token: 0x06003984 RID: 14724 RVA: 0x000DC665 File Offset: 0x000DA865
		private IEnumerator<T> GetEnumerator(ConcurrentQueue<T>.Segment head, ConcurrentQueue<T>.Segment tail, int headLow, int tailHigh)
		{
			try
			{
				SpinWait spin = default(SpinWait);
				if (head == tail)
				{
					int num;
					for (int i = headLow; i <= tailHigh; i = num + 1)
					{
						spin.Reset();
						while (!head.m_state[i].m_value)
						{
							spin.SpinOnce();
						}
						yield return head.m_array[i];
						num = i;
					}
				}
				else
				{
					int num;
					for (int i = headLow; i < 32; i = num + 1)
					{
						spin.Reset();
						while (!head.m_state[i].m_value)
						{
							spin.SpinOnce();
						}
						yield return head.m_array[i];
						num = i;
					}
					ConcurrentQueue<T>.Segment curr;
					for (curr = head.Next; curr != tail; curr = curr.Next)
					{
						for (int i = 0; i < 32; i = num + 1)
						{
							spin.Reset();
							while (!curr.m_state[i].m_value)
							{
								spin.SpinOnce();
							}
							yield return curr.m_array[i];
							num = i;
						}
					}
					for (int i = 0; i <= tailHigh; i = num + 1)
					{
						spin.Reset();
						while (!tail.m_state[i].m_value)
						{
							spin.SpinOnce();
						}
						yield return tail.m_array[i];
						num = i;
					}
					curr = null;
				}
			}
			finally
			{
				Interlocked.Decrement(ref this.m_numSnapshotTakers);
			}
			yield break;
			yield break;
		}

		// Token: 0x06003985 RID: 14725 RVA: 0x000DC694 File Offset: 0x000DA894
		[__DynamicallyInvokable]
		public void Enqueue(T item)
		{
			SpinWait spinWait = default(SpinWait);
			for (;;)
			{
				ConcurrentQueue<T>.Segment tail = this.m_tail;
				if (tail.TryAppend(item))
				{
					break;
				}
				spinWait.SpinOnce();
			}
		}

		// Token: 0x06003986 RID: 14726 RVA: 0x000DC6C4 File Offset: 0x000DA8C4
		[__DynamicallyInvokable]
		public bool TryDequeue(out T result)
		{
			while (!this.IsEmpty)
			{
				ConcurrentQueue<T>.Segment head = this.m_head;
				if (head.TryRemove(out result))
				{
					return true;
				}
			}
			result = default(T);
			return false;
		}

		// Token: 0x06003987 RID: 14727 RVA: 0x000DC6F8 File Offset: 0x000DA8F8
		[__DynamicallyInvokable]
		public bool TryPeek(out T result)
		{
			Interlocked.Increment(ref this.m_numSnapshotTakers);
			while (!this.IsEmpty)
			{
				ConcurrentQueue<T>.Segment head = this.m_head;
				if (head.TryPeek(out result))
				{
					Interlocked.Decrement(ref this.m_numSnapshotTakers);
					return true;
				}
			}
			result = default(T);
			Interlocked.Decrement(ref this.m_numSnapshotTakers);
			return false;
		}

		// Token: 0x0400191F RID: 6431
		[NonSerialized]
		private volatile ConcurrentQueue<T>.Segment m_head;

		// Token: 0x04001920 RID: 6432
		[NonSerialized]
		private volatile ConcurrentQueue<T>.Segment m_tail;

		// Token: 0x04001921 RID: 6433
		private T[] m_serializationArray;

		// Token: 0x04001922 RID: 6434
		private const int SEGMENT_SIZE = 32;

		// Token: 0x04001923 RID: 6435
		[NonSerialized]
		internal volatile int m_numSnapshotTakers;

		// Token: 0x02000BC6 RID: 3014
		private class Segment
		{
			// Token: 0x06006E7A RID: 28282 RVA: 0x0017D22F File Offset: 0x0017B42F
			internal Segment(long index, ConcurrentQueue<T> source)
			{
				this.m_array = new T[32];
				this.m_state = new VolatileBool[32];
				this.m_high = -1;
				this.m_index = index;
				this.m_source = source;
			}

			// Token: 0x170012E3 RID: 4835
			// (get) Token: 0x06006E7B RID: 28283 RVA: 0x0017D26E File Offset: 0x0017B46E
			internal ConcurrentQueue<T>.Segment Next
			{
				get
				{
					return this.m_next;
				}
			}

			// Token: 0x170012E4 RID: 4836
			// (get) Token: 0x06006E7C RID: 28284 RVA: 0x0017D278 File Offset: 0x0017B478
			internal bool IsEmpty
			{
				get
				{
					return this.Low > this.High;
				}
			}

			// Token: 0x06006E7D RID: 28285 RVA: 0x0017D288 File Offset: 0x0017B488
			internal void UnsafeAdd(T value)
			{
				this.m_high++;
				this.m_array[this.m_high] = value;
				this.m_state[this.m_high].m_value = true;
			}

			// Token: 0x06006E7E RID: 28286 RVA: 0x0017D2DC File Offset: 0x0017B4DC
			internal ConcurrentQueue<T>.Segment UnsafeGrow()
			{
				ConcurrentQueue<T>.Segment segment = new ConcurrentQueue<T>.Segment(this.m_index + 1L, this.m_source);
				this.m_next = segment;
				return segment;
			}

			// Token: 0x06006E7F RID: 28287 RVA: 0x0017D30C File Offset: 0x0017B50C
			internal void Grow()
			{
				ConcurrentQueue<T>.Segment next = new ConcurrentQueue<T>.Segment(this.m_index + 1L, this.m_source);
				this.m_next = next;
				this.m_source.m_tail = this.m_next;
			}

			// Token: 0x06006E80 RID: 28288 RVA: 0x0017D350 File Offset: 0x0017B550
			internal bool TryAppend(T value)
			{
				if (this.m_high >= 31)
				{
					return false;
				}
				int num = 32;
				try
				{
				}
				finally
				{
					num = Interlocked.Increment(ref this.m_high);
					if (num <= 31)
					{
						this.m_array[num] = value;
						this.m_state[num].m_value = true;
					}
					if (num == 31)
					{
						this.Grow();
					}
				}
				return num <= 31;
			}

			// Token: 0x06006E81 RID: 28289 RVA: 0x0017D3CC File Offset: 0x0017B5CC
			internal bool TryRemove(out T result)
			{
				SpinWait spinWait = default(SpinWait);
				int i = this.Low;
				int high = this.High;
				while (i <= high)
				{
					if (Interlocked.CompareExchange(ref this.m_low, i + 1, i) == i)
					{
						SpinWait spinWait2 = default(SpinWait);
						while (!this.m_state[i].m_value)
						{
							spinWait2.SpinOnce();
						}
						result = this.m_array[i];
						if (this.m_source.m_numSnapshotTakers <= 0)
						{
							this.m_array[i] = default(T);
						}
						if (i + 1 >= 32)
						{
							spinWait2 = default(SpinWait);
							while (this.m_next == null)
							{
								spinWait2.SpinOnce();
							}
							this.m_source.m_head = this.m_next;
						}
						return true;
					}
					spinWait.SpinOnce();
					i = this.Low;
					high = this.High;
				}
				result = default(T);
				return false;
			}

			// Token: 0x06006E82 RID: 28290 RVA: 0x0017D4D0 File Offset: 0x0017B6D0
			internal bool TryPeek(out T result)
			{
				result = default(T);
				int low = this.Low;
				if (low > this.High)
				{
					return false;
				}
				SpinWait spinWait = default(SpinWait);
				while (!this.m_state[low].m_value)
				{
					spinWait.SpinOnce();
				}
				result = this.m_array[low];
				return true;
			}

			// Token: 0x06006E83 RID: 28291 RVA: 0x0017D534 File Offset: 0x0017B734
			internal void AddToList(List<T> list, int start, int end)
			{
				for (int i = start; i <= end; i++)
				{
					SpinWait spinWait = default(SpinWait);
					while (!this.m_state[i].m_value)
					{
						spinWait.SpinOnce();
					}
					list.Add(this.m_array[i]);
				}
			}

			// Token: 0x170012E5 RID: 4837
			// (get) Token: 0x06006E84 RID: 28292 RVA: 0x0017D589 File Offset: 0x0017B789
			internal int Low
			{
				get
				{
					return Math.Min(this.m_low, 32);
				}
			}

			// Token: 0x170012E6 RID: 4838
			// (get) Token: 0x06006E85 RID: 28293 RVA: 0x0017D59A File Offset: 0x0017B79A
			internal int High
			{
				get
				{
					return Math.Min(this.m_high, 31);
				}
			}

			// Token: 0x040035A0 RID: 13728
			internal volatile T[] m_array;

			// Token: 0x040035A1 RID: 13729
			internal volatile VolatileBool[] m_state;

			// Token: 0x040035A2 RID: 13730
			private volatile ConcurrentQueue<T>.Segment m_next;

			// Token: 0x040035A3 RID: 13731
			internal readonly long m_index;

			// Token: 0x040035A4 RID: 13732
			private volatile int m_low;

			// Token: 0x040035A5 RID: 13733
			private volatile int m_high;

			// Token: 0x040035A6 RID: 13734
			private volatile ConcurrentQueue<T> m_source;
		}
	}
}
