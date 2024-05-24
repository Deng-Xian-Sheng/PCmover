using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000161 RID: 353
	[DataContract]
	public class GetBestEffortCoverageResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x0000F6B2 File Offset: 0x0000D8B2
		// (set) Token: 0x06000A49 RID: 2633 RVA: 0x0000F6BA File Offset: 0x0000D8BA
		[DataMember]
		internal IList<ScriptCoverage> result { get; set; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x0000F6C3 File Offset: 0x0000D8C3
		public IList<ScriptCoverage> Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
