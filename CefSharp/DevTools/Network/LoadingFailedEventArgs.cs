using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E4 RID: 740
	[DataContract]
	public class LoadingFailedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x0600156A RID: 5482 RVA: 0x00019730 File Offset: 0x00017930
		// (set) Token: 0x0600156B RID: 5483 RVA: 0x00019738 File Offset: 0x00017938
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x0600156C RID: 5484 RVA: 0x00019741 File Offset: 0x00017941
		// (set) Token: 0x0600156D RID: 5485 RVA: 0x00019749 File Offset: 0x00017949
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x0600156E RID: 5486 RVA: 0x00019752 File Offset: 0x00017952
		// (set) Token: 0x0600156F RID: 5487 RVA: 0x0001976E File Offset: 0x0001796E
		public ResourceType Type
		{
			get
			{
				return (ResourceType)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourceType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06001570 RID: 5488 RVA: 0x00019781 File Offset: 0x00017981
		// (set) Token: 0x06001571 RID: 5489 RVA: 0x00019789 File Offset: 0x00017989
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06001572 RID: 5490 RVA: 0x00019792 File Offset: 0x00017992
		// (set) Token: 0x06001573 RID: 5491 RVA: 0x0001979A File Offset: 0x0001799A
		[DataMember(Name = "errorText", IsRequired = true)]
		public string ErrorText { get; private set; }

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06001574 RID: 5492 RVA: 0x000197A3 File Offset: 0x000179A3
		// (set) Token: 0x06001575 RID: 5493 RVA: 0x000197AB File Offset: 0x000179AB
		[DataMember(Name = "canceled", IsRequired = false)]
		public bool? Canceled { get; private set; }

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06001576 RID: 5494 RVA: 0x000197B4 File Offset: 0x000179B4
		// (set) Token: 0x06001577 RID: 5495 RVA: 0x000197D0 File Offset: 0x000179D0
		public BlockedReason? BlockedReason
		{
			get
			{
				return (BlockedReason?)DevToolsDomainEventArgsBase.StringToEnum(typeof(BlockedReason?), this.blockedReason);
			}
			set
			{
				this.blockedReason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06001578 RID: 5496 RVA: 0x000197E3 File Offset: 0x000179E3
		// (set) Token: 0x06001579 RID: 5497 RVA: 0x000197EB File Offset: 0x000179EB
		[DataMember(Name = "blockedReason", IsRequired = false)]
		internal string blockedReason { get; private set; }

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x0600157A RID: 5498 RVA: 0x000197F4 File Offset: 0x000179F4
		// (set) Token: 0x0600157B RID: 5499 RVA: 0x000197FC File Offset: 0x000179FC
		[DataMember(Name = "corsErrorStatus", IsRequired = false)]
		public CorsErrorStatus CorsErrorStatus { get; private set; }
	}
}
