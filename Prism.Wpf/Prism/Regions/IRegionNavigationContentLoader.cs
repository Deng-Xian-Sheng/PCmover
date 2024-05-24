using System;

namespace Prism.Regions
{
	// Token: 0x02000015 RID: 21
	public interface IRegionNavigationContentLoader
	{
		// Token: 0x06000064 RID: 100
		object LoadContent(IRegion region, NavigationContext navigationContext);
	}
}
