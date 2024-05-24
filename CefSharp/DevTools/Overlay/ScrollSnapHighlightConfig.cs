using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000298 RID: 664
	[DataContract]
	public class ScrollSnapHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x0600130D RID: 4877 RVA: 0x00017852 File Offset: 0x00015A52
		// (set) Token: 0x0600130E RID: 4878 RVA: 0x0001785A File Offset: 0x00015A5A
		[DataMember(Name = "scrollSnapContainerHighlightConfig", IsRequired = true)]
		public ScrollSnapContainerHighlightConfig ScrollSnapContainerHighlightConfig { get; set; }

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x0600130F RID: 4879 RVA: 0x00017863 File Offset: 0x00015A63
		// (set) Token: 0x06001310 RID: 4880 RVA: 0x0001786B File Offset: 0x00015A6B
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }
	}
}
