using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x02000168 RID: 360
	[DataContract]
	public class SamplingHeapProfileSample : DevToolsDomainEntityBase
	{
		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0000FA3C File Offset: 0x0000DC3C
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x0000FA44 File Offset: 0x0000DC44
		[DataMember(Name = "size", IsRequired = true)]
		public double Size { get; set; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0000FA4D File Offset: 0x0000DC4D
		// (set) Token: 0x06000A7E RID: 2686 RVA: 0x0000FA55 File Offset: 0x0000DC55
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0000FA5E File Offset: 0x0000DC5E
		// (set) Token: 0x06000A80 RID: 2688 RVA: 0x0000FA66 File Offset: 0x0000DC66
		[DataMember(Name = "ordinal", IsRequired = true)]
		public double Ordinal { get; set; }
	}
}
