using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000310 RID: 784
	[DataContract]
	public class SamplingProfile : DevToolsDomainEntityBase
	{
		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x0600170B RID: 5899 RVA: 0x0001B195 File Offset: 0x00019395
		// (set) Token: 0x0600170C RID: 5900 RVA: 0x0001B19D File Offset: 0x0001939D
		[DataMember(Name = "samples", IsRequired = true)]
		public IList<SamplingProfileNode> Samples { get; set; }

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x0600170D RID: 5901 RVA: 0x0001B1A6 File Offset: 0x000193A6
		// (set) Token: 0x0600170E RID: 5902 RVA: 0x0001B1AE File Offset: 0x000193AE
		[DataMember(Name = "modules", IsRequired = true)]
		public IList<Module> Modules { get; set; }
	}
}
