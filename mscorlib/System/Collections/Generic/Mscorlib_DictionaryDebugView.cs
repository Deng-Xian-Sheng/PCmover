using System;
using System.Diagnostics;

namespace System.Collections.Generic
{
	// Token: 0x020004CD RID: 1229
	internal sealed class Mscorlib_DictionaryDebugView<K, V>
	{
		// Token: 0x06003ABA RID: 15034 RVA: 0x000DF900 File Offset: 0x000DDB00
		public Mscorlib_DictionaryDebugView(IDictionary<K, V> dictionary)
		{
			if (dictionary == null)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.dictionary);
			}
			this.dict = dictionary;
		}

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x06003ABB RID: 15035 RVA: 0x000DF918 File Offset: 0x000DDB18
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair<K, V>[] Items
		{
			get
			{
				KeyValuePair<K, V>[] array = new KeyValuePair<K, V>[this.dict.Count];
				this.dict.CopyTo(array, 0);
				return array;
			}
		}

		// Token: 0x0400194F RID: 6479
		private IDictionary<K, V> dict;
	}
}
