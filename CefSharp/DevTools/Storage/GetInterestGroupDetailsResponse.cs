using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x0200020A RID: 522
	[DataContract]
	public class GetInterestGroupDetailsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x00013D6A File Offset: 0x00011F6A
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x00013D72 File Offset: 0x00011F72
		[DataMember]
		internal InterestGroupDetails details { get; set; }

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x00013D7B File Offset: 0x00011F7B
		public InterestGroupDetails Details
		{
			get
			{
				return this.details;
			}
		}
	}
}
