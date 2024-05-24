using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F5 RID: 757
	[DataContract]
	public class WebTransportClosedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x0600161F RID: 5663 RVA: 0x00019DFC File Offset: 0x00017FFC
		// (set) Token: 0x06001620 RID: 5664 RVA: 0x00019E04 File Offset: 0x00018004
		[DataMember(Name = "transportId", IsRequired = true)]
		public string TransportId { get; private set; }

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06001621 RID: 5665 RVA: 0x00019E0D File Offset: 0x0001800D
		// (set) Token: 0x06001622 RID: 5666 RVA: 0x00019E15 File Offset: 0x00018015
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
