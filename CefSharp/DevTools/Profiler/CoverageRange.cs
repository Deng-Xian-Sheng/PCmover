using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000158 RID: 344
	[DataContract]
	public class CoverageRange : DevToolsDomainEntityBase
	{
		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x0000F4C1 File Offset: 0x0000D6C1
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x0000F4C9 File Offset: 0x0000D6C9
		[DataMember(Name = "startOffset", IsRequired = true)]
		public int StartOffset { get; set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x0000F4D2 File Offset: 0x0000D6D2
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x0000F4DA File Offset: 0x0000D6DA
		[DataMember(Name = "endOffset", IsRequired = true)]
		public int EndOffset { get; set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x0000F4E3 File Offset: 0x0000D6E3
		// (set) Token: 0x06000A12 RID: 2578 RVA: 0x0000F4EB File Offset: 0x0000D6EB
		[DataMember(Name = "count", IsRequired = true)]
		public int Count { get; set; }
	}
}
