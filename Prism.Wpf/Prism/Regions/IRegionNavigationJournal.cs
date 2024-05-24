using System;

namespace Prism.Regions
{
	// Token: 0x02000016 RID: 22
	public interface IRegionNavigationJournal
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000065 RID: 101
		bool CanGoBack { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000066 RID: 102
		bool CanGoForward { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000067 RID: 103
		IRegionNavigationJournalEntry CurrentEntry { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000068 RID: 104
		// (set) Token: 0x06000069 RID: 105
		INavigateAsync NavigationTarget { get; set; }

		// Token: 0x0600006A RID: 106
		void GoBack();

		// Token: 0x0600006B RID: 107
		void GoForward();

		// Token: 0x0600006C RID: 108
		void RecordNavigation(IRegionNavigationJournalEntry entry);

		// Token: 0x0600006D RID: 109
		void Clear();
	}
}
