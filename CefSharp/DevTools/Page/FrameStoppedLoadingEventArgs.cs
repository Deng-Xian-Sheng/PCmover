using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000264 RID: 612
	[DataContract]
	public class FrameStoppedLoadingEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06001155 RID: 4437 RVA: 0x00015BED File Offset: 0x00013DED
		// (set) Token: 0x06001156 RID: 4438 RVA: 0x00015BF5 File Offset: 0x00013DF5
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }
	}
}
