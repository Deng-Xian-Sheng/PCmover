using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x0200015A RID: 346
	[DataContract]
	public class ScriptCoverage : DevToolsDomainEntityBase
	{
		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x0000F537 File Offset: 0x0000D737
		// (set) Token: 0x06000A1C RID: 2588 RVA: 0x0000F53F File Offset: 0x0000D73F
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x0000F548 File Offset: 0x0000D748
		// (set) Token: 0x06000A1E RID: 2590 RVA: 0x0000F550 File Offset: 0x0000D750
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000A1F RID: 2591 RVA: 0x0000F559 File Offset: 0x0000D759
		// (set) Token: 0x06000A20 RID: 2592 RVA: 0x0000F561 File Offset: 0x0000D761
		[DataMember(Name = "functions", IsRequired = true)]
		public IList<FunctionCoverage> Functions { get; set; }
	}
}
