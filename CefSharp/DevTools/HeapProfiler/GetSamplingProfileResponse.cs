using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x02000170 RID: 368
	[DataContract]
	public class GetSamplingProfileResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x0000FB7A File Offset: 0x0000DD7A
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x0000FB82 File Offset: 0x0000DD82
		[DataMember]
		internal SamplingHeapProfile profile { get; set; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0000FB8B File Offset: 0x0000DD8B
		public SamplingHeapProfile Profile
		{
			get
			{
				return this.profile;
			}
		}
	}
}
