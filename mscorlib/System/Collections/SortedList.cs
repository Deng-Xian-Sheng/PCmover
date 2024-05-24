using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections
{
	// Token: 0x020004A3 RID: 1187
	[DebuggerTypeProxy(typeof(SortedList.SortedListDebugView))]
	[DebuggerDisplay("Count = {Count}")]
	[ComVisible(true)]
	[Serializable]
	public class SortedList : IDictionary, ICollection, IEnumerable, ICloneable
	{
		// Token: 0x060038CA RID: 14538 RVA: 0x000D9BFB File Offset: 0x000D7DFB
		public SortedList()
		{
			this.Init();
		}

		// Token: 0x060038CB RID: 14539 RVA: 0x000D9C09 File Offset: 0x000D7E09
		private void Init()
		{
			this.keys = SortedList.emptyArray;
			this.values = SortedList.emptyArray;
			this._size = 0;
			this.comparer = new Comparer(CultureInfo.CurrentCulture);
		}

		// Token: 0x060038CC RID: 14540 RVA: 0x000D9C38 File Offset: 0x000D7E38
		public SortedList(int initialCapacity)
		{
			if (initialCapacity < 0)
			{
				throw new ArgumentOutOfRangeException("initialCapacity", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.keys = new object[initialCapacity];
			this.values = new object[initialCapacity];
			this.comparer = new Comparer(CultureInfo.CurrentCulture);
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x000D9C8C File Offset: 0x000D7E8C
		public SortedList(IComparer comparer) : this()
		{
			if (comparer != null)
			{
				this.comparer = comparer;
			}
		}

		// Token: 0x060038CE RID: 14542 RVA: 0x000D9C9E File Offset: 0x000D7E9E
		public SortedList(IComparer comparer, int capacity) : this(comparer)
		{
			this.Capacity = capacity;
		}

		// Token: 0x060038CF RID: 14543 RVA: 0x000D9CAE File Offset: 0x000D7EAE
		public SortedList(IDictionary d) : this(d, null)
		{
		}

		// Token: 0x060038D0 RID: 14544 RVA: 0x000D9CB8 File Offset: 0x000D7EB8
		public SortedList(IDictionary d, IComparer comparer) : this(comparer, (d != null) ? d.Count : 0)
		{
			if (d == null)
			{
				throw new ArgumentNullException("d", Environment.GetResourceString("ArgumentNull_Dictionary"));
			}
			d.Keys.CopyTo(this.keys, 0);
			d.Values.CopyTo(this.values, 0);
			Array.Sort(this.keys, this.values, comparer);
			this._size = d.Count;
		}

		// Token: 0x060038D1 RID: 14545 RVA: 0x000D9D34 File Offset: 0x000D7F34
		public virtual void Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
			}
			int num = Array.BinarySearch(this.keys, 0, this._size, key, this.comparer);
			if (num >= 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_AddingDuplicate__", new object[]
				{
					this.GetKey(num),
					key
				}));
			}
			this.Insert(~num, key, value);
		}

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x060038D2 RID: 14546 RVA: 0x000D9DA5 File Offset: 0x000D7FA5
		// (set) Token: 0x060038D3 RID: 14547 RVA: 0x000D9DB0 File Offset: 0x000D7FB0
		public virtual int Capacity
		{
			get
			{
				return this.keys.Length;
			}
			set
			{
				if (value < this.Count)
				{
					throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_SmallCapacity"));
				}
				if (value != this.keys.Length)
				{
					if (value > 0)
					{
						object[] destinationArray = new object[value];
						object[] destinationArray2 = new object[value];
						if (this._size > 0)
						{
							Array.Copy(this.keys, 0, destinationArray, 0, this._size);
							Array.Copy(this.values, 0, destinationArray2, 0, this._size);
						}
						this.keys = destinationArray;
						this.values = destinationArray2;
						return;
					}
					this.keys = SortedList.emptyArray;
					this.values = SortedList.emptyArray;
				}
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x060038D4 RID: 14548 RVA: 0x000D9E4E File Offset: 0x000D804E
		public virtual int Count
		{
			get
			{
				return this._size;
			}
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x060038D5 RID: 14549 RVA: 0x000D9E56 File Offset: 0x000D8056
		public virtual ICollection Keys
		{
			get
			{
				return this.GetKeyList();
			}
		}

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x060038D6 RID: 14550 RVA: 0x000D9E5E File Offset: 0x000D805E
		public virtual ICollection Values
		{
			get
			{
				return this.GetValueList();
			}
		}

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x060038D7 RID: 14551 RVA: 0x000D9E66 File Offset: 0x000D8066
		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x060038D8 RID: 14552 RVA: 0x000D9E69 File Offset: 0x000D8069
		public virtual bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x060038D9 RID: 14553 RVA: 0x000D9E6C File Offset: 0x000D806C
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x060038DA RID: 14554 RVA: 0x000D9E6F File Offset: 0x000D806F
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

		// Token: 0x060038DB RID: 14555 RVA: 0x000D9E91 File Offset: 0x000D8091
		public virtual void Clear()
		{
			this.version++;
			Array.Clear(this.keys, 0, this._size);
			Array.Clear(this.values, 0, this._size);
			this._size = 0;
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x000D9ECC File Offset: 0x000D80CC
		public virtual object Clone()
		{
			SortedList sortedList = new SortedList(this._size);
			Array.Copy(this.keys, 0, sortedList.keys, 0, this._size);
			Array.Copy(this.values, 0, sortedList.values, 0, this._size);
			sortedList._size = this._size;
			sortedList.version = this.version;
			sortedList.comparer = this.comparer;
			return sortedList;
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x000D9F3C File Offset: 0x000D813C
		public virtual bool Contains(object key)
		{
			return this.IndexOfKey(key) >= 0;
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x000D9F4B File Offset: 0x000D814B
		public virtual bool ContainsKey(object key)
		{
			return this.IndexOfKey(key) >= 0;
		}

		// Token: 0x060038DF RID: 14559 RVA: 0x000D9F5A File Offset: 0x000D815A
		public virtual bool ContainsValue(object value)
		{
			return this.IndexOfValue(value) >= 0;
		}

		// Token: 0x060038E0 RID: 14560 RVA: 0x000D9F6C File Offset: 0x000D816C
		public virtual void CopyTo(Array array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (array.Length - arrayIndex < this.Count)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ArrayPlusOffTooSmall"));
			}
			for (int i = 0; i < this.Count; i++)
			{
				DictionaryEntry dictionaryEntry = new DictionaryEntry(this.keys[i], this.values[i]);
				array.SetValue(dictionaryEntry, i + arrayIndex);
			}
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x000DA01C File Offset: 0x000D821C
		internal virtual KeyValuePairs[] ToKeyValuePairsArray()
		{
			KeyValuePairs[] array = new KeyValuePairs[this.Count];
			for (int i = 0; i < this.Count; i++)
			{
				array[i] = new KeyValuePairs(this.keys[i], this.values[i]);
			}
			return array;
		}

		// Token: 0x060038E2 RID: 14562 RVA: 0x000DA060 File Offset: 0x000D8260
		private void EnsureCapacity(int min)
		{
			int num = (this.keys.Length == 0) ? 16 : (this.keys.Length * 2);
			if (num > 2146435071)
			{
				num = 2146435071;
			}
			if (num < min)
			{
				num = min;
			}
			this.Capacity = num;
		}

		// Token: 0x060038E3 RID: 14563 RVA: 0x000DA0A0 File Offset: 0x000D82A0
		public virtual object GetByIndex(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return this.values[index];
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x000DA0CC File Offset: 0x000D82CC
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new SortedList.SortedListEnumerator(this, 0, this._size, 3);
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x000DA0DC File Offset: 0x000D82DC
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return new SortedList.SortedListEnumerator(this, 0, this._size, 3);
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x000DA0EC File Offset: 0x000D82EC
		public virtual object GetKey(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return this.keys[index];
		}

		// Token: 0x060038E7 RID: 14567 RVA: 0x000DA118 File Offset: 0x000D8318
		public virtual IList GetKeyList()
		{
			if (this.keyList == null)
			{
				this.keyList = new SortedList.KeyList(this);
			}
			return this.keyList;
		}

		// Token: 0x060038E8 RID: 14568 RVA: 0x000DA134 File Offset: 0x000D8334
		public virtual IList GetValueList()
		{
			if (this.valueList == null)
			{
				this.valueList = new SortedList.ValueList(this);
			}
			return this.valueList;
		}

		// Token: 0x17000886 RID: 2182
		public virtual object this[object key]
		{
			get
			{
				int num = this.IndexOfKey(key);
				if (num >= 0)
				{
					return this.values[num];
				}
				return null;
			}
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
				}
				int num = Array.BinarySearch(this.keys, 0, this._size, key, this.comparer);
				if (num >= 0)
				{
					this.values[num] = value;
					this.version++;
					return;
				}
				this.Insert(~num, key, value);
			}
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x000DA1DC File Offset: 0x000D83DC
		public virtual int IndexOfKey(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
			}
			int num = Array.BinarySearch(this.keys, 0, this._size, key, this.comparer);
			if (num < 0)
			{
				return -1;
			}
			return num;
		}

		// Token: 0x060038EC RID: 14572 RVA: 0x000DA222 File Offset: 0x000D8422
		public virtual int IndexOfValue(object value)
		{
			return Array.IndexOf<object>(this.values, value, 0, this._size);
		}

		// Token: 0x060038ED RID: 14573 RVA: 0x000DA238 File Offset: 0x000D8438
		private void Insert(int index, object key, object value)
		{
			if (this._size == this.keys.Length)
			{
				this.EnsureCapacity(this._size + 1);
			}
			if (index < this._size)
			{
				Array.Copy(this.keys, index, this.keys, index + 1, this._size - index);
				Array.Copy(this.values, index, this.values, index + 1, this._size - index);
			}
			this.keys[index] = key;
			this.values[index] = value;
			this._size++;
			this.version++;
		}

		// Token: 0x060038EE RID: 14574 RVA: 0x000DA2D4 File Offset: 0x000D84D4
		public virtual void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			this._size--;
			if (index < this._size)
			{
				Array.Copy(this.keys, index + 1, this.keys, index, this._size - index);
				Array.Copy(this.values, index + 1, this.values, index, this._size - index);
			}
			this.keys[this._size] = null;
			this.values[this._size] = null;
			this.version++;
		}

		// Token: 0x060038EF RID: 14575 RVA: 0x000DA380 File Offset: 0x000D8580
		public virtual void Remove(object key)
		{
			int num = this.IndexOfKey(key);
			if (num >= 0)
			{
				this.RemoveAt(num);
			}
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x000DA3A0 File Offset: 0x000D85A0
		public virtual void SetByIndex(int index, object value)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			this.values[index] = value;
			this.version++;
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x000DA3DB File Offset: 0x000D85DB
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
		public static SortedList Synchronized(SortedList list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			return new SortedList.SyncSortedList(list);
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x000DA3F1 File Offset: 0x000D85F1
		public virtual void TrimToSize()
		{
			this.Capacity = this._size;
		}

		// Token: 0x040018FD RID: 6397
		private object[] keys;

		// Token: 0x040018FE RID: 6398
		private object[] values;

		// Token: 0x040018FF RID: 6399
		private int _size;

		// Token: 0x04001900 RID: 6400
		private int version;

		// Token: 0x04001901 RID: 6401
		private IComparer comparer;

		// Token: 0x04001902 RID: 6402
		private SortedList.KeyList keyList;

		// Token: 0x04001903 RID: 6403
		private SortedList.ValueList valueList;

		// Token: 0x04001904 RID: 6404
		[NonSerialized]
		private object _syncRoot;

		// Token: 0x04001905 RID: 6405
		private const int _defaultCapacity = 16;

		// Token: 0x04001906 RID: 6406
		private static object[] emptyArray = EmptyArray<object>.Value;

		// Token: 0x02000BBB RID: 3003
		[Serializable]
		private class SyncSortedList : SortedList
		{
			// Token: 0x06006E1C RID: 28188 RVA: 0x0017C358 File Offset: 0x0017A558
			internal SyncSortedList(SortedList list)
			{
				this._list = list;
				this._root = list.SyncRoot;
			}

			// Token: 0x170012C3 RID: 4803
			// (get) Token: 0x06006E1D RID: 28189 RVA: 0x0017C374 File Offset: 0x0017A574
			public override int Count
			{
				get
				{
					object root = this._root;
					int count;
					lock (root)
					{
						count = this._list.Count;
					}
					return count;
				}
			}

			// Token: 0x170012C4 RID: 4804
			// (get) Token: 0x06006E1E RID: 28190 RVA: 0x0017C3BC File Offset: 0x0017A5BC
			public override object SyncRoot
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170012C5 RID: 4805
			// (get) Token: 0x06006E1F RID: 28191 RVA: 0x0017C3C4 File Offset: 0x0017A5C4
			public override bool IsReadOnly
			{
				get
				{
					return this._list.IsReadOnly;
				}
			}

			// Token: 0x170012C6 RID: 4806
			// (get) Token: 0x06006E20 RID: 28192 RVA: 0x0017C3D1 File Offset: 0x0017A5D1
			public override bool IsFixedSize
			{
				get
				{
					return this._list.IsFixedSize;
				}
			}

			// Token: 0x170012C7 RID: 4807
			// (get) Token: 0x06006E21 RID: 28193 RVA: 0x0017C3DE File Offset: 0x0017A5DE
			public override bool IsSynchronized
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170012C8 RID: 4808
			public override object this[object key]
			{
				get
				{
					object root = this._root;
					object result;
					lock (root)
					{
						result = this._list[key];
					}
					return result;
				}
				set
				{
					object root = this._root;
					lock (root)
					{
						this._list[key] = value;
					}
				}
			}

			// Token: 0x06006E24 RID: 28196 RVA: 0x0017C474 File Offset: 0x0017A674
			public override void Add(object key, object value)
			{
				object root = this._root;
				lock (root)
				{
					this._list.Add(key, value);
				}
			}

			// Token: 0x170012C9 RID: 4809
			// (get) Token: 0x06006E25 RID: 28197 RVA: 0x0017C4BC File Offset: 0x0017A6BC
			public override int Capacity
			{
				get
				{
					object root = this._root;
					int capacity;
					lock (root)
					{
						capacity = this._list.Capacity;
					}
					return capacity;
				}
			}

			// Token: 0x06006E26 RID: 28198 RVA: 0x0017C504 File Offset: 0x0017A704
			public override void Clear()
			{
				object root = this._root;
				lock (root)
				{
					this._list.Clear();
				}
			}

			// Token: 0x06006E27 RID: 28199 RVA: 0x0017C54C File Offset: 0x0017A74C
			public override object Clone()
			{
				object root = this._root;
				object result;
				lock (root)
				{
					result = this._list.Clone();
				}
				return result;
			}

			// Token: 0x06006E28 RID: 28200 RVA: 0x0017C594 File Offset: 0x0017A794
			public override bool Contains(object key)
			{
				object root = this._root;
				bool result;
				lock (root)
				{
					result = this._list.Contains(key);
				}
				return result;
			}

			// Token: 0x06006E29 RID: 28201 RVA: 0x0017C5DC File Offset: 0x0017A7DC
			public override bool ContainsKey(object key)
			{
				object root = this._root;
				bool result;
				lock (root)
				{
					result = this._list.ContainsKey(key);
				}
				return result;
			}

			// Token: 0x06006E2A RID: 28202 RVA: 0x0017C624 File Offset: 0x0017A824
			public override bool ContainsValue(object key)
			{
				object root = this._root;
				bool result;
				lock (root)
				{
					result = this._list.ContainsValue(key);
				}
				return result;
			}

			// Token: 0x06006E2B RID: 28203 RVA: 0x0017C66C File Offset: 0x0017A86C
			public override void CopyTo(Array array, int index)
			{
				object root = this._root;
				lock (root)
				{
					this._list.CopyTo(array, index);
				}
			}

			// Token: 0x06006E2C RID: 28204 RVA: 0x0017C6B4 File Offset: 0x0017A8B4
			public override object GetByIndex(int index)
			{
				object root = this._root;
				object byIndex;
				lock (root)
				{
					byIndex = this._list.GetByIndex(index);
				}
				return byIndex;
			}

			// Token: 0x06006E2D RID: 28205 RVA: 0x0017C6FC File Offset: 0x0017A8FC
			public override IDictionaryEnumerator GetEnumerator()
			{
				object root = this._root;
				IDictionaryEnumerator enumerator;
				lock (root)
				{
					enumerator = this._list.GetEnumerator();
				}
				return enumerator;
			}

			// Token: 0x06006E2E RID: 28206 RVA: 0x0017C744 File Offset: 0x0017A944
			public override object GetKey(int index)
			{
				object root = this._root;
				object key;
				lock (root)
				{
					key = this._list.GetKey(index);
				}
				return key;
			}

			// Token: 0x06006E2F RID: 28207 RVA: 0x0017C78C File Offset: 0x0017A98C
			public override IList GetKeyList()
			{
				object root = this._root;
				IList keyList;
				lock (root)
				{
					keyList = this._list.GetKeyList();
				}
				return keyList;
			}

			// Token: 0x06006E30 RID: 28208 RVA: 0x0017C7D4 File Offset: 0x0017A9D4
			public override IList GetValueList()
			{
				object root = this._root;
				IList valueList;
				lock (root)
				{
					valueList = this._list.GetValueList();
				}
				return valueList;
			}

			// Token: 0x06006E31 RID: 28209 RVA: 0x0017C81C File Offset: 0x0017AA1C
			public override int IndexOfKey(object key)
			{
				if (key == null)
				{
					throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
				}
				object root = this._root;
				int result;
				lock (root)
				{
					result = this._list.IndexOfKey(key);
				}
				return result;
			}

			// Token: 0x06006E32 RID: 28210 RVA: 0x0017C87C File Offset: 0x0017AA7C
			public override int IndexOfValue(object value)
			{
				object root = this._root;
				int result;
				lock (root)
				{
					result = this._list.IndexOfValue(value);
				}
				return result;
			}

			// Token: 0x06006E33 RID: 28211 RVA: 0x0017C8C4 File Offset: 0x0017AAC4
			public override void RemoveAt(int index)
			{
				object root = this._root;
				lock (root)
				{
					this._list.RemoveAt(index);
				}
			}

			// Token: 0x06006E34 RID: 28212 RVA: 0x0017C90C File Offset: 0x0017AB0C
			public override void Remove(object key)
			{
				object root = this._root;
				lock (root)
				{
					this._list.Remove(key);
				}
			}

			// Token: 0x06006E35 RID: 28213 RVA: 0x0017C954 File Offset: 0x0017AB54
			public override void SetByIndex(int index, object value)
			{
				object root = this._root;
				lock (root)
				{
					this._list.SetByIndex(index, value);
				}
			}

			// Token: 0x06006E36 RID: 28214 RVA: 0x0017C99C File Offset: 0x0017AB9C
			internal override KeyValuePairs[] ToKeyValuePairsArray()
			{
				return this._list.ToKeyValuePairsArray();
			}

			// Token: 0x06006E37 RID: 28215 RVA: 0x0017C9AC File Offset: 0x0017ABAC
			public override void TrimToSize()
			{
				object root = this._root;
				lock (root)
				{
					this._list.TrimToSize();
				}
			}

			// Token: 0x0400357A RID: 13690
			private SortedList _list;

			// Token: 0x0400357B RID: 13691
			private object _root;
		}

		// Token: 0x02000BBC RID: 3004
		[Serializable]
		private class SortedListEnumerator : IDictionaryEnumerator, IEnumerator, ICloneable
		{
			// Token: 0x06006E38 RID: 28216 RVA: 0x0017C9F4 File Offset: 0x0017ABF4
			internal SortedListEnumerator(SortedList sortedList, int index, int count, int getObjRetType)
			{
				this.sortedList = sortedList;
				this.index = index;
				this.startIndex = index;
				this.endIndex = index + count;
				this.version = sortedList.version;
				this.getObjectRetType = getObjRetType;
				this.current = false;
			}

			// Token: 0x06006E39 RID: 28217 RVA: 0x0017CA40 File Offset: 0x0017AC40
			public object Clone()
			{
				return base.MemberwiseClone();
			}

			// Token: 0x170012CA RID: 4810
			// (get) Token: 0x06006E3A RID: 28218 RVA: 0x0017CA48 File Offset: 0x0017AC48
			public virtual object Key
			{
				get
				{
					if (this.version != this.sortedList.version)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
					}
					if (!this.current)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					return this.key;
				}
			}

			// Token: 0x06006E3B RID: 28219 RVA: 0x0017CA98 File Offset: 0x0017AC98
			public virtual bool MoveNext()
			{
				if (this.version != this.sortedList.version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				if (this.index < this.endIndex)
				{
					this.key = this.sortedList.keys[this.index];
					this.value = this.sortedList.values[this.index];
					this.index++;
					this.current = true;
					return true;
				}
				this.key = null;
				this.value = null;
				this.current = false;
				return false;
			}

			// Token: 0x170012CB RID: 4811
			// (get) Token: 0x06006E3C RID: 28220 RVA: 0x0017CB34 File Offset: 0x0017AD34
			public virtual DictionaryEntry Entry
			{
				get
				{
					if (this.version != this.sortedList.version)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
					}
					if (!this.current)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					return new DictionaryEntry(this.key, this.value);
				}
			}

			// Token: 0x170012CC RID: 4812
			// (get) Token: 0x06006E3D RID: 28221 RVA: 0x0017CB90 File Offset: 0x0017AD90
			public virtual object Current
			{
				get
				{
					if (!this.current)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					if (this.getObjectRetType == 1)
					{
						return this.key;
					}
					if (this.getObjectRetType == 2)
					{
						return this.value;
					}
					return new DictionaryEntry(this.key, this.value);
				}
			}

			// Token: 0x170012CD RID: 4813
			// (get) Token: 0x06006E3E RID: 28222 RVA: 0x0017CBEC File Offset: 0x0017ADEC
			public virtual object Value
			{
				get
				{
					if (this.version != this.sortedList.version)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
					}
					if (!this.current)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
					}
					return this.value;
				}
			}

			// Token: 0x06006E3F RID: 28223 RVA: 0x0017CC3C File Offset: 0x0017AE3C
			public virtual void Reset()
			{
				if (this.version != this.sortedList.version)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
				}
				this.index = this.startIndex;
				this.current = false;
				this.key = null;
				this.value = null;
			}

			// Token: 0x0400357C RID: 13692
			private SortedList sortedList;

			// Token: 0x0400357D RID: 13693
			private object key;

			// Token: 0x0400357E RID: 13694
			private object value;

			// Token: 0x0400357F RID: 13695
			private int index;

			// Token: 0x04003580 RID: 13696
			private int startIndex;

			// Token: 0x04003581 RID: 13697
			private int endIndex;

			// Token: 0x04003582 RID: 13698
			private int version;

			// Token: 0x04003583 RID: 13699
			private bool current;

			// Token: 0x04003584 RID: 13700
			private int getObjectRetType;

			// Token: 0x04003585 RID: 13701
			internal const int Keys = 1;

			// Token: 0x04003586 RID: 13702
			internal const int Values = 2;

			// Token: 0x04003587 RID: 13703
			internal const int DictEntry = 3;
		}

		// Token: 0x02000BBD RID: 3005
		[Serializable]
		private class KeyList : IList, ICollection, IEnumerable
		{
			// Token: 0x06006E40 RID: 28224 RVA: 0x0017CC8D File Offset: 0x0017AE8D
			internal KeyList(SortedList sortedList)
			{
				this.sortedList = sortedList;
			}

			// Token: 0x170012CE RID: 4814
			// (get) Token: 0x06006E41 RID: 28225 RVA: 0x0017CC9C File Offset: 0x0017AE9C
			public virtual int Count
			{
				get
				{
					return this.sortedList._size;
				}
			}

			// Token: 0x170012CF RID: 4815
			// (get) Token: 0x06006E42 RID: 28226 RVA: 0x0017CCA9 File Offset: 0x0017AEA9
			public virtual bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170012D0 RID: 4816
			// (get) Token: 0x06006E43 RID: 28227 RVA: 0x0017CCAC File Offset: 0x0017AEAC
			public virtual bool IsFixedSize
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170012D1 RID: 4817
			// (get) Token: 0x06006E44 RID: 28228 RVA: 0x0017CCAF File Offset: 0x0017AEAF
			public virtual bool IsSynchronized
			{
				get
				{
					return this.sortedList.IsSynchronized;
				}
			}

			// Token: 0x170012D2 RID: 4818
			// (get) Token: 0x06006E45 RID: 28229 RVA: 0x0017CCBC File Offset: 0x0017AEBC
			public virtual object SyncRoot
			{
				get
				{
					return this.sortedList.SyncRoot;
				}
			}

			// Token: 0x06006E46 RID: 28230 RVA: 0x0017CCC9 File Offset: 0x0017AEC9
			public virtual int Add(object key)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x06006E47 RID: 28231 RVA: 0x0017CCDA File Offset: 0x0017AEDA
			public virtual void Clear()
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x06006E48 RID: 28232 RVA: 0x0017CCEB File Offset: 0x0017AEEB
			public virtual bool Contains(object key)
			{
				return this.sortedList.Contains(key);
			}

			// Token: 0x06006E49 RID: 28233 RVA: 0x0017CCF9 File Offset: 0x0017AEF9
			public virtual void CopyTo(Array array, int arrayIndex)
			{
				if (array != null && array.Rank != 1)
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
				}
				Array.Copy(this.sortedList.keys, 0, array, arrayIndex, this.sortedList.Count);
			}

			// Token: 0x06006E4A RID: 28234 RVA: 0x0017CD35 File Offset: 0x0017AF35
			public virtual void Insert(int index, object value)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x170012D3 RID: 4819
			public virtual object this[int index]
			{
				get
				{
					return this.sortedList.GetKey(index);
				}
				set
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_KeyCollectionSet"));
				}
			}

			// Token: 0x06006E4D RID: 28237 RVA: 0x0017CD65 File Offset: 0x0017AF65
			public virtual IEnumerator GetEnumerator()
			{
				return new SortedList.SortedListEnumerator(this.sortedList, 0, this.sortedList.Count, 1);
			}

			// Token: 0x06006E4E RID: 28238 RVA: 0x0017CD80 File Offset: 0x0017AF80
			public virtual int IndexOf(object key)
			{
				if (key == null)
				{
					throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
				}
				int num = Array.BinarySearch(this.sortedList.keys, 0, this.sortedList.Count, key, this.sortedList.comparer);
				if (num >= 0)
				{
					return num;
				}
				return -1;
			}

			// Token: 0x06006E4F RID: 28239 RVA: 0x0017CDD5 File Offset: 0x0017AFD5
			public virtual void Remove(object key)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x06006E50 RID: 28240 RVA: 0x0017CDE6 File Offset: 0x0017AFE6
			public virtual void RemoveAt(int index)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x04003588 RID: 13704
			private SortedList sortedList;
		}

		// Token: 0x02000BBE RID: 3006
		[Serializable]
		private class ValueList : IList, ICollection, IEnumerable
		{
			// Token: 0x06006E51 RID: 28241 RVA: 0x0017CDF7 File Offset: 0x0017AFF7
			internal ValueList(SortedList sortedList)
			{
				this.sortedList = sortedList;
			}

			// Token: 0x170012D4 RID: 4820
			// (get) Token: 0x06006E52 RID: 28242 RVA: 0x0017CE06 File Offset: 0x0017B006
			public virtual int Count
			{
				get
				{
					return this.sortedList._size;
				}
			}

			// Token: 0x170012D5 RID: 4821
			// (get) Token: 0x06006E53 RID: 28243 RVA: 0x0017CE13 File Offset: 0x0017B013
			public virtual bool IsReadOnly
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170012D6 RID: 4822
			// (get) Token: 0x06006E54 RID: 28244 RVA: 0x0017CE16 File Offset: 0x0017B016
			public virtual bool IsFixedSize
			{
				get
				{
					return true;
				}
			}

			// Token: 0x170012D7 RID: 4823
			// (get) Token: 0x06006E55 RID: 28245 RVA: 0x0017CE19 File Offset: 0x0017B019
			public virtual bool IsSynchronized
			{
				get
				{
					return this.sortedList.IsSynchronized;
				}
			}

			// Token: 0x170012D8 RID: 4824
			// (get) Token: 0x06006E56 RID: 28246 RVA: 0x0017CE26 File Offset: 0x0017B026
			public virtual object SyncRoot
			{
				get
				{
					return this.sortedList.SyncRoot;
				}
			}

			// Token: 0x06006E57 RID: 28247 RVA: 0x0017CE33 File Offset: 0x0017B033
			public virtual int Add(object key)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x06006E58 RID: 28248 RVA: 0x0017CE44 File Offset: 0x0017B044
			public virtual void Clear()
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x06006E59 RID: 28249 RVA: 0x0017CE55 File Offset: 0x0017B055
			public virtual bool Contains(object value)
			{
				return this.sortedList.ContainsValue(value);
			}

			// Token: 0x06006E5A RID: 28250 RVA: 0x0017CE63 File Offset: 0x0017B063
			public virtual void CopyTo(Array array, int arrayIndex)
			{
				if (array != null && array.Rank != 1)
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
				}
				Array.Copy(this.sortedList.values, 0, array, arrayIndex, this.sortedList.Count);
			}

			// Token: 0x06006E5B RID: 28251 RVA: 0x0017CE9F File Offset: 0x0017B09F
			public virtual void Insert(int index, object value)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x170012D9 RID: 4825
			public virtual object this[int index]
			{
				get
				{
					return this.sortedList.GetByIndex(index);
				}
				set
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
				}
			}

			// Token: 0x06006E5E RID: 28254 RVA: 0x0017CECF File Offset: 0x0017B0CF
			public virtual IEnumerator GetEnumerator()
			{
				return new SortedList.SortedListEnumerator(this.sortedList, 0, this.sortedList.Count, 2);
			}

			// Token: 0x06006E5F RID: 28255 RVA: 0x0017CEE9 File Offset: 0x0017B0E9
			public virtual int IndexOf(object value)
			{
				return Array.IndexOf<object>(this.sortedList.values, value, 0, this.sortedList.Count);
			}

			// Token: 0x06006E60 RID: 28256 RVA: 0x0017CF08 File Offset: 0x0017B108
			public virtual void Remove(object value)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x06006E61 RID: 28257 RVA: 0x0017CF19 File Offset: 0x0017B119
			public virtual void RemoveAt(int index)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_SortedListNestedWrite"));
			}

			// Token: 0x04003589 RID: 13705
			private SortedList sortedList;
		}

		// Token: 0x02000BBF RID: 3007
		internal class SortedListDebugView
		{
			// Token: 0x06006E62 RID: 28258 RVA: 0x0017CF2A File Offset: 0x0017B12A
			public SortedListDebugView(SortedList sortedList)
			{
				if (sortedList == null)
				{
					throw new ArgumentNullException("sortedList");
				}
				this.sortedList = sortedList;
			}

			// Token: 0x170012DA RID: 4826
			// (get) Token: 0x06006E63 RID: 28259 RVA: 0x0017CF47 File Offset: 0x0017B147
			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public KeyValuePairs[] Items
			{
				get
				{
					return this.sortedList.ToKeyValuePairsArray();
				}
			}

			// Token: 0x0400358A RID: 13706
			private SortedList sortedList;
		}
	}
}
