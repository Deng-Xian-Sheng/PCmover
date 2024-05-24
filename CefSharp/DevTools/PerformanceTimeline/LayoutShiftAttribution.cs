using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.PerformanceTimeline
{
	// Token: 0x02000223 RID: 547
	[DataContract]
	public class LayoutShiftAttribution : DevToolsDomainEntityBase
	{
		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x00014C53 File Offset: 0x00012E53
		// (set) Token: 0x06000FDB RID: 4059 RVA: 0x00014C5B File Offset: 0x00012E5B
		[DataMember(Name = "previousRect", IsRequired = true)]
		public Rect PreviousRect { get; set; }

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x00014C64 File Offset: 0x00012E64
		// (set) Token: 0x06000FDD RID: 4061 RVA: 0x00014C6C File Offset: 0x00012E6C
		[DataMember(Name = "currentRect", IsRequired = true)]
		public Rect CurrentRect { get; set; }

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06000FDE RID: 4062 RVA: 0x00014C75 File Offset: 0x00012E75
		// (set) Token: 0x06000FDF RID: 4063 RVA: 0x00014C7D File Offset: 0x00012E7D
		[DataMember(Name = "nodeId", IsRequired = false)]
		public int? NodeId { get; set; }
	}
}
