﻿using System;
using System.Collections;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000852 RID: 2130
	internal class AggregateDictionary : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x06005A4F RID: 23119 RVA: 0x0013D967 File Offset: 0x0013BB67
		public AggregateDictionary(ICollection dictionaries)
		{
			this._dictionaries = dictionaries;
		}

		// Token: 0x17000F12 RID: 3858
		public virtual object this[object key]
		{
			get
			{
				foreach (object obj in this._dictionaries)
				{
					IDictionary dictionary = (IDictionary)obj;
					if (dictionary.Contains(key))
					{
						return dictionary[key];
					}
				}
				return null;
			}
			set
			{
				foreach (object obj in this._dictionaries)
				{
					IDictionary dictionary = (IDictionary)obj;
					if (dictionary.Contains(key))
					{
						dictionary[key] = value;
					}
				}
			}
		}

		// Token: 0x17000F13 RID: 3859
		// (get) Token: 0x06005A52 RID: 23122 RVA: 0x0013DA44 File Offset: 0x0013BC44
		public virtual ICollection Keys
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object obj in this._dictionaries)
				{
					IDictionary dictionary = (IDictionary)obj;
					ICollection keys = dictionary.Keys;
					if (keys != null)
					{
						foreach (object value in keys)
						{
							arrayList.Add(value);
						}
					}
				}
				return arrayList;
			}
		}

		// Token: 0x17000F14 RID: 3860
		// (get) Token: 0x06005A53 RID: 23123 RVA: 0x0013DAF4 File Offset: 0x0013BCF4
		public virtual ICollection Values
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object obj in this._dictionaries)
				{
					IDictionary dictionary = (IDictionary)obj;
					ICollection values = dictionary.Values;
					if (values != null)
					{
						foreach (object value in values)
						{
							arrayList.Add(value);
						}
					}
				}
				return arrayList;
			}
		}

		// Token: 0x06005A54 RID: 23124 RVA: 0x0013DBA4 File Offset: 0x0013BDA4
		public virtual bool Contains(object key)
		{
			foreach (object obj in this._dictionaries)
			{
				IDictionary dictionary = (IDictionary)obj;
				if (dictionary.Contains(key))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000F15 RID: 3861
		// (get) Token: 0x06005A55 RID: 23125 RVA: 0x0013DC08 File Offset: 0x0013BE08
		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000F16 RID: 3862
		// (get) Token: 0x06005A56 RID: 23126 RVA: 0x0013DC0B File Offset: 0x0013BE0B
		public virtual bool IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06005A57 RID: 23127 RVA: 0x0013DC0E File Offset: 0x0013BE0E
		public virtual void Add(object key, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A58 RID: 23128 RVA: 0x0013DC15 File Offset: 0x0013BE15
		public virtual void Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A59 RID: 23129 RVA: 0x0013DC1C File Offset: 0x0013BE1C
		public virtual void Remove(object key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A5A RID: 23130 RVA: 0x0013DC23 File Offset: 0x0013BE23
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return new DictionaryEnumeratorByKeys(this);
		}

		// Token: 0x06005A5B RID: 23131 RVA: 0x0013DC2B File Offset: 0x0013BE2B
		public virtual void CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000F17 RID: 3863
		// (get) Token: 0x06005A5C RID: 23132 RVA: 0x0013DC34 File Offset: 0x0013BE34
		public virtual int Count
		{
			get
			{
				int num = 0;
				foreach (object obj in this._dictionaries)
				{
					IDictionary dictionary = (IDictionary)obj;
					num += dictionary.Count;
				}
				return num;
			}
		}

		// Token: 0x17000F18 RID: 3864
		// (get) Token: 0x06005A5D RID: 23133 RVA: 0x0013DC94 File Offset: 0x0013BE94
		public virtual object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000F19 RID: 3865
		// (get) Token: 0x06005A5E RID: 23134 RVA: 0x0013DC97 File Offset: 0x0013BE97
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06005A5F RID: 23135 RVA: 0x0013DC9A File Offset: 0x0013BE9A
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DictionaryEnumeratorByKeys(this);
		}

		// Token: 0x040028FD RID: 10493
		private ICollection _dictionaries;
	}
}
