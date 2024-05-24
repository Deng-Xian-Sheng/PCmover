using System;

namespace Prism.Regions
{
	// Token: 0x02000017 RID: 23
	public interface IRegionNavigationJournalEntry
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600006E RID: 110
		// (set) Token: 0x0600006F RID: 111
		Uri Uri { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000070 RID: 112
		// (set) Token: 0x06000071 RID: 113
		NavigationParameters Parameters { get; set; }
	}
}
