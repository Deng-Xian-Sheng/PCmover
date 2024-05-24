using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001DD RID: 477
	[DataContract]
	public class TargetInfo : DevToolsDomainEntityBase
	{
		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x00012DC9 File Offset: 0x00010FC9
		// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x00012DD1 File Offset: 0x00010FD1
		[DataMember(Name = "targetId", IsRequired = true)]
		public string TargetId { get; set; }

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x00012DDA File Offset: 0x00010FDA
		// (set) Token: 0x06000DBA RID: 3514 RVA: 0x00012DE2 File Offset: 0x00010FE2
		[DataMember(Name = "type", IsRequired = true)]
		public string Type { get; set; }

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000DBB RID: 3515 RVA: 0x00012DEB File Offset: 0x00010FEB
		// (set) Token: 0x06000DBC RID: 3516 RVA: 0x00012DF3 File Offset: 0x00010FF3
		[DataMember(Name = "title", IsRequired = true)]
		public string Title { get; set; }

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000DBD RID: 3517 RVA: 0x00012DFC File Offset: 0x00010FFC
		// (set) Token: 0x06000DBE RID: 3518 RVA: 0x00012E04 File Offset: 0x00011004
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x00012E0D File Offset: 0x0001100D
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x00012E15 File Offset: 0x00011015
		[DataMember(Name = "attached", IsRequired = true)]
		public bool Attached { get; set; }

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00012E1E File Offset: 0x0001101E
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x00012E26 File Offset: 0x00011026
		[DataMember(Name = "openerId", IsRequired = false)]
		public string OpenerId { get; set; }

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00012E2F File Offset: 0x0001102F
		// (set) Token: 0x06000DC4 RID: 3524 RVA: 0x00012E37 File Offset: 0x00011037
		[DataMember(Name = "canAccessOpener", IsRequired = true)]
		public bool CanAccessOpener { get; set; }

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00012E40 File Offset: 0x00011040
		// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x00012E48 File Offset: 0x00011048
		[DataMember(Name = "openerFrameId", IsRequired = false)]
		public string OpenerFrameId { get; set; }

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00012E51 File Offset: 0x00011051
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x00012E59 File Offset: 0x00011059
		[DataMember(Name = "browserContextId", IsRequired = false)]
		public string BrowserContextId { get; set; }
	}
}
