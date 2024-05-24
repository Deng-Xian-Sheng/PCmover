using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001EC RID: 492
	[DataContract]
	public class GetTargetInfoResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000E0A RID: 3594 RVA: 0x00013080 File Offset: 0x00011280
		// (set) Token: 0x06000E0B RID: 3595 RVA: 0x00013088 File Offset: 0x00011288
		[DataMember]
		internal TargetInfo targetInfo { get; set; }

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x00013091 File Offset: 0x00011291
		public TargetInfo TargetInfo
		{
			get
			{
				return this.targetInfo;
			}
		}
	}
}
