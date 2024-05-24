using System;
using System.Globalization;

namespace Prism.Regions
{
	// Token: 0x0200002E RID: 46
	public class RegionNavigationJournalEntry : IRegionNavigationJournalEntry
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00004021 File Offset: 0x00002221
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00004029 File Offset: 0x00002229
		public Uri Uri { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00004032 File Offset: 0x00002232
		// (set) Token: 0x06000131 RID: 305 RVA: 0x0000403A File Offset: 0x0000223A
		public NavigationParameters Parameters { get; set; }

		// Token: 0x06000132 RID: 306 RVA: 0x00004043 File Offset: 0x00002243
		public override string ToString()
		{
			if (this.Uri != null)
			{
				return string.Format(CultureInfo.CurrentCulture, "RegionNavigationJournalEntry:'{0}'", new object[]
				{
					this.Uri.ToString()
				});
			}
			return base.ToString();
		}
	}
}
