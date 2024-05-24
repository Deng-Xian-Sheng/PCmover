using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000417 RID: 1047
	[DataContract]
	public class HeavyAdIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x06001E65 RID: 7781 RVA: 0x00022BF7 File Offset: 0x00020DF7
		// (set) Token: 0x06001E66 RID: 7782 RVA: 0x00022C13 File Offset: 0x00020E13
		public HeavyAdResolutionStatus Resolution
		{
			get
			{
				return (HeavyAdResolutionStatus)DevToolsDomainEntityBase.StringToEnum(typeof(HeavyAdResolutionStatus), this.resolution);
			}
			set
			{
				this.resolution = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x06001E67 RID: 7783 RVA: 0x00022C26 File Offset: 0x00020E26
		// (set) Token: 0x06001E68 RID: 7784 RVA: 0x00022C2E File Offset: 0x00020E2E
		[DataMember(Name = "resolution", IsRequired = true)]
		internal string resolution { get; set; }

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06001E69 RID: 7785 RVA: 0x00022C37 File Offset: 0x00020E37
		// (set) Token: 0x06001E6A RID: 7786 RVA: 0x00022C53 File Offset: 0x00020E53
		public HeavyAdReason Reason
		{
			get
			{
				return (HeavyAdReason)DevToolsDomainEntityBase.StringToEnum(typeof(HeavyAdReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06001E6B RID: 7787 RVA: 0x00022C66 File Offset: 0x00020E66
		// (set) Token: 0x06001E6C RID: 7788 RVA: 0x00022C6E File Offset: 0x00020E6E
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; set; }

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06001E6D RID: 7789 RVA: 0x00022C77 File Offset: 0x00020E77
		// (set) Token: 0x06001E6E RID: 7790 RVA: 0x00022C7F File Offset: 0x00020E7F
		[DataMember(Name = "frame", IsRequired = true)]
		public AffectedFrame Frame { get; set; }
	}
}
