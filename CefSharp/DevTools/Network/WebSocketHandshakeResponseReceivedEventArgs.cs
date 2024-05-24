using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F1 RID: 753
	[DataContract]
	public class WebSocketHandshakeResponseReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06001601 RID: 5633 RVA: 0x00019CFF File Offset: 0x00017EFF
		// (set) Token: 0x06001602 RID: 5634 RVA: 0x00019D07 File Offset: 0x00017F07
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06001603 RID: 5635 RVA: 0x00019D10 File Offset: 0x00017F10
		// (set) Token: 0x06001604 RID: 5636 RVA: 0x00019D18 File Offset: 0x00017F18
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06001605 RID: 5637 RVA: 0x00019D21 File Offset: 0x00017F21
		// (set) Token: 0x06001606 RID: 5638 RVA: 0x00019D29 File Offset: 0x00017F29
		[DataMember(Name = "response", IsRequired = true)]
		public WebSocketResponse Response { get; private set; }
	}
}
