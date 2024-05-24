using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000315 RID: 789
	[DataContract]
	public class GetSamplingProfileResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x0600172B RID: 5931 RVA: 0x0001B2A0 File Offset: 0x000194A0
		// (set) Token: 0x0600172C RID: 5932 RVA: 0x0001B2A8 File Offset: 0x000194A8
		[DataMember]
		internal SamplingProfile profile { get; set; }

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x0600172D RID: 5933 RVA: 0x0001B2B1 File Offset: 0x000194B1
		public SamplingProfile Profile
		{
			get
			{
				return this.profile;
			}
		}
	}
}
