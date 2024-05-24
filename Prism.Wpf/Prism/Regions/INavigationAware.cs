using System;

namespace Prism.Regions
{
	// Token: 0x0200000B RID: 11
	public interface INavigationAware
	{
		// Token: 0x0600002B RID: 43
		void OnNavigatedTo(NavigationContext navigationContext);

		// Token: 0x0600002C RID: 44
		bool IsNavigationTarget(NavigationContext navigationContext);

		// Token: 0x0600002D RID: 45
		void OnNavigatedFrom(NavigationContext navigationContext);
	}
}
