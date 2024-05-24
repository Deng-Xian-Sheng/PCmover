﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections
{
	// Token: 0x0200048E RID: 1166
	[DebuggerTypeProxy(typeof(Queue.QueueDebugView))]
	[DebuggerDisplay("Count = {Count}")]
	[ComVisible(true)]
	[Serializable]
	public class Queue : ICollection, IEnumerable, ICloneable
	{
		// Token: 0x060037B5 RID: 14261 RVA: 0x000D5C39 File Offset: 0x000D3E39
		public Queue() : this(32, 2f)
		{
		}

		// Token: 0x060037B6 RID: 14262 RVA: 0x000D5C48 File Offset: 0x000D3E48
		public Queue(int capacity) : this(capacity, 2f)
		{
		}

		// Token: 0x060037B7 RID: 14263 RVA: 0x000D5C58 File Offset: 0x000D3E58
		public Queue(int capacity, float growFactor)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if ((double)growFactor < 1.0 || (double)growFactor > 10.0)
			{
				throw new ArgumentOutOfRangeException("growFactor", Environment.GetResourceString("ArgumentOutOfRange_QueueGrowFactor", new object[]
				{
					1,
					10
				}));
			}
			this._array = new object[capacity];
			this._head = 0;
			this._tail = 0;
			this._size = 0;
			this._growFactor = (int)(growFactor * 100f);
		}

		// Token: 0x060037B8 RID: 14264 RVA: 0x000D5CFC File Offset: 0x000D3EFC
		public Queue(ICollection col) : this((col == null) ? 32 : col.Count)
		{
			if (col == null)
			{
				throw new ArgumentNullException("col");
			}
			foreach (object obj in col)
			{
				this.Enqueue(obj);
			}
		}

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x060037B9 RID: 14265 RVA: 0x000D5D47 File Offset: 0x000D3F47
		public virtual int Count
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x060037BA RID: 14266 RVA: 0x000D5D50 File Offset: 0x000D3F50
		public virtual object Clone()
		{
			Queue queue = new Queue(this._size);
			queue._size = this._size;
			int num = this._size;
			int num2 = (this._array.Length - this._head < num) ? (this._array.Length - this._head) : num;
			Array.Copy(this._array, this._head, queue._array, 0, num2);
			num -= num2;
			if (num > 0)
			{
				Array.Copy(this._array, 0, queue._array, this._array.Length - this._head, num);
			}
			queue._version = this._version;
			return queue;
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x060037BB RID: 14267 RVA: 0x000D5DF1 File Offset: 0x000D3FF1
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x060037BC RID: 14268 RVA: 0x000D5DF4 File Offset: 0x000D3FF4
		public virtual object SyncRoot
		{
			get
			{
				if (this._syncRoot == null)
				{
					Interlocked.CompareExchange(ref this._syncRoot, new object(), null);
				}
				return this._syncRoot;
			}
		}

		// Token: 0x060037BD RID: 14269 RVA: 0x000D5E18 File Offset: 0x000D4018
		public virtual void Clear()
		{
			if (this._head < this._tail)
			{
				Array.Clear(this._array, this._head, this._size);
			}
			else
			{
				Array.Clear(this._array, this._head, this._array.Length - this._head);
				Array.Clear(this._array, 0, this._tail);
			}
			this._head = 0;
			this._tail = 0;
			this._size = 0;
			this._version++;
		}

		// Token: 0x060037BE RID: 14270 RVA: 0x000D5EA4 File Offset: 0x000D40A4
		public virtual void CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			int length = array.Length;
			if (length - index < this._size)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			int num = this._size;
			if (num == 0)
			{
				return;
			}
			int num2 = (this._array.Length - this._head < num) ? (this._array.Length - this._head) : num;
			Array.Copy(this._array, this._head, array, index, num2);
			num -= num2;
			if (num > 0)
			{
				Array.Copy(this._array, 0, array, index + this._array.Length - this._head, num);
			}
		}

		// Token: 0x060037BF RID: 14271 RVA: 0x000D5F80 File Offset: 0x000D4180
		public virtual void Enqueue(object obj)
		{
			if (this._size == this._array.Length)
			{
				int num = (int)((long)this._array.Length * (long)this._growFactor / 100L);
				if (num < this._array.Length + 4)
				{
					num = this._array.Length + 4;
				}
				this.SetCapacity(num);
			}
			this._array[this._tail] = obj;
			this._tail = (this._tail + 1) % this._array.Length;
			this._size++;
			this._version++;
		}

		// Token: 0x060037C0 RID: 14272 RVA: 0x000D6014 File Offset: 0x000D4214
		public virtual IEnumerator GetEnumerator()
		{
			return new Queue.QueueEnumerator(this);
		}

		// Token: 0x060037C1 RID: 14273 RVA: 0x000D601C File Offset: 0x000D421C
		public virtual object Dequeue()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyQueue"));
			}
			object result = this._array[this._head];
			this._array[this._head] = null;
			this._head = (this._head + 1) % this._array.Length;
			this._size--;
			this._version++;
			return result;
		}

		// Token: 0x060037C2 RID: 14274 RVA: 0x000D6091 File Offset: 0x000D4291
		public virtual object Peek()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyQueue"));
			}
			return this._array[this._head];
		}

		// Token: 0x060037C3 RID: 14275 RVA: 0x000D60B8 File Offset: 0x000D42B8
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
		public static Queue Synchronized(Queue queue)
		{
			if (queue == null)
			{
				throw new ArgumentNullException("queue");
			}
			return new Queue.SynchronizedQueue(queue);
		}

		// Token: 0x060037C4 RID: 14276 RVA: 0x000D60D0 File Offset: 0x000D42D0
		public virtual bool Contains(object obj)
		{
			int num = this._head;
			int size = this._size;
			while (size-- > 0)
			{
				if (obj == null)
				{
					if (this._array[num] == null)
					{
						return true;
					}
				}
				else if (this._array[num] != null && this._array[num].Equals(obj))
				{
					return true;
				}
				num = (num + 1) % this._array.Length;
			}
			return false;
		}

		// Token: 0x060037C5 RID: 14277 RVA: 0x000D612E File Offset: 0x000D432E
		internal object GetElement(int i)
		{
			return this._array[(this._head + i) % this._array.Length];
		}

		// Token: 0x060037C6 RID: 14278 RVA: 0x000D6148 File Offset: 0x000D4348
		public virtual object[] ToArray()
		{
			object[] array = new object[this._size];
			if (this._size == 0)
			{
				return array;
			}
			if (this._head < this._tail)
			{
				Array.Copy(this._array, this._head, array, 0, this._size);
			}
			else
			{
				Array.Copy(this._array, this._head, array, 0, this._array.Length - this._head);
				Array.Copy(this._array, 0, array, this._array.Length - this._head, this._tail);
			}
			return array;
		}

		// Token: 0x060037C7 RID: 14279 RVA: 0x000D61DC File Offset: 0x000D43DC
		private void SetCapacity(int capacity)
		{
			object[] array = new object[capacity];
			if (this._size > 0)
			{
				if (this._head < this._tail)
				{
					Array.Copy(this._array, this._head, array, 0, this._size);
				}
				else
				{
					Array.Copy(this._array, this._head, array, 0, this._array.Length - this._head);
					Array.Copy(this._array, 0, array, this._array.Length - this._head, this._tail);
				}
			}
			this._array = array;
			this._head = 0;
			this._tail = ((this._size == capacity) ? 0 : this._size);
			this._version++;
		}

		// Token: 0x060037C8 RID: 14280 RVA: 0x000D629A File Offset: 0x000D449A
		public virtual void TrimToSize()
		{
			this.SetCapacity(this._size);
		}

		// Token: 0x040018B4 RID: 6324
		private object[] _array;

		// Token: 0x040018B5 RID: 6325
		private int _head;

		// Token: 0x040018B6 RID: 6326
		private int _tail;

		// Token: 0x040018B7 RID: 6327
		private int _size;

		// Token: 0x040018B8 RID: 6328
		private int _growFactor;

		// Token: 0x040018B9 RID: 6329
		private int _version;

		// Token: 0x040018BA RID: 6330
		[NonSerialized]
		private object _syncRoot;

		// Token: 0x040018BB RID: 6331
		private const int _MinimumGrow = 4;

		// Token: 0x040018BC RID: 6332
		private const int _ShrinkThreshold = 32;

		// Token: 0x02000B9F RID: 2975
		[Serializable]
		private class SynchronizedQueue : Queue
		{
			// Token: 0x06006CA7 RID: 27815 RVA: 0x00178007 File Offset: 0x00176207
			internal SynchronizedQueue(Queue q)
			{
				this._q = q;
				this.root = this._q.SyncRoot;
			}

			// Token: 0x17001262 RID: 4706
			// (get) Token: 0x06006CA8 RID: 27816 RVA: 0x00178027 File Offset: 0x00176227
			public override bool IsSynchronized
			{
				get
				{
					return true;
				}
			}

			// Token: 0x17001263 RID: 4707
			// (get) Token: 0x06006CA9 RID: 27817 RVA: 0x0017802A File Offset: 0x0017622A
			public override object SyncRoot
			{
				get
				{
					return this.root;
				}
			}

			// Token: 0x17001264 RID: 4708
			// (get) Token: 0x06006CAA RID: 27818 RVA: 0x00178034 File Offset: 0x00176234
			public override int Count
			{
				get
				{
					object obj = this.root;
					int count;
					lock (obj)
					{
						count = this._q.Count;
					}
					return count;
				}
			}

			// Token: 0x06006CAB RID: 27819 RVA: 0x0017807C File Offset: 0x0017627C
			public override void Clear()
			{
				object obj = this.root;
				lock (obj)
				{
					this._q.Clear();
				}
			}

			// Token: 0x06006CAC RID: 27820 RVA: 0x001780C4 File Offset: 0x001762C4
			public override object Clone()
			{
				object obj = this.root;
				object result;
				lock (obj)
				{
					result = new Queue.SynchronizedQueue((Queue)this._q.Clone());
				}
				return result;
			}

			// Token: 0x06006CAD RID: 27821 RVA: 0x00178118 File Offset: 0x00176318
			public override bool Contains(object obj)
			{
				object obj2 = this.root;
				bool result;
				lock (obj2)
				{
					result = this._q.Contains(obj);
				}
				return result;
			}

			// Token: 0x06006CAE RID: 27822 RVA: 0x00178160 File Offset: 0x00176360
			public override void CopyTo(Array array, int arrayIndex)
			{
				object obj = this.root;
				lock (obj)
				{
					this._q.CopyTo(array, arrayIndex);
				}
			}

			// Token: 0x06006CAF RID: 27823 RVA: 0x001781A8 File Offset: 0x001763A8
			public override void Enqueue(object value)
			{
				object obj = this.root;
				lock (obj)
				{
					this._q.Enqueue(value);
				}
			}

			// Token: 0x06006CB0 RID: 27824 RVA: 0x001781F0 File Offset: 0x001763F0
			public override object Dequeue()
			{
				object obj = this.root;
				object result;
				lock (obj)
				{
					result = this._q.Dequeue();
				}
				return result;
			}

			// Token: 0x06006CB1 RID: 27825 RVA: 0x00178238 File Offset: 0x00176438
			public override IEnumerator GetEnumerator()
			{
				object obj = this.root;
				IEnumerator enumerator;
				lock (obj)
				{
					enumerator = this._q.GetEnumerator();
				}
				return enumerator;
			}

			// Token: 0x06006CB2 RID: 27826 RVA: 0x00178280 File Offset: 0x00176480
			public override object Peek()
			{
				object obj = this.root;
				object result;
				lock (obj)
				{
					result = this._q.Peek();
				}
				return result;
			}

			// Token: 0x06006CB3 RID: 27827 RVA: 0x001782C8 File Offset: 0x001764C8
			public override object[] ToArray()
			{
				object obj = this.root;
				object[] result;
				lock (obj)
				{
					result = this._q.ToArray();
				}
				return result;
			}

			// Token: 0x06006CB4 RID: 27828 RVA: 0x00178310 File Offset: 0x00176510
			public override void TrimToSize()
			{
				object obj = this.root;
				lock (obj)
				{
					this._q.TrimToSize();
				}
			}

			// Token: 0x04003534 RID: 13620
			private Queue _q;

			// Token: 0x04003535 RID: 13621
			private object root;
		}

		// Token: 0x02000BA0 RID: 2976
		[Serializable]
		private class QueueEnumerator : IEnumerator, ICloneable
		{
			// Token: 0x06006CB5 RID: 27829 RVA: 0x00178358 File Offset: 0x00176558
			internal QueueEnumerator(Queue q)
			{
				this._q = q;
				this._version = this._q._version;
				this._index = 0;
				this.currentElement = this._q._array;
				if (this._q._size == 0)
				{
					this._index = -1;
				}
			}

			// Token: 0x06006CB6 RID: 27830 RVA: 0x001783AF File Offset: 0x001765AF
			public object Clone()
			{
				return base.MemberwiseClone();
			}

			// Token: 0x06006CB7 RID: 27831 RVA: 0x001783B8 File Offset: 0x001765B8
			public virtual bool MoveNext()
			{
				if (this._version != this._q._version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				if (this._index < 0)
				{
					this.currentElement = this._q._array;
					return false;
				}
				this.currentElement = this._q.GetElement(this._index);
				this._index++;
				if (this._index == this._q._size)
				{
					this._index = -1;
				}
				return true;
			}

			// Token: 0x17001265 RID: 4709
			// (get) Token: 0x06006CB8 RID: 27832 RVA: 0x00178444 File Offset: 0x00176644
			public virtual object Current
			{
				get
				{
					if (this.currentElement != this._q._array)
					{
						return this.currentElement;
					}
					if (this._index == 0)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
				}
			}

			// Token: 0x06006CB9 RID: 27833 RVA: 0x00178494 File Offset: 0x00176694
			public virtual void Reset()
			{
				if (this._version != this._q._version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				if (this._q._size == 0)
				{
					this._index = -1;
				}
				else
				{
					this._index = 0;
				}
				this.currentElement = this._q._array;
			}

			// Token: 0x04003536 RID: 13622
			private Queue _q;

			// Token: 0x04003537 RID: 13623
			private int _index;

			// Token: 0x04003538 RID: 13624
			private int _version;

			// Token: 0x04003539 RID: 13625
			private object currentElement;
		}

		// Token: 0x02000BA1 RID: 2977
		internal class QueueDebugView
		{
			// Token: 0x06006CBA RID: 27834 RVA: 0x001784F2 File Offset: 0x001766F2
			public QueueDebugView(Queue queue)
			{
				if (queue == null)
				{
					throw new ArgumentNullException("queue");
				}
				this.queue = queue;
			}

			// Token: 0x17001266 RID: 4710
			// (get) Token: 0x06006CBB RID: 27835 RVA: 0x0017850F File Offset: 0x0017670F
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public object[] Items
			{
				get
				{
					return this.queue.ToArray();
				}
			}

			// Token: 0x0400353A RID: 13626
			private Queue queue;
		}
	}
}
