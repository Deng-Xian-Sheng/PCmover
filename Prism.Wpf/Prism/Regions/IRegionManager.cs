using System;

namespace Prism.Regions
{
	// Token: 0x02000012 RID: 18
	public interface IRegionManager
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000052 RID: 82
		IRegionCollection Regions { get; }

		// Token: 0x06000053 RID: 83
		IRegionManager CreateRegionManager();

		// Token: 0x06000054 RID: 84
		IRegionManager AddToRegion(string regionName, object view);

		// Token: 0x06000055 RID: 85
		IRegionManager RegisterViewWithRegion(string regionName, Type viewType);

		// Token: 0x06000056 RID: 86
		IRegionManager RegisterViewWithRegion(string regionName, Func<object> getContentDelegate);

		// Token: 0x06000057 RID: 87
		void RequestNavigate(string regionName, Uri source, Action<NavigationResult> navigationCallback);

		// Token: 0x06000058 RID: 88
		void RequestNavigate(string regionName, Uri source);

		// Token: 0x06000059 RID: 89
		void RequestNavigate(string regionName, string source, Action<NavigationResult> navigationCallback);

		// Token: 0x0600005A RID: 90
		void RequestNavigate(string regionName, string source);

		// Token: 0x0600005B RID: 91
		void RequestNavigate(string regionName, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters);

		// Token: 0x0600005C RID: 92
		void RequestNavigate(string regionName, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters);

		// Token: 0x0600005D RID: 93
		void RequestNavigate(string regionName, Uri target, NavigationParameters navigationParameters);

		// Token: 0x0600005E RID: 94
		void RequestNavigate(string regionName, string target, NavigationParameters navigationParameters);
	}
}
