using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009CB RID: 2507
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	internal sealed class ConstantSplittableMap<TKey, TValue> : IMapView<TKey, TValue>, IIterable<IKeyValuePair<TKey, TValue>>, IEnumerable<IKeyValuePair<TKey, TValue>>, IEnumerable
	{
		// Token: 0x060063C6 RID: 25542 RVA: 0x00154864 File Offset: 0x00152A64
		internal ConstantSplittableMap(IReadOnlyDictionary<TKey, TValue> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			this.firstItemIndex = 0;
			this.lastItemIndex = data.Count - 1;
			this.items = this.CreateKeyValueArray(data.Count, data.GetEnumerator());
		}

		// Token: 0x060063C7 RID: 25543 RVA: 0x001548B4 File Offset: 0x00152AB4
		internal ConstantSplittableMap(IMapView<TKey, TValue> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (2147483647U < data.Size)
			{
				Exception ex = new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CollectionBackingDictionaryTooLarge"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
			int size = (int)data.Size;
			this.firstItemIndex = 0;
			this.lastItemIndex = size - 1;
			this.items = this.CreateKeyValueArray(size, data.GetEnumerator());
		}

		// Token: 0x060063C8 RID: 25544 RVA: 0x00154929 File Offset: 0x00152B29
		private ConstantSplittableMap(KeyValuePair<TKey, TValue>[] items, int firstItemIndex, int lastItemIndex)
		{
			this.items = items;
			this.firstItemIndex = firstItemIndex;
			this.lastItemIndex = lastItemIndex;
		}

		// Token: 0x060063C9 RID: 25545 RVA: 0x00154948 File Offset: 0x00152B48
		private KeyValuePair<TKey, TValue>[] CreateKeyValueArray(int count, IEnumerator<KeyValuePair<TKey, TValue>> data)
		{
			KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[count];
			int num = 0;
			while (data.MoveNext())
			{
				KeyValuePair<!0, !1> keyValuePair = data.Current;
				array[num++] = keyValuePair;
			}
			Array.Sort<KeyValuePair<TKey, TValue>>(array, ConstantSplittableMap<TKey, TValue>.keyValuePairComparator);
			return array;
		}

		// Token: 0x060063CA RID: 25546 RVA: 0x00154988 File Offset: 0x00152B88
		private KeyValuePair<TKey, TValue>[] CreateKeyValueArray(int count, IEnumerator<IKeyValuePair<TKey, TValue>> data)
		{
			KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[count];
			int num = 0;
			while (data.MoveNext())
			{
				IKeyValuePair<TKey, TValue> keyValuePair = data.Current;
				array[num++] = new KeyValuePair<TKey, TValue>(keyValuePair.Key, keyValuePair.Value);
			}
			Array.Sort<KeyValuePair<TKey, TValue>>(array, ConstantSplittableMap<TKey, TValue>.keyValuePairComparator);
			return array;
		}

		// Token: 0x17001140 RID: 4416
		// (get) Token: 0x060063CB RID: 25547 RVA: 0x001549D7 File Offset: 0x00152BD7
		public int Count
		{
			get
			{
				return this.lastItemIndex - this.firstItemIndex + 1;
			}
		}

		// Token: 0x17001141 RID: 4417
		// (get) Token: 0x060063CC RID: 25548 RVA: 0x001549E8 File Offset: 0x00152BE8
		public uint Size
		{
			get
			{
				return (uint)(this.lastItemIndex - this.firstItemIndex + 1);
			}
		}

		// Token: 0x060063CD RID: 25549 RVA: 0x001549FC File Offset: 0x00152BFC
		public TValue Lookup(TKey key)
		{
			TValue result;
			if (!this.TryGetValue(key, out result))
			{
				Exception ex = new KeyNotFoundException(Environment.GetResourceString("Arg_KeyNotFound"));
				ex.SetErrorCode(-2147483637);
				throw ex;
			}
			return result;
		}

		// Token: 0x060063CE RID: 25550 RVA: 0x00154A34 File Offset: 0x00152C34
		public bool HasKey(TKey key)
		{
			TValue tvalue;
			return this.TryGetValue(key, out tvalue);
		}

		// Token: 0x060063CF RID: 25551 RVA: 0x00154A4C File Offset: 0x00152C4C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IKeyValuePair<TKey, TValue>>)this).GetEnumerator();
		}

		// Token: 0x060063D0 RID: 25552 RVA: 0x00154A54 File Offset: 0x00152C54
		public IIterator<IKeyValuePair<TKey, TValue>> First()
		{
			return new EnumeratorToIteratorAdapter<IKeyValuePair<TKey, TValue>>(this.GetEnumerator());
		}

		// Token: 0x060063D1 RID: 25553 RVA: 0x00154A61 File Offset: 0x00152C61
		public IEnumerator<IKeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new ConstantSplittableMap<TKey, TValue>.IKeyValuePairEnumerator(this.items, this.firstItemIndex, this.lastItemIndex);
		}

		// Token: 0x060063D2 RID: 25554 RVA: 0x00154A80 File Offset: 0x00152C80
		public void Split(out IMapView<TKey, TValue> firstPartition, out IMapView<TKey, TValue> secondPartition)
		{
			if (this.Count < 2)
			{
				firstPartition = null;
				secondPartition = null;
				return;
			}
			int num = (int)(((long)this.firstItemIndex + (long)this.lastItemIndex) / 2L);
			firstPartition = new ConstantSplittableMap<TKey, TValue>(this.items, this.firstItemIndex, num);
			secondPartition = new ConstantSplittableMap<TKey, TValue>(this.items, num + 1, this.lastItemIndex);
		}

		// Token: 0x060063D3 RID: 25555 RVA: 0x00154ADC File Offset: 0x00152CDC
		public bool ContainsKey(TKey key)
		{
			KeyValuePair<TKey, TValue> value = new KeyValuePair<TKey, TValue>(key, default(TValue));
			int num = Array.BinarySearch<KeyValuePair<TKey, TValue>>(this.items, this.firstItemIndex, this.Count, value, ConstantSplittableMap<TKey, TValue>.keyValuePairComparator);
			return num >= 0;
		}

		// Token: 0x060063D4 RID: 25556 RVA: 0x00154B20 File Offset: 0x00152D20
		public bool TryGetValue(TKey key, out TValue value)
		{
			KeyValuePair<TKey, TValue> value2 = new KeyValuePair<TKey, TValue>(key, default(TValue));
			int num = Array.BinarySearch<KeyValuePair<TKey, TValue>>(this.items, this.firstItemIndex, this.Count, value2, ConstantSplittableMap<TKey, TValue>.keyValuePairComparator);
			if (num < 0)
			{
				value = default(TValue);
				return false;
			}
			value = this.items[num].Value;
			return true;
		}

		// Token: 0x17001142 RID: 4418
		public TValue this[TKey key]
		{
			get
			{
				return this.Lookup(key);
			}
		}

		// Token: 0x17001143 RID: 4419
		// (get) Token: 0x060063D6 RID: 25558 RVA: 0x00154B8A File Offset: 0x00152D8A
		public IEnumerable<TKey> Keys
		{
			get
			{
				throw new NotImplementedException("NYI");
			}
		}

		// Token: 0x17001144 RID: 4420
		// (get) Token: 0x060063D7 RID: 25559 RVA: 0x00154B96 File Offset: 0x00152D96
		public IEnumerable<TValue> Values
		{
			get
			{
				throw new NotImplementedException("NYI");
			}
		}

		// Token: 0x04002CDA RID: 11482
		private static readonly ConstantSplittableMap<TKey, TValue>.KeyValuePairComparator keyValuePairComparator = new ConstantSplittableMap<TKey, TValue>.KeyValuePairComparator();

		// Token: 0x04002CDB RID: 11483
		private readonly KeyValuePair<TKey, TValue>[] items;

		// Token: 0x04002CDC RID: 11484
		private readonly int firstItemIndex;

		// Token: 0x04002CDD RID: 11485
		private readonly int lastItemIndex;

		// Token: 0x02000C9F RID: 3231
		private class KeyValuePairComparator : IComparer<KeyValuePair<TKey, TValue>>
		{
			// Token: 0x06007122 RID: 28962 RVA: 0x00185645 File Offset: 0x00183845
			public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return ConstantSplittableMap<TKey, TValue>.KeyValuePairComparator.keyComparator.Compare(x.Key, y.Key);
			}

			// Token: 0x04003877 RID: 14455
			private static readonly IComparer<TKey> keyComparator = Comparer<TKey>.Default;
		}

		// Token: 0x02000CA0 RID: 3232
		[Serializable]
		internal struct IKeyValuePairEnumerator : IEnumerator<IKeyValuePair<TKey, TValue>>, IDisposable, IEnumerator
		{
			// Token: 0x06007125 RID: 28965 RVA: 0x00185673 File Offset: 0x00183873
			internal IKeyValuePairEnumerator(KeyValuePair<TKey, TValue>[] items, int first, int end)
			{
				this._array = items;
				this._start = first;
				this._end = end;
				this._current = this._start - 1;
			}

			// Token: 0x06007126 RID: 28966 RVA: 0x00185698 File Offset: 0x00183898
			public bool MoveNext()
			{
				if (this._current < this._end)
				{
					this._current++;
					return true;
				}
				return false;
			}

			// Token: 0x17001367 RID: 4967
			// (get) Token: 0x06007127 RID: 28967 RVA: 0x001856BC File Offset: 0x001838BC
			public IKeyValuePair<TKey, TValue> Current
			{
				get
				{
					if (this._current < this._start)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
					}
					if (this._current > this._end)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
					}
					return new CLRIKeyValuePairImpl<TKey, TValue>(ref this._array[this._current]);
				}
			}

			// Token: 0x17001368 RID: 4968
			// (get) Token: 0x06007128 RID: 28968 RVA: 0x0018571B File Offset: 0x0018391B
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06007129 RID: 28969 RVA: 0x00185723 File Offset: 0x00183923
			void IEnumerator.Reset()
			{
				this._current = this._start - 1;
			}

			// Token: 0x0600712A RID: 28970 RVA: 0x00185733 File Offset: 0x00183933
			public void Dispose()
			{
			}

			// Token: 0x04003878 RID: 14456
			private KeyValuePair<TKey, TValue>[] _array;

			// Token: 0x04003879 RID: 14457
			private int _start;

			// Token: 0x0400387A RID: 14458
			private int _end;

			// Token: 0x0400387B RID: 14459
			private int _current;
		}
	}
}
