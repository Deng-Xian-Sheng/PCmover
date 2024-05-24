using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x02000171 RID: 369
	[DataContract]
	public class StopSamplingResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x0000FB9B File Offset: 0x0000DD9B
		// (set) Token: 0x06000AA6 RID: 2726 RVA: 0x0000FBA3 File Offset: 0x0000DDA3
		[DataMember]
		internal SamplingHeapProfile profile { get; set; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x0000FBAC File Offset: 0x0000DDAC
		public SamplingHeapProfile Profile
		{
			get
			{
				return this.profile;
			}
		}
	}
}
