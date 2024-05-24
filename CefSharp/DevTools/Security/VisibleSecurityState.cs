using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x0200021A RID: 538
	[DataContract]
	public class VisibleSecurityState : DevToolsDomainEntityBase
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000F7F RID: 3967 RVA: 0x00014823 File Offset: 0x00012A23
		// (set) Token: 0x06000F80 RID: 3968 RVA: 0x0001483F File Offset: 0x00012A3F
		public SecurityState SecurityState
		{
			get
			{
				return (SecurityState)DevToolsDomainEntityBase.StringToEnum(typeof(SecurityState), this.securityState);
			}
			set
			{
				this.securityState = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x00014852 File Offset: 0x00012A52
		// (set) Token: 0x06000F82 RID: 3970 RVA: 0x0001485A File Offset: 0x00012A5A
		[DataMember(Name = "securityState", IsRequired = true)]
		internal string securityState { get; set; }

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x00014863 File Offset: 0x00012A63
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x0001486B File Offset: 0x00012A6B
		[DataMember(Name = "certificateSecurityState", IsRequired = false)]
		public CertificateSecurityState CertificateSecurityState { get; set; }

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x00014874 File Offset: 0x00012A74
		// (set) Token: 0x06000F86 RID: 3974 RVA: 0x0001487C File Offset: 0x00012A7C
		[DataMember(Name = "safetyTipInfo", IsRequired = false)]
		public SafetyTipInfo SafetyTipInfo { get; set; }

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x00014885 File Offset: 0x00012A85
		// (set) Token: 0x06000F88 RID: 3976 RVA: 0x0001488D File Offset: 0x00012A8D
		[DataMember(Name = "securityStateIssueIds", IsRequired = true)]
		public string[] SecurityStateIssueIds { get; set; }
	}
}
