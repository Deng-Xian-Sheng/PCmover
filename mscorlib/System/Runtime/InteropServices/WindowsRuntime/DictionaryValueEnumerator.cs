using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009CF RID: 2511
	[Serializable]
	internal sealed class DictionaryValueEnumerator<TKey, TValue> : IEnumerator<TValue>, IDisposable, IEnumerator
	{
		// Token: 0x060063F3 RID: 25587 RVA: 0x00154EF6 File Offset: 0x001530F6
		public DictionaryValueEnumerator(IDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
			this.enumeration = dictionary.GetEnumerator();
		}

		// Token: 0x060063F4 RID: 25588 RVA: 0x00154F1F File Offset: 0x0015311F
		void IDisposable.Dispose()
		{
			this.enumeration.Dispose();
		}

		// Token: 0x060063F5 RID: 25589 RVA: 0x00154F2C File Offset: 0x0015312C
		public bool MoveNext()
		{
			return this.enumeration.MoveNext();
		}

		// Token: 0x1700114B RID: 4427
		// (get) Token: 0x060063F6 RID: 25590 RVA: 0x00154F39 File Offset: 0x00153139
		object IEnumerator.Current
		{
			get
			{
				return ((IEnumerator<TValue>)this).Current;
			}
		}

		// Token: 0x1700114C RID: 4428
		// (get) Token: 0x060063F7 RID: 25591 RVA: 0x00154F48 File Offset: 0x00153148
		public TValue Current
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this.enumeration.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x060063F8 RID: 25592 RVA: 0x00154F68 File Offset: 0x00153168
		public void Reset()
		{
			this.enumeration = this.dictionary.GetEnumerator();
		}

		// Token: 0x04002CE2 RID: 11490
		private readonly IDictionary<TKey, TValue> dictionary;

		// Token: 0x04002CE3 RID: 11491
		private IEnumerator<KeyValuePair<TKey, TValue>> enumeration;
	}
}
