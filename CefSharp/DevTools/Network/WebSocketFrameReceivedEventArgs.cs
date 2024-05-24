using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002EF RID: 751
	[DataContract]
	public class WebSocketFrameReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x060015F3 RID: 5619 RVA: 0x00019C89 File Offset: 0x00017E89
		// (set) Token: 0x060015F4 RID: 5620 RVA: 0x00019C91 File Offset: 0x00017E91
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x060015F5 RID: 5621 RVA: 0x00019C9A File Offset: 0x00017E9A
		// (set) Token: 0x060015F6 RID: 5622 RVA: 0x00019CA2 File Offset: 0x00017EA2
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x060015F7 RID: 5623 RVA: 0x00019CAB File Offset: 0x00017EAB
		// (set) Token: 0x060015F8 RID: 5624 RVA: 0x00019CB3 File Offset: 0x00017EB3
		[DataMember(Name = "response", IsRequired = true)]
		public WebSocketFrame Response { get; private set; }
	}
}
