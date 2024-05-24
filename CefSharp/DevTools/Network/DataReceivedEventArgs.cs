using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E2 RID: 738
	[DataContract]
	public class DataReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06001556 RID: 5462 RVA: 0x00019687 File Offset: 0x00017887
		// (set) Token: 0x06001557 RID: 5463 RVA: 0x0001968F File Offset: 0x0001788F
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06001558 RID: 5464 RVA: 0x00019698 File Offset: 0x00017898
		// (set) Token: 0x06001559 RID: 5465 RVA: 0x000196A0 File Offset: 0x000178A0
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x0600155A RID: 5466 RVA: 0x000196A9 File Offset: 0x000178A9
		// (set) Token: 0x0600155B RID: 5467 RVA: 0x000196B1 File Offset: 0x000178B1
		[DataMember(Name = "dataLength", IsRequired = true)]
		public int DataLength { get; private set; }

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x0600155C RID: 5468 RVA: 0x000196BA File Offset: 0x000178BA
		// (set) Token: 0x0600155D RID: 5469 RVA: 0x000196C2 File Offset: 0x000178C2
		[DataMember(Name = "encodedDataLength", IsRequired = true)]
		public int EncodedDataLength { get; private set; }
	}
}
