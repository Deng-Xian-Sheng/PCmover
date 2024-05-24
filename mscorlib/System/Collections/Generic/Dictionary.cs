using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Threading;

namespace System.Collections.Generic
{
	// Token: 0x020004BE RID: 1214
	[DebuggerTypeProxy(typeof(Mscorlib_DictionaryDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[ComVisible(false)]
	[__DynamicallyInvokable]
	[Serializable]
	public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<!0, !1>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, ISerializable, IDeserializationCallback
	{
		// Token: 0x06003A34 RID: 14900 RVA: 0x000DDE44 File Offset: 0x000DC044
		[__DynamicallyInvokable]
		public Dictionary() : this(0, null)
		{
		}

		// Token: 0x06003A35 RID: 14901 RVA: 0x000DDE4E File Offset: 0x000DC04E
		[__DynamicallyInvokable]
		public Dictionary(int capacity) : this(capacity, null)
		{
		}

		// Token: 0x06003A36 RID: 14902 RVA: 0x000DDE58 File Offset: 0x000DC058
		[__DynamicallyInvokable]
		public Dictionary(IEqualityComparer<TKey> comparer) : this(0, comparer)
		{
		}

		// Token: 0x06003A37 RID: 14903 RVA: 0x000DDE62 File Offset: 0x000DC062
		[__DynamicallyInvokable]
		public Dictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			if (capacity < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity);
			}
			if (capacity > 0)
			{
				this.Initialize(capacity);
			}
			this.comparer = (comparer ?? EqualityComparer<TKey>.Default);
		}

		// Token: 0x06003A38 RID: 14904 RVA: 0x000DDE90 File Offset: 0x000DC090
		[__DynamicallyInvokable]
		public Dictionary(IDictionary<TKey, TValue> dictionary) : this(dictionary, null)
		{
		}

		// Token: 0x06003A39 RID: 14905 RVA: 0x000DDE9C File Offset: 0x000DC09C
		[__DynamicallyInvokable]
		public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : this((dictionary != null) ? dictionary.Count : 0, comparer)
		{
			if (dictionary == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
			}
			foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary)
			{
				this.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x06003A3A RID: 14906 RVA: 0x000DDF10 File Offset: 0x000DC110
		protected Dictionary(SerializationInfo info, StreamingContext context)
		{
			HashHelpers.SerializationInfoTable.Add(this, info);
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x06003A3B RID: 14907 RVA: 0x000DDF24 File Offset: 0x000DC124
		[__DynamicallyInvokable]
		public IEqualityComparer<TKey> Comparer
		{
			[__DynamicallyInvokable]
			get
			{
				return this.comparer;
			}
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x06003A3C RID: 14908 RVA: 0x000DDF2C File Offset: 0x000DC12C
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.count - this.freeCount;
			}
		}

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x06003A3D RID: 14909 RVA: 0x000DDF3B File Offset: 0x000DC13B
		[__DynamicallyInvokable]
		public Dictionary<TKey, TValue>.KeyCollection Keys
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.keys == null)
				{
					this.keys = new Dictionary<TKey, TValue>.KeyCollection(this);
				}
				return this.keys;
			}
		}

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x06003A3E RID: 14910 RVA: 0x000DDF57 File Offset: 0x000DC157
		[__DynamicallyInvokable]
		ICollection<TKey> IDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.keys == null)
				{
					this.keys = new Dictionary<TKey, TValue>.KeyCollection(this);
				}
				return this.keys;
			}
		}

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x06003A3F RID: 14911 RVA: 0x000DDF73 File Offset: 0x000DC173
		[__DynamicallyInvokable]
		IEnumerable<TKey> IReadOnlyDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.keys == null)
				{
					this.keys = new Dictionary<TKey, TValue>.KeyCollection(this);
				}
				return this.keys;
			}
		}

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x06003A40 RID: 14912 RVA: 0x000DDF8F File Offset: 0x000DC18F
		[__DynamicallyInvokable]
		public Dictionary<TKey, TValue>.ValueCollection Values
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.values == null)
				{
					this.values = new Dictionary<TKey, TValue>.ValueCollection(this);
				}
				return this.values;
			}
		}

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x06003A41 RID: 14913 RVA: 0x000DDFAB File Offset: 0x000DC1AB
		[__DynamicallyInvokable]
		ICollection<TValue> IDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.values == null)
				{
					this.values = new Dictionary<TKey, TValue>.ValueCollection(this);
				}
				return this.values;
			}
		}

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x06003A42 RID: 14914 RVA: 0x000DDFC7 File Offset: 0x000DC1C7
		[__DynamicallyInvokable]
		IEnumerable<TValue> IReadOnlyDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.values == null)
				{
					this.values = new Dictionary<TKey, TValue>.ValueCollection(this);
				}
				return this.values;
			}
		}

		// Token: 0x170008D7 RID: 2263
		[__DynamicallyInvokable]
		public TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				int num = this.FindEntry(key);
				if (num >= 0)
				{
					return this.entries[num].value;
				}
				ThrowHelper.ThrowKeyNotFoundException();
				return default(TValue);
			}
			[__DynamicallyInvokable]
			set
			{
				this.Insert(key, value, false);
			}
		}

		// Token: 0x06003A45 RID: 14917 RVA: 0x000DE028 File Offset: 0x000DC228
		[__DynamicallyInvokable]
		public void Add(TKey key, TValue value)
		{
			this.Insert(key, value, true);
		}

		// Token: 0x06003A46 RID: 14918 RVA: 0x000DE033 File Offset: 0x000DC233
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			this.Add(keyValuePair.Key, keyValuePair.Value);
		}

		// Token: 0x06003A47 RID: 14919 RVA: 0x000DE04C File Offset: 0x000DC24C
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = this.FindEntry(keyValuePair.Key);
			return num >= 0 && EqualityComparer<TValue>.Default.Equals(this.entries[num].value, keyValuePair.Value);
		}

		// Token: 0x06003A48 RID: 14920 RVA: 0x000DE094 File Offset: 0x000DC294
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			int num = this.FindEntry(keyValuePair.Key);
			if (num >= 0 && EqualityComparer<TValue>.Default.Equals(this.entries[num].value, keyValuePair.Value))
			{
				this.Remove(keyValuePair.Key);
				return true;
			}
			return false;
		}

		// Token: 0x06003A49 RID: 14921 RVA: 0x000DE0E8 File Offset: 0x000DC2E8
		[__DynamicallyInvokable]
		public void Clear()
		{
			if (this.count > 0)
			{
				for (int i = 0; i < this.buckets.Length; i++)
				{
					this.buckets[i] = -1;
				}
				Array.Clear(this.entries, 0, this.count);
				this.freeList = -1;
				this.count = 0;
				this.freeCount = 0;
				this.version++;
			}
		}

		// Token: 0x06003A4A RID: 14922 RVA: 0x000DE14F File Offset: 0x000DC34F
		[__DynamicallyInvokable]
		public bool ContainsKey(TKey key)
		{
			return this.FindEntry(key) >= 0;
		}

		// Token: 0x06003A4B RID: 14923 RVA: 0x000DE160 File Offset: 0x000DC360
		[__DynamicallyInvokable]
		public bool ContainsValue(TValue value)
		{
			if (value == null)
			{
				for (int i = 0; i < this.count; i++)
				{
					if (this.entries[i].hashCode >= 0 && this.entries[i].value == null)
					{
						return true;
					}
				}
			}
			else
			{
				EqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
				for (int j = 0; j < this.count; j++)
				{
					if (this.entries[j].hashCode >= 0 && @default.Equals(this.entries[j].value, value))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06003A4C RID: 14924 RVA: 0x000DE200 File Offset: 0x000DC400
		private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
			}
			if (index < 0 || index > array.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			if (array.Length - index < this.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			int num = this.count;
			Dictionary<TKey, TValue>.Entry[] array2 = this.entries;
			for (int i = 0; i < num; i++)
			{
				if (array2[i].hashCode >= 0)
				{
					array[index++] = new KeyValuePair<TKey, TValue>(array2[i].key, array2[i].value);
				}
			}
		}

		// Token: 0x06003A4D RID: 14925 RVA: 0x000DE28D File Offset: 0x000DC48D
		[__DynamicallyInvokable]
		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return new Dictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x06003A4E RID: 14926 RVA: 0x000DE296 File Offset: 0x000DC496
		[__DynamicallyInvokable]
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
		{
			return new Dictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x06003A4F RID: 14927 RVA: 0x000DE2A4 File Offset: 0x000DC4A4
		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.info);
			}
			info.AddValue("Version", this.version);
			info.AddValue("Comparer", HashHelpers.GetEqualityComparerForSerialization(this.comparer), typeof(IEqualityComparer<TKey>));
			info.AddValue("HashSize", (this.buckets == null) ? 0 : this.buckets.Length);
			if (this.buckets != null)
			{
				KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[this.Count];
				this.CopyTo(array, 0);
				info.AddValue("KeyValuePairs", array, typeof(KeyValuePair<TKey, TValue>[]));
			}
		}

		// Token: 0x06003A50 RID: 14928 RVA: 0x000DE33C File Offset: 0x000DC53C
		private int FindEntry(TKey key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.buckets != null)
			{
				int num = this.comparer.GetHashCode(key) & int.MaxValue;
				for (int i = this.buckets[num % this.buckets.Length]; i >= 0; i = this.entries[i].next)
				{
					if (this.entries[i].hashCode == num && this.comparer.Equals(this.entries[i].key, key))
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x06003A51 RID: 14929 RVA: 0x000DE3D4 File Offset: 0x000DC5D4
		private void Initialize(int capacity)
		{
			int prime = HashHelpers.GetPrime(capacity);
			this.buckets = new int[prime];
			for (int i = 0; i < this.buckets.Length; i++)
			{
				this.buckets[i] = -1;
			}
			this.entries = new Dictionary<TKey, TValue>.Entry[prime];
			this.freeList = -1;
		}

		// Token: 0x06003A52 RID: 14930 RVA: 0x000DE424 File Offset: 0x000DC624
		private void Insert(TKey key, TValue value, bool add)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.buckets == null)
			{
				this.Initialize(0);
			}
			int num = this.comparer.GetHashCode(key) & int.MaxValue;
			int num2 = num % this.buckets.Length;
			int num3 = 0;
			for (int i = this.buckets[num2]; i >= 0; i = this.entries[i].next)
			{
				if (this.entries[i].hashCode == num && this.comparer.Equals(this.entries[i].key, key))
				{
					if (add)
					{
						ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
					}
					this.entries[i].value = value;
					this.version++;
					return;
				}
				num3++;
			}
			int num4;
			if (this.freeCount > 0)
			{
				num4 = this.freeList;
				this.freeList = this.entries[num4].next;
				this.freeCount--;
			}
			else
			{
				if (this.count == this.entries.Length)
				{
					this.Resize();
					num2 = num % this.buckets.Length;
				}
				num4 = this.count;
				this.count++;
			}
			this.entries[num4].hashCode = num;
			this.entries[num4].next = this.buckets[num2];
			this.entries[num4].key = key;
			this.entries[num4].value = value;
			this.buckets[num2] = num4;
			this.version++;
			if (num3 > 100 && HashHelpers.IsWellKnownEqualityComparer(this.comparer))
			{
				this.comparer = (IEqualityComparer<TKey>)HashHelpers.GetRandomizedEqualityComparer(this.comparer);
				this.Resize(this.entries.Length, true);
			}
		}

		// Token: 0x06003A53 RID: 14931 RVA: 0x000DE604 File Offset: 0x000DC804
		public virtual void OnDeserialization(object sender)
		{
			SerializationInfo serializationInfo;
			HashHelpers.SerializationInfoTable.TryGetValue(this, out serializationInfo);
			if (serializationInfo == null)
			{
				return;
			}
			int @int = serializationInfo.GetInt32("Version");
			int int2 = serializationInfo.GetInt32("HashSize");
			this.comparer = (IEqualityComparer<TKey>)serializationInfo.GetValue("Comparer", typeof(IEqualityComparer<TKey>));
			if (int2 != 0)
			{
				this.buckets = new int[int2];
				for (int i = 0; i < this.buckets.Length; i++)
				{
					this.buckets[i] = -1;
				}
				this.entries = new Dictionary<TKey, TValue>.Entry[int2];
				this.freeList = -1;
				KeyValuePair<TKey, TValue>[] array = (KeyValuePair<TKey, TValue>[])serializationInfo.GetValue("KeyValuePairs", typeof(KeyValuePair<TKey, TValue>[]));
				if (array == null)
				{
					ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_MissingKeys);
				}
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].Key == null)
					{
						ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_NullKey);
					}
					this.Insert(array[j].Key, array[j].Value, true);
				}
			}
			else
			{
				this.buckets = null;
			}
			this.version = @int;
			HashHelpers.SerializationInfoTable.Remove(this);
		}

		// Token: 0x06003A54 RID: 14932 RVA: 0x000DE730 File Offset: 0x000DC930
		private void Resize()
		{
			this.Resize(HashHelpers.ExpandPrime(this.count), false);
		}

		// Token: 0x06003A55 RID: 14933 RVA: 0x000DE744 File Offset: 0x000DC944
		private void Resize(int newSize, bool forceNewHashCodes)
		{
			int[] array = new int[newSize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			Dictionary<TKey, TValue>.Entry[] array2 = new Dictionary<TKey, TValue>.Entry[newSize];
			Array.Copy(this.entries, 0, array2, 0, this.count);
			if (forceNewHashCodes)
			{
				for (int j = 0; j < this.count; j++)
				{
					if (array2[j].hashCode != -1)
					{
						array2[j].hashCode = (this.comparer.GetHashCode(array2[j].key) & int.MaxValue);
					}
				}
			}
			for (int k = 0; k < this.count; k++)
			{
				if (array2[k].hashCode >= 0)
				{
					int num = array2[k].hashCode % newSize;
					array2[k].next = array[num];
					array[num] = k;
				}
			}
			this.buckets = array;
			this.entries = array2;
		}

		// Token: 0x06003A56 RID: 14934 RVA: 0x000DE82C File Offset: 0x000DCA2C
		[__DynamicallyInvokable]
		public bool Remove(TKey key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			if (this.buckets != null)
			{
				int num = this.comparer.GetHashCode(key) & int.MaxValue;
				int num2 = num % this.buckets.Length;
				int num3 = -1;
				for (int i = this.buckets[num2]; i >= 0; i = this.entries[i].next)
				{
					if (this.entries[i].hashCode == num && this.comparer.Equals(this.entries[i].key, key))
					{
						if (num3 < 0)
						{
							this.buckets[num2] = this.entries[i].next;
						}
						else
						{
							this.entries[num3].next = this.entries[i].next;
						}
						this.entries[i].hashCode = -1;
						this.entries[i].next = this.freeList;
						this.entries[i].key = default(TKey);
						this.entries[i].value = default(TValue);
						this.freeList = i;
						this.freeCount++;
						this.version++;
						return true;
					}
					num3 = i;
				}
			}
			return false;
		}

		// Token: 0x06003A57 RID: 14935 RVA: 0x000DE994 File Offset: 0x000DCB94
		[__DynamicallyInvokable]
		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = this.FindEntry(key);
			if (num >= 0)
			{
				value = this.entries[num].value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06003A58 RID: 14936 RVA: 0x000DE9D0 File Offset: 0x000DCBD0
		internal TValue GetValueOrDefault(TKey key)
		{
			int num = this.FindEntry(key);
			if (num >= 0)
			{
				return this.entries[num].value;
			}
			return default(TValue);
		}

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x06003A59 RID: 14937 RVA: 0x000DEA04 File Offset: 0x000DCC04
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x06003A5A RID: 14938 RVA: 0x000DEA07 File Offset: 0x000DCC07
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			this.CopyTo(array, index);
		}

		// Token: 0x06003A5B RID: 14939 RVA: 0x000DEA14 File Offset: 0x000DCC14
		[__DynamicallyInvokable]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
			}
			if (array.Rank != 1)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
			}
			if (array.GetLowerBound(0) != 0)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
			}
			if (index < 0 || index > array.Length)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
			}
			if (array.Length - index < this.Count)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
			}
			KeyValuePair<TKey, TValue>[] array2 = array as KeyValuePair<TKey, TValue>[];
			if (array2 != null)
			{
				this.CopyTo(array2, index);
				return;
			}
			if (array is DictionaryEntry[])
			{
				DictionaryEntry[] array3 = array as DictionaryEntry[];
				Dictionary<TKey, TValue>.Entry[] array4 = this.entries;
				for (int i = 0; i < this.count; i++)
				{
					if (array4[i].hashCode >= 0)
					{
						array3[index++] = new DictionaryEntry(array4[i].key, array4[i].value);
					}
				}
				return;
			}
			object[] array5 = array as object[];
			if (array5 == null)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			try
			{
				int num = this.count;
				Dictionary<TKey, TValue>.Entry[] array6 = this.entries;
				for (int j = 0; j < num; j++)
				{
					if (array6[j].hashCode >= 0)
					{
						array5[index++] = new KeyValuePair<TKey, TValue>(array6[j].key, array6[j].value);
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
		}

		// Token: 0x06003A5C RID: 14940 RVA: 0x000DEB84 File Offset: 0x000DCD84
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Dictionary<TKey, TValue>.Enumerator(this, 2);
		}

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x06003A5D RID: 14941 RVA: 0x000DEB92 File Offset: 0x000DCD92
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x06003A5E RID: 14942 RVA: 0x000DEB95 File Offset: 0x000DCD95
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				if (this._syncRoot == null)
				{
					Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
				}
				return this._syncRoot;
			}
		}

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x06003A5F RID: 14943 RVA: 0x000DEBB7 File Offset: 0x000DCDB7
		[__DynamicallyInvokable]
		bool IDictionary.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x06003A60 RID: 14944 RVA: 0x000DEBBA File Offset: 0x000DCDBA
		[__DynamicallyInvokable]
		bool IDictionary.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x06003A61 RID: 14945 RVA: 0x000DEBBD File Offset: 0x000DCDBD
		[__DynamicallyInvokable]
		ICollection IDictionary.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x06003A62 RID: 14946 RVA: 0x000DEBC5 File Offset: 0x000DCDC5
		[__DynamicallyInvokable]
		ICollection IDictionary.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		// Token: 0x170008DF RID: 2271
		[__DynamicallyInvokable]
		object IDictionary.this[object key]
		{
			[__DynamicallyInvokable]
			get
			{
				if (Dictionary<TKey, TValue>.IsCompatibleKey(key))
				{
					int num = this.FindEntry((TKey)((object)key));
					if (num >= 0)
					{
						return this.entries[num].value;
					}
				}
				return null;
			}
			[__DynamicallyInvokable]
			set
			{
				if (key == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
				}
				ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
				try
				{
					TKey key2 = (TKey)((object)key);
					try
					{
						this[key2] = (TValue)((object)value);
					}
					catch (InvalidCastException)
					{
						ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(TValue));
					}
				}
				catch (InvalidCastException)
				{
					ThrowHelper.ThrowWrongKeyTypeArgumentException(key, typeof(TKey));
				}
			}
		}

		// Token: 0x06003A65 RID: 14949 RVA: 0x000DEC88 File Offset: 0x000DCE88
		private static bool IsCompatibleKey(object key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			return key is TKey;
		}

		// Token: 0x06003A66 RID: 14950 RVA: 0x000DEC9C File Offset: 0x000DCE9C
		[__DynamicallyInvokable]
		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			ThrowHelper.IfNullAndNullsAreIllegalThenThrow<TValue>(value, ExceptionArgument.value);
			try
			{
				TKey key2 = (TKey)((object)key);
				try
				{
					this.Add(key2, (TValue)((object)value));
				}
				catch (InvalidCastException)
				{
					ThrowHelper.ThrowWrongValueTypeArgumentException(value, typeof(TValue));
				}
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowWrongKeyTypeArgumentException(key, typeof(TKey));
			}
		}

		// Token: 0x06003A67 RID: 14951 RVA: 0x000DED14 File Offset: 0x000DCF14
		[__DynamicallyInvokable]
		bool IDictionary.Contains(object key)
		{
			return Dictionary<TKey, TValue>.IsCompatibleKey(key) && this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x06003A68 RID: 14952 RVA: 0x000DED2C File Offset: 0x000DCF2C
		[__DynamicallyInvokable]
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Dictionary<TKey, TValue>.Enumerator(this, 1);
		}

		// Token: 0x06003A69 RID: 14953 RVA: 0x000DED3A File Offset: 0x000DCF3A
		[__DynamicallyInvokable]
		void IDictionary.Remove(object key)
		{
			if (Dictionary<TKey, TValue>.IsCompatibleKey(key))
			{
				this.Remove((TKey)((object)key));
			}
		}

		// Token: 0x0400193B RID: 6459
		private int[] buckets;

		// Token: 0x0400193C RID: 6460
		private Dictionary<TKey, TValue>.Entry[] entries;

		// Token: 0x0400193D RID: 6461
		private int count;

		// Token: 0x0400193E RID: 6462
		private int version;

		// Token: 0x0400193F RID: 6463
		private int freeList;

		// Token: 0x04001940 RID: 6464
		private int freeCount;

		// Token: 0x04001941 RID: 6465
		private IEqualityComparer<TKey> comparer;

		// Token: 0x04001942 RID: 6466
		private Dictionary<TKey, TValue>.KeyCollection keys;

		// Token: 0x04001943 RID: 6467
		private Dictionary<TKey, TValue>.ValueCollection values;

		// Token: 0x04001944 RID: 6468
		private object _syncRoot;

		// Token: 0x04001945 RID: 6469
		private const string VersionName = "Version";

		// Token: 0x04001946 RID: 6470
		private const string HashSizeName = "HashSize";

		// Token: 0x04001947 RID: 6471
		private const string KeyValuePairsName = "KeyValuePairs";

		// Token: 0x04001948 RID: 6472
		private const string ComparerName = "Comparer";

		// Token: 0x02000BDE RID: 3038
		private struct Entry
		{
			// Token: 0x040035E5 RID: 13797
			public int hashCode;

			// Token: 0x040035E6 RID: 13798
			public int next;

			// Token: 0x040035E7 RID: 13799
			public TKey key;

			// Token: 0x040035E8 RID: 13800
			public TValue value;
		}

		// Token: 0x02000BDF RID: 3039
		[__DynamicallyInvokable]
		[Serializable]
		public struct Enumerator : IEnumerator<KeyValuePair<!0, !1>>, IDisposable, IEnumerator, IDictionaryEnumerator
		{
			// Token: 0x06006EFD RID: 28413 RVA: 0x0017E49A File Offset: 0x0017C69A
			internal Enumerator(Dictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				this.dictionary = dictionary;
				this.version = dictionary.version;
				this.index = 0;
				this.getEnumeratorRetType = getEnumeratorRetType;
				this.current = default(KeyValuePair<TKey, TValue>);
			}

			// Token: 0x06006EFE RID: 28414 RVA: 0x0017E4CC File Offset: 0x0017C6CC
			[__DynamicallyInvokable]
			public bool MoveNext()
			{
				if (this.version != this.dictionary.version)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
				}
				while (this.index < this.dictionary.count)
				{
					if (this.dictionary.entries[this.index].hashCode >= 0)
					{
						this.current = new KeyValuePair<TKey, TValue>(this.dictionary.entries[this.index].key, this.dictionary.entries[this.index].value);
						this.index++;
						return true;
					}
					this.index++;
				}
				this.index = this.dictionary.count + 1;
				this.current = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			// Token: 0x17001309 RID: 4873
			// (get) Token: 0x06006EFF RID: 28415 RVA: 0x0017E5AB File Offset: 0x0017C7AB
			[__DynamicallyInvokable]
			public KeyValuePair<TKey, TValue> Current
			{
				[__DynamicallyInvokable]
				get
				{
					return this.current;
				}
			}

			// Token: 0x06006F00 RID: 28416 RVA: 0x0017E5B3 File Offset: 0x0017C7B3
			[__DynamicallyInvokable]
			public void Dispose()
			{
			}

			// Token: 0x1700130A RID: 4874
			// (get) Token: 0x06006F01 RID: 28417 RVA: 0x0017E5B8 File Offset: 0x0017C7B8
			[__DynamicallyInvokable]
			object IEnumerator.Current
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.index == 0 || this.index == this.dictionary.count + 1)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
					}
					if (this.getEnumeratorRetType == 1)
					{
						return new DictionaryEntry(this.current.Key, this.current.Value);
					}
					return new KeyValuePair<TKey, TValue>(this.current.Key, this.current.Value);
				}
			}

			// Token: 0x06006F02 RID: 28418 RVA: 0x0017E63D File Offset: 0x0017C83D
			[__DynamicallyInvokable]
			void IEnumerator.Reset()
			{
				if (this.version != this.dictionary.version)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
				}
				this.index = 0;
				this.current = default(KeyValuePair<TKey, TValue>);
			}

			// Token: 0x1700130B RID: 4875
			// (get) Token: 0x06006F03 RID: 28419 RVA: 0x0017E66C File Offset: 0x0017C86C
			[__DynamicallyInvokable]
			DictionaryEntry IDictionaryEnumerator.Entry
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.index == 0 || this.index == this.dictionary.count + 1)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
					}
					return new DictionaryEntry(this.current.Key, this.current.Value);
				}
			}

			// Token: 0x1700130C RID: 4876
			// (get) Token: 0x06006F04 RID: 28420 RVA: 0x0017E6C2 File Offset: 0x0017C8C2
			[__DynamicallyInvokable]
			object IDictionaryEnumerator.Key
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.index == 0 || this.index == this.dictionary.count + 1)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
					}
					return this.current.Key;
				}
			}

			// Token: 0x1700130D RID: 4877
			// (get) Token: 0x06006F05 RID: 28421 RVA: 0x0017E6F8 File Offset: 0x0017C8F8
			[__DynamicallyInvokable]
			object IDictionaryEnumerator.Value
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.index == 0 || this.index == this.dictionary.count + 1)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
					}
					return this.current.Value;
				}
			}

			// Token: 0x040035E9 RID: 13801
			private Dictionary<TKey, TValue> dictionary;

			// Token: 0x040035EA RID: 13802
			private int version;

			// Token: 0x040035EB RID: 13803
			private int index;

			// Token: 0x040035EC RID: 13804
			private KeyValuePair<TKey, TValue> current;

			// Token: 0x040035ED RID: 13805
			private int getEnumeratorRetType;

			// Token: 0x040035EE RID: 13806
			internal const int DictEntry = 1;

			// Token: 0x040035EF RID: 13807
			internal const int KeyValuePair = 2;
		}

		// Token: 0x02000BE0 RID: 3040
		[DebuggerTypeProxy(typeof(Mscorlib_DictionaryKeyCollectionDebugView<, >))]
		[DebuggerDisplay("Count = {Count}")]
		[__DynamicallyInvokable]
		[Serializable]
		public sealed class KeyCollection : ICollection<!0>, IEnumerable<!0>, IEnumerable, ICollection, IReadOnlyCollection<TKey>
		{
			// Token: 0x06006F06 RID: 28422 RVA: 0x0017E72E File Offset: 0x0017C92E
			[__DynamicallyInvokable]
			public KeyCollection(Dictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
				}
				this.dictionary = dictionary;
			}

			// Token: 0x06006F07 RID: 28423 RVA: 0x0017E746 File Offset: 0x0017C946
			[__DynamicallyInvokable]
			public Dictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator()
			{
				return new Dictionary<TKey, TValue>.KeyCollection.Enumerator(this.dictionary);
			}

			// Token: 0x06006F08 RID: 28424 RVA: 0x0017E754 File Offset: 0x0017C954
			[__DynamicallyInvokable]
			public void CopyTo(TKey[] array, int index)
			{
				if (array == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
				}
				if (index < 0 || index > array.Length)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
				}
				if (array.Length - index < this.dictionary.Count)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
				}
				int count = this.dictionary.count;
				Dictionary<TKey, TValue>.Entry[] entries = this.dictionary.entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].key;
					}
				}
			}

			// Token: 0x1700130E RID: 4878
			// (get) Token: 0x06006F09 RID: 28425 RVA: 0x0017E7DF File Offset: 0x0017C9DF
			[__DynamicallyInvokable]
			public int Count
			{
				[__DynamicallyInvokable]
				get
				{
					return this.dictionary.Count;
				}
			}

			// Token: 0x1700130F RID: 4879
			// (get) Token: 0x06006F0A RID: 28426 RVA: 0x0017E7EC File Offset: 0x0017C9EC
			[__DynamicallyInvokable]
			bool ICollection<!0>.IsReadOnly
			{
				[__DynamicallyInvokable]
				get
				{
					return true;
				}
			}

			// Token: 0x06006F0B RID: 28427 RVA: 0x0017E7EF File Offset: 0x0017C9EF
			[__DynamicallyInvokable]
			void ICollection<!0>.Add(TKey item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
			}

			// Token: 0x06006F0C RID: 28428 RVA: 0x0017E7F8 File Offset: 0x0017C9F8
			[__DynamicallyInvokable]
			void ICollection<!0>.Clear()
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
			}

			// Token: 0x06006F0D RID: 28429 RVA: 0x0017E801 File Offset: 0x0017CA01
			[__DynamicallyInvokable]
			bool ICollection<!0>.Contains(TKey item)
			{
				return this.dictionary.ContainsKey(item);
			}

			// Token: 0x06006F0E RID: 28430 RVA: 0x0017E80F File Offset: 0x0017CA0F
			[__DynamicallyInvokable]
			bool ICollection<!0>.Remove(TKey item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_KeyCollectionSet);
				return false;
			}

			// Token: 0x06006F0F RID: 28431 RVA: 0x0017E819 File Offset: 0x0017CA19
			[__DynamicallyInvokable]
			IEnumerator<TKey> IEnumerable<!0>.GetEnumerator()
			{
				return new Dictionary<TKey, TValue>.KeyCollection.Enumerator(this.dictionary);
			}

			// Token: 0x06006F10 RID: 28432 RVA: 0x0017E82B File Offset: 0x0017CA2B
			[__DynamicallyInvokable]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Dictionary<TKey, TValue>.KeyCollection.Enumerator(this.dictionary);
			}

			// Token: 0x06006F11 RID: 28433 RVA: 0x0017E840 File Offset: 0x0017CA40
			[__DynamicallyInvokable]
			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
				}
				if (array.Rank != 1)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
				}
				if (array.GetLowerBound(0) != 0)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
				}
				if (index < 0 || index > array.Length)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
				}
				if (array.Length - index < this.dictionary.Count)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
				}
				TKey[] array2 = array as TKey[];
				if (array2 != null)
				{
					this.CopyTo(array2, index);
					return;
				}
				object[] array3 = array as object[];
				if (array3 == null)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
				}
				int count = this.dictionary.count;
				Dictionary<TKey, TValue>.Entry[] entries = this.dictionary.entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].key;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
				}
			}

			// Token: 0x17001310 RID: 4880
			// (get) Token: 0x06006F12 RID: 28434 RVA: 0x0017E938 File Offset: 0x0017CB38
			[__DynamicallyInvokable]
			bool ICollection.IsSynchronized
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			// Token: 0x17001311 RID: 4881
			// (get) Token: 0x06006F13 RID: 28435 RVA: 0x0017E93B File Offset: 0x0017CB3B
			[__DynamicallyInvokable]
			object ICollection.SyncRoot
			{
				[__DynamicallyInvokable]
				get
				{
					return ((ICollection)this.dictionary).SyncRoot;
				}
			}

			// Token: 0x040035F0 RID: 13808
			private Dictionary<TKey, TValue> dictionary;

			// Token: 0x02000D0A RID: 3338
			[__DynamicallyInvokable]
			[Serializable]
			public struct Enumerator : IEnumerator<!0>, IDisposable, IEnumerator
			{
				// Token: 0x0600720F RID: 29199 RVA: 0x001892B6 File Offset: 0x001874B6
				internal Enumerator(Dictionary<TKey, TValue> dictionary)
				{
					this.dictionary = dictionary;
					this.version = dictionary.version;
					this.index = 0;
					this.currentKey = default(TKey);
				}

				// Token: 0x06007210 RID: 29200 RVA: 0x001892DE File Offset: 0x001874DE
				[__DynamicallyInvokable]
				public void Dispose()
				{
				}

				// Token: 0x06007211 RID: 29201 RVA: 0x001892E0 File Offset: 0x001874E0
				[__DynamicallyInvokable]
				public bool MoveNext()
				{
					if (this.version != this.dictionary.version)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
					}
					while (this.index < this.dictionary.count)
					{
						if (this.dictionary.entries[this.index].hashCode >= 0)
						{
							this.currentKey = this.dictionary.entries[this.index].key;
							this.index++;
							return true;
						}
						this.index++;
					}
					this.index = this.dictionary.count + 1;
					this.currentKey = default(TKey);
					return false;
				}

				// Token: 0x1700138C RID: 5004
				// (get) Token: 0x06007212 RID: 29202 RVA: 0x00189399 File Offset: 0x00187599
				[__DynamicallyInvokable]
				public TKey Current
				{
					[__DynamicallyInvokable]
					get
					{
						return this.currentKey;
					}
				}

				// Token: 0x1700138D RID: 5005
				// (get) Token: 0x06007213 RID: 29203 RVA: 0x001893A1 File Offset: 0x001875A1
				[__DynamicallyInvokable]
				object IEnumerator.Current
				{
					[__DynamicallyInvokable]
					get
					{
						if (this.index == 0 || this.index == this.dictionary.count + 1)
						{
							ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
						}
						return this.currentKey;
					}
				}

				// Token: 0x06007214 RID: 29204 RVA: 0x001893D2 File Offset: 0x001875D2
				[__DynamicallyInvokable]
				void IEnumerator.Reset()
				{
					if (this.version != this.dictionary.version)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
					}
					this.index = 0;
					this.currentKey = default(TKey);
				}

				// Token: 0x04003950 RID: 14672
				private Dictionary<TKey, TValue> dictionary;

				// Token: 0x04003951 RID: 14673
				private int index;

				// Token: 0x04003952 RID: 14674
				private int version;

				// Token: 0x04003953 RID: 14675
				private TKey currentKey;
			}
		}

		// Token: 0x02000BE1 RID: 3041
		[DebuggerTypeProxy(typeof(Mscorlib_DictionaryValueCollectionDebugView<, >))]
		[DebuggerDisplay("Count = {Count}")]
		[__DynamicallyInvokable]
		[Serializable]
		public sealed class ValueCollection : ICollection<!1>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue>
		{
			// Token: 0x06006F14 RID: 28436 RVA: 0x0017E948 File Offset: 0x0017CB48
			[__DynamicallyInvokable]
			public ValueCollection(Dictionary<TKey, TValue> dictionary)
			{
				if (dictionary == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
				}
				this.dictionary = dictionary;
			}

			// Token: 0x06006F15 RID: 28437 RVA: 0x0017E960 File Offset: 0x0017CB60
			[__DynamicallyInvokable]
			public Dictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator()
			{
				return new Dictionary<TKey, TValue>.ValueCollection.Enumerator(this.dictionary);
			}

			// Token: 0x06006F16 RID: 28438 RVA: 0x0017E970 File Offset: 0x0017CB70
			[__DynamicallyInvokable]
			public void CopyTo(TValue[] array, int index)
			{
				if (array == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
				}
				if (index < 0 || index > array.Length)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
				}
				if (array.Length - index < this.dictionary.Count)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
				}
				int count = this.dictionary.count;
				Dictionary<TKey, TValue>.Entry[] entries = this.dictionary.entries;
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array[index++] = entries[i].value;
					}
				}
			}

			// Token: 0x17001312 RID: 4882
			// (get) Token: 0x06006F17 RID: 28439 RVA: 0x0017E9FB File Offset: 0x0017CBFB
			[__DynamicallyInvokable]
			public int Count
			{
				[__DynamicallyInvokable]
				get
				{
					return this.dictionary.Count;
				}
			}

			// Token: 0x17001313 RID: 4883
			// (get) Token: 0x06006F18 RID: 28440 RVA: 0x0017EA08 File Offset: 0x0017CC08
			[__DynamicallyInvokable]
			bool ICollection<!1>.IsReadOnly
			{
				[__DynamicallyInvokable]
				get
				{
					return true;
				}
			}

			// Token: 0x06006F19 RID: 28441 RVA: 0x0017EA0B File Offset: 0x0017CC0B
			[__DynamicallyInvokable]
			void ICollection<!1>.Add(TValue item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
			}

			// Token: 0x06006F1A RID: 28442 RVA: 0x0017EA14 File Offset: 0x0017CC14
			[__DynamicallyInvokable]
			bool ICollection<!1>.Remove(TValue item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
				return false;
			}

			// Token: 0x06006F1B RID: 28443 RVA: 0x0017EA1E File Offset: 0x0017CC1E
			[__DynamicallyInvokable]
			void ICollection<!1>.Clear()
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ValueCollectionSet);
			}

			// Token: 0x06006F1C RID: 28444 RVA: 0x0017EA27 File Offset: 0x0017CC27
			[__DynamicallyInvokable]
			bool ICollection<!1>.Contains(TValue item)
			{
				return this.dictionary.ContainsValue(item);
			}

			// Token: 0x06006F1D RID: 28445 RVA: 0x0017EA35 File Offset: 0x0017CC35
			[__DynamicallyInvokable]
			IEnumerator<TValue> IEnumerable<!1>.GetEnumerator()
			{
				return new Dictionary<TKey, TValue>.ValueCollection.Enumerator(this.dictionary);
			}

			// Token: 0x06006F1E RID: 28446 RVA: 0x0017EA47 File Offset: 0x0017CC47
			[__DynamicallyInvokable]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new Dictionary<TKey, TValue>.ValueCollection.Enumerator(this.dictionary);
			}

			// Token: 0x06006F1F RID: 28447 RVA: 0x0017EA5C File Offset: 0x0017CC5C
			[__DynamicallyInvokable]
			void ICollection.CopyTo(Array array, int index)
			{
				if (array == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
				}
				if (array.Rank != 1)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
				}
				if (array.GetLowerBound(0) != 0)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NonZeroLowerBound);
				}
				if (index < 0 || index > array.Length)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
				}
				if (array.Length - index < this.dictionary.Count)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
				}
				TValue[] array2 = array as TValue[];
				if (array2 != null)
				{
					this.CopyTo(array2, index);
					return;
				}
				object[] array3 = array as object[];
				if (array3 == null)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
				}
				int count = this.dictionary.count;
				Dictionary<TKey, TValue>.Entry[] entries = this.dictionary.entries;
				try
				{
					for (int i = 0; i < count; i++)
					{
						if (entries[i].hashCode >= 0)
						{
							array3[index++] = entries[i].value;
						}
					}
				}
				catch (ArrayTypeMismatchException)
				{
					ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
				}
			}

			// Token: 0x17001314 RID: 4884
			// (get) Token: 0x06006F20 RID: 28448 RVA: 0x0017EB54 File Offset: 0x0017CD54
			[__DynamicallyInvokable]
			bool ICollection.IsSynchronized
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			// Token: 0x17001315 RID: 4885
			// (get) Token: 0x06006F21 RID: 28449 RVA: 0x0017EB57 File Offset: 0x0017CD57
			[__DynamicallyInvokable]
			object ICollection.SyncRoot
			{
				[__DynamicallyInvokable]
				get
				{
					return ((ICollection)this.dictionary).SyncRoot;
				}
			}

			// Token: 0x040035F1 RID: 13809
			private Dictionary<TKey, TValue> dictionary;

			// Token: 0x02000D0B RID: 3339
			[__DynamicallyInvokable]
			[Serializable]
			public struct Enumerator : IEnumerator<TValue>, IDisposable, IEnumerator
			{
				// Token: 0x06007215 RID: 29205 RVA: 0x00189401 File Offset: 0x00187601
				internal Enumerator(Dictionary<TKey, TValue> dictionary)
				{
					this.dictionary = dictionary;
					this.version = dictionary.version;
					this.index = 0;
					this.currentValue = default(TValue);
				}

				// Token: 0x06007216 RID: 29206 RVA: 0x00189429 File Offset: 0x00187629
				[__DynamicallyInvokable]
				public void Dispose()
				{
				}

				// Token: 0x06007217 RID: 29207 RVA: 0x0018942C File Offset: 0x0018762C
				[__DynamicallyInvokable]
				public bool MoveNext()
				{
					if (this.version != this.dictionary.version)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
					}
					while (this.index < this.dictionary.count)
					{
						if (this.dictionary.entries[this.index].hashCode >= 0)
						{
							this.currentValue = this.dictionary.entries[this.index].value;
							this.index++;
							return true;
						}
						this.index++;
					}
					this.index = this.dictionary.count + 1;
					this.currentValue = default(TValue);
					return false;
				}

				// Token: 0x1700138E RID: 5006
				// (get) Token: 0x06007218 RID: 29208 RVA: 0x001894E5 File Offset: 0x001876E5
				[__DynamicallyInvokable]
				public TValue Current
				{
					[__DynamicallyInvokable]
					get
					{
						return this.currentValue;
					}
				}

				// Token: 0x1700138F RID: 5007
				// (get) Token: 0x06007219 RID: 29209 RVA: 0x001894ED File Offset: 0x001876ED
				[__DynamicallyInvokable]
				object IEnumerator.Current
				{
					[__DynamicallyInvokable]
					get
					{
						if (this.index == 0 || this.index == this.dictionary.count + 1)
						{
							ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
						}
						return this.currentValue;
					}
				}

				// Token: 0x0600721A RID: 29210 RVA: 0x0018951E File Offset: 0x0018771E
				[__DynamicallyInvokable]
				void IEnumerator.Reset()
				{
					if (this.version != this.dictionary.version)
					{
						ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
					}
					this.index = 0;
					this.currentValue = default(TValue);
				}

				// Token: 0x04003954 RID: 14676
				private Dictionary<TKey, TValue> dictionary;

				// Token: 0x04003955 RID: 14677
				private int index;

				// Token: 0x04003956 RID: 14678
				private int version;

				// Token: 0x04003957 RID: 14679
				private TValue currentValue;
			}
		}
	}
}
