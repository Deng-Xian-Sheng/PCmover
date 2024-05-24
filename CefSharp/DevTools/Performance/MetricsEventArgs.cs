using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Performance
{
	// Token: 0x02000229 RID: 553
	[DataContract]
	public class MetricsEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x00014E02 File Offset: 0x00013002
		// (set) Token: 0x06001006 RID: 4102 RVA: 0x00014E0A File Offset: 0x0001300A
		[DataMember(Name = "metrics", IsRequired = true)]
		public IList<Metric> Metrics { get; private set; }

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x00014E13 File Offset: 0x00013013
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x00014E1B File Offset: 0x0001301B
		[DataMember(Name = "title", IsRequired = true)]
		public string Title { get; private set; }
	}
}
