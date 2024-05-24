using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200029A RID: 666
	[DataContract]
	public class ContainerQueryHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06001319 RID: 4889 RVA: 0x000178B7 File Offset: 0x00015AB7
		// (set) Token: 0x0600131A RID: 4890 RVA: 0x000178BF File Offset: 0x00015ABF
		[DataMember(Name = "containerQueryContainerHighlightConfig", IsRequired = true)]
		public ContainerQueryContainerHighlightConfig ContainerQueryContainerHighlightConfig { get; set; }

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x000178C8 File Offset: 0x00015AC8
		// (set) Token: 0x0600131C RID: 4892 RVA: 0x000178D0 File Offset: 0x00015AD0
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }
	}
}
