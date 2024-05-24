using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A3 RID: 931
	[DataContract]
	public class PushNodesByBackendIdsToFrontendResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06001B24 RID: 6948 RVA: 0x0001F3A2 File Offset: 0x0001D5A2
		// (set) Token: 0x06001B25 RID: 6949 RVA: 0x0001F3AA File Offset: 0x0001D5AA
		[DataMember]
		internal int[] nodeIds { get; set; }

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x06001B26 RID: 6950 RVA: 0x0001F3B3 File Offset: 0x0001D5B3
		public int[] NodeIds
		{
			get
			{
				return this.nodeIds;
			}
		}
	}
}
