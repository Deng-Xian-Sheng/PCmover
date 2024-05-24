using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E7 RID: 487
	[DataContract]
	public class AttachToBrowserTargetResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x00012FDB File Offset: 0x000111DB
		// (set) Token: 0x06000DF7 RID: 3575 RVA: 0x00012FE3 File Offset: 0x000111E3
		[DataMember]
		internal string sessionId { get; set; }

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x00012FEC File Offset: 0x000111EC
		public string SessionId
		{
			get
			{
				return this.sessionId;
			}
		}
	}
}
