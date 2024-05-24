using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000296 RID: 662
	[DataContract]
	public class FlexNodeHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x060012FF RID: 4863 RVA: 0x000177DC File Offset: 0x000159DC
		// (set) Token: 0x06001300 RID: 4864 RVA: 0x000177E4 File Offset: 0x000159E4
		[DataMember(Name = "flexContainerHighlightConfig", IsRequired = true)]
		public FlexContainerHighlightConfig FlexContainerHighlightConfig { get; set; }

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06001301 RID: 4865 RVA: 0x000177ED File Offset: 0x000159ED
		// (set) Token: 0x06001302 RID: 4866 RVA: 0x000177F5 File Offset: 0x000159F5
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }
	}
}
