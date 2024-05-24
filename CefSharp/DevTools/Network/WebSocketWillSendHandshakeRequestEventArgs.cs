using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F2 RID: 754
	[DataContract]
	public class WebSocketWillSendHandshakeRequestEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x00019D3A File Offset: 0x00017F3A
		// (set) Token: 0x06001609 RID: 5641 RVA: 0x00019D42 File Offset: 0x00017F42
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x00019D4B File Offset: 0x00017F4B
		// (set) Token: 0x0600160B RID: 5643 RVA: 0x00019D53 File Offset: 0x00017F53
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x0600160C RID: 5644 RVA: 0x00019D5C File Offset: 0x00017F5C
		// (set) Token: 0x0600160D RID: 5645 RVA: 0x00019D64 File Offset: 0x00017F64
		[DataMember(Name = "wallTime", IsRequired = true)]
		public double WallTime { get; private set; }

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x0600160E RID: 5646 RVA: 0x00019D6D File Offset: 0x00017F6D
		// (set) Token: 0x0600160F RID: 5647 RVA: 0x00019D75 File Offset: 0x00017F75
		[DataMember(Name = "request", IsRequired = true)]
		public WebSocketRequest Request { get; private set; }
	}
}
