using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000314 RID: 788
	[DataContract]
	public class GetBrowserSamplingProfileResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x0001B27F File Offset: 0x0001947F
		// (set) Token: 0x06001728 RID: 5928 RVA: 0x0001B287 File Offset: 0x00019487
		[DataMember]
		internal SamplingProfile profile { get; set; }

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x0001B290 File Offset: 0x00019490
		public SamplingProfile Profile
		{
			get
			{
				return this.profile;
			}
		}
	}
}
