using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002ED RID: 749
	[DataContract]
	public class WebSocketCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x060015E5 RID: 5605 RVA: 0x00019C13 File Offset: 0x00017E13
		// (set) Token: 0x060015E6 RID: 5606 RVA: 0x00019C1B File Offset: 0x00017E1B
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x060015E7 RID: 5607 RVA: 0x00019C24 File Offset: 0x00017E24
		// (set) Token: 0x060015E8 RID: 5608 RVA: 0x00019C2C File Offset: 0x00017E2C
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x060015E9 RID: 5609 RVA: 0x00019C35 File Offset: 0x00017E35
		// (set) Token: 0x060015EA RID: 5610 RVA: 0x00019C3D File Offset: 0x00017E3D
		[DataMember(Name = "initiator", IsRequired = false)]
		public Initiator Initiator { get; private set; }
	}
}
