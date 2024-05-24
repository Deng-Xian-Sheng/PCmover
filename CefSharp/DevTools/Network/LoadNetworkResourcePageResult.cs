using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E0 RID: 736
	[DataContract]
	public class LoadNetworkResourcePageResult : DevToolsDomainEntityBase
	{
		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x06001544 RID: 5444 RVA: 0x000195EF File Offset: 0x000177EF
		// (set) Token: 0x06001545 RID: 5445 RVA: 0x000195F7 File Offset: 0x000177F7
		[DataMember(Name = "success", IsRequired = true)]
		public bool Success { get; set; }

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06001546 RID: 5446 RVA: 0x00019600 File Offset: 0x00017800
		// (set) Token: 0x06001547 RID: 5447 RVA: 0x00019608 File Offset: 0x00017808
		[DataMember(Name = "netError", IsRequired = false)]
		public double? NetError { get; set; }

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06001548 RID: 5448 RVA: 0x00019611 File Offset: 0x00017811
		// (set) Token: 0x06001549 RID: 5449 RVA: 0x00019619 File Offset: 0x00017819
		[DataMember(Name = "netErrorName", IsRequired = false)]
		public string NetErrorName { get; set; }

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x0600154A RID: 5450 RVA: 0x00019622 File Offset: 0x00017822
		// (set) Token: 0x0600154B RID: 5451 RVA: 0x0001962A File Offset: 0x0001782A
		[DataMember(Name = "httpStatusCode", IsRequired = false)]
		public double? HttpStatusCode { get; set; }

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x0600154C RID: 5452 RVA: 0x00019633 File Offset: 0x00017833
		// (set) Token: 0x0600154D RID: 5453 RVA: 0x0001963B File Offset: 0x0001783B
		[DataMember(Name = "stream", IsRequired = false)]
		public string Stream { get; set; }

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x00019644 File Offset: 0x00017844
		// (set) Token: 0x0600154F RID: 5455 RVA: 0x0001964C File Offset: 0x0001784C
		[DataMember(Name = "headers", IsRequired = false)]
		public Headers Headers { get; set; }
	}
}
