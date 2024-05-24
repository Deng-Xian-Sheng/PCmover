using System;
using System.Collections;
using System.Collections.Generic;

namespace Prism.Common
{
	// Token: 0x02000080 RID: 128
	public sealed class ListDictionary<TKey, TValue> : IDictionary<TKey, IList<TValue>>, ICollection<KeyValuePair<TKey, IList<TValue>>>, IEnumerable<KeyValuePair<TKey, IList<TValue>>>, IEnumerable
	{
		// Token: 0x060003A6 RID: 934 RVA: 0x00009617 File Offset: 0x00007817
		public void Add(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this.CreateNewList(key);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00009634 File Offset: 0x00007834
		public void Add(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.innerValues.ContainsKey(key))
			{
				this.innerValues[key].Add(value);
				return;
			}
			this.CreateNewList(key).Add(value);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00009698 File Offset: 0x00007898
		private List<TValue> CreateNewList(TKey key)
		{
			List<TValue> list = new List<TValue>();
			this.innerValues.Add(key, list);
			return list;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000096B9 File Offset: 0x000078B9
		public void Clear()
		{
			this.innerValues.Clear();
		}

		// Token: 0x060003AA RID: 938 RVA: 0x000096C8 File Offset: 0x000078C8
		public bool ContainsValue(TValue value)
		{
			foreach (KeyValuePair<TKey, IList<TValue>> keyValuePair in this.innerValues)
			{
				if (keyValuePair.Value.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000972C File Offset: 0x0000792C
		public bool ContainsKey(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.innerValues.ContainsKey(key);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000974D File Offset: 0x0000794D
		public IEnumerable<TValue> FindAllValuesByKey(Predicate<TKey> keyFilter)
		{
			foreach (KeyValuePair<TKey, IList<TValue>> keyValuePair in ((IEnumerable<KeyValuePair<!0, IList<!1>>>)this))
			{
				if (keyFilter(keyValuePair.Key))
				{
					foreach (TValue tvalue in keyValuePair.Value)
					{
						yield return tvalue;
					}
					IEnumerator<TValue> enumerator2 = null;
				}
			}
			IEnumerator<KeyValuePair<TKey, IList<TValue>>> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00009764 File Offset: 0x00007964
		public IEnumerable<TValue> FindAllValues(Predicate<TValue> valueFilter)
		{
			foreach (KeyValuePair<TKey, IList<TValue>> keyValuePair in ((IEnumerable<KeyValuePair<!0, IList<!1>>>)this))
			{
				foreach (TValue tvalue in keyValuePair.Value)
				{
					if (valueFilter(tvalue))
					{
						yield return tvalue;
					}
				}
				IEnumerator<TValue> enumerator2 = null;
			}
			IEnumerator<KeyValuePair<TKey, IList<TValue>>> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000977B File Offset: 0x0000797B
		public bool Remove(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.innerValues.Remove(key);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000979C File Offset: 0x0000799C
		public void Remove(TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.innerValues.ContainsKey(key))
			{
				((List<TValue>)this.innerValues[key]).RemoveAll((TValue item) => value.Equals(item));
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00009814 File Offset: 0x00007A14
		public void Remove(TValue value)
		{
			foreach (KeyValuePair<TKey, IList<TValue>> keyValuePair in this.innerValues)
			{
				this.Remove(keyValuePair.Key, value);
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x00009870 File Offset: 0x00007A70
		public IList<TValue> Values
		{
			get
			{
				List<TValue> list = new List<TValue>();
				foreach (IEnumerable<TValue> collection in this.innerValues.Values)
				{
					list.AddRange(collection);
				}
				return list;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x000098D0 File Offset: 0x00007AD0
		public ICollection<TKey> Keys
		{
			get
			{
				return this.innerValues.Keys;
			}
		}

		// Token: 0x170000DA RID: 218
		public IList<TValue> this[TKey key]
		{
			get
			{
				if (!this.innerValues.ContainsKey(key))
				{
					this.innerValues.Add(key, new List<TValue>());
				}
				return this.innerValues[key];
			}
			set
			{
				this.innerValues[key] = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00009919 File Offset: 0x00007B19
		public int Count
		{
			get
			{
				return this.innerValues.Count;
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00009926 File Offset: 0x00007B26
		void IDictionary<!0, IList<!1>>.Add(TKey key, IList<TValue> value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.innerValues.Add(key, value);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00009956 File Offset: 0x00007B56
		bool IDictionary<!0, IList<!1>>.TryGetValue(TKey key, out IList<TValue> value)
		{
			value = this[key];
			return true;
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00009962 File Offset: 0x00007B62
		ICollection<IList<TValue>> IDictionary<!0, IList<!1>>.Values
		{
			get
			{
				return this.innerValues.Values;
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000996F File Offset: 0x00007B6F
		void ICollection<KeyValuePair<!0, IList<!1>>>.Add(KeyValuePair<TKey, IList<TValue>> item)
		{
			((ICollection<KeyValuePair<!0, IList<!1>>>)this.innerValues).Add(item);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000997D File Offset: 0x00007B7D
		bool ICollection<KeyValuePair<!0, IList<!1>>>.Contains(KeyValuePair<TKey, IList<TValue>> item)
		{
			return ((ICollection<KeyValuePair<!0, IList<!1>>>)this.innerValues).Contains(item);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000998B File Offset: 0x00007B8B
		void ICollection<KeyValuePair<!0, IList<!1>>>.CopyTo(KeyValuePair<TKey, IList<TValue>>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<!0, IList<!1>>>)this.innerValues).CopyTo(array, arrayIndex);
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003BC RID: 956 RVA: 0x0000999A File Offset: 0x00007B9A
		bool ICollection<KeyValuePair<!0, IList<!1>>>.IsReadOnly
		{
			get
			{
				return ((ICollection<KeyValuePair<!0, IList<!1>>>)this.innerValues).IsReadOnly;
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000099A7 File Offset: 0x00007BA7
		bool ICollection<KeyValuePair<!0, IList<!1>>>.Remove(KeyValuePair<TKey, IList<TValue>> item)
		{
			return ((ICollection<KeyValuePair<!0, IList<!1>>>)this.innerValues).Remove(item);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000099B5 File Offset: 0x00007BB5
		IEnumerator<KeyValuePair<TKey, IList<TValue>>> IEnumerable<KeyValuePair<!0, IList<!1>>>.GetEnumerator()
		{
			return this.innerValues.GetEnumerator();
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000099B5 File Offset: 0x00007BB5
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.innerValues.GetEnumerator();
		}

		// Token: 0x040000B7 RID: 183
		private Dictionary<TKey, IList<TValue>> innerValues = new Dictionary<TKey, IList<TValue>>();
	}
}
