using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E6 RID: 486
	[DataContract]
	public class AttachToTargetResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x00012FBA File Offset: 0x000111BA
		// (set) Token: 0x06000DF3 RID: 3571 RVA: 0x00012FC2 File Offset: 0x000111C2
		[DataMember]
		internal string sessionId { get; set; }

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x00012FCB File Offset: 0x000111CB
		public string SessionId
		{
			get
			{
				return this.sessionId;
			}
		}
	}
}
