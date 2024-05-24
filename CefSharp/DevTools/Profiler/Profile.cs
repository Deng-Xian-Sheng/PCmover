using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000156 RID: 342
	[DataContract]
	public class Profile : DevToolsDomainEntityBase
	{
		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x0000F43A File Offset: 0x0000D63A
		// (set) Token: 0x060009FE RID: 2558 RVA: 0x0000F442 File Offset: 0x0000D642
		[DataMember(Name = "nodes", IsRequired = true)]
		public IList<ProfileNode> Nodes { get; set; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x0000F44B File Offset: 0x0000D64B
		// (set) Token: 0x06000A00 RID: 2560 RVA: 0x0000F453 File Offset: 0x0000D653
		[DataMember(Name = "startTime", IsRequired = true)]
		public double StartTime { get; set; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x0000F45C File Offset: 0x0000D65C
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x0000F464 File Offset: 0x0000D664
		[DataMember(Name = "endTime", IsRequired = true)]
		public double EndTime { get; set; }

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x0000F46D File Offset: 0x0000D66D
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x0000F475 File Offset: 0x0000D675
		[DataMember(Name = "samples", IsRequired = false)]
		public int[] Samples { get; set; }

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x0000F47E File Offset: 0x0000D67E
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x0000F486 File Offset: 0x0000D686
		[DataMember(Name = "timeDeltas", IsRequired = false)]
		public int[] TimeDeltas { get; set; }
	}
}
