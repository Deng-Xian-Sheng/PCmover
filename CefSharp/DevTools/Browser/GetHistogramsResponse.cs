using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003FD RID: 1021
	[DataContract]
	public class GetHistogramsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x06001DD1 RID: 7633 RVA: 0x0002211A File Offset: 0x0002031A
		// (set) Token: 0x06001DD2 RID: 7634 RVA: 0x00022122 File Offset: 0x00020322
		[DataMember]
		internal IList<Histogram> histograms { get; set; }

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06001DD3 RID: 7635 RVA: 0x0002212B File Offset: 0x0002032B
		public IList<Histogram> Histograms
		{
			get
			{
				return this.histograms;
			}
		}
	}
}
