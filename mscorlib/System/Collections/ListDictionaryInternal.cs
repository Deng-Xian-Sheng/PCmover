using System;
using System.Threading;

namespace System.Collections
{
	// Token: 0x02000494 RID: 1172
	[Serializable]
	internal class ListDictionaryInternal : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x1700084F RID: 2127
		public object this[object key]
		{
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
				}
				for (ListDictionaryInternal.DictionaryNode next = this.head; next != null; next = next.next)
				{
					if (next.key.Equals(key))
					{
						return next.value;
					}
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
				}
				if (!key.GetType().IsSerializable)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "key");
				}
				if (value != null && !value.GetType().IsSerializable)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "value");
				}
				this.version++;
				ListDictionaryInternal.DictionaryNode dictionaryNode = null;
				ListDictionaryInternal.DictionaryNode next = this.head;
				while (next != null && !next.key.Equals(key))
				{
					dictionaryNode = next;
					next = next.next;
				}
				if (next != null)
				{
					next.value = value;
					return;
				}
				ListDictionaryInternal.DictionaryNode dictionaryNode2 = new ListDictionaryInternal.DictionaryNode();
				dictionaryNode2.key = key;
				dictionaryNode2.value = value;
				if (dictionaryNode != null)
				{
					dictionaryNode.next = dictionaryNode2;
				}
				else
				{
					this.head = dictionaryNode2;
				}
				this.count++;
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x0600383B RID: 14395 RVA: 0x000D7ECF File Offset: 0x000D60CF
		public int Count
		{
			get
			{
				return this.count;
			}
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x0600383C RID: 14396 RVA: 0x000D7ED7 File Offset: 0x000D60D7
		public ICollection Keys
		{
			get
			{
				return new ListDictionaryInternal.NodeKeyValueCollection(this, true);
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x0600383D RID: 14397 RVA: 0x000D7EE0 File Offset: 0x000D60E0
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x0600383E RID: 14398 RVA: 0x000D7EE3 File Offset: 0x000D60E3
		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x0600383F RID: 14399 RVA: 0x000D7EE6 File Offset: 0x000D60E6
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06003840 RID: 14400 RVA: 0x000D7EE9 File Offset: 0x000D60E9
		public object SyncRoot
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

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06003841 RID: 14401 RVA: 0x000D7F0B File Offset: 0x000D610B
		public ICollection Values
		{
			get
			{
				return new ListDictionaryInternal.NodeKeyValueCollection(this, false);
			}
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x000D7F14 File Offset: 0x000D6114
		public void Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
			}
			if (!key.GetType().IsSerializable)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "key");
			}
			if (value != null && !value.GetType().IsSerializable)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "value");
			}
			this.version++;
			ListDictionaryInternal.DictionaryNode dictionaryNode = null;
			ListDictionaryInternal.DictionaryNode next;
			for (next = this.head; next != null; next = next.next)
			{
				if (next.key.Equals(key))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_AddingDuplicate__", new object[]
					{
						next.key,
						key
					}));
				}
				dictionaryNode = next;
			}
			if (next != null)
			{
				next.value = value;
				return;
			}
			ListDictionaryInternal.DictionaryNode dictionaryNode2 = new ListDictionaryInternal.DictionaryNode();
			dictionaryNode2.key = key;
			dictionaryNode2.value = value;
			if (dictionaryNode != null)
			{
				dictionaryNode.next = dictionaryNode2;
			}
			else
			{
				this.head = dictionaryNode2;
			}
			this.count++;
		}

		// Token: 0x06003843 RID: 14403 RVA: 0x000D8016 File Offset: 0x000D6216
		public void Clear()
		{
			this.count = 0;
			this.head = null;
			this.version++;
		}

		// Token: 0x06003844 RID: 14404 RVA: 0x000D8034 File Offset: 0x000D6234
		public bool Contains(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
			}
			for (ListDictionaryInternal.DictionaryNode next = this.head; next != null; next = next.next)
			{
				if (next.key.Equals(key))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003845 RID: 14405 RVA: 0x000D8080 File Offset: 0x000D6280
		public void CopyTo(Array array, int index)
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
			if (array.Length - index < this.Count)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentOutOfRange_Index"), "index");
			}
			for (ListDictionaryInternal.DictionaryNode next = this.head; next != null; next = next.next)
			{
				array.SetValue(new DictionaryEntry(next.key, next.value), index);
				index++;
			}
		}

		// Token: 0x06003846 RID: 14406 RVA: 0x000D8127 File Offset: 0x000D6327
		public IDictionaryEnumerator GetEnumerator()
		{
			return new ListDictionaryInternal.NodeEnumerator(this);
		}

		// Token: 0x06003847 RID: 14407 RVA: 0x000D812F File Offset: 0x000D632F
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ListDictionaryInternal.NodeEnumerator(this);
		}

		// Token: 0x06003848 RID: 14408 RVA: 0x000D8138 File Offset: 0x000D6338
		public void Remove(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
			}
			this.version++;
			ListDictionaryInternal.DictionaryNode dictionaryNode = null;
			ListDictionaryInternal.DictionaryNode next = this.head;
			while (next != null && !next.key.Equals(key))
			{
				dictionaryNode = next;
				next = next.next;
			}
			if (next == null)
			{
				return;
			}
			if (next == this.head)
			{
				this.head = next.next;
			}
			else
			{
				dictionaryNode.next = next.next;
			}
			this.count--;
		}

		// Token: 0x040018D6 RID: 6358
		private ListDictionaryInternal.DictionaryNode head;

		// Token: 0x040018D7 RID: 6359
		private int version;

		// Token: 0x040018D8 RID: 6360
		private int count;

		// Token: 0x040018D9 RID: 6361
		[NonSerialized]
		private object _syncRoot;

		// Token: 0x02000BB1 RID: 2993
		private class NodeEnumerator : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06006DD9 RID: 28121 RVA: 0x0017B894 File Offset: 0x00179A94
			public NodeEnumerator(ListDictionaryInternal list)
			{
				this.list = list;
				this.version = list.version;
				this.start = true;
				this.current = null;
			}

			// Token: 0x170012A5 RID: 4773
			// (get) Token: 0x06006DDA RID: 28122 RVA: 0x0017B8BD File Offset: 0x00179ABD
			public object Current
			{
				get
				{
					return this.Entry;
				}
			}

			// Token: 0x170012A6 RID: 4774
			// (get) Token: 0x06006DDB RID: 28123 RVA: 0x0017B8CA File Offset: 0x00179ACA
			public DictionaryEntry Entry
			{
				get
				{
					if (this.current == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					return new DictionaryEntry(this.current.key, this.current.value);
				}
			}

			// Token: 0x170012A7 RID: 4775
			// (get) Token: 0x06006DDC RID: 28124 RVA: 0x0017B8FF File Offset: 0x00179AFF
			public object Key
			{
				get
				{
					if (this.current == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					return this.current.key;
				}
			}

			// Token: 0x170012A8 RID: 4776
			// (get) Token: 0x06006DDD RID: 28125 RVA: 0x0017B924 File Offset: 0x00179B24
			public object Value
			{
				get
				{
					if (this.current == null)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					return this.current.value;
				}
			}

			// Token: 0x06006DDE RID: 28126 RVA: 0x0017B94C File Offset: 0x00179B4C
			public bool MoveNext()
			{
				if (this.version != this.list.version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				if (this.start)
				{
					this.current = this.list.head;
					this.start = false;
				}
				else if (this.current != null)
				{
					this.current = this.current.next;
				}
				return this.current != null;
			}

			// Token: 0x06006DDF RID: 28127 RVA: 0x0017B9C0 File Offset: 0x00179BC0
			public void Reset()
			{
				if (this.version != this.list.version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				this.start = true;
				this.current = null;
			}

			// Token: 0x04003560 RID: 13664
			private ListDictionaryInternal list;

			// Token: 0x04003561 RID: 13665
			private ListDictionaryInternal.DictionaryNode current;

			// Token: 0x04003562 RID: 13666
			private int version;

			// Token: 0x04003563 RID: 13667
			private bool start;
		}

		// Token: 0x02000BB2 RID: 2994
		private class NodeKeyValueCollection : ICollection, IEnumerable
		{
			// Token: 0x06006DE0 RID: 28128 RVA: 0x0017B9F3 File Offset: 0x00179BF3
			public NodeKeyValueCollection(ListDictionaryInternal list, bool isKeys)
			{
				this.list = list;
				this.isKeys = isKeys;
			}

			// Token: 0x06006DE1 RID: 28129 RVA: 0x0017BA0C File Offset: 0x00179C0C
			void ICollection.CopyTo(Array array, int index)
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
				if (array.Length - index < this.list.Count)
				{
					throw new ArgumentException(Environment.GetResourceString("ArgumentOutOfRange_Index"), "index");
				}
				for (ListDictionaryInternal.DictionaryNode dictionaryNode = this.list.head; dictionaryNode != null; dictionaryNode = dictionaryNode.next)
				{
					array.SetValue(this.isKeys ? dictionaryNode.key : dictionaryNode.value, index);
					index++;
				}
			}

			// Token: 0x170012A9 RID: 4777
			// (get) Token: 0x06006DE2 RID: 28130 RVA: 0x0017BAC0 File Offset: 0x00179CC0
			int ICollection.Count
			{
				get
				{
					int num = 0;
					for (ListDictionaryInternal.DictionaryNode dictionaryNode = this.list.head; dictionaryNode != null; dictionaryNode = dictionaryNode.next)
					{
						num++;
					}
					return num;
				}
			}

			// Token: 0x170012AA RID: 4778
			// (get) Token: 0x06006DE3 RID: 28131 RVA: 0x0017BAEC File Offset: 0x00179CEC
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170012AB RID: 4779
			// (get) Token: 0x06006DE4 RID: 28132 RVA: 0x0017BAEF File Offset: 0x00179CEF
			object ICollection.SyncRoot
			{
				get
				{
					return this.list.SyncRoot;
				}
			}

			// Token: 0x06006DE5 RID: 28133 RVA: 0x0017BAFC File Offset: 0x00179CFC
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new ListDictionaryInternal.NodeKeyValueCollection.NodeKeyValueEnumerator(this.list, this.isKeys);
			}

			// Token: 0x04003564 RID: 13668
			private ListDictionaryInternal list;

			// Token: 0x04003565 RID: 13669
			private bool isKeys;

			// Token: 0x02000D03 RID: 3331
			private class NodeKeyValueEnumerator : IEnumerator
			{
				// Token: 0x060071F1 RID: 29169 RVA: 0x00188A6B File Offset: 0x00186C6B
				public NodeKeyValueEnumerator(ListDictionaryInternal list, bool isKeys)
				{
					this.list = list;
					this.isKeys = isKeys;
					this.version = list.version;
					this.start = true;
					this.current = null;
				}

				// Token: 0x17001385 RID: 4997
				// (get) Token: 0x060071F2 RID: 29170 RVA: 0x00188A9B File Offset: 0x00186C9B
				public object Current
				{
					get
					{
						if (this.current == null)
						{
							throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
						}
						if (!this.isKeys)
						{
							return this.current.value;
						}
						return this.current.key;
					}
				}

				// Token: 0x060071F3 RID: 29171 RVA: 0x00188AD4 File Offset: 0x00186CD4
				public bool MoveNext()
				{
					if (this.version != this.list.version)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
					}
					if (this.start)
					{
						this.current = this.list.head;
						this.start = false;
					}
					else if (this.current != null)
					{
						this.current = this.current.next;
					}
					return this.current != null;
				}

				// Token: 0x060071F4 RID: 29172 RVA: 0x00188B48 File Offset: 0x00186D48
				public void Reset()
				{
					if (this.version != this.list.version)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
					}
					this.start = true;
					this.current = null;
				}

				// Token: 0x04003936 RID: 14646
				private ListDictionaryInternal list;

				// Token: 0x04003937 RID: 14647
				private ListDictionaryInternal.DictionaryNode current;

				// Token: 0x04003938 RID: 14648
				private int version;

				// Token: 0x04003939 RID: 14649
				private bool isKeys;

				// Token: 0x0400393A RID: 14650
				private bool start;
			}
		}

		// Token: 0x02000BB3 RID: 2995
		[Serializable]
		private class DictionaryNode
		{
			// Token: 0x04003566 RID: 13670
			public object key;

			// Token: 0x04003567 RID: 13671
			public object value;

			// Token: 0x04003568 RID: 13672
			public ListDictionaryInternal.DictionaryNode next;
		}
	}
}
