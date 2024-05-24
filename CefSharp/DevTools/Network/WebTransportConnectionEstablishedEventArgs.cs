using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F4 RID: 756
	[DataContract]
	public class WebTransportConnectionEstablishedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x0600161A RID: 5658 RVA: 0x00019DD2 File Offset: 0x00017FD2
		// (set) Token: 0x0600161B RID: 5659 RVA: 0x00019DDA File Offset: 0x00017FDA
		[DataMember(Name = "transportId", IsRequired = true)]
		public string TransportId { get; private set; }

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x0600161C RID: 5660 RVA: 0x00019DE3 File Offset: 0x00017FE3
		// (set) Token: 0x0600161D RID: 5661 RVA: 0x00019DEB File Offset: 0x00017FEB
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
