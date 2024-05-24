using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200027C RID: 636
	[DataContract]
	public class GetNavigationHistoryResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x060011F3 RID: 4595 RVA: 0x0001615F File Offset: 0x0001435F
		// (set) Token: 0x060011F4 RID: 4596 RVA: 0x00016167 File Offset: 0x00014367
		[DataMember]
		internal int currentIndex { get; set; }

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x060011F5 RID: 4597 RVA: 0x00016170 File Offset: 0x00014370
		public int CurrentIndex
		{
			get
			{
				return this.currentIndex;
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x060011F6 RID: 4598 RVA: 0x00016178 File Offset: 0x00014378
		// (set) Token: 0x060011F7 RID: 4599 RVA: 0x00016180 File Offset: 0x00014380
		[DataMember]
		internal IList<NavigationEntry> entries { get; set; }

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x060011F8 RID: 4600 RVA: 0x00016189 File Offset: 0x00014389
		public IList<NavigationEntry> Entries
		{
			get
			{
				return this.entries;
			}
		}
	}
}
