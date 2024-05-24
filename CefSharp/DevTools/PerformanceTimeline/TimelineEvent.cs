using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.PerformanceTimeline
{
	// Token: 0x02000225 RID: 549
	[DataContract]
	public class TimelineEvent : DevToolsDomainEntityBase
	{
		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06000FEA RID: 4074 RVA: 0x00014CDA File Offset: 0x00012EDA
		// (set) Token: 0x06000FEB RID: 4075 RVA: 0x00014CE2 File Offset: 0x00012EE2
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; set; }

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06000FEC RID: 4076 RVA: 0x00014CEB File Offset: 0x00012EEB
		// (set) Token: 0x06000FED RID: 4077 RVA: 0x00014CF3 File Offset: 0x00012EF3
		[DataMember(Name = "type", IsRequired = true)]
		public string Type { get; set; }

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06000FEE RID: 4078 RVA: 0x00014CFC File Offset: 0x00012EFC
		// (set) Token: 0x06000FEF RID: 4079 RVA: 0x00014D04 File Offset: 0x00012F04
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x00014D0D File Offset: 0x00012F0D
		// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x00014D15 File Offset: 0x00012F15
		[DataMember(Name = "time", IsRequired = true)]
		public double Time { get; set; }

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x00014D1E File Offset: 0x00012F1E
		// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00014D26 File Offset: 0x00012F26
		[DataMember(Name = "duration", IsRequired = false)]
		public double? Duration { get; set; }

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x00014D2F File Offset: 0x00012F2F
		// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x00014D37 File Offset: 0x00012F37
		[DataMember(Name = "lcpDetails", IsRequired = false)]
		public LargestContentfulPaint LcpDetails { get; set; }

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x00014D40 File Offset: 0x00012F40
		// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x00014D48 File Offset: 0x00012F48
		[DataMember(Name = "layoutShiftDetails", IsRequired = false)]
		public LayoutShift LayoutShiftDetails { get; set; }
	}
}
