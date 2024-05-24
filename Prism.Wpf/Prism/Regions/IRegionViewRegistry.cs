using System;
using System.Collections.Generic;

namespace Prism.Regions
{
	// Token: 0x02000019 RID: 25
	public interface IRegionViewRegistry
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600007B RID: 123
		// (remove) Token: 0x0600007C RID: 124
		event EventHandler<ViewRegisteredEventArgs> ContentRegistered;

		// Token: 0x0600007D RID: 125
		IEnumerable<object> GetContents(string regionName);

		// Token: 0x0600007E RID: 126
		void RegisterViewWithRegion(string regionName, Type viewType);

		// Token: 0x0600007F RID: 127
		void RegisterViewWithRegion(string regionName, Func<object> getContentDelegate);
	}
}
