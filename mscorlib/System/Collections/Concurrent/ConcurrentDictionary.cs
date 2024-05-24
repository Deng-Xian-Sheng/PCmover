﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections.Concurrent
{
	// Token: 0x020004AD RID: 1197
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(Mscorlib_DictionaryDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	[Serializable]
	public class ConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x0600392A RID: 14634 RVA: 0x000DAB74 File Offset: 0x000D8D74
		private static bool IsValueWriteAtomic()
		{
			Type typeFromHandle = typeof(TValue);
			if (typeFromHandle.IsClass)
			{
				return true;
			}
			switch (Type.GetTypeCode(typeFromHandle))
			{
			case TypeCode.Boolean:
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Single:
				return true;
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Double:
				return IntPtr.Size == 8;
			default:
				return false;
			}
		}

		// Token: 0x0600392B RID: 14635 RVA: 0x000DABE3 File Offset: 0x000D8DE3
		[__DynamicallyInvokable]
		public ConcurrentDictionary() : this(ConcurrentDictionary<TKey, TValue>.DefaultConcurrencyLevel, 31, true, EqualityComparer<TKey>.Default)
		{
		}

		// Token: 0x0600392C RID: 14636 RVA: 0x000DABF8 File Offset: 0x000D8DF8
		[__DynamicallyInvokable]
		public ConcurrentDictionary(int concurrencyLevel, int capacity) : this(concurrencyLevel, capacity, false, EqualityComparer<TKey>.Default)
		{
		}

		// Token: 0x0600392D RID: 14637 RVA: 0x000DAC08 File Offset: 0x000D8E08
		[__DynamicallyInvokable]
		public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : this(collection, EqualityComparer<TKey>.Default)
		{
		}

		// Token: 0x0600392E RID: 14638 RVA: 0x000DAC16 File Offset: 0x000D8E16
		[__DynamicallyInvokable]
		public ConcurrentDictionary(IEqualityComparer<TKey> comparer) : this(ConcurrentDictionary<TKey, TValue>.DefaultConcurrencyLevel, 31, true, comparer)
		{
		}

		// Token: 0x0600392F RID: 14639 RVA: 0x000DAC27 File Offset: 0x000D8E27
		[__DynamicallyInvokable]
		public ConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : this(comparer)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			this.InitializeFromCollection(collection);
		}

		// Token: 0x06003930 RID: 14640 RVA: 0x000DAC45 File Offset: 0x000D8E45
		[__DynamicallyInvokable]
		public ConcurrentDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : this(concurrencyLevel, 31, false, comparer)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			this.InitializeFromCollection(collection);
		}

		// Token: 0x06003931 RID: 14641 RVA: 0x000DAC78 File Offset: 0x000D8E78
		private void InitializeFromCollection(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		{
			foreach (KeyValuePair<TKey, TValue> keyValuePair in collection)
			{
				if (keyValuePair.Key == null)
				{
					throw new ArgumentNullException("key");
				}
				TValue tvalue;
				if (!this.TryAddInternal(keyValuePair.Key, keyValuePair.Value, false, false, out tvalue))
				{
					throw new ArgumentException(this.GetResource("ConcurrentDictionary_SourceContainsDuplicateKeys"));
				}
			}
			if (this.m_budget == 0)
			{
				this.m_budget = this.m_tables.m_buckets.Length / this.m_tables.m_locks.Length;
			}
		}

		// Token: 0x06003932 RID: 14642 RVA: 0x000DAD2C File Offset: 0x000D8F2C
		[__DynamicallyInvokable]
		public ConcurrentDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer) : this(concurrencyLevel, capacity, false, comparer)
		{
		}

		// Token: 0x06003933 RID: 14643 RVA: 0x000DAD38 File Offset: 0x000D8F38
		internal ConcurrentDictionary(int concurrencyLevel, int capacity, bool growLockArray, IEqualityComparer<TKey> comparer)
		{
			if (concurrencyLevel < 1)
			{
				throw new ArgumentOutOfRangeException("concurrencyLevel", this.GetResource("ConcurrentDictionary_ConcurrencyLevelMustBePositive"));
			}
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity", this.GetResource("ConcurrentDictionary_CapacityMustNotBeNegative"));
			}
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (capacity < concurrencyLevel)
			{
				capacity = concurrencyLevel;
			}
			object[] array = new object[concurrencyLevel];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new object();
			}
			int[] countPerLock = new int[array.Length];
			ConcurrentDictionary<TKey, TValue>.Node[] array2 = new ConcurrentDictionary<TKey, TValue>.Node[capacity];
			this.m_tables = new ConcurrentDictionary<TKey, TValue>.Tables(array2, array, countPerLock, comparer);
			this.m_growLockArray = growLockArray;
			this.m_budget = array2.Length / array.Length;
		}

		// Token: 0x06003934 RID: 14644 RVA: 0x000DADE8 File Offset: 0x000D8FE8
		[__DynamicallyInvokable]
		public bool TryAdd(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue tvalue;
			return this.TryAddInternal(key, value, false, true, out tvalue);
		}

		// Token: 0x06003935 RID: 14645 RVA: 0x000DAE14 File Offset: 0x000D9014
		[__DynamicallyInvokable]
		public bool ContainsKey(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue tvalue;
			return this.TryGetValue(key, out tvalue);
		}

		// Token: 0x06003936 RID: 14646 RVA: 0x000DAE40 File Offset: 0x000D9040
		[__DynamicallyInvokable]
		public bool TryRemove(TKey key, out TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.TryRemoveInternal(key, out value, false, default(TValue));
		}

		// Token: 0x06003937 RID: 14647 RVA: 0x000DAE74 File Offset: 0x000D9074
		private bool TryRemoveInternal(TKey key, out TValue value, bool matchValue, TValue oldValue)
		{
			for (;;)
			{
				ConcurrentDictionary<TKey, TValue>.Tables tables = this.m_tables;
				IEqualityComparer<TKey> comparer = tables.m_comparer;
				int num;
				int num2;
				this.GetBucketAndLockNo(comparer.GetHashCode(key), out num, out num2, tables.m_buckets.Length, tables.m_locks.Length);
				object obj = tables.m_locks[num2];
				lock (obj)
				{
					if (tables != this.m_tables)
					{
						continue;
					}
					ConcurrentDictionary<TKey, TValue>.Node node = null;
					ConcurrentDictionary<TKey, TValue>.Node node2 = tables.m_buckets[num];
					while (node2 != null)
					{
						if (comparer.Equals(node2.m_key, key))
						{
							if (matchValue && !EqualityComparer<TValue>.Default.Equals(oldValue, node2.m_value))
							{
								value = default(TValue);
								return false;
							}
							if (node == null)
							{
								Volatile.Write<ConcurrentDictionary<TKey, TValue>.Node>(ref tables.m_buckets[num], node2.m_next);
							}
							else
							{
								node.m_next = node2.m_next;
							}
							value = node2.m_value;
							tables.m_countPerLock[num2]--;
							return true;
						}
						else
						{
							node = node2;
							node2 = node2.m_next;
						}
					}
				}
				break;
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06003938 RID: 14648 RVA: 0x000DAFBC File Offset: 0x000D91BC
		[__DynamicallyInvokable]
		public bool TryGetValue(TKey key, out TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			ConcurrentDictionary<TKey, TValue>.Tables tables = this.m_tables;
			IEqualityComparer<TKey> comparer = tables.m_comparer;
			int num;
			int num2;
			this.GetBucketAndLockNo(comparer.GetHashCode(key), out num, out num2, tables.m_buckets.Length, tables.m_locks.Length);
			for (ConcurrentDictionary<TKey, TValue>.Node node = Volatile.Read<ConcurrentDictionary<TKey, TValue>.Node>(ref tables.m_buckets[num]); node != null; node = node.m_next)
			{
				if (comparer.Equals(node.m_key, key))
				{
					value = node.m_value;
					return true;
				}
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06003939 RID: 14649 RVA: 0x000DB058 File Offset: 0x000D9258
		[__DynamicallyInvokable]
		public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			IEqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
			bool result;
			for (;;)
			{
				ConcurrentDictionary<TKey, TValue>.Tables tables = this.m_tables;
				IEqualityComparer<TKey> comparer = tables.m_comparer;
				int hashCode = comparer.GetHashCode(key);
				int num;
				int num2;
				this.GetBucketAndLockNo(hashCode, out num, out num2, tables.m_buckets.Length, tables.m_locks.Length);
				object obj = tables.m_locks[num2];
				lock (obj)
				{
					if (tables != this.m_tables)
					{
						continue;
					}
					ConcurrentDictionary<TKey, TValue>.Node node = null;
					ConcurrentDictionary<TKey, TValue>.Node node2 = tables.m_buckets[num];
					while (node2 != null)
					{
						if (comparer.Equals(node2.m_key, key))
						{
							if (@default.Equals(node2.m_value, comparisonValue))
							{
								if (ConcurrentDictionary<TKey, TValue>.s_isValueWriteAtomic)
								{
									node2.m_value = newValue;
								}
								else
								{
									ConcurrentDictionary<TKey, TValue>.Node node3 = new ConcurrentDictionary<TKey, TValue>.Node(node2.m_key, newValue, hashCode, node2.m_next);
									if (node == null)
									{
										tables.m_buckets[num] = node3;
									}
									else
									{
										node.m_next = node3;
									}
								}
								return true;
							}
							return false;
						}
						else
						{
							node = node2;
							node2 = node2.m_next;
						}
					}
					result = false;
				}
				break;
			}
			return result;
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x000DB19C File Offset: 0x000D939C
		[__DynamicallyInvokable]
		public void Clear()
		{
			int toExclusive = 0;
			try
			{
				this.AcquireAllLocks(ref toExclusive);
				ConcurrentDictionary<TKey, TValue>.Tables tables = new ConcurrentDictionary<TKey, TValue>.Tables(new ConcurrentDictionary<TKey, TValue>.Node[31], this.m_tables.m_locks, new int[this.m_tables.m_countPerLock.Length], this.m_tables.m_comparer);
				this.m_tables = tables;
				this.m_budget = Math.Max(1, tables.m_buckets.Length / tables.m_locks.Length);
			}
			finally
			{
				this.ReleaseLocks(0, toExclusive);
			}
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x000DB234 File Offset: 0x000D9434
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", this.GetResource("ConcurrentDictionary_IndexIsNegative"));
			}
			int toExclusive = 0;
			try
			{
				this.AcquireAllLocks(ref toExclusive);
				int num = 0;
				int num2 = 0;
				while (num2 < this.m_tables.m_locks.Length && num >= 0)
				{
					num += this.m_tables.m_countPerLock[num2];
					num2++;
				}
				if (array.Length - num < index || num < 0)
				{
					throw new ArgumentException(this.GetResource("ConcurrentDictionary_ArrayNotLargeEnough"));
				}
				this.CopyToPairs(array, index);
			}
			finally
			{
				this.ReleaseLocks(0, toExclusive);
			}
		}

		// Token: 0x0600393C RID: 14652 RVA: 0x000DB2E8 File Offset: 0x000D94E8
		[__DynamicallyInvokable]
		public KeyValuePair<TKey, TValue>[] ToArray()
		{
			int toExclusive = 0;
			checked
			{
				KeyValuePair<TKey, TValue>[] result;
				try
				{
					this.AcquireAllLocks(ref toExclusive);
					int num = 0;
					for (int i = 0; i < this.m_tables.m_locks.Length; i++)
					{
						num += this.m_tables.m_countPerLock[i];
					}
					if (num == 0)
					{
						result = Array.Empty<KeyValuePair<TKey, TValue>>();
					}
					else
					{
						KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[num];
						this.CopyToPairs(array, 0);
						result = array;
					}
				}
				finally
				{
					this.ReleaseLocks(0, toExclusive);
				}
				return result;
			}
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x000DB36C File Offset: 0x000D956C
		private void CopyToPairs(KeyValuePair<TKey, TValue>[] array, int index)
		{
			foreach (ConcurrentDictionary<TKey, TValue>.Node node in this.m_tables.m_buckets)
			{
				while (node != null)
				{
					array[index] = new KeyValuePair<TKey, TValue>(node.m_key, node.m_value);
					index++;
					node = node.m_next;
				}
			}
		}

		// Token: 0x0600393E RID: 14654 RVA: 0x000DB3C4 File Offset: 0x000D95C4
		private void CopyToEntries(DictionaryEntry[] array, int index)
		{
			foreach (ConcurrentDictionary<TKey, TValue>.Node node in this.m_tables.m_buckets)
			{
				while (node != null)
				{
					array[index] = new DictionaryEntry(node.m_key, node.m_value);
					index++;
					node = node.m_next;
				}
			}
		}

		// Token: 0x0600393F RID: 14655 RVA: 0x000DB428 File Offset: 0x000D9628
		private void CopyToObjects(object[] array, int index)
		{
			foreach (ConcurrentDictionary<TKey, TValue>.Node node in this.m_tables.m_buckets)
			{
				while (node != null)
				{
					array[index] = new KeyValuePair<TKey, TValue>(node.m_key, node.m_value);
					index++;
					node = node.m_next;
				}
			}
		}

		// Token: 0x06003940 RID: 14656 RVA: 0x000DB481 File Offset: 0x000D9681
		[__DynamicallyInvokable]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			ConcurrentDictionary<TKey, TValue>.Node[] buckets = this.m_tables.m_buckets;
			int num;
			for (int i = 0; i < buckets.Length; i = num + 1)
			{
				ConcurrentDictionary<TKey, TValue>.Node current;
				for (current = Volatile.Read<ConcurrentDictionary<TKey, TValue>.Node>(ref buckets[i]); current != null; current = current.m_next)
				{
					yield return new KeyValuePair<TKey, TValue>(current.m_key, current.m_value);
				}
				current = null;
				num = i;
			}
			yield break;
		}

		// Token: 0x06003941 RID: 14657 RVA: 0x000DB490 File Offset: 0x000D9690
		private bool TryAddInternal(TKey key, TValue value, bool updateIfExists, bool acquireLock, out TValue resultingValue)
		{
			ConcurrentDictionary<TKey, TValue>.Tables tables;
			IEqualityComparer<TKey> comparer;
			bool flag;
			bool flag3;
			for (;;)
			{
				tables = this.m_tables;
				comparer = tables.m_comparer;
				int hashCode = comparer.GetHashCode(key);
				int num;
				int num2;
				this.GetBucketAndLockNo(hashCode, out num, out num2, tables.m_buckets.Length, tables.m_locks.Length);
				flag = false;
				bool flag2 = false;
				flag3 = false;
				try
				{
					if (acquireLock)
					{
						Monitor.Enter(tables.m_locks[num2], ref flag2);
					}
					if (tables != this.m_tables)
					{
						continue;
					}
					int num3 = 0;
					ConcurrentDictionary<TKey, TValue>.Node node = null;
					for (ConcurrentDictionary<TKey, TValue>.Node node2 = tables.m_buckets[num]; node2 != null; node2 = node2.m_next)
					{
						if (comparer.Equals(node2.m_key, key))
						{
							if (updateIfExists)
							{
								if (ConcurrentDictionary<TKey, TValue>.s_isValueWriteAtomic)
								{
									node2.m_value = value;
								}
								else
								{
									ConcurrentDictionary<TKey, TValue>.Node node3 = new ConcurrentDictionary<TKey, TValue>.Node(node2.m_key, value, hashCode, node2.m_next);
									if (node == null)
									{
										tables.m_buckets[num] = node3;
									}
									else
									{
										node.m_next = node3;
									}
								}
								resultingValue = value;
							}
							else
							{
								resultingValue = node2.m_value;
							}
							return false;
						}
						node = node2;
						num3++;
					}
					if (num3 > 100 && HashHelpers.IsWellKnownEqualityComparer(comparer))
					{
						flag = true;
						flag3 = true;
					}
					Volatile.Write<ConcurrentDictionary<TKey, TValue>.Node>(ref tables.m_buckets[num], new ConcurrentDictionary<TKey, TValue>.Node(key, value, hashCode, tables.m_buckets[num]));
					checked
					{
						tables.m_countPerLock[num2]++;
						if (tables.m_countPerLock[num2] > this.m_budget)
						{
							flag = true;
						}
					}
				}
				finally
				{
					if (flag2)
					{
						Monitor.Exit(tables.m_locks[num2]);
					}
				}
				break;
			}
			if (flag)
			{
				if (flag3)
				{
					this.GrowTable(tables, (IEqualityComparer<TKey>)HashHelpers.GetRandomizedEqualityComparer(comparer), true, this.m_keyRehashCount);
				}
				else
				{
					this.GrowTable(tables, tables.m_comparer, false, this.m_keyRehashCount);
				}
			}
			resultingValue = value;
			return true;
		}

		// Token: 0x1700088E RID: 2190
		[__DynamicallyInvokable]
		public TValue this[TKey key]
		{
			[__DynamicallyInvokable]
			get
			{
				TValue result;
				if (!this.TryGetValue(key, out result))
				{
					throw new KeyNotFoundException();
				}
				return result;
			}
			[__DynamicallyInvokable]
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				TValue tvalue;
				this.TryAddInternal(key, value, true, true, out tvalue);
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06003944 RID: 14660 RVA: 0x000DB6C8 File Offset: 0x000D98C8
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				int toExclusive = 0;
				int countInternal;
				try
				{
					this.AcquireAllLocks(ref toExclusive);
					countInternal = this.GetCountInternal();
				}
				finally
				{
					this.ReleaseLocks(0, toExclusive);
				}
				return countInternal;
			}
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x000DB704 File Offset: 0x000D9904
		private int GetCountInternal()
		{
			int num = 0;
			for (int i = 0; i < this.m_tables.m_countPerLock.Length; i++)
			{
				num += this.m_tables.m_countPerLock[i];
			}
			return num;
		}

		// Token: 0x06003946 RID: 14662 RVA: 0x000DB744 File Offset: 0x000D9944
		[__DynamicallyInvokable]
		public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (valueFactory == null)
			{
				throw new ArgumentNullException("valueFactory");
			}
			TValue result;
			if (this.TryGetValue(key, out result))
			{
				return result;
			}
			this.TryAddInternal(key, valueFactory(key), false, true, out result);
			return result;
		}

		// Token: 0x06003947 RID: 14663 RVA: 0x000DB794 File Offset: 0x000D9994
		[__DynamicallyInvokable]
		public TValue GetOrAdd(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			TValue result;
			this.TryAddInternal(key, value, false, true, out result);
			return result;
		}

		// Token: 0x06003948 RID: 14664 RVA: 0x000DB7C4 File Offset: 0x000D99C4
		public TValue GetOrAdd<TArg>(TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (valueFactory == null)
			{
				throw new ArgumentNullException("valueFactory");
			}
			TValue result;
			if (!this.TryGetValue(key, out result))
			{
				this.TryAddInternal(key, valueFactory(key, factoryArgument), false, true, out result);
			}
			return result;
		}

		// Token: 0x06003949 RID: 14665 RVA: 0x000DB814 File Offset: 0x000D9A14
		public TValue AddOrUpdate<TArg>(TKey key, Func<TKey, TArg, TValue> addValueFactory, Func<TKey, TValue, TArg, TValue> updateValueFactory, TArg factoryArgument)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (addValueFactory == null)
			{
				throw new ArgumentNullException("addValueFactory");
			}
			if (updateValueFactory == null)
			{
				throw new ArgumentNullException("updateValueFactory");
			}
			TValue tvalue2;
			for (;;)
			{
				TValue tvalue;
				TValue result;
				if (this.TryGetValue(key, out tvalue))
				{
					tvalue2 = updateValueFactory(key, tvalue, factoryArgument);
					if (this.TryUpdate(key, tvalue2, tvalue))
					{
						break;
					}
				}
				else if (this.TryAddInternal(key, addValueFactory(key, factoryArgument), false, true, out result))
				{
					return result;
				}
			}
			return tvalue2;
		}

		// Token: 0x0600394A RID: 14666 RVA: 0x000DB88C File Offset: 0x000D9A8C
		[__DynamicallyInvokable]
		public TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (addValueFactory == null)
			{
				throw new ArgumentNullException("addValueFactory");
			}
			if (updateValueFactory == null)
			{
				throw new ArgumentNullException("updateValueFactory");
			}
			TValue tvalue2;
			for (;;)
			{
				TValue tvalue;
				if (this.TryGetValue(key, out tvalue))
				{
					tvalue2 = updateValueFactory(key, tvalue);
					if (this.TryUpdate(key, tvalue2, tvalue))
					{
						break;
					}
				}
				else
				{
					tvalue2 = addValueFactory(key);
					TValue result;
					if (this.TryAddInternal(key, tvalue2, false, true, out result))
					{
						return result;
					}
				}
			}
			return tvalue2;
		}

		// Token: 0x0600394B RID: 14667 RVA: 0x000DB900 File Offset: 0x000D9B00
		[__DynamicallyInvokable]
		public TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (updateValueFactory == null)
			{
				throw new ArgumentNullException("updateValueFactory");
			}
			TValue tvalue2;
			for (;;)
			{
				TValue tvalue;
				TValue result;
				if (this.TryGetValue(key, out tvalue))
				{
					tvalue2 = updateValueFactory(key, tvalue);
					if (this.TryUpdate(key, tvalue2, tvalue))
					{
						break;
					}
				}
				else if (this.TryAddInternal(key, addValue, false, true, out result))
				{
					return result;
				}
			}
			return tvalue2;
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x0600394C RID: 14668 RVA: 0x000DB960 File Offset: 0x000D9B60
		[__DynamicallyInvokable]
		public bool IsEmpty
		{
			[__DynamicallyInvokable]
			get
			{
				int toExclusive = 0;
				try
				{
					this.AcquireAllLocks(ref toExclusive);
					for (int i = 0; i < this.m_tables.m_countPerLock.Length; i++)
					{
						if (this.m_tables.m_countPerLock[i] != 0)
						{
							return false;
						}
					}
				}
				finally
				{
					this.ReleaseLocks(0, toExclusive);
				}
				return true;
			}
		}

		// Token: 0x0600394D RID: 14669 RVA: 0x000DB9C8 File Offset: 0x000D9BC8
		[__DynamicallyInvokable]
		void IDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			if (!this.TryAdd(key, value))
			{
				throw new ArgumentException(this.GetResource("ConcurrentDictionary_KeyAlreadyExisted"));
			}
		}

		// Token: 0x0600394E RID: 14670 RVA: 0x000DB9E8 File Offset: 0x000D9BE8
		[__DynamicallyInvokable]
		bool IDictionary<!0, !1>.Remove(TKey key)
		{
			TValue tvalue;
			return this.TryRemove(key, out tvalue);
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x0600394F RID: 14671 RVA: 0x000DB9FE File Offset: 0x000D9BFE
		[__DynamicallyInvokable]
		public ICollection<TKey> Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetKeys();
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x06003950 RID: 14672 RVA: 0x000DBA06 File Offset: 0x000D9C06
		[__DynamicallyInvokable]
		IEnumerable<TKey> IReadOnlyDictionary<!0, !1>.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetKeys();
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x06003951 RID: 14673 RVA: 0x000DBA0E File Offset: 0x000D9C0E
		[__DynamicallyInvokable]
		public ICollection<TValue> Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetValues();
			}
		}

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x06003952 RID: 14674 RVA: 0x000DBA16 File Offset: 0x000D9C16
		[__DynamicallyInvokable]
		IEnumerable<TValue> IReadOnlyDictionary<!0, !1>.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetValues();
			}
		}

		// Token: 0x06003953 RID: 14675 RVA: 0x000DBA1E File Offset: 0x000D9C1E
		[__DynamicallyInvokable]
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
			((IDictionary<!0, !1>)this).Add(keyValuePair.Key, keyValuePair.Value);
		}

		// Token: 0x06003954 RID: 14676 RVA: 0x000DBA34 File Offset: 0x000D9C34
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			TValue x;
			return this.TryGetValue(keyValuePair.Key, out x) && EqualityComparer<TValue>.Default.Equals(x, keyValuePair.Value);
		}

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06003955 RID: 14677 RVA: 0x000DBA66 File Offset: 0x000D9C66
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x06003956 RID: 14678 RVA: 0x000DBA6C File Offset: 0x000D9C6C
		[__DynamicallyInvokable]
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			if (keyValuePair.Key == null)
			{
				throw new ArgumentNullException(this.GetResource("ConcurrentDictionary_ItemKeyIsNull"));
			}
			TValue tvalue;
			return this.TryRemoveInternal(keyValuePair.Key, out tvalue, true, keyValuePair.Value);
		}

		// Token: 0x06003957 RID: 14679 RVA: 0x000DBAAF File Offset: 0x000D9CAF
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06003958 RID: 14680 RVA: 0x000DBAB8 File Offset: 0x000D9CB8
		[__DynamicallyInvokable]
		void IDictionary.Add(object key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (!(key is TKey))
			{
				throw new ArgumentException(this.GetResource("ConcurrentDictionary_TypeOfKeyIncorrect"));
			}
			TValue value2;
			try
			{
				value2 = (TValue)((object)value);
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(this.GetResource("ConcurrentDictionary_TypeOfValueIncorrect"));
			}
			((IDictionary<!0, !1>)this).Add((TKey)((object)key), value2);
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x000DBB28 File Offset: 0x000D9D28
		[__DynamicallyInvokable]
		bool IDictionary.Contains(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return key is TKey && this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x0600395A RID: 14682 RVA: 0x000DBB4E File Offset: 0x000D9D4E
		[__DynamicallyInvokable]
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new ConcurrentDictionary<TKey, TValue>.DictionaryEnumerator(this);
		}

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x0600395B RID: 14683 RVA: 0x000DBB56 File Offset: 0x000D9D56
		[__DynamicallyInvokable]
		bool IDictionary.IsFixedSize
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x0600395C RID: 14684 RVA: 0x000DBB59 File Offset: 0x000D9D59
		[__DynamicallyInvokable]
		bool IDictionary.IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x0600395D RID: 14685 RVA: 0x000DBB5C File Offset: 0x000D9D5C
		[__DynamicallyInvokable]
		ICollection IDictionary.Keys
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetKeys();
			}
		}

		// Token: 0x0600395E RID: 14686 RVA: 0x000DBB64 File Offset: 0x000D9D64
		[__DynamicallyInvokable]
		void IDictionary.Remove(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (key is TKey)
			{
				TValue tvalue;
				this.TryRemove((TKey)((object)key), out tvalue);
			}
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x0600395F RID: 14687 RVA: 0x000DBB96 File Offset: 0x000D9D96
		[__DynamicallyInvokable]
		ICollection IDictionary.Values
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetValues();
			}
		}

		// Token: 0x1700089A RID: 2202
		[__DynamicallyInvokable]
		object IDictionary.this[object key]
		{
			[__DynamicallyInvokable]
			get
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				TValue tvalue;
				if (key is TKey && this.TryGetValue((TKey)((object)key), out tvalue))
				{
					return tvalue;
				}
				return null;
			}
			[__DynamicallyInvokable]
			set
			{
				if (key == null)
				{
					throw new ArgumentNullException("key");
				}
				if (!(key is TKey))
				{
					throw new ArgumentException(this.GetResource("ConcurrentDictionary_TypeOfKeyIncorrect"));
				}
				if (!(value is TValue))
				{
					throw new ArgumentException(this.GetResource("ConcurrentDictionary_TypeOfValueIncorrect"));
				}
				this[(TKey)((object)key)] = (TValue)((object)value);
			}
		}

		// Token: 0x06003962 RID: 14690 RVA: 0x000DBC3C File Offset: 0x000D9E3C
		[__DynamicallyInvokable]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", this.GetResource("ConcurrentDictionary_IndexIsNegative"));
			}
			int toExclusive = 0;
			try
			{
				this.AcquireAllLocks(ref toExclusive);
				ConcurrentDictionary<TKey, TValue>.Tables tables = this.m_tables;
				int num = 0;
				int num2 = 0;
				while (num2 < tables.m_locks.Length && num >= 0)
				{
					num += tables.m_countPerLock[num2];
					num2++;
				}
				if (array.Length - num < index || num < 0)
				{
					throw new ArgumentException(this.GetResource("ConcurrentDictionary_ArrayNotLargeEnough"));
				}
				KeyValuePair<TKey, TValue>[] array2 = array as KeyValuePair<TKey, TValue>[];
				if (array2 != null)
				{
					this.CopyToPairs(array2, index);
				}
				else
				{
					DictionaryEntry[] array3 = array as DictionaryEntry[];
					if (array3 != null)
					{
						this.CopyToEntries(array3, index);
					}
					else
					{
						object[] array4 = array as object[];
						if (array4 == null)
						{
							throw new ArgumentException(this.GetResource("ConcurrentDictionary_ArrayIncorrectType"), "array");
						}
						this.CopyToObjects(array4, index);
					}
				}
			}
			finally
			{
				this.ReleaseLocks(0, toExclusive);
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x06003963 RID: 14691 RVA: 0x000DBD40 File Offset: 0x000D9F40
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x06003964 RID: 14692 RVA: 0x000DBD43 File Offset: 0x000D9F43
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("ConcurrentCollection_SyncRoot_NotSupported"));
			}
		}

		// Token: 0x06003965 RID: 14693 RVA: 0x000DBD54 File Offset: 0x000D9F54
		private void GrowTable(ConcurrentDictionary<TKey, TValue>.Tables tables, IEqualityComparer<TKey> newComparer, bool regenerateHashKeys, int rehashCount)
		{
			int toExclusive = 0;
			try
			{
				this.AcquireLocks(0, 1, ref toExclusive);
				if (regenerateHashKeys && rehashCount == this.m_keyRehashCount)
				{
					tables = this.m_tables;
				}
				else
				{
					if (tables != this.m_tables)
					{
						return;
					}
					long num = 0L;
					for (int i = 0; i < tables.m_countPerLock.Length; i++)
					{
						num += (long)tables.m_countPerLock[i];
					}
					if (num < (long)(tables.m_buckets.Length / 4))
					{
						this.m_budget = 2 * this.m_budget;
						if (this.m_budget < 0)
						{
							this.m_budget = int.MaxValue;
						}
						return;
					}
				}
				int num2 = 0;
				bool flag = false;
				object[] array;
				checked
				{
					try
					{
						num2 = tables.m_buckets.Length * 2 + 1;
						while (num2 % 3 == 0 || num2 % 5 == 0 || num2 % 7 == 0)
						{
							num2 += 2;
						}
						if (num2 > 2146435071)
						{
							flag = true;
						}
					}
					catch (OverflowException)
					{
						flag = true;
					}
					if (flag)
					{
						num2 = 2146435071;
						this.m_budget = int.MaxValue;
					}
					this.AcquireLocks(1, tables.m_locks.Length, ref toExclusive);
					array = tables.m_locks;
				}
				if (this.m_growLockArray && tables.m_locks.Length < 1024)
				{
					array = new object[tables.m_locks.Length * 2];
					Array.Copy(tables.m_locks, array, tables.m_locks.Length);
					for (int j = tables.m_locks.Length; j < array.Length; j++)
					{
						array[j] = new object();
					}
				}
				ConcurrentDictionary<TKey, TValue>.Node[] array2 = new ConcurrentDictionary<TKey, TValue>.Node[num2];
				int[] array3 = new int[array.Length];
				for (int k = 0; k < tables.m_buckets.Length; k++)
				{
					checked
					{
						ConcurrentDictionary<TKey, TValue>.Node next;
						for (ConcurrentDictionary<TKey, TValue>.Node node = tables.m_buckets[k]; node != null; node = next)
						{
							next = node.m_next;
							int hashcode = node.m_hashcode;
							if (regenerateHashKeys)
							{
								hashcode = newComparer.GetHashCode(node.m_key);
							}
							int num3;
							int num4;
							this.GetBucketAndLockNo(hashcode, out num3, out num4, array2.Length, array.Length);
							array2[num3] = new ConcurrentDictionary<TKey, TValue>.Node(node.m_key, node.m_value, hashcode, array2[num3]);
							array3[num4]++;
						}
					}
				}
				if (regenerateHashKeys)
				{
					this.m_keyRehashCount++;
				}
				this.m_budget = Math.Max(1, array2.Length / array.Length);
				this.m_tables = new ConcurrentDictionary<TKey, TValue>.Tables(array2, array, array3, newComparer);
			}
			finally
			{
				this.ReleaseLocks(0, toExclusive);
			}
		}

		// Token: 0x06003966 RID: 14694 RVA: 0x000DBFDC File Offset: 0x000DA1DC
		private void GetBucketAndLockNo(int hashcode, out int bucketNo, out int lockNo, int bucketCount, int lockCount)
		{
			bucketNo = (hashcode & int.MaxValue) % bucketCount;
			lockNo = bucketNo % lockCount;
		}

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x06003967 RID: 14695 RVA: 0x000DBFF1 File Offset: 0x000DA1F1
		private static int DefaultConcurrencyLevel
		{
			get
			{
				return PlatformHelper.ProcessorCount;
			}
		}

		// Token: 0x06003968 RID: 14696 RVA: 0x000DBFF8 File Offset: 0x000DA1F8
		private void AcquireAllLocks(ref int locksAcquired)
		{
			if (CDSCollectionETWBCLProvider.Log.IsEnabled())
			{
				CDSCollectionETWBCLProvider.Log.ConcurrentDictionary_AcquiringAllLocks(this.m_tables.m_buckets.Length);
			}
			this.AcquireLocks(0, 1, ref locksAcquired);
			this.AcquireLocks(1, this.m_tables.m_locks.Length, ref locksAcquired);
		}

		// Token: 0x06003969 RID: 14697 RVA: 0x000DC04C File Offset: 0x000DA24C
		private void AcquireLocks(int fromInclusive, int toExclusive, ref int locksAcquired)
		{
			object[] locks = this.m_tables.m_locks;
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				bool flag = false;
				try
				{
					Monitor.Enter(locks[i], ref flag);
				}
				finally
				{
					if (flag)
					{
						locksAcquired++;
					}
				}
			}
		}

		// Token: 0x0600396A RID: 14698 RVA: 0x000DC09C File Offset: 0x000DA29C
		private void ReleaseLocks(int fromInclusive, int toExclusive)
		{
			for (int i = fromInclusive; i < toExclusive; i++)
			{
				Monitor.Exit(this.m_tables.m_locks[i]);
			}
		}

		// Token: 0x0600396B RID: 14699 RVA: 0x000DC0CC File Offset: 0x000DA2CC
		private ReadOnlyCollection<TKey> GetKeys()
		{
			int toExclusive = 0;
			ReadOnlyCollection<TKey> result;
			try
			{
				this.AcquireAllLocks(ref toExclusive);
				int countInternal = this.GetCountInternal();
				if (countInternal < 0)
				{
					throw new OutOfMemoryException();
				}
				List<TKey> list = new List<TKey>(countInternal);
				for (int i = 0; i < this.m_tables.m_buckets.Length; i++)
				{
					for (ConcurrentDictionary<TKey, TValue>.Node node = this.m_tables.m_buckets[i]; node != null; node = node.m_next)
					{
						list.Add(node.m_key);
					}
				}
				result = new ReadOnlyCollection<TKey>(list);
			}
			finally
			{
				this.ReleaseLocks(0, toExclusive);
			}
			return result;
		}

		// Token: 0x0600396C RID: 14700 RVA: 0x000DC16C File Offset: 0x000DA36C
		private ReadOnlyCollection<TValue> GetValues()
		{
			int toExclusive = 0;
			ReadOnlyCollection<TValue> result;
			try
			{
				this.AcquireAllLocks(ref toExclusive);
				int countInternal = this.GetCountInternal();
				if (countInternal < 0)
				{
					throw new OutOfMemoryException();
				}
				List<TValue> list = new List<TValue>(countInternal);
				for (int i = 0; i < this.m_tables.m_buckets.Length; i++)
				{
					for (ConcurrentDictionary<TKey, TValue>.Node node = this.m_tables.m_buckets[i]; node != null; node = node.m_next)
					{
						list.Add(node.m_value);
					}
				}
				result = new ReadOnlyCollection<TValue>(list);
			}
			finally
			{
				this.ReleaseLocks(0, toExclusive);
			}
			return result;
		}

		// Token: 0x0600396D RID: 14701 RVA: 0x000DC20C File Offset: 0x000DA40C
		[Conditional("DEBUG")]
		private void Assert(bool condition)
		{
		}

		// Token: 0x0600396E RID: 14702 RVA: 0x000DC20E File Offset: 0x000DA40E
		private string GetResource(string key)
		{
			return Environment.GetResourceString(key);
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x000DC218 File Offset: 0x000DA418
		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			ConcurrentDictionary<TKey, TValue>.Tables tables = this.m_tables;
			this.m_serializationArray = this.ToArray();
			this.m_serializationConcurrencyLevel = tables.m_locks.Length;
			this.m_serializationCapacity = tables.m_buckets.Length;
			this.m_comparer = (IEqualityComparer<TKey>)HashHelpers.GetEqualityComparerForSerialization(tables.m_comparer);
		}

		// Token: 0x06003970 RID: 14704 RVA: 0x000DC26C File Offset: 0x000DA46C
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			KeyValuePair<TKey, TValue>[] serializationArray = this.m_serializationArray;
			ConcurrentDictionary<TKey, TValue>.Node[] buckets = new ConcurrentDictionary<TKey, TValue>.Node[this.m_serializationCapacity];
			int[] countPerLock = new int[this.m_serializationConcurrencyLevel];
			object[] array = new object[this.m_serializationConcurrencyLevel];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new object();
			}
			this.m_tables = new ConcurrentDictionary<TKey, TValue>.Tables(buckets, array, countPerLock, this.m_comparer);
			this.InitializeFromCollection(serializationArray);
			this.m_serializationArray = null;
		}

		// Token: 0x04001914 RID: 6420
		[NonSerialized]
		private volatile ConcurrentDictionary<TKey, TValue>.Tables m_tables;

		// Token: 0x04001915 RID: 6421
		internal IEqualityComparer<TKey> m_comparer;

		// Token: 0x04001916 RID: 6422
		[NonSerialized]
		private readonly bool m_growLockArray;

		// Token: 0x04001917 RID: 6423
		[OptionalField]
		private int m_keyRehashCount;

		// Token: 0x04001918 RID: 6424
		[NonSerialized]
		private int m_budget;

		// Token: 0x04001919 RID: 6425
		private KeyValuePair<TKey, TValue>[] m_serializationArray;

		// Token: 0x0400191A RID: 6426
		private int m_serializationConcurrencyLevel;

		// Token: 0x0400191B RID: 6427
		private int m_serializationCapacity;

		// Token: 0x0400191C RID: 6428
		private const int DEFAULT_CAPACITY = 31;

		// Token: 0x0400191D RID: 6429
		private const int MAX_LOCK_NUMBER = 1024;

		// Token: 0x0400191E RID: 6430
		private static readonly bool s_isValueWriteAtomic = ConcurrentDictionary<TKey, TValue>.IsValueWriteAtomic();

		// Token: 0x02000BC2 RID: 3010
		private class Tables
		{
			// Token: 0x06006E6B RID: 28267 RVA: 0x0017D005 File Offset: 0x0017B205
			internal Tables(ConcurrentDictionary<TKey, TValue>.Node[] buckets, object[] locks, int[] countPerLock, IEqualityComparer<TKey> comparer)
			{
				this.m_buckets = buckets;
				this.m_locks = locks;
				this.m_countPerLock = countPerLock;
				this.m_comparer = comparer;
			}

			// Token: 0x04003591 RID: 13713
			internal readonly ConcurrentDictionary<TKey, TValue>.Node[] m_buckets;

			// Token: 0x04003592 RID: 13714
			internal readonly object[] m_locks;

			// Token: 0x04003593 RID: 13715
			internal volatile int[] m_countPerLock;

			// Token: 0x04003594 RID: 13716
			internal readonly IEqualityComparer<TKey> m_comparer;
		}

		// Token: 0x02000BC3 RID: 3011
		private class Node
		{
			// Token: 0x06006E6C RID: 28268 RVA: 0x0017D02C File Offset: 0x0017B22C
			internal Node(TKey key, TValue value, int hashcode, ConcurrentDictionary<TKey, TValue>.Node next)
			{
				this.m_key = key;
				this.m_value = value;
				this.m_next = next;
				this.m_hashcode = hashcode;
			}

			// Token: 0x04003595 RID: 13717
			internal TKey m_key;

			// Token: 0x04003596 RID: 13718
			internal TValue m_value;

			// Token: 0x04003597 RID: 13719
			internal volatile ConcurrentDictionary<TKey, TValue>.Node m_next;

			// Token: 0x04003598 RID: 13720
			internal int m_hashcode;
		}

		// Token: 0x02000BC4 RID: 3012
		private class DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
		{
			// Token: 0x06006E6D RID: 28269 RVA: 0x0017D053 File Offset: 0x0017B253
			internal DictionaryEnumerator(ConcurrentDictionary<TKey, TValue> dictionary)
			{
				this.m_enumerator = dictionary.GetEnumerator();
			}

			// Token: 0x170012DD RID: 4829
			// (get) Token: 0x06006E6E RID: 28270 RVA: 0x0017D068 File Offset: 0x0017B268
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

			// Token: 0x170012DE RID: 4830
			// (get) Token: 0x06006E6F RID: 28271 RVA: 0x0017D0AC File Offset: 0x0017B2AC
			public object Key
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					return keyValuePair.Key;
				}
			}

			// Token: 0x170012DF RID: 4831
			// (get) Token: 0x06006E70 RID: 28272 RVA: 0x0017D0D4 File Offset: 0x0017B2D4
			public object Value
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.m_enumerator.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x170012E0 RID: 4832
			// (get) Token: 0x06006E71 RID: 28273 RVA: 0x0017D0F9 File Offset: 0x0017B2F9
			public object Current
			{
				get
				{
					return this.Entry;
				}
			}

			// Token: 0x06006E72 RID: 28274 RVA: 0x0017D106 File Offset: 0x0017B306
			public bool MoveNext()
			{
				return this.m_enumerator.MoveNext();
			}

			// Token: 0x06006E73 RID: 28275 RVA: 0x0017D113 File Offset: 0x0017B313
			public void Reset()
			{
				this.m_enumerator.Reset();
			}

			// Token: 0x04003599 RID: 13721
			private IEnumerator<KeyValuePair<TKey, TValue>> m_enumerator;
		}
	}
}
