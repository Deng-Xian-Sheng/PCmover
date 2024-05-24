using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace System.Collections.ObjectModel
{
	// Token: 0x020004B6 RID: 1206
	[DebuggerTypeProxy(typeof(Mscorlib_DictionaryDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[Serializable]
	public class ReadOnlyDictionary<TKey, TValue> : IDictionary<!0, !1>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<!0, !1>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x060039E5 RID: 14821 RVA: 0x000DD240 File Offset: 0x000DB440
		[__DynamicallyInvokable]
		public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.m_dictionary = dictionary;
		}

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x060039E6 RID: 14822 RVA: 0x000DD25D File Offset: 0x000DB45D
		[__DynamicallyInvokable]
		protected IDictionary<TKey, TValue> Dictionary
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary;
			}
		}

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x060039E7 RID: 14823 RVA: 0x000DD265 File Offset: 0x000DB465
		[__DynamicallyInvokable]
		public ReadOnlyDictionary<TKey, TValue>.KeyCollection Keys
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_keys == null)
				{
					this.m_keys = new ReadOnlyDictionary<TKey, TValue>.KeyCollection(this.m_dictionary.Keys);
				}
				return this.m_keys;
			}
		}

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x060039E8 RID: 14824 RVA: 0x000DD28B File Offset: 0x000DB48B
		[__DynamicallyInvokable]
		public ReadOnlyDictionary<TKey, TValue>.ValueCollection Values
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_values == null)
				{
					this.m_values = new ReadOnlyDictionary<TKey, TValue>.ValueCollection(this.m_dictionary.Values);
				}
				return this.m_values;
			}
		}

		// Token: 0x060039E9 RID: 14825 RVA: 0x000DD2B1 File Offset: 0x000DB4B1
		[__DynamicallyInvokable]
		public bool ContainsKey(TKey key)
		{
			return this.m_dictionary.ContainsKey(key);
		}

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x060039EA RID: 14826 RVA: 0x000DD2BF File Offset: 0x000DB4BF
		[__DynamicallyInvokable]
		ICollection<TKey> IDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x060039EB RID: 14827 RVA: 0x000DD2C7 File Offset: 0x000DB4C7
		[__DynamicallyInvokable]
		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.m_dictionary.TryGetValue(key, out value);
		}

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x060039EC RID: 14828 RVA: 0x000DD2D6 File Offset: 0x000DB4D6
		[__DynamicallyInvokable]
		ICollection<TValue> IDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		// Token: 0x170008BE RID: 2238
		[__DynamicallyInvokable]
		public TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary[key];
			}
		}

		// Token: 0x060039EE RID: 14830 RVA: 0x000DD2EC File Offset: 0x000DB4EC
		[__DynamicallyInvokable]
		void IDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039EF RID: 14831 RVA: 0x000DD2F5 File Offset: 0x000DB4F5
		[__DynamicallyInvokable]
		bool IDictionary<!0, !1>.Remove(TKey key)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return false;
		}

		// Token: 0x170008BF RID: 2239
		[__DynamicallyInvokable]
		TValue IDictionary<!0, !1>.this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary[key];
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x060039F2 RID: 14834 RVA: 0x000DD316 File Offset: 0x000DB516
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_dictionary.Count;
			}
		}

		// Token: 0x060039F3 RID: 14835 RVA: 0x000DD323 File Offset: 0x000DB523
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return this.m_dictionary.Contains(item);
		}

		// Token: 0x060039F4 RID: 14836 RVA: 0x000DD331 File Offset: 0x000DB531
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this.m_dictionary.CopyTo(array, arrayIndex);
		}

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x060039F5 RID: 14837 RVA: 0x000DD340 File Offset: 0x000DB540
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x060039F6 RID: 14838 RVA: 0x000DD343 File Offset: 0x000DB543
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039F7 RID: 14839 RVA: 0x000DD34C File Offset: 0x000DB54C
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039F8 RID: 14840 RVA: 0x000DD355 File Offset: 0x000DB555
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			return false;
		}

		// Token: 0x060039F9 RID: 14841 RVA: 0x000DD35F File Offset: 0x000DB55F
		[__DynamicallyInvokable]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.m_dictionary.GetEnumerator();
		}

		// Token: 0x060039FA RID: 14842 RVA: 0x000DD36C File Offset: 0x000DB56C
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_dictionary.GetEnumerator();
		}

		// Token: 0x060039FB RID: 14843 RVA: 0x000DD379 File Offset: 0x000DB579
		private static bool IsCompatibleKey(object key)
		{
			if (key == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
			}
			return key is TKey;
		}

		// Token: 0x060039FC RID: 14844 RVA: 0x000DD38D File Offset: 0x000DB58D
		[__DynamicallyInvokable]
		void IDictionary.Add(object key, object value)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039FD RID: 14845 RVA: 0x000DD396 File Offset: 0x000DB596
		[__DynamicallyInvokable]
		void IDictionary.Clear()
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x060039FE RID: 14846 RVA: 0x000DD39F File Offset: 0x000DB59F
		[__DynamicallyInvokable]
		bool IDictionary.Contains(object key)
		{
			return ReadOnlyDictionary<TKey, TValue>.IsCompatibleKey(key) && this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x060039FF RID: 14847 RVA: 0x000DD3B8 File Offset: 0x000DB5B8
		[__DynamicallyInvokable]
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			IDictionary dictionary = this.m_dictionary as IDictionary;
			if (dictionary != null)
			{
				return dictionary.GetEnumerator();
			}
			return new ReadOnlyDictionary<TKey, TValue>.DictionaryEnumerator(this.m_dictionary);
		}

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x06003A00 RID: 14848 RVA: 0x000DD3EB File Offset: 0x000DB5EB
		[__DynamicallyInvokable]
		bool IDictionary.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x06003A01 RID: 14849 RVA: 0x000DD3EE File Offset: 0x000DB5EE
		[__DynamicallyInvokable]
		bool IDictionary.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x06003A02 RID: 14850 RVA: 0x000DD3F1 File Offset: 0x000DB5F1
		[__DynamicallyInvokable]
		ICollection IDictionary.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x06003A03 RID: 14851 RVA: 0x000DD3F9 File Offset: 0x000DB5F9
		[__DynamicallyInvokable]
		void IDictionary.Remove(object key)
		{
			ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x06003A04 RID: 14852 RVA: 0x000DD402 File Offset: 0x000DB602
		[__DynamicallyInvokable]
		ICollection IDictionary.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		// Token: 0x170008C6 RID: 2246
		[__DynamicallyInvokable]
		object IDictionary.this[object key]
		{
			[__DynamicallyInvokable]
			get
			{
				if (ReadOnlyDictionary<TKey, TValue>.IsCompatibleKey(key))
				{
					return this[(TKey)((object)key)];
				}
				return null;
			}
			[__DynamicallyInvokable]
			set
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}
		}

		// Token: 0x06003A07 RID: 14855 RVA: 0x000DD430 File Offset: 0x000DB630
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
				this.m_dictionary.CopyTo(array2, index);
				return;
			}
			DictionaryEntry[] array3 = array as DictionaryEntry[];
			if (array3 != null)
			{
				using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = this.m_dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<TKey, TValue> keyValuePair = enumerator.Current;
						array3[index++] = new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
					}
					return;
				}
			}
			object[] array4 = array as object[];
			if (array4 == null)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
			try
			{
				foreach (KeyValuePair<TKey, TValue> keyValuePair2 in this.m_dictionary)
				{
					array4[index++] = new KeyValuePair<TKey, TValue>(keyValuePair2.Key, keyValuePair2.Value);
				}
			}
			catch (ArrayTypeMismatchException)
			{
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			}
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x06003A08 RID: 14856 RVA: 0x000DD59C File Offset: 0x000DB79C
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x06003A09 RID: 14857 RVA: 0x000DD5A0 File Offset: 0x000DB7A0
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_syncRoot == null)
				{
					ICollection collection = this.m_dictionary as ICollection;
					if (collection != null)
					{
						this.m_syncRoot = collection.SyncRoot;
					}
					else
					{
						Interlocked.CompareExchange<object>(ref this.m_syncRoot, new object(), null);
					}
				}
				return this.m_syncRoot;
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x06003A0A RID: 14858 RVA: 0x000DD5EA File Offset: 0x000DB7EA
		[__DynamicallyInvokable]
		IEnumerable<TKey> IReadOnlyDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Keys;
			}
		}

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x06003A0B RID: 14859 RVA: 0x000DD5F2 File Offset: 0x000DB7F2
		[__DynamicallyInvokable]
		IEnumerable<TValue> IReadOnlyDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.Values;
			}
		}

		// Token: 0x04001930 RID: 6448
		private readonly IDictionary<TKey, TValue> m_dictionary;

		// Token: 0x04001931 RID: 6449
		[NonSerialized]
		private object m_syncRoot;

		// Token: 0x04001932 RID: 6450
		[NonSerialized]
		private ReadOnlyDictionary<TKey, TValue>.KeyCollection m_keys;

		// Token: 0x04001933 RID: 6451
		[NonSerialized]
		private ReadOnlyDictionary<TKey, TValue>.ValueCollection m_values;

		// Token: 0x02000BDB RID: 3035
		[Serializable]
		private struct DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06006EDC RID: 28380 RVA: 0x0017E213 File Offset: 0x0017C413
			public DictionaryEnumerator(IDictionary<TKey, TValue> dictionary)
			{
				this.m_dictionary = dictionary;
				this.m_enumerator = this.m_dictionary.GetEnumerator();
			}

			// Token: 0x170012FD RID: 4861
			// (get) Token: 0x06006EDD RID: 28381 RVA: 0x0017E230 File Offset: 0x0017C430
			public DictionaryEntry Entry
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					object key = keyValuePair.Key;
					keyValuePair = this.m_enumerator.Current;
					return new DictionaryEntry(key, keyValuePair.Value);
				}
			}

			// Token: 0x170012FE RID: 4862
			// (get) Token: 0x06006EDE RID: 28382 RVA: 0x0017E274 File Offset: 0x0017C474
			public object Key
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					return keyValuePair.Key;
				}
			}

			// Token: 0x170012FF RID: 4863
			// (get) Token: 0x06006EDF RID: 28383 RVA: 0x0017E29C File Offset: 0x0017C49C
			public object Value
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x17001300 RID: 4864
			// (get) Token: 0x06006EE0 RID: 28384 RVA: 0x0017E2C1 File Offset: 0x0017C4C1
			public object Current
			{
				get
				{
					return this.Entry;
				}
			}

			// Token: 0x06006EE1 RID: 28385 RVA: 0x0017E2CE File Offset: 0x0017C4CE
			public bool MoveNext()
			{
				return this.m_enumerator.MoveNext();
			}

			// Token: 0x06006EE2 RID: 28386 RVA: 0x0017E2DB File Offset: 0x0017C4DB
			public void Reset()
			{
				this.m_enumerator.Reset();
			}

			// Token: 0x040035DF RID: 13791
			private readonly IDictionary<TKey, TValue> m_dictionary;

			// Token: 0x040035E0 RID: 13792
			private IEnumerator<KeyValuePair<TKey, TValue>> m_enumerator;
		}

		// Token: 0x02000BDC RID: 3036
		[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
		[DebuggerDisplay("Count = {Count}")]
		[__DynamicallyInvokable]
		[Serializable]
		public sealed class KeyCollection : ICollection<!0>, IEnumerable<!0>, IEnumerable, ICollection, IReadOnlyCollection<TKey>
		{
			// Token: 0x06006EE3 RID: 28387 RVA: 0x0017E2E8 File Offset: 0x0017C4E8
			internal KeyCollection(ICollection<TKey> collection)
			{
				if (collection == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
				}
				this.m_collection = collection;
			}

			// Token: 0x06006EE4 RID: 28388 RVA: 0x0017E300 File Offset: 0x0017C500
			[__DynamicallyInvokable]
			void ICollection<!0>.Add(TKey item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006EE5 RID: 28389 RVA: 0x0017E309 File Offset: 0x0017C509
			[__DynamicallyInvokable]
			void ICollection<!0>.Clear()
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006EE6 RID: 28390 RVA: 0x0017E312 File Offset: 0x0017C512
			[__DynamicallyInvokable]
			bool ICollection<!0>.Contains(TKey item)
			{
				return this.m_collection.Contains(item);
			}

			// Token: 0x06006EE7 RID: 28391 RVA: 0x0017E320 File Offset: 0x0017C520
			[__DynamicallyInvokable]
			public void CopyTo(TKey[] array, int arrayIndex)
			{
				this.m_collection.CopyTo(array, arrayIndex);
			}

			// Token: 0x17001301 RID: 4865
			// (get) Token: 0x06006EE8 RID: 28392 RVA: 0x0017E32F File Offset: 0x0017C52F
			[__DynamicallyInvokable]
			public int Count
			{
				[__DynamicallyInvokable]
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x17001302 RID: 4866
			// (get) Token: 0x06006EE9 RID: 28393 RVA: 0x0017E33C File Offset: 0x0017C53C
			[__DynamicallyInvokable]
			bool ICollection<!0>.IsReadOnly
			{
				[__DynamicallyInvokable]
				get
				{
					return true;
				}
			}

			// Token: 0x06006EEA RID: 28394 RVA: 0x0017E33F File Offset: 0x0017C53F
			[__DynamicallyInvokable]
			bool ICollection<!0>.Remove(TKey item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
				return false;
			}

			// Token: 0x06006EEB RID: 28395 RVA: 0x0017E349 File Offset: 0x0017C549
			[__DynamicallyInvokable]
			public IEnumerator<TKey> GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x06006EEC RID: 28396 RVA: 0x0017E356 File Offset: 0x0017C556
			[__DynamicallyInvokable]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x06006EED RID: 28397 RVA: 0x0017E363 File Offset: 0x0017C563
			[__DynamicallyInvokable]
			void ICollection.CopyTo(Array array, int index)
			{
				ReadOnlyDictionaryHelpers.CopyToNonGenericICollectionHelper<TKey>(this.m_collection, array, index);
			}

			// Token: 0x17001303 RID: 4867
			// (get) Token: 0x06006EEE RID: 28398 RVA: 0x0017E372 File Offset: 0x0017C572
			[__DynamicallyInvokable]
			bool ICollection.IsSynchronized
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			// Token: 0x17001304 RID: 4868
			// (get) Token: 0x06006EEF RID: 28399 RVA: 0x0017E378 File Offset: 0x0017C578
			[__DynamicallyInvokable]
			object ICollection.SyncRoot
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.m_syncRoot == null)
					{
						ICollection collection = this.m_collection as ICollection;
						if (collection != null)
						{
							this.m_syncRoot = collection.SyncRoot;
						}
						else
						{
							Interlocked.CompareExchange<object>(ref this.m_syncRoot, new object(), null);
						}
					}
					return this.m_syncRoot;
				}
			}

			// Token: 0x040035E1 RID: 13793
			private readonly ICollection<TKey> m_collection;

			// Token: 0x040035E2 RID: 13794
			[NonSerialized]
			private object m_syncRoot;
		}

		// Token: 0x02000BDD RID: 3037
		[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
		[DebuggerDisplay("Count = {Count}")]
		[__DynamicallyInvokable]
		[Serializable]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue>
		{
			// Token: 0x06006EF0 RID: 28400 RVA: 0x0017E3C2 File Offset: 0x0017C5C2
			internal ValueCollection(ICollection<TValue> collection)
			{
				if (collection == null)
				{
					ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
				}
				this.m_collection = collection;
			}

			// Token: 0x06006EF1 RID: 28401 RVA: 0x0017E3DA File Offset: 0x0017C5DA
			[__DynamicallyInvokable]
			void ICollection<!1>.Add(TValue item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006EF2 RID: 28402 RVA: 0x0017E3E3 File Offset: 0x0017C5E3
			[__DynamicallyInvokable]
			void ICollection<!1>.Clear()
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
			}

			// Token: 0x06006EF3 RID: 28403 RVA: 0x0017E3EC File Offset: 0x0017C5EC
			[__DynamicallyInvokable]
			bool ICollection<!1>.Contains(TValue item)
			{
				return this.m_collection.Contains(item);
			}

			// Token: 0x06006EF4 RID: 28404 RVA: 0x0017E3FA File Offset: 0x0017C5FA
			[__DynamicallyInvokable]
			public void CopyTo(TValue[] array, int arrayIndex)
			{
				this.m_collection.CopyTo(array, arrayIndex);
			}

			// Token: 0x17001305 RID: 4869
			// (get) Token: 0x06006EF5 RID: 28405 RVA: 0x0017E409 File Offset: 0x0017C609
			[__DynamicallyInvokable]
			public int Count
			{
				[__DynamicallyInvokable]
				get
				{
					return this.m_collection.Count;
				}
			}

			// Token: 0x17001306 RID: 4870
			// (get) Token: 0x06006EF6 RID: 28406 RVA: 0x0017E416 File Offset: 0x0017C616
			[__DynamicallyInvokable]
			bool ICollection<!1>.IsReadOnly
			{
				[__DynamicallyInvokable]
				get
				{
					return true;
				}
			}

			// Token: 0x06006EF7 RID: 28407 RVA: 0x0017E419 File Offset: 0x0017C619
			[__DynamicallyInvokable]
			bool ICollection<!1>.Remove(TValue item)
			{
				ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
				return false;
			}

			// Token: 0x06006EF8 RID: 28408 RVA: 0x0017E423 File Offset: 0x0017C623
			[__DynamicallyInvokable]
			public IEnumerator<TValue> GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x06006EF9 RID: 28409 RVA: 0x0017E430 File Offset: 0x0017C630
			[__DynamicallyInvokable]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.m_collection.GetEnumerator();
			}

			// Token: 0x06006EFA RID: 28410 RVA: 0x0017E43D File Offset: 0x0017C63D
			[__DynamicallyInvokable]
			void ICollection.CopyTo(Array array, int index)
			{
				ReadOnlyDictionaryHelpers.CopyToNonGenericICollectionHelper<TValue>(this.m_collection, array, index);
			}

			// Token: 0x17001307 RID: 4871
			// (get) Token: 0x06006EFB RID: 28411 RVA: 0x0017E44C File Offset: 0x0017C64C
			[__DynamicallyInvokable]
			bool ICollection.IsSynchronized
			{
				[__DynamicallyInvokable]
				get
				{
					return false;
				}
			}

			// Token: 0x17001308 RID: 4872
			// (get) Token: 0x06006EFC RID: 28412 RVA: 0x0017E450 File Offset: 0x0017C650
			[__DynamicallyInvokable]
			object ICollection.SyncRoot
			{
				[__DynamicallyInvokable]
				get
				{
					if (this.m_syncRoot == null)
					{
						ICollection collection = this.m_collection as ICollection;
						if (collection != null)
						{
							this.m_syncRoot = collection.SyncRoot;
						}
						else
						{
							Interlocked.CompareExchange<object>(ref this.m_syncRoot, new object(), null);
						}
					}
					return this.m_syncRoot;
				}
			}

			// Token: 0x040035E3 RID: 13795
			private readonly ICollection<TValue> m_collection;

			// Token: 0x040035E4 RID: 13796
			[NonSerialized]
			private object m_syncRoot;
		}
	}
}
