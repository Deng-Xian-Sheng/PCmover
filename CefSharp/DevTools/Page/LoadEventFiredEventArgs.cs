using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200026C RID: 620
	[DataContract]
	public class LoadEventFiredEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06001190 RID: 4496 RVA: 0x00015E1B File Offset: 0x0001401B
		// (set) Token: 0x06001191 RID: 4497 RVA: 0x00015E23 File Offset: 0x00014023
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
