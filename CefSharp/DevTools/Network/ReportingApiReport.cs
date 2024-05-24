using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002DE RID: 734
	[DataContract]
	public class ReportingApiReport : DevToolsDomainEntityBase
	{
		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x0600152A RID: 5418 RVA: 0x000194F5 File Offset: 0x000176F5
		// (set) Token: 0x0600152B RID: 5419 RVA: 0x000194FD File Offset: 0x000176FD
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; set; }

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x0600152C RID: 5420 RVA: 0x00019506 File Offset: 0x00017706
		// (set) Token: 0x0600152D RID: 5421 RVA: 0x0001950E File Offset: 0x0001770E
		[DataMember(Name = "initiatorUrl", IsRequired = true)]
		public string InitiatorUrl { get; set; }

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x0600152E RID: 5422 RVA: 0x00019517 File Offset: 0x00017717
		// (set) Token: 0x0600152F RID: 5423 RVA: 0x0001951F File Offset: 0x0001771F
		[DataMember(Name = "destination", IsRequired = true)]
		public string Destination { get; set; }

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06001530 RID: 5424 RVA: 0x00019528 File Offset: 0x00017728
		// (set) Token: 0x06001531 RID: 5425 RVA: 0x00019530 File Offset: 0x00017730
		[DataMember(Name = "type", IsRequired = true)]
		public string Type { get; set; }

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06001532 RID: 5426 RVA: 0x00019539 File Offset: 0x00017739
		// (set) Token: 0x06001533 RID: 5427 RVA: 0x00019541 File Offset: 0x00017741
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; set; }

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06001534 RID: 5428 RVA: 0x0001954A File Offset: 0x0001774A
		// (set) Token: 0x06001535 RID: 5429 RVA: 0x00019552 File Offset: 0x00017752
		[DataMember(Name = "depth", IsRequired = true)]
		public int Depth { get; set; }

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06001536 RID: 5430 RVA: 0x0001955B File Offset: 0x0001775B
		// (set) Token: 0x06001537 RID: 5431 RVA: 0x00019563 File Offset: 0x00017763
		[DataMember(Name = "completedAttempts", IsRequired = true)]
		public int CompletedAttempts { get; set; }

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06001538 RID: 5432 RVA: 0x0001956C File Offset: 0x0001776C
		// (set) Token: 0x06001539 RID: 5433 RVA: 0x00019574 File Offset: 0x00017774
		[DataMember(Name = "body", IsRequired = true)]
		public object Body { get; set; }

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x0600153A RID: 5434 RVA: 0x0001957D File Offset: 0x0001777D
		// (set) Token: 0x0600153B RID: 5435 RVA: 0x00019599 File Offset: 0x00017799
		public ReportStatus Status
		{
			get
			{
				return (ReportStatus)DevToolsDomainEntityBase.StringToEnum(typeof(ReportStatus), this.status);
			}
			set
			{
				this.status = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x0600153C RID: 5436 RVA: 0x000195AC File Offset: 0x000177AC
		// (set) Token: 0x0600153D RID: 5437 RVA: 0x000195B4 File Offset: 0x000177B4
		[DataMember(Name = "status", IsRequired = true)]
		internal string status { get; set; }
	}
}
