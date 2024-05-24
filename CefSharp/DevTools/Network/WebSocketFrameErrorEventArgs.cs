using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002EE RID: 750
	[DataContract]
	public class WebSocketFrameErrorEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x060015EC RID: 5612 RVA: 0x00019C4E File Offset: 0x00017E4E
		// (set) Token: 0x060015ED RID: 5613 RVA: 0x00019C56 File Offset: 0x00017E56
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x060015EE RID: 5614 RVA: 0x00019C5F File Offset: 0x00017E5F
		// (set) Token: 0x060015EF RID: 5615 RVA: 0x00019C67 File Offset: 0x00017E67
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x00019C70 File Offset: 0x00017E70
		// (set) Token: 0x060015F1 RID: 5617 RVA: 0x00019C78 File Offset: 0x00017E78
		[DataMember(Name = "errorMessage", IsRequired = true)]
		public string ErrorMessage { get; private set; }
	}
}
