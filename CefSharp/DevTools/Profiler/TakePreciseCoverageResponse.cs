using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000164 RID: 356
	[DataContract]
	public class TakePreciseCoverageResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0000F715 File Offset: 0x0000D915
		// (set) Token: 0x06000A55 RID: 2645 RVA: 0x0000F71D File Offset: 0x0000D91D
		[DataMember]
		internal IList<ScriptCoverage> result { get; set; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000A56 RID: 2646 RVA: 0x0000F726 File Offset: 0x0000D926
		public IList<ScriptCoverage> Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x0000F72E File Offset: 0x0000D92E
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x0000F736 File Offset: 0x0000D936
		[DataMember]
		internal double timestamp { get; set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x0000F73F File Offset: 0x0000D93F
		public double Timestamp
		{
			get
			{
				return this.timestamp;
			}
		}
	}
}
