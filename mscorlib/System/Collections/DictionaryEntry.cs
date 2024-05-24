using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x02000498 RID: 1176
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct DictionaryEntry
	{
		// Token: 0x0600389D RID: 14493 RVA: 0x000D9BA3 File Offset: 0x000D7DA3
		[__DynamicallyInvokable]
		public DictionaryEntry(object key, object value)
		{
			this._key = key;
			this._value = value;
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x0600389E RID: 14494 RVA: 0x000D9BB3 File Offset: 0x000D7DB3
		// (set) Token: 0x0600389F RID: 14495 RVA: 0x000D9BBB File Offset: 0x000D7DBB
		[__DynamicallyInvokable]
		public object Key
		{
			[__DynamicallyInvokable]
			get
			{
				return this._key;
			}
			[__DynamicallyInvokable]
			set
			{
				this._key = value;
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x060038A0 RID: 14496 RVA: 0x000D9BC4 File Offset: 0x000D7DC4
		// (set) Token: 0x060038A1 RID: 14497 RVA: 0x000D9BCC File Offset: 0x000D7DCC
		[__DynamicallyInvokable]
		public object Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._value;
			}
			[__DynamicallyInvokable]
			set
			{
				this._value = value;
			}
		}

		// Token: 0x040018F9 RID: 6393
		private object _key;

		// Token: 0x040018FA RID: 6394
		private object _value;
	}
}
