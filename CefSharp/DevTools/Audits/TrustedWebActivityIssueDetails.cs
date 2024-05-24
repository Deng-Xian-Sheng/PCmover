using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200041E RID: 1054
	[DataContract]
	public class TrustedWebActivityIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x06001E93 RID: 7827 RVA: 0x00022DF4 File Offset: 0x00020FF4
		// (set) Token: 0x06001E94 RID: 7828 RVA: 0x00022DFC File Offset: 0x00020FFC
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000B23 RID: 2851
		// (get) Token: 0x06001E95 RID: 7829 RVA: 0x00022E05 File Offset: 0x00021005
		// (set) Token: 0x06001E96 RID: 7830 RVA: 0x00022E21 File Offset: 0x00021021
		public TwaQualityEnforcementViolationType ViolationType
		{
			get
			{
				return (TwaQualityEnforcementViolationType)DevToolsDomainEntityBase.StringToEnum(typeof(TwaQualityEnforcementViolationType), this.violationType);
			}
			set
			{
				this.violationType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B24 RID: 2852
		// (get) Token: 0x06001E97 RID: 7831 RVA: 0x00022E34 File Offset: 0x00021034
		// (set) Token: 0x06001E98 RID: 7832 RVA: 0x00022E3C File Offset: 0x0002103C
		[DataMember(Name = "violationType", IsRequired = true)]
		internal string violationType { get; set; }

		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x06001E99 RID: 7833 RVA: 0x00022E45 File Offset: 0x00021045
		// (set) Token: 0x06001E9A RID: 7834 RVA: 0x00022E4D File Offset: 0x0002104D
		[DataMember(Name = "httpStatusCode", IsRequired = false)]
		public int? HttpStatusCode { get; set; }

		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x06001E9B RID: 7835 RVA: 0x00022E56 File Offset: 0x00021056
		// (set) Token: 0x06001E9C RID: 7836 RVA: 0x00022E5E File Offset: 0x0002105E
		[DataMember(Name = "packageName", IsRequired = false)]
		public string PackageName { get; set; }

		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x06001E9D RID: 7837 RVA: 0x00022E67 File Offset: 0x00021067
		// (set) Token: 0x06001E9E RID: 7838 RVA: 0x00022E6F File Offset: 0x0002106F
		[DataMember(Name = "signature", IsRequired = false)]
		public string Signature { get; set; }
	}
}
