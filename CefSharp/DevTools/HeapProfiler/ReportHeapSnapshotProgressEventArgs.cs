using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x0200016D RID: 365
	[DataContract]
	public class ReportHeapSnapshotProgressEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0000FAFD File Offset: 0x0000DCFD
		// (set) Token: 0x06000A93 RID: 2707 RVA: 0x0000FB05 File Offset: 0x0000DD05
		[DataMember(Name = "done", IsRequired = true)]
		public int Done { get; private set; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0000FB0E File Offset: 0x0000DD0E
		// (set) Token: 0x06000A95 RID: 2709 RVA: 0x0000FB16 File Offset: 0x0000DD16
		[DataMember(Name = "total", IsRequired = true)]
		public int Total { get; private set; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0000FB1F File Offset: 0x0000DD1F
		// (set) Token: 0x06000A97 RID: 2711 RVA: 0x0000FB27 File Offset: 0x0000DD27
		[DataMember(Name = "finished", IsRequired = false)]
		public bool? Finished { get; private set; }
	}
}
