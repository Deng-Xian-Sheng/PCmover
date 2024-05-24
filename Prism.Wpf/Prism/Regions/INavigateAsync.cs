using System;

namespace Prism.Regions
{
	// Token: 0x0200000A RID: 10
	public interface INavigateAsync
	{
		// Token: 0x06000029 RID: 41
		void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback);

		// Token: 0x0600002A RID: 42
		void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters);
	}
}
