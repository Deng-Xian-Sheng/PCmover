using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000155 RID: 341
	[DataContract]
	public class ProfileNode : DevToolsDomainEntityBase
	{
		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x0000F3CC File Offset: 0x0000D5CC
		// (set) Token: 0x060009F1 RID: 2545 RVA: 0x0000F3D4 File Offset: 0x0000D5D4
		[DataMember(Name = "id", IsRequired = true)]
		public int Id { get; set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x0000F3DD File Offset: 0x0000D5DD
		// (set) Token: 0x060009F3 RID: 2547 RVA: 0x0000F3E5 File Offset: 0x0000D5E5
		[DataMember(Name = "callFrame", IsRequired = true)]
		public CallFrame CallFrame { get; set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x0000F3EE File Offset: 0x0000D5EE
		// (set) Token: 0x060009F5 RID: 2549 RVA: 0x0000F3F6 File Offset: 0x0000D5F6
		[DataMember(Name = "hitCount", IsRequired = false)]
		public int? HitCount { get; set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x0000F3FF File Offset: 0x0000D5FF
		// (set) Token: 0x060009F7 RID: 2551 RVA: 0x0000F407 File Offset: 0x0000D607
		[DataMember(Name = "children", IsRequired = false)]
		public int[] Children { get; set; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x0000F410 File Offset: 0x0000D610
		// (set) Token: 0x060009F9 RID: 2553 RVA: 0x0000F418 File Offset: 0x0000D618
		[DataMember(Name = "deoptReason", IsRequired = false)]
		public string DeoptReason { get; set; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x0000F421 File Offset: 0x0000D621
		// (set) Token: 0x060009FB RID: 2555 RVA: 0x0000F429 File Offset: 0x0000D629
		[DataMember(Name = "positionTicks", IsRequired = false)]
		public IList<PositionTickInfo> PositionTicks { get; set; }
	}
}
