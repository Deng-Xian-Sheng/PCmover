using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E4 RID: 484
	[DataContract]
	public class TargetCrashedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00012F66 File Offset: 0x00011166
		// (set) Token: 0x06000DE9 RID: 3561 RVA: 0x00012F6E File Offset: 0x0001116E
		[DataMember(Name = "targetId", IsRequired = true)]
		public string TargetId { get; private set; }

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x00012F77 File Offset: 0x00011177
		// (set) Token: 0x06000DEB RID: 3563 RVA: 0x00012F7F File Offset: 0x0001117F
		[DataMember(Name = "status", IsRequired = true)]
		public string Status { get; private set; }

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000DEC RID: 3564 RVA: 0x00012F88 File Offset: 0x00011188
		// (set) Token: 0x06000DED RID: 3565 RVA: 0x00012F90 File Offset: 0x00011190
		[DataMember(Name = "errorCode", IsRequired = true)]
		public int ErrorCode { get; private set; }
	}
}
