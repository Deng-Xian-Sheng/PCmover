using System;
using System.Collections.Concurrent;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000798 RID: 1944
	internal sealed class NameCache
	{
		// Token: 0x0600544D RID: 21581 RVA: 0x001291BC File Offset: 0x001273BC
		internal object GetCachedValue(string name)
		{
			this.name = name;
			object result;
			if (!NameCache.ht.TryGetValue(name, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600544E RID: 21582 RVA: 0x001291E2 File Offset: 0x001273E2
		internal void SetCachedValue(object value)
		{
			NameCache.ht[this.name] = value;
		}

		// Token: 0x0400264F RID: 9807
		private static ConcurrentDictionary<string, object> ht = new ConcurrentDictionary<string, object>();

		// Token: 0x04002650 RID: 9808
		private string name;
	}
}
