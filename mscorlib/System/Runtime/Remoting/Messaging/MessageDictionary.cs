using System;
using System.Collections;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000864 RID: 2148
	internal abstract class MessageDictionary : IDictionary, ICollection, IEnumerable
	{
		// Token: 0x06005B0A RID: 23306 RVA: 0x0013F76F File Offset: 0x0013D96F
		internal MessageDictionary(string[] keys, IDictionary idict)
		{
			this._keys = keys;
			this._dict = idict;
		}

		// Token: 0x06005B0B RID: 23307 RVA: 0x0013F785 File Offset: 0x0013D985
		internal bool HasUserData()
		{
			return this._dict != null && this._dict.Count > 0;
		}

		// Token: 0x17000F57 RID: 3927
		// (get) Token: 0x06005B0C RID: 23308 RVA: 0x0013F7A0 File Offset: 0x0013D9A0
		internal IDictionary InternalDictionary
		{
			get
			{
				return this._dict;
			}
		}

		// Token: 0x06005B0D RID: 23309
		internal abstract object GetMessageValue(int i);

		// Token: 0x06005B0E RID: 23310
		[SecurityCritical]
		internal abstract void SetSpecialKey(int keyNum, object value);

		// Token: 0x17000F58 RID: 3928
		// (get) Token: 0x06005B0F RID: 23311 RVA: 0x0013F7A8 File Offset: 0x0013D9A8
		public virtual bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000F59 RID: 3929
		// (get) Token: 0x06005B10 RID: 23312 RVA: 0x0013F7AB File Offset: 0x0013D9AB
		public virtual bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000F5A RID: 3930
		// (get) Token: 0x06005B11 RID: 23313 RVA: 0x0013F7AE File Offset: 0x0013D9AE
		public virtual bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000F5B RID: 3931
		// (get) Token: 0x06005B12 RID: 23314 RVA: 0x0013F7B1 File Offset: 0x0013D9B1
		public virtual object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06005B13 RID: 23315 RVA: 0x0013F7B4 File Offset: 0x0013D9B4
		public virtual bool Contains(object key)
		{
			return this.ContainsSpecialKey(key) || (this._dict != null && this._dict.Contains(key));
		}

		// Token: 0x06005B14 RID: 23316 RVA: 0x0013F7D8 File Offset: 0x0013D9D8
		protected virtual bool ContainsSpecialKey(object key)
		{
			if (!(key is string))
			{
				return false;
			}
			string text = (string)key;
			for (int i = 0; i < this._keys.Length; i++)
			{
				if (text.Equals(this._keys[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06005B15 RID: 23317 RVA: 0x0013F81C File Offset: 0x0013DA1C
		public virtual void CopyTo(Array array, int index)
		{
			for (int i = 0; i < this._keys.Length; i++)
			{
				array.SetValue(this.GetMessageValue(i), index + i);
			}
			if (this._dict != null)
			{
				this._dict.CopyTo(array, index + this._keys.Length);
			}
		}

		// Token: 0x17000F5C RID: 3932
		public virtual object this[object key]
		{
			get
			{
				string text = key as string;
				if (text != null)
				{
					for (int i = 0; i < this._keys.Length; i++)
					{
						if (text.Equals(this._keys[i]))
						{
							return this.GetMessageValue(i);
						}
					}
					if (this._dict != null)
					{
						return this._dict[key];
					}
				}
				return null;
			}
			[SecuritySafeCritical]
			set
			{
				if (!this.ContainsSpecialKey(key))
				{
					if (this._dict == null)
					{
						this._dict = new Hashtable();
					}
					this._dict[key] = value;
					return;
				}
				if (key.Equals(Message.UriKey))
				{
					this.SetSpecialKey(0, value);
					return;
				}
				if (key.Equals(Message.CallContextKey))
				{
					this.SetSpecialKey(1, value);
					return;
				}
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidKey"));
			}
		}

		// Token: 0x06005B18 RID: 23320 RVA: 0x0013F936 File Offset: 0x0013DB36
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new MessageDictionaryEnumerator(this, this._dict);
		}

		// Token: 0x06005B19 RID: 23321 RVA: 0x0013F944 File Offset: 0x0013DB44
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B1A RID: 23322 RVA: 0x0013F94B File Offset: 0x0013DB4B
		public virtual void Add(object key, object value)
		{
			if (this.ContainsSpecialKey(key))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidKey"));
			}
			if (this._dict == null)
			{
				this._dict = new Hashtable();
			}
			this._dict.Add(key, value);
		}

		// Token: 0x06005B1B RID: 23323 RVA: 0x0013F986 File Offset: 0x0013DB86
		public virtual void Clear()
		{
			if (this._dict != null)
			{
				this._dict.Clear();
			}
		}

		// Token: 0x06005B1C RID: 23324 RVA: 0x0013F99B File Offset: 0x0013DB9B
		public virtual void Remove(object key)
		{
			if (this.ContainsSpecialKey(key) || this._dict == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidKey"));
			}
			this._dict.Remove(key);
		}

		// Token: 0x17000F5D RID: 3933
		// (get) Token: 0x06005B1D RID: 23325 RVA: 0x0013F9CC File Offset: 0x0013DBCC
		public virtual ICollection Keys
		{
			get
			{
				int num = this._keys.Length;
				ICollection collection = (this._dict != null) ? this._dict.Keys : null;
				if (collection != null)
				{
					num += collection.Count;
				}
				ArrayList arrayList = new ArrayList(num);
				for (int i = 0; i < this._keys.Length; i++)
				{
					arrayList.Add(this._keys[i]);
				}
				if (collection != null)
				{
					arrayList.AddRange(collection);
				}
				return arrayList;
			}
		}

		// Token: 0x17000F5E RID: 3934
		// (get) Token: 0x06005B1E RID: 23326 RVA: 0x0013FA3C File Offset: 0x0013DC3C
		public virtual ICollection Values
		{
			get
			{
				int num = this._keys.Length;
				ICollection collection = (this._dict != null) ? this._dict.Keys : null;
				if (collection != null)
				{
					num += collection.Count;
				}
				ArrayList arrayList = new ArrayList(num);
				for (int i = 0; i < this._keys.Length; i++)
				{
					arrayList.Add(this.GetMessageValue(i));
				}
				if (collection != null)
				{
					arrayList.AddRange(collection);
				}
				return arrayList;
			}
		}

		// Token: 0x17000F5F RID: 3935
		// (get) Token: 0x06005B1F RID: 23327 RVA: 0x0013FAA8 File Offset: 0x0013DCA8
		public virtual int Count
		{
			get
			{
				if (this._dict != null)
				{
					return this._dict.Count + this._keys.Length;
				}
				return this._keys.Length;
			}
		}

		// Token: 0x0400293D RID: 10557
		internal string[] _keys;

		// Token: 0x0400293E RID: 10558
		internal IDictionary _dict;
	}
}
