using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F0 RID: 752
	[DataContract]
	public class WebSocketFrameSentEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x00019CC4 File Offset: 0x00017EC4
		// (set) Token: 0x060015FB RID: 5627 RVA: 0x00019CCC File Offset: 0x00017ECC
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x00019CD5 File Offset: 0x00017ED5
		// (set) Token: 0x060015FD RID: 5629 RVA: 0x00019CDD File Offset: 0x00017EDD
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x060015FE RID: 5630 RVA: 0x00019CE6 File Offset: 0x00017EE6
		// (set) Token: 0x060015FF RID: 5631 RVA: 0x00019CEE File Offset: 0x00017EEE
		[DataMember(Name = "response", IsRequired = true)]
		public WebSocketFrame Response { get; private set; }
	}
}
