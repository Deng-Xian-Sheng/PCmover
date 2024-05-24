using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.BackgroundService
{
	// Token: 0x02000405 RID: 1029
	[DataContract]
	public class BackgroundServiceEvent : DevToolsDomainEntityBase
	{
		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x06001DFF RID: 7679 RVA: 0x000226A1 File Offset: 0x000208A1
		// (set) Token: 0x06001E00 RID: 7680 RVA: 0x000226A9 File Offset: 0x000208A9
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; set; }

		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x06001E01 RID: 7681 RVA: 0x000226B2 File Offset: 0x000208B2
		// (set) Token: 0x06001E02 RID: 7682 RVA: 0x000226BA File Offset: 0x000208BA
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; set; }

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x06001E03 RID: 7683 RVA: 0x000226C3 File Offset: 0x000208C3
		// (set) Token: 0x06001E04 RID: 7684 RVA: 0x000226CB File Offset: 0x000208CB
		[DataMember(Name = "serviceWorkerRegistrationId", IsRequired = true)]
		public string ServiceWorkerRegistrationId { get; set; }

		// Token: 0x17000AE6 RID: 2790
		// (get) Token: 0x06001E05 RID: 7685 RVA: 0x000226D4 File Offset: 0x000208D4
		// (set) Token: 0x06001E06 RID: 7686 RVA: 0x000226F0 File Offset: 0x000208F0
		public ServiceName Service
		{
			get
			{
				return (ServiceName)DevToolsDomainEntityBase.StringToEnum(typeof(ServiceName), this.service);
			}
			set
			{
				this.service = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x06001E07 RID: 7687 RVA: 0x00022703 File Offset: 0x00020903
		// (set) Token: 0x06001E08 RID: 7688 RVA: 0x0002270B File Offset: 0x0002090B
		[DataMember(Name = "service", IsRequired = true)]
		internal string service { get; set; }

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06001E09 RID: 7689 RVA: 0x00022714 File Offset: 0x00020914
		// (set) Token: 0x06001E0A RID: 7690 RVA: 0x0002271C File Offset: 0x0002091C
		[DataMember(Name = "eventName", IsRequired = true)]
		public string EventName { get; set; }

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06001E0B RID: 7691 RVA: 0x00022725 File Offset: 0x00020925
		// (set) Token: 0x06001E0C RID: 7692 RVA: 0x0002272D File Offset: 0x0002092D
		[DataMember(Name = "instanceId", IsRequired = true)]
		public string InstanceId { get; set; }

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x06001E0D RID: 7693 RVA: 0x00022736 File Offset: 0x00020936
		// (set) Token: 0x06001E0E RID: 7694 RVA: 0x0002273E File Offset: 0x0002093E
		[DataMember(Name = "eventMetadata", IsRequired = true)]
		public IList<EventMetadata> EventMetadata { get; set; }
	}
}
