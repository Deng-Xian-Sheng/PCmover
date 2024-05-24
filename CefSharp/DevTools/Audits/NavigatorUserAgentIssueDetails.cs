using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000424 RID: 1060
	[DataContract]
	public class NavigatorUserAgentIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B42 RID: 2882
		// (get) Token: 0x06001ED8 RID: 7896 RVA: 0x00023096 File Offset: 0x00021296
		// (set) Token: 0x06001ED9 RID: 7897 RVA: 0x0002309E File Offset: 0x0002129E
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000B43 RID: 2883
		// (get) Token: 0x06001EDA RID: 7898 RVA: 0x000230A7 File Offset: 0x000212A7
		// (set) Token: 0x06001EDB RID: 7899 RVA: 0x000230AF File Offset: 0x000212AF
		[DataMember(Name = "location", IsRequired = false)]
		public SourceCodeLocation Location { get; set; }
	}
}
