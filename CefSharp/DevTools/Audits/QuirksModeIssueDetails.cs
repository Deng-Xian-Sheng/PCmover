using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000423 RID: 1059
	[DataContract]
	public class QuirksModeIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B3D RID: 2877
		// (get) Token: 0x06001ECD RID: 7885 RVA: 0x00023039 File Offset: 0x00021239
		// (set) Token: 0x06001ECE RID: 7886 RVA: 0x00023041 File Offset: 0x00021241
		[DataMember(Name = "isLimitedQuirksMode", IsRequired = true)]
		public bool IsLimitedQuirksMode { get; set; }

		// Token: 0x17000B3E RID: 2878
		// (get) Token: 0x06001ECF RID: 7887 RVA: 0x0002304A File Offset: 0x0002124A
		// (set) Token: 0x06001ED0 RID: 7888 RVA: 0x00023052 File Offset: 0x00021252
		[DataMember(Name = "documentNodeId", IsRequired = true)]
		public int DocumentNodeId { get; set; }

		// Token: 0x17000B3F RID: 2879
		// (get) Token: 0x06001ED1 RID: 7889 RVA: 0x0002305B File Offset: 0x0002125B
		// (set) Token: 0x06001ED2 RID: 7890 RVA: 0x00023063 File Offset: 0x00021263
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000B40 RID: 2880
		// (get) Token: 0x06001ED3 RID: 7891 RVA: 0x0002306C File Offset: 0x0002126C
		// (set) Token: 0x06001ED4 RID: 7892 RVA: 0x00023074 File Offset: 0x00021274
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; set; }

		// Token: 0x17000B41 RID: 2881
		// (get) Token: 0x06001ED5 RID: 7893 RVA: 0x0002307D File Offset: 0x0002127D
		// (set) Token: 0x06001ED6 RID: 7894 RVA: 0x00023085 File Offset: 0x00021285
		[DataMember(Name = "loaderId", IsRequired = true)]
		public string LoaderId { get; set; }
	}
}
