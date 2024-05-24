using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x02000140 RID: 320
	internal class ShellPropertyDescriptionsCache
	{
		// Token: 0x06000DDC RID: 3548 RVA: 0x00033D68 File Offset: 0x00031F68
		private ShellPropertyDescriptionsCache()
		{
			this.propsDictionary = new Dictionary<PropertyKey, ShellPropertyDescription>();
		}

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00033D80 File Offset: 0x00031F80
		public static ShellPropertyDescriptionsCache Cache
		{
			get
			{
				if (ShellPropertyDescriptionsCache.cacheInstance == null)
				{
					ShellPropertyDescriptionsCache.cacheInstance = new ShellPropertyDescriptionsCache();
				}
				return ShellPropertyDescriptionsCache.cacheInstance;
			}
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00033DB4 File Offset: 0x00031FB4
		public ShellPropertyDescription GetPropertyDescription(PropertyKey key)
		{
			if (!this.propsDictionary.ContainsKey(key))
			{
				this.propsDictionary.Add(key, new ShellPropertyDescription(key));
			}
			return this.propsDictionary[key];
		}

		// Token: 0x04000577 RID: 1399
		private IDictionary<PropertyKey, ShellPropertyDescription> propsDictionary;

		// Token: 0x04000578 RID: 1400
		private static ShellPropertyDescriptionsCache cacheInstance;
	}
}
