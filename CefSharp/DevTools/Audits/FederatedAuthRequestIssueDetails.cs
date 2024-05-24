using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000429 RID: 1065
	[DataContract]
	public class FederatedAuthRequestIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B4B RID: 2891
		// (get) Token: 0x06001EED RID: 7917 RVA: 0x00023165 File Offset: 0x00021365
		// (set) Token: 0x06001EEE RID: 7918 RVA: 0x00023181 File Offset: 0x00021381
		public FederatedAuthRequestIssueReason FederatedAuthRequestIssueReason
		{
			get
			{
				return (FederatedAuthRequestIssueReason)DevToolsDomainEntityBase.StringToEnum(typeof(FederatedAuthRequestIssueReason), this.federatedAuthRequestIssueReason);
			}
			set
			{
				this.federatedAuthRequestIssueReason = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B4C RID: 2892
		// (get) Token: 0x06001EEF RID: 7919 RVA: 0x00023194 File Offset: 0x00021394
		// (set) Token: 0x06001EF0 RID: 7920 RVA: 0x0002319C File Offset: 0x0002139C
		[DataMember(Name = "federatedAuthRequestIssueReason", IsRequired = true)]
		internal string federatedAuthRequestIssueReason { get; set; }
	}
}
