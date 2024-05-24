using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002DB RID: 731
	[DataContract]
	public class CrossOriginEmbedderPolicyStatus : DevToolsDomainEntityBase
	{
		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x06001518 RID: 5400 RVA: 0x00019421 File Offset: 0x00017621
		// (set) Token: 0x06001519 RID: 5401 RVA: 0x0001943D File Offset: 0x0001763D
		public CrossOriginEmbedderPolicyValue Value
		{
			get
			{
				return (CrossOriginEmbedderPolicyValue)DevToolsDomainEntityBase.StringToEnum(typeof(CrossOriginEmbedderPolicyValue), this.value);
			}
			set
			{
				this.value = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x0600151A RID: 5402 RVA: 0x00019450 File Offset: 0x00017650
		// (set) Token: 0x0600151B RID: 5403 RVA: 0x00019458 File Offset: 0x00017658
		[DataMember(Name = "value", IsRequired = true)]
		internal string value { get; set; }

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x0600151C RID: 5404 RVA: 0x00019461 File Offset: 0x00017661
		// (set) Token: 0x0600151D RID: 5405 RVA: 0x0001947D File Offset: 0x0001767D
		public CrossOriginEmbedderPolicyValue ReportOnlyValue
		{
			get
			{
				return (CrossOriginEmbedderPolicyValue)DevToolsDomainEntityBase.StringToEnum(typeof(CrossOriginEmbedderPolicyValue), this.reportOnlyValue);
			}
			set
			{
				this.reportOnlyValue = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x0600151E RID: 5406 RVA: 0x00019490 File Offset: 0x00017690
		// (set) Token: 0x0600151F RID: 5407 RVA: 0x00019498 File Offset: 0x00017698
		[DataMember(Name = "reportOnlyValue", IsRequired = true)]
		internal string reportOnlyValue { get; set; }

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06001520 RID: 5408 RVA: 0x000194A1 File Offset: 0x000176A1
		// (set) Token: 0x06001521 RID: 5409 RVA: 0x000194A9 File Offset: 0x000176A9
		[DataMember(Name = "reportingEndpoint", IsRequired = false)]
		public string ReportingEndpoint { get; set; }

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x06001522 RID: 5410 RVA: 0x000194B2 File Offset: 0x000176B2
		// (set) Token: 0x06001523 RID: 5411 RVA: 0x000194BA File Offset: 0x000176BA
		[DataMember(Name = "reportOnlyReportingEndpoint", IsRequired = false)]
		public string ReportOnlyReportingEndpoint { get; set; }
	}
}
