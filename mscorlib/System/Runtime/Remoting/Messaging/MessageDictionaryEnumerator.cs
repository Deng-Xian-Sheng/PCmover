using System;
using System.Collections;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000865 RID: 2149
	internal class MessageDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x06005B20 RID: 23328 RVA: 0x0013FACF File Offset: 0x0013DCCF
		public MessageDictionaryEnumerator(MessageDictionary md, IDictionary hashtable)
		{
			this._md = md;
			if (hashtable != null)
			{
				this._enumHash = hashtable.GetEnumerator();
				return;
			}
			this._enumHash = null;
		}

		// Token: 0x17000F60 RID: 3936
		// (get) Token: 0x06005B21 RID: 23329 RVA: 0x0013FAFC File Offset: 0x0013DCFC
		public object Key
		{
			get
			{
				if (this.i < 0)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
				}
				if (this.i < this._md._keys.Length)
				{
					return this._md._keys[this.i];
				}
				return this._enumHash.Key;
			}
		}

		// Token: 0x17000F61 RID: 3937
		// (get) Token: 0x06005B22 RID: 23330 RVA: 0x0013FB58 File Offset: 0x0013DD58
		public object Value
		{
			get
			{
				if (this.i < 0)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
				}
				if (this.i < this._md._keys.Length)
				{
					return this._md.GetMessageValue(this.i);
				}
				return this._enumHash.Value;
			}
		}

		// Token: 0x06005B23 RID: 23331 RVA: 0x0013FBB0 File Offset: 0x0013DDB0
		public bool MoveNext()
		{
			if (this.i == -2)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
			this.i++;
			if (this.i < this._md._keys.Length)
			{
				return true;
			}
			if (this._enumHash != null && this._enumHash.MoveNext())
			{
				return true;
			}
			this.i = -2;
			return false;
		}

		// Token: 0x17000F62 RID: 3938
		// (get) Token: 0x06005B24 RID: 23332 RVA: 0x0013FC1C File Offset: 0x0013DE1C
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x17000F63 RID: 3939
		// (get) Token: 0x06005B25 RID: 23333 RVA: 0x0013FC29 File Offset: 0x0013DE29
		public DictionaryEntry Entry
		{
			get
			{
				return new DictionaryEntry(this.Key, this.Value);
			}
		}

		// Token: 0x06005B26 RID: 23334 RVA: 0x0013FC3C File Offset: 0x0013DE3C
		public void Reset()
		{
			this.i = -1;
			if (this._enumHash != null)
			{
				this._enumHash.Reset();
			}
		}

		// Token: 0x0400293F RID: 10559
		private int i = -1;

		// Token: 0x04002940 RID: 10560
		private IDictionaryEnumerator _enumHash;

		// Token: 0x04002941 RID: 10561
		private MessageDictionary _md;
	}
}
