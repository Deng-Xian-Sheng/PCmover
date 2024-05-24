using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009CD RID: 2509
	[Serializable]
	internal sealed class DictionaryKeyEnumerator<TKey, TValue> : IEnumerator<!0>, IDisposable, IEnumerator
	{
		// Token: 0x060063E3 RID: 25571 RVA: 0x00154CEA File Offset: 0x00152EEA
		public DictionaryKeyEnumerator(IDictionary<TKey, TValue> dictionary)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			this.dictionary = dictionary;
			this.enumeration = dictionary.GetEnumerator();
		}

		// Token: 0x060063E4 RID: 25572 RVA: 0x00154D13 File Offset: 0x00152F13
		void IDisposable.Dispose()
		{
			this.enumeration.Dispose();
		}

		// Token: 0x060063E5 RID: 25573 RVA: 0x00154D20 File Offset: 0x00152F20
		public bool MoveNext()
		{
			return this.enumeration.MoveNext();
		}

		// Token: 0x17001147 RID: 4423
		// (get) Token: 0x060063E6 RID: 25574 RVA: 0x00154D2D File Offset: 0x00152F2D
		object IEnumerator.Current
		{
			get
			{
				return ((IEnumerator<!0>)this).Current;
			}
		}

		// Token: 0x17001148 RID: 4424
		// (get) Token: 0x060063E7 RID: 25575 RVA: 0x00154D3C File Offset: 0x00152F3C
		public TKey Current
		{
			get
			{
				KeyValuePair<TKey, TValue> keyValuePair = this.enumeration.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x060063E8 RID: 25576 RVA: 0x00154D5C File Offset: 0x00152F5C
		public void Reset()
		{
			this.enumeration = this.dictionary.GetEnumerator();
		}

		// Token: 0x04002CDF RID: 11487
		private readonly IDictionary<TKey, TValue> dictionary;

		// Token: 0x04002CE0 RID: 11488
		private IEnumerator<KeyValuePair<TKey, TValue>> enumeration;
	}
}
