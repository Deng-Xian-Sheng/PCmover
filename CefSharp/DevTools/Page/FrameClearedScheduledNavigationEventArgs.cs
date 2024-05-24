using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200025C RID: 604
	[DataContract]
	public class FrameClearedScheduledNavigationEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x000159CB File Offset: 0x00013BCB
		// (set) Token: 0x06001127 RID: 4391 RVA: 0x000159D3 File Offset: 0x00013BD3
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }
	}
}
