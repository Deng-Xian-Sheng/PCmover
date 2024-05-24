using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000258 RID: 600
	[DataContract]
	public class DomContentEventFiredEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06001113 RID: 4371 RVA: 0x0001590D File Offset: 0x00013B0D
		// (set) Token: 0x06001114 RID: 4372 RVA: 0x00015915 File Offset: 0x00013B15
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
