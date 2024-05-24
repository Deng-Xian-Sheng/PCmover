using System;

namespace Prism.Regions
{
	// Token: 0x02000018 RID: 24
	public interface IRegionNavigationService : INavigateAsync
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000072 RID: 114
		// (set) Token: 0x06000073 RID: 115
		IRegion Region { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000074 RID: 116
		IRegionNavigationJournal Journal { get; }

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000075 RID: 117
		// (remove) Token: 0x06000076 RID: 118
		event EventHandler<RegionNavigationEventArgs> Navigating;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000077 RID: 119
		// (remove) Token: 0x06000078 RID: 120
		event EventHandler<RegionNavigationEventArgs> Navigated;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000079 RID: 121
		// (remove) Token: 0x0600007A RID: 122
		event EventHandler<RegionNavigationFailedEventArgs> NavigationFailed;
	}
}
