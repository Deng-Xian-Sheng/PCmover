using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x0200030F RID: 783
	[DataContract]
	public class SamplingProfileNode : DevToolsDomainEntityBase
	{
		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0001B15A File Offset: 0x0001935A
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x0001B162 File Offset: 0x00019362
		[DataMember(Name = "size", IsRequired = true)]
		public double Size { get; set; }

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x0001B16B File Offset: 0x0001936B
		// (set) Token: 0x06001707 RID: 5895 RVA: 0x0001B173 File Offset: 0x00019373
		[DataMember(Name = "total", IsRequired = true)]
		public double Total { get; set; }

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x0001B17C File Offset: 0x0001937C
		// (set) Token: 0x06001709 RID: 5897 RVA: 0x0001B184 File Offset: 0x00019384
		[DataMember(Name = "stack", IsRequired = true)]
		public string[] Stack { get; set; }
	}
}
