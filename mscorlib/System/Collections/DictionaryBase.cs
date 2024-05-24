using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200048C RID: 1164
	[ComVisible(true)]
	[Serializable]
	public abstract class DictionaryBase : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06003791 RID: 14225 RVA: 0x000D596D File Offset: 0x000D3B6D
		protected Hashtable InnerHashtable
		{
			get
			{
				if (this.hashtable == null)
				{
					this.hashtable = new Hashtable();
				}
				return this.hashtable;
			}
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06003792 RID: 14226 RVA: 0x000D5988 File Offset: 0x000D3B88
		protected IDictionary Dictionary
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06003793 RID: 14227 RVA: 0x000D598B File Offset: 0x000D3B8B
		public int Count
		{
			get
			{
				if (this.hashtable != null)
				{
					return this.hashtable.Count;
				}
				return 0;
			}
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06003794 RID: 14228 RVA: 0x000D59A2 File Offset: 0x000D3BA2
		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.InnerHashtable.IsReadOnly;
			}
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06003795 RID: 14229 RVA: 0x000D59AF File Offset: 0x000D3BAF
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.InnerHashtable.IsFixedSize;
			}
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06003796 RID: 14230 RVA: 0x000D59BC File Offset: 0x000D3BBC
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.InnerHashtable.IsSynchronized;
			}
		}

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06003797 RID: 14231 RVA: 0x000D59C9 File Offset: 0x000D3BC9
		ICollection IDictionary.Keys
		{
			get
			{
				return this.InnerHashtable.Keys;
			}
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06003798 RID: 14232 RVA: 0x000D59D6 File Offset: 0x000D3BD6
		object ICollection.SyncRoot
		{
			get
			{
				return this.InnerHashtable.SyncRoot;
			}
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06003799 RID: 14233 RVA: 0x000D59E3 File Offset: 0x000D3BE3
		ICollection IDictionary.Values
		{
			get
			{
				return this.InnerHashtable.Values;
			}
		}

		// Token: 0x0600379A RID: 14234 RVA: 0x000D59F0 File Offset: 0x000D3BF0
		public void CopyTo(Array array, int index)
		{
			this.InnerHashtable.CopyTo(array, index);
		}

		// Token: 0x17000835 RID: 2101
		object IDictionary.this[object key]
		{
			get
			{
				object obj = this.InnerHashtable[key];
				this.OnGet(key, obj);
				return obj;
			}
			set
			{
				this.OnValidate(key, value);
				bool flag = true;
				object obj = this.InnerHashtable[key];
				if (obj == null)
				{
					flag = this.InnerHashtable.Contains(key);
				}
				this.OnSet(key, obj, value);
				this.InnerHashtable[key] = value;
				try
				{
					this.OnSetComplete(key, obj, value);
				}
				catch
				{
					if (flag)
					{
						this.InnerHashtable[key] = obj;
					}
					else
					{
						this.InnerHashtable.Remove(key);
					}
					throw;
				}
			}
		}

		// Token: 0x0600379D RID: 14237 RVA: 0x000D5AAC File Offset: 0x000D3CAC
		bool IDictionary.Contains(object key)
		{
			return this.InnerHashtable.Contains(key);
		}

		// Token: 0x0600379E RID: 14238 RVA: 0x000D5ABC File Offset: 0x000D3CBC
		void IDictionary.Add(object key, object value)
		{
			this.OnValidate(key, value);
			this.OnInsert(key, value);
			this.InnerHashtable.Add(key, value);
			try
			{
				this.OnInsertComplete(key, value);
			}
			catch
			{
				this.InnerHashtable.Remove(key);
				throw;
			}
		}

		// Token: 0x0600379F RID: 14239 RVA: 0x000D5B10 File Offset: 0x000D3D10
		public void Clear()
		{
			this.OnClear();
			this.InnerHashtable.Clear();
			this.OnClearComplete();
		}

		// Token: 0x060037A0 RID: 14240 RVA: 0x000D5B2C File Offset: 0x000D3D2C
		void IDictionary.Remove(object key)
		{
			if (this.InnerHashtable.Contains(key))
			{
				object value = this.InnerHashtable[key];
				this.OnValidate(key, value);
				this.OnRemove(key, value);
				this.InnerHashtable.Remove(key);
				try
				{
					this.OnRemoveComplete(key, value);
				}
				catch
				{
					this.InnerHashtable.Add(key, value);
					throw;
				}
			}
		}

		// Token: 0x060037A1 RID: 14241 RVA: 0x000D5B9C File Offset: 0x000D3D9C
		public IDictionaryEnumerator GetEnumerator()
		{
			return this.InnerHashtable.GetEnumerator();
		}

		// Token: 0x060037A2 RID: 14242 RVA: 0x000D5BA9 File Offset: 0x000D3DA9
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.InnerHashtable.GetEnumerator();
		}

		// Token: 0x060037A3 RID: 14243 RVA: 0x000D5BB6 File Offset: 0x000D3DB6
		protected virtual object OnGet(object key, object currentValue)
		{
			return currentValue;
		}

		// Token: 0x060037A4 RID: 14244 RVA: 0x000D5BB9 File Offset: 0x000D3DB9
		protected virtual void OnSet(object key, object oldValue, object newValue)
		{
		}

		// Token: 0x060037A5 RID: 14245 RVA: 0x000D5BBB File Offset: 0x000D3DBB
		protected virtual void OnInsert(object key, object value)
		{
		}

		// Token: 0x060037A6 RID: 14246 RVA: 0x000D5BBD File Offset: 0x000D3DBD
		protected virtual void OnClear()
		{
		}

		// Token: 0x060037A7 RID: 14247 RVA: 0x000D5BBF File Offset: 0x000D3DBF
		protected virtual void OnRemove(object key, object value)
		{
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x000D5BC1 File Offset: 0x000D3DC1
		protected virtual void OnValidate(object key, object value)
		{
		}

		// Token: 0x060037A9 RID: 14249 RVA: 0x000D5BC3 File Offset: 0x000D3DC3
		protected virtual void OnSetComplete(object key, object oldValue, object newValue)
		{
		}

		// Token: 0x060037AA RID: 14250 RVA: 0x000D5BC5 File Offset: 0x000D3DC5
		protected virtual void OnInsertComplete(object key, object value)
		{
		}

		// Token: 0x060037AB RID: 14251 RVA: 0x000D5BC7 File Offset: 0x000D3DC7
		protected virtual void OnClearComplete()
		{
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x000D5BC9 File Offset: 0x000D3DC9
		protected virtual void OnRemoveComplete(object key, object value)
		{
		}

		// Token: 0x040018B2 RID: 6322
		private Hashtable hashtable;
	}
}
