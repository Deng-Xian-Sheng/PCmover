using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002EC RID: 748
	[DataContract]
	public class WebSocketClosedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x060015E0 RID: 5600 RVA: 0x00019BE9 File Offset: 0x00017DE9
		// (set) Token: 0x060015E1 RID: 5601 RVA: 0x00019BF1 File Offset: 0x00017DF1
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x060015E2 RID: 5602 RVA: 0x00019BFA File Offset: 0x00017DFA
		// (set) Token: 0x060015E3 RID: 5603 RVA: 0x00019C02 File Offset: 0x00017E02
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
