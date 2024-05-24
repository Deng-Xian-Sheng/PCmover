using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000313 RID: 787
	[DataContract]
	public class GetAllTimeSamplingProfileResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06001723 RID: 5923 RVA: 0x0001B25E File Offset: 0x0001945E
		// (set) Token: 0x06001724 RID: 5924 RVA: 0x0001B266 File Offset: 0x00019466
		[DataMember]
		internal SamplingProfile profile { get; set; }

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x0001B26F File Offset: 0x0001946F
		public SamplingProfile Profile
		{
			get
			{
				return this.profile;
			}
		}
	}
}
