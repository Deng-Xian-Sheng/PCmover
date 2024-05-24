using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E3 RID: 739
	[DataContract]
	public class EventSourceMessageReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x0600155F RID: 5471 RVA: 0x000196D3 File Offset: 0x000178D3
		// (set) Token: 0x06001560 RID: 5472 RVA: 0x000196DB File Offset: 0x000178DB
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06001561 RID: 5473 RVA: 0x000196E4 File Offset: 0x000178E4
		// (set) Token: 0x06001562 RID: 5474 RVA: 0x000196EC File Offset: 0x000178EC
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06001563 RID: 5475 RVA: 0x000196F5 File Offset: 0x000178F5
		// (set) Token: 0x06001564 RID: 5476 RVA: 0x000196FD File Offset: 0x000178FD
		[DataMember(Name = "eventName", IsRequired = true)]
		public string EventName { get; private set; }

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06001565 RID: 5477 RVA: 0x00019706 File Offset: 0x00017906
		// (set) Token: 0x06001566 RID: 5478 RVA: 0x0001970E File Offset: 0x0001790E
		[DataMember(Name = "eventId", IsRequired = true)]
		public string EventId { get; private set; }

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06001567 RID: 5479 RVA: 0x00019717 File Offset: 0x00017917
		// (set) Token: 0x06001568 RID: 5480 RVA: 0x0001971F File Offset: 0x0001791F
		[DataMember(Name = "data", IsRequired = true)]
		public string Data { get; private set; }
	}
}
