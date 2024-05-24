using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000263 RID: 611
	[DataContract]
	public class FrameStartedLoadingEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06001152 RID: 4434 RVA: 0x00015BD4 File Offset: 0x00013DD4
		// (set) Token: 0x06001153 RID: 4435 RVA: 0x00015BDC File Offset: 0x00013DDC
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }
	}
}
