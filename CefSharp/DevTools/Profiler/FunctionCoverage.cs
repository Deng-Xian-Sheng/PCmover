using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000159 RID: 345
	[DataContract]
	public class FunctionCoverage : DevToolsDomainEntityBase
	{
		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000A14 RID: 2580 RVA: 0x0000F4FC File Offset: 0x0000D6FC
		// (set) Token: 0x06000A15 RID: 2581 RVA: 0x0000F504 File Offset: 0x0000D704
		[DataMember(Name = "functionName", IsRequired = true)]
		public string FunctionName { get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x0000F50D File Offset: 0x0000D70D
		// (set) Token: 0x06000A17 RID: 2583 RVA: 0x0000F515 File Offset: 0x0000D715
		[DataMember(Name = "ranges", IsRequired = true)]
		public IList<CoverageRange> Ranges { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x0000F51E File Offset: 0x0000D71E
		// (set) Token: 0x06000A19 RID: 2585 RVA: 0x0000F526 File Offset: 0x0000D726
		[DataMember(Name = "isBlockCoverage", IsRequired = true)]
		public bool IsBlockCoverage { get; set; }
	}
}
