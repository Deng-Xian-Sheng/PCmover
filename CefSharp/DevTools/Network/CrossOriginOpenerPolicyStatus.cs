using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D9 RID: 729
	[DataContract]
	public class CrossOriginOpenerPolicyStatus : DevToolsDomainEntityBase
	{
		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x00019377 File Offset: 0x00017577
		// (set) Token: 0x0600150C RID: 5388 RVA: 0x00019393 File Offset: 0x00017593
		public CrossOriginOpenerPolicyValue Value
		{
			get
			{
				return (CrossOriginOpenerPolicyValue)DevToolsDomainEntityBase.StringToEnum(typeof(CrossOriginOpenerPolicyValue), this.value);
			}
			set
			{
				this.value = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x000193A6 File Offset: 0x000175A6
		// (set) Token: 0x0600150E RID: 5390 RVA: 0x000193AE File Offset: 0x000175AE
		[DataMember(Name = "value", IsRequired = true)]
		internal string value { get; set; }

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x0600150F RID: 5391 RVA: 0x000193B7 File Offset: 0x000175B7
		// (set) Token: 0x06001510 RID: 5392 RVA: 0x000193D3 File Offset: 0x000175D3
		public CrossOriginOpenerPolicyValue ReportOnlyValue
		{
			get
			{
				return (CrossOriginOpenerPolicyValue)DevToolsDomainEntityBase.StringToEnum(typeof(CrossOriginOpenerPolicyValue), this.reportOnlyValue);
			}
			set
			{
				this.reportOnlyValue = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x06001511 RID: 5393 RVA: 0x000193E6 File Offset: 0x000175E6
		// (set) Token: 0x06001512 RID: 5394 RVA: 0x000193EE File Offset: 0x000175EE
		[DataMember(Name = "reportOnlyValue", IsRequired = true)]
		internal string reportOnlyValue { get; set; }

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x06001513 RID: 5395 RVA: 0x000193F7 File Offset: 0x000175F7
		// (set) Token: 0x06001514 RID: 5396 RVA: 0x000193FF File Offset: 0x000175FF
		[DataMember(Name = "reportingEndpoint", IsRequired = false)]
		public string ReportingEndpoint { get; set; }

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x06001515 RID: 5397 RVA: 0x00019408 File Offset: 0x00017608
		// (set) Token: 0x06001516 RID: 5398 RVA: 0x00019410 File Offset: 0x00017610
		[DataMember(Name = "reportOnlyReportingEndpoint", IsRequired = false)]
		public string ReportOnlyReportingEndpoint { get; set; }
	}
}
