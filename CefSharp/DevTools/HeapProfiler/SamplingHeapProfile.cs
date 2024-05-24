using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x02000169 RID: 361
	[DataContract]
	public class SamplingHeapProfile : DevToolsDomainEntityBase
	{
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0000FA77 File Offset: 0x0000DC77
		// (set) Token: 0x06000A83 RID: 2691 RVA: 0x0000FA7F File Offset: 0x0000DC7F
		[DataMember(Name = "head", IsRequired = true)]
		public SamplingHeapProfileNode Head { get; set; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0000FA88 File Offset: 0x0000DC88
		// (set) Token: 0x06000A85 RID: 2693 RVA: 0x0000FA90 File Offset: 0x0000DC90
		[DataMember(Name = "samples", IsRequired = true)]
		public IList<SamplingHeapProfileSample> Samples { get; set; }
	}
}
