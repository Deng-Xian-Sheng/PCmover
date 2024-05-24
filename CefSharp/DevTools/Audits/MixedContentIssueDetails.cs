using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000412 RID: 1042
	[DataContract]
	public class MixedContentIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x06001E49 RID: 7753 RVA: 0x00022AB0 File Offset: 0x00020CB0
		// (set) Token: 0x06001E4A RID: 7754 RVA: 0x00022ACC File Offset: 0x00020CCC
		public MixedContentResourceType? ResourceType
		{
			get
			{
				return (MixedContentResourceType?)DevToolsDomainEntityBase.StringToEnum(typeof(MixedContentResourceType?), this.resourceType);
			}
			set
			{
				this.resourceType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x06001E4B RID: 7755 RVA: 0x00022ADF File Offset: 0x00020CDF
		// (set) Token: 0x06001E4C RID: 7756 RVA: 0x00022AE7 File Offset: 0x00020CE7
		[DataMember(Name = "resourceType", IsRequired = false)]
		internal string resourceType { get; set; }

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x06001E4D RID: 7757 RVA: 0x00022AF0 File Offset: 0x00020CF0
		// (set) Token: 0x06001E4E RID: 7758 RVA: 0x00022B0C File Offset: 0x00020D0C
		public MixedContentResolutionStatus ResolutionStatus
		{
			get
			{
				return (MixedContentResolutionStatus)DevToolsDomainEntityBase.StringToEnum(typeof(MixedContentResolutionStatus), this.resolutionStatus);
			}
			set
			{
				this.resolutionStatus = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x06001E4F RID: 7759 RVA: 0x00022B1F File Offset: 0x00020D1F
		// (set) Token: 0x06001E50 RID: 7760 RVA: 0x00022B27 File Offset: 0x00020D27
		[DataMember(Name = "resolutionStatus", IsRequired = true)]
		internal string resolutionStatus { get; set; }

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x06001E51 RID: 7761 RVA: 0x00022B30 File Offset: 0x00020D30
		// (set) Token: 0x06001E52 RID: 7762 RVA: 0x00022B38 File Offset: 0x00020D38
		[DataMember(Name = "insecureURL", IsRequired = true)]
		public string InsecureURL { get; set; }

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x06001E53 RID: 7763 RVA: 0x00022B41 File Offset: 0x00020D41
		// (set) Token: 0x06001E54 RID: 7764 RVA: 0x00022B49 File Offset: 0x00020D49
		[DataMember(Name = "mainResourceURL", IsRequired = true)]
		public string MainResourceURL { get; set; }

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06001E55 RID: 7765 RVA: 0x00022B52 File Offset: 0x00020D52
		// (set) Token: 0x06001E56 RID: 7766 RVA: 0x00022B5A File Offset: 0x00020D5A
		[DataMember(Name = "request", IsRequired = false)]
		public AffectedRequest Request { get; set; }

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x06001E57 RID: 7767 RVA: 0x00022B63 File Offset: 0x00020D63
		// (set) Token: 0x06001E58 RID: 7768 RVA: 0x00022B6B File Offset: 0x00020D6B
		[DataMember(Name = "frame", IsRequired = false)]
		public AffectedFrame Frame { get; set; }
	}
}
