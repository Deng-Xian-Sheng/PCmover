using System;
using System.Collections;
using System.Collections.Generic;

namespace Prism.Regions
{
	// Token: 0x0200000F RID: 15
	public interface IRegionBehaviorCollection : IEnumerable<KeyValuePair<string, IRegionBehavior>>, IEnumerable
	{
		// Token: 0x06000047 RID: 71
		void Add(string key, IRegionBehavior regionBehavior);

		// Token: 0x06000048 RID: 72
		bool ContainsKey(string key);

		// Token: 0x1700000E RID: 14
		IRegionBehavior this[string key]
		{
			get;
		}
	}
}
