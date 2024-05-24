using System;
using System.ComponentModel;

namespace Prism.Regions
{
	// Token: 0x0200000C RID: 12
	public interface IRegion : INavigateAsync, INotifyPropertyChanged
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002E RID: 46
		IViewsCollection Views { get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002F RID: 47
		IViewsCollection ActiveViews { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000030 RID: 48
		// (set) Token: 0x06000031 RID: 49
		object Context { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50
		// (set) Token: 0x06000033 RID: 51
		string Name { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000034 RID: 52
		// (set) Token: 0x06000035 RID: 53
		Comparison<object> SortComparison { get; set; }

		// Token: 0x06000036 RID: 54
		IRegionManager Add(object view);

		// Token: 0x06000037 RID: 55
		IRegionManager Add(object view, string viewName);

		// Token: 0x06000038 RID: 56
		IRegionManager Add(object view, string viewName, bool createRegionManagerScope);

		// Token: 0x06000039 RID: 57
		void Remove(object view);

		// Token: 0x0600003A RID: 58
		void RemoveAll();

		// Token: 0x0600003B RID: 59
		void Activate(object view);

		// Token: 0x0600003C RID: 60
		void Deactivate(object view);

		// Token: 0x0600003D RID: 61
		object GetView(string viewName);

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003E RID: 62
		// (set) Token: 0x0600003F RID: 63
		IRegionManager RegionManager { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000040 RID: 64
		IRegionBehaviorCollection Behaviors { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000041 RID: 65
		// (set) Token: 0x06000042 RID: 66
		IRegionNavigationService NavigationService { get; set; }
	}
}
