using System;
using System.Windows;

namespace Prism.Regions
{
	// Token: 0x02000013 RID: 19
	public interface IRegionManagerAccessor
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600005F RID: 95
		// (remove) Token: 0x06000060 RID: 96
		event EventHandler UpdatingRegions;

		// Token: 0x06000061 RID: 97
		string GetRegionName(DependencyObject element);

		// Token: 0x06000062 RID: 98
		IRegionManager GetRegionManager(DependencyObject element);
	}
}
