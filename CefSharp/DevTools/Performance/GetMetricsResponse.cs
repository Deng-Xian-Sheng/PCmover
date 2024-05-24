using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Performance
{
	// Token: 0x0200022A RID: 554
	[DataContract]
	public class GetMetricsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x00014E2C File Offset: 0x0001302C
		// (set) Token: 0x0600100B RID: 4107 RVA: 0x00014E34 File Offset: 0x00013034
		[DataMember]
		internal IList<Metric> metrics { get; set; }

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x0600100C RID: 4108 RVA: 0x00014E3D File Offset: 0x0001303D
		public IList<Metric> Metrics
		{
			get
			{
				return this.metrics;
			}
		}
	}
}
