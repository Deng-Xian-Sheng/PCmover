using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001EB RID: 491
	[DataContract]
	public class CreateTargetResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x0001305F File Offset: 0x0001125F
		// (set) Token: 0x06000E07 RID: 3591 RVA: 0x00013067 File Offset: 0x00011267
		[DataMember]
		internal string targetId { get; set; }

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x00013070 File Offset: 0x00011270
		public string TargetId
		{
			get
			{
				return this.targetId;
			}
		}
	}
}
