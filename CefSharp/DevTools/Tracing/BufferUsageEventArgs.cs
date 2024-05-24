using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D3 RID: 467
	[DataContract]
	public class BufferUsageEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000D7E RID: 3454 RVA: 0x00012923 File Offset: 0x00010B23
		// (set) Token: 0x06000D7F RID: 3455 RVA: 0x0001292B File Offset: 0x00010B2B
		[DataMember(Name = "percentFull", IsRequired = false)]
		public double? PercentFull { get; private set; }

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000D80 RID: 3456 RVA: 0x00012934 File Offset: 0x00010B34
		// (set) Token: 0x06000D81 RID: 3457 RVA: 0x0001293C File Offset: 0x00010B3C
		[DataMember(Name = "eventCount", IsRequired = false)]
		public double? EventCount { get; private set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000D82 RID: 3458 RVA: 0x00012945 File Offset: 0x00010B45
		// (set) Token: 0x06000D83 RID: 3459 RVA: 0x0001294D File Offset: 0x00010B4D
		[DataMember(Name = "value", IsRequired = false)]
		public double? Value { get; private set; }
	}
}
