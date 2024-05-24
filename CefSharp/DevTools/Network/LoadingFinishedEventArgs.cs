using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E5 RID: 741
	[DataContract]
	public class LoadingFinishedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x0600157D RID: 5501 RVA: 0x0001980D File Offset: 0x00017A0D
		// (set) Token: 0x0600157E RID: 5502 RVA: 0x00019815 File Offset: 0x00017A15
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x0600157F RID: 5503 RVA: 0x0001981E File Offset: 0x00017A1E
		// (set) Token: 0x06001580 RID: 5504 RVA: 0x00019826 File Offset: 0x00017A26
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06001581 RID: 5505 RVA: 0x0001982F File Offset: 0x00017A2F
		// (set) Token: 0x06001582 RID: 5506 RVA: 0x00019837 File Offset: 0x00017A37
		[DataMember(Name = "encodedDataLength", IsRequired = true)]
		public double EncodedDataLength { get; private set; }

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x06001583 RID: 5507 RVA: 0x00019840 File Offset: 0x00017A40
		// (set) Token: 0x06001584 RID: 5508 RVA: 0x00019848 File Offset: 0x00017A48
		[DataMember(Name = "shouldReportCorbBlocking", IsRequired = false)]
		public bool? ShouldReportCorbBlocking { get; private set; }
	}
}
