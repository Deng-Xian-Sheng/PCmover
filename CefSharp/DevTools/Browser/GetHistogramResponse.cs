using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003FE RID: 1022
	[DataContract]
	public class GetHistogramResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x06001DD5 RID: 7637 RVA: 0x0002213B File Offset: 0x0002033B
		// (set) Token: 0x06001DD6 RID: 7638 RVA: 0x00022143 File Offset: 0x00020343
		[DataMember]
		internal Histogram histogram { get; set; }

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x06001DD7 RID: 7639 RVA: 0x0002214C File Offset: 0x0002034C
		public Histogram Histogram
		{
			get
			{
				return this.histogram;
			}
		}
	}
}
