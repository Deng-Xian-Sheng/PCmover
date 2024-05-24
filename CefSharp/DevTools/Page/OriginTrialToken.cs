using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200023A RID: 570
	[DataContract]
	public class OriginTrialToken : DevToolsDomainEntityBase
	{
		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x0600102D RID: 4141 RVA: 0x0001504E File Offset: 0x0001324E
		// (set) Token: 0x0600102E RID: 4142 RVA: 0x00015056 File Offset: 0x00013256
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; set; }

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x0600102F RID: 4143 RVA: 0x0001505F File Offset: 0x0001325F
		// (set) Token: 0x06001030 RID: 4144 RVA: 0x00015067 File Offset: 0x00013267
		[DataMember(Name = "matchSubDomains", IsRequired = true)]
		public bool MatchSubDomains { get; set; }

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x00015070 File Offset: 0x00013270
		// (set) Token: 0x06001032 RID: 4146 RVA: 0x00015078 File Offset: 0x00013278
		[DataMember(Name = "trialName", IsRequired = true)]
		public string TrialName { get; set; }

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x00015081 File Offset: 0x00013281
		// (set) Token: 0x06001034 RID: 4148 RVA: 0x00015089 File Offset: 0x00013289
		[DataMember(Name = "expiryTime", IsRequired = true)]
		public double ExpiryTime { get; set; }

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06001035 RID: 4149 RVA: 0x00015092 File Offset: 0x00013292
		// (set) Token: 0x06001036 RID: 4150 RVA: 0x0001509A File Offset: 0x0001329A
		[DataMember(Name = "isThirdParty", IsRequired = true)]
		public bool IsThirdParty { get; set; }

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06001037 RID: 4151 RVA: 0x000150A3 File Offset: 0x000132A3
		// (set) Token: 0x06001038 RID: 4152 RVA: 0x000150BF File Offset: 0x000132BF
		public OriginTrialUsageRestriction UsageRestriction
		{
			get
			{
				return (OriginTrialUsageRestriction)DevToolsDomainEntityBase.StringToEnum(typeof(OriginTrialUsageRestriction), this.usageRestriction);
			}
			set
			{
				this.usageRestriction = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06001039 RID: 4153 RVA: 0x000150D2 File Offset: 0x000132D2
		// (set) Token: 0x0600103A RID: 4154 RVA: 0x000150DA File Offset: 0x000132DA
		[DataMember(Name = "usageRestriction", IsRequired = true)]
		internal string usageRestriction { get; set; }
	}
}
