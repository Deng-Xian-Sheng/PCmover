using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200041A RID: 1050
	[DataContract]
	public class ContentSecurityPolicyIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x06001E79 RID: 7801 RVA: 0x00022CDC File Offset: 0x00020EDC
		// (set) Token: 0x06001E7A RID: 7802 RVA: 0x00022CE4 File Offset: 0x00020EE4
		[DataMember(Name = "blockedURL", IsRequired = false)]
		public string BlockedURL { get; set; }

		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x06001E7B RID: 7803 RVA: 0x00022CED File Offset: 0x00020EED
		// (set) Token: 0x06001E7C RID: 7804 RVA: 0x00022CF5 File Offset: 0x00020EF5
		[DataMember(Name = "violatedDirective", IsRequired = true)]
		public string ViolatedDirective { get; set; }

		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x06001E7D RID: 7805 RVA: 0x00022CFE File Offset: 0x00020EFE
		// (set) Token: 0x06001E7E RID: 7806 RVA: 0x00022D06 File Offset: 0x00020F06
		[DataMember(Name = "isReportOnly", IsRequired = true)]
		public bool IsReportOnly { get; set; }

		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x06001E7F RID: 7807 RVA: 0x00022D0F File Offset: 0x00020F0F
		// (set) Token: 0x06001E80 RID: 7808 RVA: 0x00022D2B File Offset: 0x00020F2B
		public ContentSecurityPolicyViolationType ContentSecurityPolicyViolationType
		{
			get
			{
				return (ContentSecurityPolicyViolationType)DevToolsDomainEntityBase.StringToEnum(typeof(ContentSecurityPolicyViolationType), this.contentSecurityPolicyViolationType);
			}
			set
			{
				this.contentSecurityPolicyViolationType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B1A RID: 2842
		// (get) Token: 0x06001E81 RID: 7809 RVA: 0x00022D3E File Offset: 0x00020F3E
		// (set) Token: 0x06001E82 RID: 7810 RVA: 0x00022D46 File Offset: 0x00020F46
		[DataMember(Name = "contentSecurityPolicyViolationType", IsRequired = true)]
		internal string contentSecurityPolicyViolationType { get; set; }

		// Token: 0x17000B1B RID: 2843
		// (get) Token: 0x06001E83 RID: 7811 RVA: 0x00022D4F File Offset: 0x00020F4F
		// (set) Token: 0x06001E84 RID: 7812 RVA: 0x00022D57 File Offset: 0x00020F57
		[DataMember(Name = "frameAncestor", IsRequired = false)]
		public AffectedFrame FrameAncestor { get; set; }

		// Token: 0x17000B1C RID: 2844
		// (get) Token: 0x06001E85 RID: 7813 RVA: 0x00022D60 File Offset: 0x00020F60
		// (set) Token: 0x06001E86 RID: 7814 RVA: 0x00022D68 File Offset: 0x00020F68
		[DataMember(Name = "sourceCodeLocation", IsRequired = false)]
		public SourceCodeLocation SourceCodeLocation { get; set; }

		// Token: 0x17000B1D RID: 2845
		// (get) Token: 0x06001E87 RID: 7815 RVA: 0x00022D71 File Offset: 0x00020F71
		// (set) Token: 0x06001E88 RID: 7816 RVA: 0x00022D79 File Offset: 0x00020F79
		[DataMember(Name = "violatingNodeId", IsRequired = false)]
		public int? ViolatingNodeId { get; set; }
	}
}
