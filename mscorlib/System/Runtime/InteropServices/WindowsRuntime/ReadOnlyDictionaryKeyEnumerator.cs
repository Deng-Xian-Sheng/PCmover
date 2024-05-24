using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E5 RID: 2533
	[Serializable]
	internal sealed class ReadOnlyDictionaryKeyEnumerator<TKey, TValue> : IEnumerator<!0>, IDisposable, IEnumerator
	{
		// Token: 0x06006488 RID: 25736 RVA: 0x00156B82 File Offset: 0x00154D82
		public ReadOnlyDictionaryKeyEnumerator(IReadOnlyDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
			this.enumeration = dictionary.GetEnumerator();
		}

		// Token: 0x06006489 RID: 25737 RVA: 0x00156BAB File Offset: 0x00154DAB
		void IDisposable.Dispose()
		{
			this.enumeration.Dispose();
		}

		// Token: 0x0600648A RID: 25738 RVA: 0x00156BB8 File Offset: 0x00154DB8
		public bool MoveNext()
		{
			return this.enumeration.MoveNext();
		}

		// Token: 0x17001153 RID: 4435
		// (get) Token: 0x0600648B RID: 25739 RVA: 0x00156BC5 File Offset: 0x00154DC5
		object IEnumerator.Current
		{
			get
			{
				return ((IEnumerator<!0>)this).Current;
			}
		}

		// Token: 0x17001154 RID: 4436
		// (get) Token: 0x0600648C RID: 25740 RVA: 0x00156BD4 File Offset: 0x00154DD4
		public TKey Current
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this.enumeration.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x0600648D RID: 25741 RVA: 0x00156BF4 File Offset: 0x00154DF4
		public void Reset()
		{
			this.enumeration = this.dictionary.GetEnumerator();
		}

		// Token: 0x04002CEC RID: 11500
		private readonly IReadOnlyDictionary<TKey, TValue> dictionary;

		// Token: 0x04002CED RID: 11501
		private IEnumerator<KeyValuePair<TKey, TValue>> enumeration;
	}
}
