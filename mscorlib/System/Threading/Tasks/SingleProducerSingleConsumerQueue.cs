using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Threading.Tasks
{
	// Token: 0x02000583 RID: 1411
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(SingleProducerSingleConsumerQueue<>.SingleProducerSingleConsumerQueue_DebugView))]
	internal sealed class SingleProducerSingleConsumerQueue<T> : IProducerConsumerQueue<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06004267 RID: 16999 RVA: 0x000F7220 File Offset: 0x000F5420
		internal SingleProducerSingleConsumerQueue()
		{
			this.m_head = (this.m_tail = new SingleProducerSingleConsumerQueue<T>.Segment(32));
		}

		// Token: 0x06004268 RID: 17000 RVA: 0x000F7250 File Offset: 0x000F5450
		public void Enqueue(T item)
		{
			SingleProducerSingleConsumerQueue<T>.Segment tail = this.m_tail;
			T[] array = tail.m_array;
			int last = tail.m_state.m_last;
			int num = last + 1 & array.Length - 1;
			if (num != tail.m_state.m_firstCopy)
			{
				array[last] = item;
				tail.m_state.m_last = num;
				return;
			}
			this.EnqueueSlow(item, ref tail);
		}

		// Token: 0x06004269 RID: 17001 RVA: 0x000F72B4 File Offset: 0x000F54B4
		private void EnqueueSlow(T item, ref SingleProducerSingleConsumerQueue<T>.Segment segment)
		{
			if (segment.m_state.m_firstCopy != segment.m_state.m_first)
			{
				segment.m_state.m_firstCopy = segment.m_state.m_first;
				this.Enqueue(item);
				return;
			}
			int num = this.m_tail.m_array.Length << 1;
			if (num > 16777216)
			{
				num = 16777216;
			}
			SingleProducerSingleConsumerQueue<T>.Segment segment2 = new SingleProducerSingleConsumerQueue<T>.Segment(num);
			segment2.m_array[0] = item;
			segment2.m_state.m_last = 1;
			segment2.m_state.m_lastCopy = 1;
			try
			{
			}
			finally
			{
				Volatile.Write<SingleProducerSingleConsumerQueue<T>.Segment>(ref this.m_tail.m_next, segment2);
				this.m_tail = segment2;
			}
		}

		// Token: 0x0600426A RID: 17002 RVA: 0x000F737C File Offset: 0x000F557C
		public bool TryDequeue(out T result)
		{
			SingleProducerSingleConsumerQueue<T>.Segment head = this.m_head;
			T[] array = head.m_array;
			int first = head.m_state.m_first;
			if (first != head.m_state.m_lastCopy)
			{
				result = array[first];
				array[first] = default(T);
				head.m_state.m_first = (first + 1 & array.Length - 1);
				return true;
			}
			return this.TryDequeueSlow(ref head, ref array, out result);
		}

		// Token: 0x0600426B RID: 17003 RVA: 0x000F73F8 File Offset: 0x000F55F8
		private bool TryDequeueSlow(ref SingleProducerSingleConsumerQueue<T>.Segment segment, ref T[] array, out T result)
		{
			if (segment.m_state.m_last != segment.m_state.m_lastCopy)
			{
				segment.m_state.m_lastCopy = segment.m_state.m_last;
				return this.TryDequeue(out result);
			}
			if (segment.m_next != null && segment.m_state.m_first == segment.m_state.m_last)
			{
				segment = segment.m_next;
				array = segment.m_array;
				this.m_head = segment;
			}
			int first = segment.m_state.m_first;
			if (first == segment.m_state.m_last)
			{
				result = default(T);
				return false;
			}
			result = array[first];
			array[first] = default(T);
			segment.m_state.m_first = (first + 1 & segment.m_array.Length - 1);
			segment.m_state.m_lastCopy = segment.m_state.m_last;
			return true;
		}

		// Token: 0x0600426C RID: 17004 RVA: 0x000F7508 File Offset: 0x000F5708
		public bool TryPeek(out T result)
		{
			SingleProducerSingleConsumerQueue<T>.Segment head = this.m_head;
			T[] array = head.m_array;
			int first = head.m_state.m_first;
			if (first != head.m_state.m_lastCopy)
			{
				result = array[first];
				return true;
			}
			return this.TryPeekSlow(ref head, ref array, out result);
		}

		// Token: 0x0600426D RID: 17005 RVA: 0x000F755C File Offset: 0x000F575C
		private bool TryPeekSlow(ref SingleProducerSingleConsumerQueue<T>.Segment segment, ref T[] array, out T result)
		{
			if (segment.m_state.m_last != segment.m_state.m_lastCopy)
			{
				segment.m_state.m_lastCopy = segment.m_state.m_last;
				return this.TryPeek(out result);
			}
			if (segment.m_next != null && segment.m_state.m_first == segment.m_state.m_last)
			{
				segment = segment.m_next;
				array = segment.m_array;
				this.m_head = segment;
			}
			int first = segment.m_state.m_first;
			if (first == segment.m_state.m_last)
			{
				result = default(T);
				return false;
			}
			result = array[first];
			return true;
		}

		// Token: 0x0600426E RID: 17006 RVA: 0x000F7624 File Offset: 0x000F5824
		public bool TryDequeueIf(Predicate<T> predicate, out T result)
		{
			SingleProducerSingleConsumerQueue<T>.Segment head = this.m_head;
			T[] array = head.m_array;
			int first = head.m_state.m_first;
			if (first == head.m_state.m_lastCopy)
			{
				return this.TryDequeueIfSlow(predicate, ref head, ref array, out result);
			}
			result = array[first];
			if (predicate == null || predicate(result))
			{
				array[first] = default(T);
				head.m_state.m_first = (first + 1 & array.Length - 1);
				return true;
			}
			result = default(T);
			return false;
		}

		// Token: 0x0600426F RID: 17007 RVA: 0x000F76B8 File Offset: 0x000F58B8
		private bool TryDequeueIfSlow(Predicate<T> predicate, ref SingleProducerSingleConsumerQueue<T>.Segment segment, ref T[] array, out T result)
		{
			if (segment.m_state.m_last != segment.m_state.m_lastCopy)
			{
				segment.m_state.m_lastCopy = segment.m_state.m_last;
				return this.TryDequeueIf(predicate, out result);
			}
			if (segment.m_next != null && segment.m_state.m_first == segment.m_state.m_last)
			{
				segment = segment.m_next;
				array = segment.m_array;
				this.m_head = segment;
			}
			int first = segment.m_state.m_first;
			if (first == segment.m_state.m_last)
			{
				result = default(T);
				return false;
			}
			result = array[first];
			if (predicate == null || predicate(result))
			{
				array[first] = default(T);
				segment.m_state.m_first = (first + 1 & segment.m_array.Length - 1);
				segment.m_state.m_lastCopy = segment.m_state.m_last;
				return true;
			}
			result = default(T);
			return false;
		}

		// Token: 0x06004270 RID: 17008 RVA: 0x000F77E8 File Offset: 0x000F59E8
		public void Clear()
		{
			T t;
			while (this.TryDequeue(out t))
			{
			}
		}

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06004271 RID: 17009 RVA: 0x000F7800 File Offset: 0x000F5A00
		public bool IsEmpty
		{
			get
			{
				SingleProducerSingleConsumerQueue<T>.Segment head = this.m_head;
				return head.m_state.m_first == head.m_state.m_lastCopy && head.m_state.m_first == head.m_state.m_last && head.m_next == null;
			}
		}

		// Token: 0x06004272 RID: 17010 RVA: 0x000F7859 File Offset: 0x000F5A59
		public IEnumerator<T> GetEnumerator()
		{
			SingleProducerSingleConsumerQueue<T>.Segment segment;
			for (segment = this.m_head; segment != null; segment = segment.m_next)
			{
				for (int pt = segment.m_state.m_first; pt != segment.m_state.m_last; pt = (pt + 1 & segment.m_array.Length - 1))
				{
					yield return segment.m_array[pt];
				}
			}
			segment = null;
			yield break;
		}

		// Token: 0x06004273 RID: 17011 RVA: 0x000F7868 File Offset: 0x000F5A68
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x06004274 RID: 17012 RVA: 0x000F7870 File Offset: 0x000F5A70
		public int Count
		{
			get
			{
				int num = 0;
				for (SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_head; segment != null; segment = segment.m_next)
				{
					int num2 = segment.m_array.Length;
					int first;
					int last;
					do
					{
						first = segment.m_state.m_first;
						last = segment.m_state.m_last;
					}
					while (first != segment.m_state.m_first);
					num += (last - first & num2 - 1);
				}
				return num;
			}
		}

		// Token: 0x06004275 RID: 17013 RVA: 0x000F78D8 File Offset: 0x000F5AD8
		int IProducerConsumerQueue<!0>.GetCountSafe(object syncObj)
		{
			int count;
			lock (syncObj)
			{
				count = this.Count;
			}
			return count;
		}

		// Token: 0x04001B94 RID: 7060
		private const int INIT_SEGMENT_SIZE = 32;

		// Token: 0x04001B95 RID: 7061
		private const int MAX_SEGMENT_SIZE = 16777216;

		// Token: 0x04001B96 RID: 7062
		private volatile SingleProducerSingleConsumerQueue<T>.Segment m_head;

		// Token: 0x04001B97 RID: 7063
		private volatile SingleProducerSingleConsumerQueue<T>.Segment m_tail;

		// Token: 0x02000C29 RID: 3113
		[StructLayout(LayoutKind.Sequential)]
		private sealed class Segment
		{
			// Token: 0x0600701E RID: 28702 RVA: 0x00182A02 File Offset: 0x00180C02
			internal Segment(int size)
			{
				this.m_array = new T[size];
			}

			// Token: 0x040036EE RID: 14062
			internal SingleProducerSingleConsumerQueue<T>.Segment m_next;

			// Token: 0x040036EF RID: 14063
			internal readonly T[] m_array;

			// Token: 0x040036F0 RID: 14064
			internal SingleProducerSingleConsumerQueue<T>.SegmentState m_state;
		}

		// Token: 0x02000C2A RID: 3114
		private struct SegmentState
		{
			// Token: 0x040036F1 RID: 14065
			internal PaddingFor32 m_pad0;

			// Token: 0x040036F2 RID: 14066
			internal volatile int m_first;

			// Token: 0x040036F3 RID: 14067
			internal int m_lastCopy;

			// Token: 0x040036F4 RID: 14068
			internal PaddingFor32 m_pad1;

			// Token: 0x040036F5 RID: 14069
			internal int m_firstCopy;

			// Token: 0x040036F6 RID: 14070
			internal volatile int m_last;

			// Token: 0x040036F7 RID: 14071
			internal PaddingFor32 m_pad2;
		}

		// Token: 0x02000C2B RID: 3115
		private sealed class SingleProducerSingleConsumerQueue_DebugView
		{
			// Token: 0x0600701F RID: 28703 RVA: 0x00182A16 File Offset: 0x00180C16
			public SingleProducerSingleConsumerQueue_DebugView(SingleProducerSingleConsumerQueue<T> queue)
			{
				this.m_queue = queue;
			}

			// Token: 0x17001337 RID: 4919
			// (get) Token: 0x06007020 RID: 28704 RVA: 0x00182A28 File Offset: 0x00180C28
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public T[] Items
			{
				get
				{
					List<T> list = new List<T>();
					foreach (T item in this.m_queue)
					{
						list.Add(item);
					}
					return list.ToArray();
				}
			}

			// Token: 0x040036F8 RID: 14072
			private readonly SingleProducerSingleConsumerQueue<T> m_queue;
		}
	}
}
