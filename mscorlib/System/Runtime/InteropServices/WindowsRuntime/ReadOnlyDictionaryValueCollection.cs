using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E6 RID: 2534
	[DebuggerDisplay("Count = {Count}")]
	[Serializable]
	internal sealed class ReadOnlyDictionaryValueCollection<TKey, TValue> : IEnumerable<!1>, IEnumerable
	{
		// Token: 0x0600648E RID: 25742 RVA: 0x00156C07 File Offset: 0x00154E07
		public ReadOnlyDictionaryValueCollection(IReadOnlyDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
		}

		// Token: 0x0600648F RID: 25743 RVA: 0x00156C24 File Offset: 0x00154E24
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<!1>)this).GetEnumerator();
		}

		// Token: 0x06006490 RID: 25744 RVA: 0x00156C2C File Offset: 0x00154E2C
		public IEnumerator<TValue> GetEnumerator()
		{
			return new ReadOnlyDictionaryValueEnumerator<TKey, TValue>(this.dictionary);
		}

		// Token: 0x04002CEE RID: 11502
		private readonly IReadOnlyDictionary<TKey, TValue> dictionary;
	}
}
