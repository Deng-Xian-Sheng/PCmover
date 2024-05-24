using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000160 RID: 352
	[DataContract]
	public class PreciseCoverageDeltaUpdateEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x0000F677 File Offset: 0x0000D877
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x0000F67F File Offset: 0x0000D87F
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x0000F688 File Offset: 0x0000D888
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x0000F690 File Offset: 0x0000D890
		[DataMember(Name = "occasion", IsRequired = true)]
		public string Occasion { get; private set; }

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x0000F699 File Offset: 0x0000D899
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x0000F6A1 File Offset: 0x0000D8A1
		[DataMember(Name = "result", IsRequired = true)]
		public IList<ScriptCoverage> Result { get; private set; }
	}
}
