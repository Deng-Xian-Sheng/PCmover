using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000257 RID: 599
	[DataContract]
	public class BackForwardCacheNotRestoredExplanationTree : DevToolsDomainEntityBase
	{
		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x0600110C RID: 4364 RVA: 0x000158D2 File Offset: 0x00013AD2
		// (set) Token: 0x0600110D RID: 4365 RVA: 0x000158DA File Offset: 0x00013ADA
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x0600110E RID: 4366 RVA: 0x000158E3 File Offset: 0x00013AE3
		// (set) Token: 0x0600110F RID: 4367 RVA: 0x000158EB File Offset: 0x00013AEB
		[DataMember(Name = "explanations", IsRequired = true)]
		public IList<BackForwardCacheNotRestoredExplanation> Explanations { get; set; }

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06001110 RID: 4368 RVA: 0x000158F4 File Offset: 0x00013AF4
		// (set) Token: 0x06001111 RID: 4369 RVA: 0x000158FC File Offset: 0x00013AFC
		[DataMember(Name = "children", IsRequired = true)]
		public IList<BackForwardCacheNotRestoredExplanationTree> Children { get; set; }
	}
}
