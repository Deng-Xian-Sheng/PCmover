using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000243 RID: 579
	[DataContract]
	public class ScreencastFrameMetadata : DevToolsDomainEntityBase
	{
		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x0600109B RID: 4251 RVA: 0x000154DC File Offset: 0x000136DC
		// (set) Token: 0x0600109C RID: 4252 RVA: 0x000154E4 File Offset: 0x000136E4
		[DataMember(Name = "offsetTop", IsRequired = true)]
		public double OffsetTop { get; set; }

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x0600109D RID: 4253 RVA: 0x000154ED File Offset: 0x000136ED
		// (set) Token: 0x0600109E RID: 4254 RVA: 0x000154F5 File Offset: 0x000136F5
		[DataMember(Name = "pageScaleFactor", IsRequired = true)]
		public double PageScaleFactor { get; set; }

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x0600109F RID: 4255 RVA: 0x000154FE File Offset: 0x000136FE
		// (set) Token: 0x060010A0 RID: 4256 RVA: 0x00015506 File Offset: 0x00013706
		[DataMember(Name = "deviceWidth", IsRequired = true)]
		public double DeviceWidth { get; set; }

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x0001550F File Offset: 0x0001370F
		// (set) Token: 0x060010A2 RID: 4258 RVA: 0x00015517 File Offset: 0x00013717
		[DataMember(Name = "deviceHeight", IsRequired = true)]
		public double DeviceHeight { get; set; }

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x060010A3 RID: 4259 RVA: 0x00015520 File Offset: 0x00013720
		// (set) Token: 0x060010A4 RID: 4260 RVA: 0x00015528 File Offset: 0x00013728
		[DataMember(Name = "scrollOffsetX", IsRequired = true)]
		public double ScrollOffsetX { get; set; }

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x060010A5 RID: 4261 RVA: 0x00015531 File Offset: 0x00013731
		// (set) Token: 0x060010A6 RID: 4262 RVA: 0x00015539 File Offset: 0x00013739
		[DataMember(Name = "scrollOffsetY", IsRequired = true)]
		public double ScrollOffsetY { get; set; }

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x060010A7 RID: 4263 RVA: 0x00015542 File Offset: 0x00013742
		// (set) Token: 0x060010A8 RID: 4264 RVA: 0x0001554A File Offset: 0x0001374A
		[DataMember(Name = "timestamp", IsRequired = false)]
		public double? Timestamp { get; set; }
	}
}
