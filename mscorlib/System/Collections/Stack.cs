using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections
{
	// Token: 0x02000491 RID: 1169
	[DebuggerTypeProxy(typeof(Stack.StackDebugView))]
	[DebuggerDisplay("Count = {Count}")]
	[ComVisible(true)]
	[Serializable]
	public class Stack : ICollection, IEnumerable, ICloneable
	{
		// Token: 0x0600381C RID: 14364 RVA: 0x000D77C1 File Offset: 0x000D59C1
		public Stack()
		{
			this._array = new object[10];
			this._size = 0;
			this._version = 0;
		}

		// Token: 0x0600381D RID: 14365 RVA: 0x000D77E4 File Offset: 0x000D59E4
		public Stack(int initialCapacity)
		{
			if (initialCapacity < 0)
			{
				throw new ArgumentOutOfRangeException("initialCapacity", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (initialCapacity < 10)
			{
				initialCapacity = 10;
			}
			this._array = new object[initialCapacity];
			this._size = 0;
			this._version = 0;
		}

		// Token: 0x0600381E RID: 14366 RVA: 0x000D7834 File Offset: 0x000D5A34
		public Stack(ICollection col) : this((col == null) ? 32 : col.Count)
		{
			if (col == null)
			{
				throw new ArgumentNullException("col");
			}
			foreach (object obj in col)
			{
				this.Push(obj);
			}
		}

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x0600381F RID: 14367 RVA: 0x000D787F File Offset: 0x000D5A7F
		public virtual int Count
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x06003820 RID: 14368 RVA: 0x000D7887 File Offset: 0x000D5A87
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x06003821 RID: 14369 RVA: 0x000D788A File Offset: 0x000D5A8A
		public virtual object SyncRoot
		{
			get
			{
				if (this._syncRoot == null)
				{
					Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
				}
				return this._syncRoot;
			}
		}

		// Token: 0x06003822 RID: 14370 RVA: 0x000D78AC File Offset: 0x000D5AAC
		public virtual void Clear()
		{
			Array.Clear(this._array, 0, this._size);
			this._size = 0;
			this._version++;
		}

		// Token: 0x06003823 RID: 14371 RVA: 0x000D78D8 File Offset: 0x000D5AD8
		public virtual object Clone()
		{
			Stack stack = new Stack(this._size);
			stack._size = this._size;
			Array.Copy(this._array, 0, stack._array, 0, this._size);
			stack._version = this._version;
			return stack;
		}

		// Token: 0x06003824 RID: 14372 RVA: 0x000D7924 File Offset: 0x000D5B24
		public virtual bool Contains(object obj)
		{
			int size = this._size;
			while (size-- > 0)
			{
				if (obj == null)
				{
					if (this._array[size] == null)
					{
						return true;
					}
				}
				else if (this._array[size] != null && this._array[size].Equals(obj))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003825 RID: 14373 RVA: 0x000D7970 File Offset: 0x000D5B70
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
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (array.Length - index < this._size)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			int i = 0;
			if (array is object[])
			{
				object[] array2 = (object[])array;
				while (i < this._size)
				{
					array2[i + index] = this._array[this._size - i - 1];
					i++;
				}
				return;
			}
			while (i < this._size)
			{
				array.SetValue(this._array[this._size - i - 1], i + index);
				i++;
			}
		}

		// Token: 0x06003826 RID: 14374 RVA: 0x000D7A3B File Offset: 0x000D5C3B
		public virtual IEnumerator GetEnumerator()
		{
			return new Stack.StackEnumerator(this);
		}

		// Token: 0x06003827 RID: 14375 RVA: 0x000D7A43 File Offset: 0x000D5C43
		public virtual object Peek()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
			}
			return this._array[this._size - 1];
		}

		// Token: 0x06003828 RID: 14376 RVA: 0x000D7A6C File Offset: 0x000D5C6C
		public virtual object Pop()
		{
			if (this._size == 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
			}
			this._version++;
			object[] array = this._array;
			int num = this._size - 1;
			this._size = num;
			object result = array[num];
			this._array[this._size] = null;
			return result;
		}

		// Token: 0x06003829 RID: 14377 RVA: 0x000D7AC8 File Offset: 0x000D5CC8
		public virtual void Push(object obj)
		{
			if (this._size == this._array.Length)
			{
				object[] array = new object[2 * this._array.Length];
				Array.Copy(this._array, 0, array, 0, this._size);
				this._array = array;
			}
			object[] array2 = this._array;
			int size = this._size;
			this._size = size + 1;
			array2[size] = obj;
			this._version++;
		}

		// Token: 0x0600382A RID: 14378 RVA: 0x000D7B37 File Offset: 0x000D5D37
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
		public static Stack Synchronized(Stack stack)
		{
			if (stack == null)
			{
				throw new ArgumentNullException("stack");
			}
			return new Stack.SyncStack(stack);
		}

		// Token: 0x0600382B RID: 14379 RVA: 0x000D7B50 File Offset: 0x000D5D50
		public virtual object[] ToArray()
		{
			object[] array = new object[this._size];
			for (int i = 0; i < this._size; i++)
			{
				array[i] = this._array[this._size - i - 1];
			}
			return array;
		}

		// Token: 0x040018CB RID: 6347
		private object[] _array;

		// Token: 0x040018CC RID: 6348
		private int _size;

		// Token: 0x040018CD RID: 6349
		private int _version;

		// Token: 0x040018CE RID: 6350
		[NonSerialized]
		private object _syncRoot;

		// Token: 0x040018CF RID: 6351
		private const int _defaultCapacity = 10;

		// Token: 0x02000BAE RID: 2990
		[Serializable]
		private class SyncStack : Stack
		{
			// Token: 0x06006DC5 RID: 28101 RVA: 0x0017B400 File Offset: 0x00179600
			internal SyncStack(Stack stack)
			{
				this._s = stack;
				this._root = stack.SyncRoot;
			}

			// Token: 0x170012A0 RID: 4768
			// (get) Token: 0x06006DC6 RID: 28102 RVA: 0x0017B41B File Offset: 0x0017961B
			public override bool IsSynchronized
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170012A1 RID: 4769
			// (get) Token: 0x06006DC7 RID: 28103 RVA: 0x0017B41E File Offset: 0x0017961E
			public override object SyncRoot
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170012A2 RID: 4770
			// (get) Token: 0x06006DC8 RID: 28104 RVA: 0x0017B428 File Offset: 0x00179628
			public override int Count
			{
				get
				{
					object root = this._root;
					int count;
					lock (root)
					{
						count = this._s.Count;
					}
					return count;
				}
			}

			// Token: 0x06006DC9 RID: 28105 RVA: 0x0017B470 File Offset: 0x00179670
			public override bool Contains(object obj)
			{
				object root = this._root;
				bool result;
				lock (root)
				{
					result = this._s.Contains(obj);
				}
				return result;
			}

			// Token: 0x06006DCA RID: 28106 RVA: 0x0017B4B8 File Offset: 0x001796B8
			public override object Clone()
			{
				object root = this._root;
				object result;
				lock (root)
				{
					result = new Stack.SyncStack((Stack)this._s.Clone());
				}
				return result;
			}

			// Token: 0x06006DCB RID: 28107 RVA: 0x0017B50C File Offset: 0x0017970C
			public override void Clear()
			{
				object root = this._root;
				lock (root)
				{
					this._s.Clear();
				}
			}

			// Token: 0x06006DCC RID: 28108 RVA: 0x0017B554 File Offset: 0x00179754
			public override void CopyTo(Array array, int arrayIndex)
			{
				object root = this._root;
				lock (root)
				{
					this._s.CopyTo(array, arrayIndex);
				}
			}

			// Token: 0x06006DCD RID: 28109 RVA: 0x0017B59C File Offset: 0x0017979C
			public override void Push(object value)
			{
				object root = this._root;
				lock (root)
				{
					this._s.Push(value);
				}
			}

			// Token: 0x06006DCE RID: 28110 RVA: 0x0017B5E4 File Offset: 0x001797E4
			public override object Pop()
			{
				object root = this._root;
				object result;
				lock (root)
				{
					result = this._s.Pop();
				}
				return result;
			}

			// Token: 0x06006DCF RID: 28111 RVA: 0x0017B62C File Offset: 0x0017982C
			public override IEnumerator GetEnumerator()
			{
				object root = this._root;
				IEnumerator enumerator;
				lock (root)
				{
					enumerator = this._s.GetEnumerator();
				}
				return enumerator;
			}

			// Token: 0x06006DD0 RID: 28112 RVA: 0x0017B674 File Offset: 0x00179874
			public override object Peek()
			{
				object root = this._root;
				object result;
				lock (root)
				{
					result = this._s.Peek();
				}
				return result;
			}

			// Token: 0x06006DD1 RID: 28113 RVA: 0x0017B6BC File Offset: 0x001798BC
			public override object[] ToArray()
			{
				object root = this._root;
				object[] result;
				lock (root)
				{
					result = this._s.ToArray();
				}
				return result;
			}

			// Token: 0x04003559 RID: 13657
			private Stack _s;

			// Token: 0x0400355A RID: 13658
			private object _root;
		}

		// Token: 0x02000BAF RID: 2991
		[Serializable]
		private class StackEnumerator : IEnumerator, ICloneable
		{
			// Token: 0x06006DD2 RID: 28114 RVA: 0x0017B704 File Offset: 0x00179904
			internal StackEnumerator(Stack stack)
			{
				this._stack = stack;
				this._version = this._stack._version;
				this._index = -2;
				this.currentElement = null;
			}

			// Token: 0x06006DD3 RID: 28115 RVA: 0x0017B733 File Offset: 0x00179933
			public object Clone()
			{
				return base.MemberwiseClone();
			}

			// Token: 0x06006DD4 RID: 28116 RVA: 0x0017B73C File Offset: 0x0017993C
			public virtual bool MoveNext()
			{
				if (this._version != this._stack._version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				bool flag;
				if (this._index == -2)
				{
					this._index = this._stack._size - 1;
					flag = (this._index >= 0);
					if (flag)
					{
						this.currentElement = this._stack._array[this._index];
					}
					return flag;
				}
				if (this._index == -1)
				{
					return false;
				}
				int num = this._index - 1;
				this._index = num;
				flag = (num >= 0);
				if (flag)
				{
					this.currentElement = this._stack._array[this._index];
				}
				else
				{
					this.currentElement = null;
				}
				return flag;
			}

			// Token: 0x170012A3 RID: 4771
			// (get) Token: 0x06006DD5 RID: 28117 RVA: 0x0017B7FB File Offset: 0x001799FB
			public virtual object Current
			{
				get
				{
					if (this._index == -2)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this._index == -1)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					return this.currentElement;
				}
			}

			// Token: 0x06006DD6 RID: 28118 RVA: 0x0017B836 File Offset: 0x00179A36
			public virtual void Reset()
			{
				if (this._version != this._stack._version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				this._index = -2;
				this.currentElement = null;
			}

			// Token: 0x0400355B RID: 13659
			private Stack _stack;

			// Token: 0x0400355C RID: 13660
			private int _index;

			// Token: 0x0400355D RID: 13661
			private int _version;

			// Token: 0x0400355E RID: 13662
			private object currentElement;
		}

		// Token: 0x02000BB0 RID: 2992
		internal class StackDebugView
		{
			// Token: 0x06006DD7 RID: 28119 RVA: 0x0017B86A File Offset: 0x00179A6A
			public StackDebugView(Stack stack)
			{
				if (stack == null)
				{
					throw new ArgumentNullException("stack");
				}
				this.stack = stack;
			}

			// Token: 0x170012A4 RID: 4772
			// (get) Token: 0x06006DD8 RID: 28120 RVA: 0x0017B887 File Offset: 0x00179A87
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public object[] Items
			{
				get
				{
					return this.stack.ToArray();
				}
			}

			// Token: 0x0400355F RID: 13663
			private Stack stack;
		}
	}
}
