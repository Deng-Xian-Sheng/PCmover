using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200040A RID: 1034
	[DataContract]
	public class AffectedRequest : DevToolsDomainEntityBase
	{
		// Token: 0x17000AF2 RID: 2802
		// (get) Token: 0x06001E2A RID: 7722 RVA: 0x0002295A File Offset: 0x00020B5A
		// (set) Token: 0x06001E2B RID: 7723 RVA: 0x00022962 File Offset: 0x00020B62
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; set; }

		// Token: 0x17000AF3 RID: 2803
		// (get) Token: 0x06001E2C RID: 7724 RVA: 0x0002296B File Offset: 0x00020B6B
		// (set) Token: 0x06001E2D RID: 7725 RVA: 0x00022973 File Offset: 0x00020B73
		[DataMember(Name = "url", IsRequired = false)]
		public string Url { get; set; }
	}
}
