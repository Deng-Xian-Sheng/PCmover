using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A5 RID: 933
	[DataContract]
	public class QuerySelectorAllResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06001B2C RID: 6956 RVA: 0x0001F3E4 File Offset: 0x0001D5E4
		// (set) Token: 0x06001B2D RID: 6957 RVA: 0x0001F3EC File Offset: 0x0001D5EC
		[DataMember]
		internal int[] nodeIds { get; set; }

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06001B2E RID: 6958 RVA: 0x0001F3F5 File Offset: 0x0001D5F5
		public int[] NodeIds
		{
			get
			{
				return this.nodeIds;
			}
		}
	}
}
