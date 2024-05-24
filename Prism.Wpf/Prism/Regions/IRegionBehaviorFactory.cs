using System;
using System.Collections;
using System.Collections.Generic;

namespace Prism.Regions
{
	// Token: 0x02000010 RID: 16
	public interface IRegionBehaviorFactory : IEnumerable<string>, IEnumerable
	{
		// Token: 0x0600004A RID: 74
		void AddIfMissing(string behaviorKey, Type behaviorType);

		// Token: 0x0600004B RID: 75
		bool ContainsKey(string behaviorKey);

		// Token: 0x0600004C RID: 76
		IRegionBehavior CreateFromKey(string key);
	}
}
