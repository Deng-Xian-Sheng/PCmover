using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E4 RID: 2532
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	internal sealed class ReadOnlyDictionaryKeyCollection<TKey, TValue> : IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06006485 RID: 25733 RVA: 0x00156B50 File Offset: 0x00154D50
		public ReadOnlyDictionaryKeyCollection(IReadOnlyDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
		}

		// Token: 0x06006486 RID: 25734 RVA: 0x00156B6D File Offset: 0x00154D6D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<!0>)this).GetEnumerator();
		}

		// Token: 0x06006487 RID: 25735 RVA: 0x00156B75 File Offset: 0x00154D75
		public IEnumerator<TKey> GetEnumerator()
		{
			return new ReadOnlyDictionaryKeyEnumerator<TKey, TValue>(this.dictionary);
		}

		// Token: 0x04002CEB RID: 11499
		private readonly IReadOnlyDictionary<TKey, TValue> dictionary;
	}
}
