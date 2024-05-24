using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000295 RID: 661
	[DataContract]
	public class GridNodeHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x060012FA RID: 4858 RVA: 0x000177B2 File Offset: 0x000159B2
		// (set) Token: 0x060012FB RID: 4859 RVA: 0x000177BA File Offset: 0x000159BA
		[DataMember(Name = "gridHighlightConfig", IsRequired = true)]
		public GridHighlightConfig GridHighlightConfig { get; set; }

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x060012FC RID: 4860 RVA: 0x000177C3 File Offset: 0x000159C3
		// (set) Token: 0x060012FD RID: 4861 RVA: 0x000177CB File Offset: 0x000159CB
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }
	}
}
