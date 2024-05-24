using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.PerformanceTimeline
{
	// Token: 0x02000224 RID: 548
	[DataContract]
	public class LayoutShift : DevToolsDomainEntityBase
	{
		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06000FE1 RID: 4065 RVA: 0x00014C8E File Offset: 0x00012E8E
		// (set) Token: 0x06000FE2 RID: 4066 RVA: 0x00014C96 File Offset: 0x00012E96
		[DataMember(Name = "value", IsRequired = true)]
		public double Value { get; set; }

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x00014C9F File Offset: 0x00012E9F
		// (set) Token: 0x06000FE4 RID: 4068 RVA: 0x00014CA7 File Offset: 0x00012EA7
		[DataMember(Name = "hadRecentInput", IsRequired = true)]
		public bool HadRecentInput { get; set; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x00014CB0 File Offset: 0x00012EB0
		// (set) Token: 0x06000FE6 RID: 4070 RVA: 0x00014CB8 File Offset: 0x00012EB8
		[DataMember(Name = "lastInputTime", IsRequired = true)]
		public double LastInputTime { get; set; }

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x00014CC1 File Offset: 0x00012EC1
		// (set) Token: 0x06000FE8 RID: 4072 RVA: 0x00014CC9 File Offset: 0x00012EC9
		[DataMember(Name = "sources", IsRequired = true)]
		public IList<LayoutShiftAttribution> Sources { get; set; }
	}
}
