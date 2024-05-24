using System;

namespace Prism.Regions
{
	// Token: 0x02000009 RID: 9
	public interface IConfirmNavigationRequest : INavigationAware
	{
		// Token: 0x06000028 RID: 40
		void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback);
	}
}
