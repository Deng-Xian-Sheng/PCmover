using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x0200016C RID: 364
	[DataContract]
	public class LastSeenObjectIdEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0000FAD3 File Offset: 0x0000DCD3
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x0000FADB File Offset: 0x0000DCDB
		[DataMember(Name = "lastSeenObjectId", IsRequired = true)]
		public int LastSeenObjectId { get; private set; }

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0000FAE4 File Offset: 0x0000DCE4
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x0000FAEC File Offset: 0x0000DCEC
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
