using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000248 RID: 584
	[DataContract]
	public class VisualViewport : DevToolsDomainEntityBase
	{
		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x060010BF RID: 4287 RVA: 0x0001560C File Offset: 0x0001380C
		// (set) Token: 0x060010C0 RID: 4288 RVA: 0x00015614 File Offset: 0x00013814
		[DataMember(Name = "offsetX", IsRequired = true)]
		public double OffsetX { get; set; }

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x060010C1 RID: 4289 RVA: 0x0001561D File Offset: 0x0001381D
		// (set) Token: 0x060010C2 RID: 4290 RVA: 0x00015625 File Offset: 0x00013825
		[DataMember(Name = "offsetY", IsRequired = true)]
		public double OffsetY { get; set; }

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x060010C3 RID: 4291 RVA: 0x0001562E File Offset: 0x0001382E
		// (set) Token: 0x060010C4 RID: 4292 RVA: 0x00015636 File Offset: 0x00013836
		[DataMember(Name = "pageX", IsRequired = true)]
		public double PageX { get; set; }

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x060010C5 RID: 4293 RVA: 0x0001563F File Offset: 0x0001383F
		// (set) Token: 0x060010C6 RID: 4294 RVA: 0x00015647 File Offset: 0x00013847
		[DataMember(Name = "pageY", IsRequired = true)]
		public double PageY { get; set; }

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x060010C7 RID: 4295 RVA: 0x00015650 File Offset: 0x00013850
		// (set) Token: 0x060010C8 RID: 4296 RVA: 0x00015658 File Offset: 0x00013858
		[DataMember(Name = "clientWidth", IsRequired = true)]
		public double ClientWidth { get; set; }

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x060010C9 RID: 4297 RVA: 0x00015661 File Offset: 0x00013861
		// (set) Token: 0x060010CA RID: 4298 RVA: 0x00015669 File Offset: 0x00013869
		[DataMember(Name = "clientHeight", IsRequired = true)]
		public double ClientHeight { get; set; }

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x060010CB RID: 4299 RVA: 0x00015672 File Offset: 0x00013872
		// (set) Token: 0x060010CC RID: 4300 RVA: 0x0001567A File Offset: 0x0001387A
		[DataMember(Name = "scale", IsRequired = true)]
		public double Scale { get; set; }

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x060010CD RID: 4301 RVA: 0x00015683 File Offset: 0x00013883
		// (set) Token: 0x060010CE RID: 4302 RVA: 0x0001568B File Offset: 0x0001388B
		[DataMember(Name = "zoom", IsRequired = false)]
		public double? Zoom { get; set; }
	}
}
