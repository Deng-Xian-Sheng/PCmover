using System;

namespace System.Collections
{
	// Token: 0x02000495 RID: 1173
	[Serializable]
	internal sealed class EmptyReadOnlyDictionaryInternal : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x0600384A RID: 14410 RVA: 0x000D81CD File Offset: 0x000D63CD
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new EmptyReadOnlyDictionaryInternal.NodeEnumerator();
		}

		// Token: 0x0600384B RID: 14411 RVA: 0x000D81D4 File Offset: 0x000D63D4
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
		}

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x0600384C RID: 14412 RVA: 0x000D8246 File Offset: 0x000D6446
		public int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x0600384D RID: 14413 RVA: 0x000D8249 File Offset: 0x000D6449
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x0600384E RID: 14414 RVA: 0x000D824C File Offset: 0x000D644C
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700085A RID: 2138
		public object this[object key]
		{
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
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
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
			}
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06003851 RID: 14417 RVA: 0x000D82E7 File Offset: 0x000D64E7
		public ICollection Keys
		{
			get
			{
				return EmptyArray<object>.Value;
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06003852 RID: 14418 RVA: 0x000D82EE File Offset: 0x000D64EE
		public ICollection Values
		{
			get
			{
				return EmptyArray<object>.Value;
			}
		}

		// Token: 0x06003853 RID: 14419 RVA: 0x000D82F5 File Offset: 0x000D64F5
		public bool Contains(object key)
		{
			return false;
		}

		// Token: 0x06003854 RID: 14420 RVA: 0x000D82F8 File Offset: 0x000D64F8
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
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
		}

		// Token: 0x06003855 RID: 14421 RVA: 0x000D8373 File Offset: 0x000D6573
		public void Clear()
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06003856 RID: 14422 RVA: 0x000D8384 File Offset: 0x000D6584
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06003857 RID: 14423 RVA: 0x000D8387 File Offset: 0x000D6587
		public bool IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06003858 RID: 14424 RVA: 0x000D838A File Offset: 0x000D658A
		public IDictionaryEnumerator GetEnumerator()
		{
			return new EmptyReadOnlyDictionaryInternal.NodeEnumerator();
		}

		// Token: 0x06003859 RID: 14425 RVA: 0x000D8391 File Offset: 0x000D6591
		public void Remove(object key)
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
		}

		// Token: 0x02000BB4 RID: 2996
		private sealed class NodeEnumerator : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06006DE8 RID: 28136 RVA: 0x0017BB1F File Offset: 0x00179D1F
			public bool MoveNext()
			{
				return false;
			}

			// Token: 0x170012AC RID: 4780
			// (get) Token: 0x06006DE9 RID: 28137 RVA: 0x0017BB22 File Offset: 0x00179D22
			public object Current
			{
				get
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
			}

			// Token: 0x06006DEA RID: 28138 RVA: 0x0017BB33 File Offset: 0x00179D33
			public void Reset()
			{
			}

			// Token: 0x170012AD RID: 4781
			// (get) Token: 0x06006DEB RID: 28139 RVA: 0x0017BB35 File Offset: 0x00179D35
			public object Key
			{
				get
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
			}

			// Token: 0x170012AE RID: 4782
			// (get) Token: 0x06006DEC RID: 28140 RVA: 0x0017BB46 File Offset: 0x00179D46
			public object Value
			{
				get
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
			}

			// Token: 0x170012AF RID: 4783
			// (get) Token: 0x06006DED RID: 28141 RVA: 0x0017BB57 File Offset: 0x00179D57
			public DictionaryEntry Entry
			{
				get
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
				}
			}
		}
	}
}
