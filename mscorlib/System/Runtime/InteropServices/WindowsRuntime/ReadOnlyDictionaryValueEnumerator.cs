using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E7 RID: 2535
	[Serializable]
	internal sealed class ReadOnlyDictionaryValueEnumerator<TKey, TValue> : IEnumerator<TValue>, IDisposable, IEnumerator
	{
		// Token: 0x06006491 RID: 25745 RVA: 0x00156C39 File Offset: 0x00154E39
		public ReadOnlyDictionaryValueEnumerator(IReadOnlyDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
			this.enumeration = dictionary.GetEnumerator();
		}

		// Token: 0x06006492 RID: 25746 RVA: 0x00156C62 File Offset: 0x00154E62
		void IDisposable.Dispose()
		{
			this.enumeration.Dispose();
		}

		// Token: 0x06006493 RID: 25747 RVA: 0x00156C6F File Offset: 0x00154E6F
		public bool MoveNext()
		{
			return this.enumeration.MoveNext();
		}

		// Token: 0x17001155 RID: 4437
		// (get) Token: 0x06006494 RID: 25748 RVA: 0x00156C7C File Offset: 0x00154E7C
		object IEnumerator.Current
		{
			get
			{
				return ((IEnumerator<TValue>)this).Current;
			}
		}

		// Token: 0x17001156 RID: 4438
		// (get) Token: 0x06006495 RID: 25749 RVA: 0x00156C8C File Offset: 0x00154E8C
		public TValue Current
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this.enumeration.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x06006496 RID: 25750 RVA: 0x00156CAC File Offset: 0x00154EAC
		public void Reset()
		{
			this.enumeration = this.dictionary.GetEnumerator();
		}

		// Token: 0x04002CEF RID: 11503
		private readonly IReadOnlyDictionary<TKey, TValue> dictionary;

		// Token: 0x04002CF0 RID: 11504
		private IEnumerator<KeyValuePair<TKey, TValue>> enumeration;
	}
}
