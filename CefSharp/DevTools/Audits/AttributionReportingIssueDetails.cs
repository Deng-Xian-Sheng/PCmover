using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000422 RID: 1058
	[DataContract]
	public class AttributionReportingIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B37 RID: 2871
		// (get) Token: 0x06001EC0 RID: 7872 RVA: 0x00022FAD File Offset: 0x000211AD
		// (set) Token: 0x06001EC1 RID: 7873 RVA: 0x00022FC9 File Offset: 0x000211C9
		public AttributionReportingIssueType ViolationType
		{
			get
			{
				return (AttributionReportingIssueType)DevToolsDomainEntityBase.StringToEnum(typeof(AttributionReportingIssueType), this.violationType);
			}
			set
			{
				this.violationType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B38 RID: 2872
		// (get) Token: 0x06001EC2 RID: 7874 RVA: 0x00022FDC File Offset: 0x000211DC
		// (set) Token: 0x06001EC3 RID: 7875 RVA: 0x00022FE4 File Offset: 0x000211E4
		[DataMember(Name = "violationType", IsRequired = true)]
		internal string violationType { get; set; }

		// Token: 0x17000B39 RID: 2873
		// (get) Token: 0x06001EC4 RID: 7876 RVA: 0x00022FED File Offset: 0x000211ED
		// (set) Token: 0x06001EC5 RID: 7877 RVA: 0x00022FF5 File Offset: 0x000211F5
		[DataMember(Name = "frame", IsRequired = false)]
		public AffectedFrame Frame { get; set; }

		// Token: 0x17000B3A RID: 2874
		// (get) Token: 0x06001EC6 RID: 7878 RVA: 0x00022FFE File Offset: 0x000211FE
		// (set) Token: 0x06001EC7 RID: 7879 RVA: 0x00023006 File Offset: 0x00021206
		[DataMember(Name = "request", IsRequired = false)]
		public AffectedRequest Request { get; set; }

		// Token: 0x17000B3B RID: 2875
		// (get) Token: 0x06001EC8 RID: 7880 RVA: 0x0002300F File Offset: 0x0002120F
		// (set) Token: 0x06001EC9 RID: 7881 RVA: 0x00023017 File Offset: 0x00021217
		[DataMember(Name = "violatingNodeId", IsRequired = false)]
		public int? ViolatingNodeId { get; set; }

		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x06001ECA RID: 7882 RVA: 0x00023020 File Offset: 0x00021220
		// (set) Token: 0x06001ECB RID: 7883 RVA: 0x00023028 File Offset: 0x00021228
		[DataMember(Name = "invalidParameter", IsRequired = false)]
		public string InvalidParameter { get; set; }
	}
}
