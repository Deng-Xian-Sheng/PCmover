using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E7 RID: 743
	[DataContract]
	public class RequestServedFromCacheEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x060015A3 RID: 5539 RVA: 0x0001998B File Offset: 0x00017B8B
		// (set) Token: 0x060015A4 RID: 5540 RVA: 0x00019993 File Offset: 0x00017B93
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }
	}
}
