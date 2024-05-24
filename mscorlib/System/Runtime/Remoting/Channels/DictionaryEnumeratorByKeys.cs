using System;
using System.Collections;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000851 RID: 2129
	internal class DictionaryEnumeratorByKeys : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x06005A48 RID: 23112 RVA: 0x0013D8ED File Offset: 0x0013BAED
		public DictionaryEnumeratorByKeys(IDictionary properties)
		{
			this._properties = properties;
			this._keyEnum = properties.Keys.GetEnumerator();
		}

		// Token: 0x06005A49 RID: 23113 RVA: 0x0013D90D File Offset: 0x0013BB0D
		public bool MoveNext()
		{
			return this._keyEnum.MoveNext();
		}

		// Token: 0x06005A4A RID: 23114 RVA: 0x0013D91A File Offset: 0x0013BB1A
		public void Reset()
		{
			this._keyEnum.Reset();
		}

		// Token: 0x17000F0E RID: 3854
		// (get) Token: 0x06005A4B RID: 23115 RVA: 0x0013D927 File Offset: 0x0013BB27
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x17000F0F RID: 3855
		// (get) Token: 0x06005A4C RID: 23116 RVA: 0x0013D934 File Offset: 0x0013BB34
		public DictionaryEntry Entry
		{
			get
			{
				return new DictionaryEntry(this.Key, this.Value);
			}
		}

		// Token: 0x17000F10 RID: 3856
		// (get) Token: 0x06005A4D RID: 23117 RVA: 0x0013D947 File Offset: 0x0013BB47
		public object Key
		{
			get
			{
				return this._keyEnum.Current;
			}
		}

		// Token: 0x17000F11 RID: 3857
		// (get) Token: 0x06005A4E RID: 23118 RVA: 0x0013D954 File Offset: 0x0013BB54
		public object Value
		{
			get
			{
				return this._properties[this.Key];
			}
		}

		// Token: 0x040028FB RID: 10491
		private IDictionary _properties;

		// Token: 0x040028FC RID: 10492
		private IEnumerator _keyEnum;
	}
}
