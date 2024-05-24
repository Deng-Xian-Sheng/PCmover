using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000414 RID: 1044
	[DataContract]
	public class BlockedByResponseIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x06001E5A RID: 7770 RVA: 0x00022B7C File Offset: 0x00020D7C
		// (set) Token: 0x06001E5B RID: 7771 RVA: 0x00022B84 File Offset: 0x00020D84
		[DataMember(Name = "request", IsRequired = true)]
		public AffectedRequest Request { get; set; }

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x06001E5C RID: 7772 RVA: 0x00022B8D File Offset: 0x00020D8D
		// (set) Token: 0x06001E5D RID: 7773 RVA: 0x00022B95 File Offset: 0x00020D95
		[DataMember(Name = "parentFrame", IsRequired = false)]
		public AffectedFrame ParentFrame { get; set; }

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06001E5E RID: 7774 RVA: 0x00022B9E File Offset: 0x00020D9E
		// (set) Token: 0x06001E5F RID: 7775 RVA: 0x00022BA6 File Offset: 0x00020DA6
		[DataMember(Name = "blockedFrame", IsRequired = false)]
		public AffectedFrame BlockedFrame { get; set; }

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06001E60 RID: 7776 RVA: 0x00022BAF File Offset: 0x00020DAF
		// (set) Token: 0x06001E61 RID: 7777 RVA: 0x00022BCB File Offset: 0x00020DCB
		public BlockedByResponseReason Reason
		{
			get
			{
				return (BlockedByResponseReason)DevToolsDomainEntityBase.StringToEnum(typeof(BlockedByResponseReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x06001E62 RID: 7778 RVA: 0x00022BDE File Offset: 0x00020DDE
		// (set) Token: 0x06001E63 RID: 7779 RVA: 0x00022BE6 File Offset: 0x00020DE6
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; set; }
	}
}
