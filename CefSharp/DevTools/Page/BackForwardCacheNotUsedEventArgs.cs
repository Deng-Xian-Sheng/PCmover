using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200026B RID: 619
	[DataContract]
	public class BackForwardCacheNotUsedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06001187 RID: 4487 RVA: 0x00015DCF File Offset: 0x00013FCF
		// (set) Token: 0x06001188 RID: 4488 RVA: 0x00015DD7 File Offset: 0x00013FD7
		[DataMember(Name = "loaderId", IsRequired = true)]
		public string LoaderId { get; private set; }

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x00015DE0 File Offset: 0x00013FE0
		// (set) Token: 0x0600118A RID: 4490 RVA: 0x00015DE8 File Offset: 0x00013FE8
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x0600118B RID: 4491 RVA: 0x00015DF1 File Offset: 0x00013FF1
		// (set) Token: 0x0600118C RID: 4492 RVA: 0x00015DF9 File Offset: 0x00013FF9
		[DataMember(Name = "notRestoredExplanations", IsRequired = true)]
		public IList<BackForwardCacheNotRestoredExplanation> NotRestoredExplanations { get; private set; }

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x0600118D RID: 4493 RVA: 0x00015E02 File Offset: 0x00014002
		// (set) Token: 0x0600118E RID: 4494 RVA: 0x00015E0A File Offset: 0x0001400A
		[DataMember(Name = "notRestoredExplanationsTree", IsRequired = false)]
		public BackForwardCacheNotRestoredExplanationTree NotRestoredExplanationsTree { get; private set; }
	}
}
