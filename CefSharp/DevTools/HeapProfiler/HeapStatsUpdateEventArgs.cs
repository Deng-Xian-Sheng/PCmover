using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x0200016B RID: 363
	[DataContract]
	public class HeapStatsUpdateEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000A8A RID: 2698 RVA: 0x0000FABA File Offset: 0x0000DCBA
		// (set) Token: 0x06000A8B RID: 2699 RVA: 0x0000FAC2 File Offset: 0x0000DCC2
		[DataMember(Name = "statsUpdate", IsRequired = true)]
		public int[] StatsUpdate { get; private set; }
	}
}
