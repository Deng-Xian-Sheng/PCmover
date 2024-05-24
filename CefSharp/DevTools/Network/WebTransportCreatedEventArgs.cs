using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F3 RID: 755
	[DataContract]
	public class WebTransportCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06001611 RID: 5649 RVA: 0x00019D86 File Offset: 0x00017F86
		// (set) Token: 0x06001612 RID: 5650 RVA: 0x00019D8E File Offset: 0x00017F8E
		[DataMember(Name = "transportId", IsRequired = true)]
		public string TransportId { get; private set; }

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06001613 RID: 5651 RVA: 0x00019D97 File Offset: 0x00017F97
		// (set) Token: 0x06001614 RID: 5652 RVA: 0x00019D9F File Offset: 0x00017F9F
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06001615 RID: 5653 RVA: 0x00019DA8 File Offset: 0x00017FA8
		// (set) Token: 0x06001616 RID: 5654 RVA: 0x00019DB0 File Offset: 0x00017FB0
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x06001617 RID: 5655 RVA: 0x00019DB9 File Offset: 0x00017FB9
		// (set) Token: 0x06001618 RID: 5656 RVA: 0x00019DC1 File Offset: 0x00017FC1
		[DataMember(Name = "initiator", IsRequired = false)]
		public Initiator Initiator { get; private set; }
	}
}
