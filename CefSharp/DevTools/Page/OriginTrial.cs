using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200023C RID: 572
	[DataContract]
	public class OriginTrial : DevToolsDomainEntityBase
	{
		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001045 RID: 4165 RVA: 0x00015155 File Offset: 0x00013355
		// (set) Token: 0x06001046 RID: 4166 RVA: 0x0001515D File Offset: 0x0001335D
		[DataMember(Name = "trialName", IsRequired = true)]
		public string TrialName { get; set; }

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001047 RID: 4167 RVA: 0x00015166 File Offset: 0x00013366
		// (set) Token: 0x06001048 RID: 4168 RVA: 0x00015182 File Offset: 0x00013382
		public OriginTrialStatus Status
		{
			get
			{
				return (OriginTrialStatus)DevToolsDomainEntityBase.StringToEnum(typeof(OriginTrialStatus), this.status);
			}
			set
			{
				this.status = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06001049 RID: 4169 RVA: 0x00015195 File Offset: 0x00013395
		// (set) Token: 0x0600104A RID: 4170 RVA: 0x0001519D File Offset: 0x0001339D
		[DataMember(Name = "status", IsRequired = true)]
		internal string status { get; set; }

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x0600104B RID: 4171 RVA: 0x000151A6 File Offset: 0x000133A6
		// (set) Token: 0x0600104C RID: 4172 RVA: 0x000151AE File Offset: 0x000133AE
		[DataMember(Name = "tokensWithStatus", IsRequired = true)]
		public IList<OriginTrialTokenWithStatus> TokensWithStatus { get; set; }
	}
}
