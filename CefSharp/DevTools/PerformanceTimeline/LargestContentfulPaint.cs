using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.PerformanceTimeline
{
	// Token: 0x02000222 RID: 546
	[DataContract]
	public class LargestContentfulPaint : DevToolsDomainEntityBase
	{
		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000FCD RID: 4045 RVA: 0x00014BE5 File Offset: 0x00012DE5
		// (set) Token: 0x06000FCE RID: 4046 RVA: 0x00014BED File Offset: 0x00012DED
		[DataMember(Name = "renderTime", IsRequired = true)]
		public double RenderTime { get; set; }

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000FCF RID: 4047 RVA: 0x00014BF6 File Offset: 0x00012DF6
		// (set) Token: 0x06000FD0 RID: 4048 RVA: 0x00014BFE File Offset: 0x00012DFE
		[DataMember(Name = "loadTime", IsRequired = true)]
		public double LoadTime { get; set; }

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x00014C07 File Offset: 0x00012E07
		// (set) Token: 0x06000FD2 RID: 4050 RVA: 0x00014C0F File Offset: 0x00012E0F
		[DataMember(Name = "size", IsRequired = true)]
		public double Size { get; set; }

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x00014C18 File Offset: 0x00012E18
		// (set) Token: 0x06000FD4 RID: 4052 RVA: 0x00014C20 File Offset: 0x00012E20
		[DataMember(Name = "elementId", IsRequired = false)]
		public string ElementId { get; set; }

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000FD5 RID: 4053 RVA: 0x00014C29 File Offset: 0x00012E29
		// (set) Token: 0x06000FD6 RID: 4054 RVA: 0x00014C31 File Offset: 0x00012E31
		[DataMember(Name = "url", IsRequired = false)]
		public string Url { get; set; }

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000FD7 RID: 4055 RVA: 0x00014C3A File Offset: 0x00012E3A
		// (set) Token: 0x06000FD8 RID: 4056 RVA: 0x00014C42 File Offset: 0x00012E42
		[DataMember(Name = "nodeId", IsRequired = false)]
		public int? NodeId { get; set; }
	}
}
