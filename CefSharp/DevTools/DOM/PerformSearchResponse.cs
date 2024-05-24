using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A1 RID: 929
	[DataContract]
	public class PerformSearchResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x06001B19 RID: 6937 RVA: 0x0001F347 File Offset: 0x0001D547
		// (set) Token: 0x06001B1A RID: 6938 RVA: 0x0001F34F File Offset: 0x0001D54F
		[DataMember]
		internal string searchId { get; set; }

		// Token: 0x170009CA RID: 2506
		// (get) Token: 0x06001B1B RID: 6939 RVA: 0x0001F358 File Offset: 0x0001D558
		public string SearchId
		{
			get
			{
				return this.searchId;
			}
		}

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06001B1C RID: 6940 RVA: 0x0001F360 File Offset: 0x0001D560
		// (set) Token: 0x06001B1D RID: 6941 RVA: 0x0001F368 File Offset: 0x0001D568
		[DataMember]
		internal int resultCount { get; set; }

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x06001B1E RID: 6942 RVA: 0x0001F371 File Offset: 0x0001D571
		public int ResultCount
		{
			get
			{
				return this.resultCount;
			}
		}
	}
}
