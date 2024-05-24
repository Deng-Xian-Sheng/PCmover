using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E6 RID: 742
	[DataContract]
	public class RequestInterceptedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06001586 RID: 5510 RVA: 0x00019859 File Offset: 0x00017A59
		// (set) Token: 0x06001587 RID: 5511 RVA: 0x00019861 File Offset: 0x00017A61
		[DataMember(Name = "interceptionId", IsRequired = true)]
		public string InterceptionId { get; private set; }

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06001588 RID: 5512 RVA: 0x0001986A File Offset: 0x00017A6A
		// (set) Token: 0x06001589 RID: 5513 RVA: 0x00019872 File Offset: 0x00017A72
		[DataMember(Name = "request", IsRequired = true)]
		public Request Request { get; private set; }

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x0600158A RID: 5514 RVA: 0x0001987B File Offset: 0x00017A7B
		// (set) Token: 0x0600158B RID: 5515 RVA: 0x00019883 File Offset: 0x00017A83
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x0600158C RID: 5516 RVA: 0x0001988C File Offset: 0x00017A8C
		// (set) Token: 0x0600158D RID: 5517 RVA: 0x000198A8 File Offset: 0x00017AA8
		public ResourceType ResourceType
		{
			get
			{
				return (ResourceType)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourceType), this.resourceType);
			}
			set
			{
				this.resourceType = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x0600158E RID: 5518 RVA: 0x000198BB File Offset: 0x00017ABB
		// (set) Token: 0x0600158F RID: 5519 RVA: 0x000198C3 File Offset: 0x00017AC3
		[DataMember(Name = "resourceType", IsRequired = true)]
		internal string resourceType { get; private set; }

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06001590 RID: 5520 RVA: 0x000198CC File Offset: 0x00017ACC
		// (set) Token: 0x06001591 RID: 5521 RVA: 0x000198D4 File Offset: 0x00017AD4
		[DataMember(Name = "isNavigationRequest", IsRequired = true)]
		public bool IsNavigationRequest { get; private set; }

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x000198DD File Offset: 0x00017ADD
		// (set) Token: 0x06001593 RID: 5523 RVA: 0x000198E5 File Offset: 0x00017AE5
		[DataMember(Name = "isDownload", IsRequired = false)]
		public bool? IsDownload { get; private set; }

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x06001594 RID: 5524 RVA: 0x000198EE File Offset: 0x00017AEE
		// (set) Token: 0x06001595 RID: 5525 RVA: 0x000198F6 File Offset: 0x00017AF6
		[DataMember(Name = "redirectUrl", IsRequired = false)]
		public string RedirectUrl { get; private set; }

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06001596 RID: 5526 RVA: 0x000198FF File Offset: 0x00017AFF
		// (set) Token: 0x06001597 RID: 5527 RVA: 0x00019907 File Offset: 0x00017B07
		[DataMember(Name = "authChallenge", IsRequired = false)]
		public AuthChallenge AuthChallenge { get; private set; }

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06001598 RID: 5528 RVA: 0x00019910 File Offset: 0x00017B10
		// (set) Token: 0x06001599 RID: 5529 RVA: 0x0001992C File Offset: 0x00017B2C
		public ErrorReason? ResponseErrorReason
		{
			get
			{
				return (ErrorReason?)DevToolsDomainEventArgsBase.StringToEnum(typeof(ErrorReason?), this.responseErrorReason);
			}
			set
			{
				this.responseErrorReason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x0600159A RID: 5530 RVA: 0x0001993F File Offset: 0x00017B3F
		// (set) Token: 0x0600159B RID: 5531 RVA: 0x00019947 File Offset: 0x00017B47
		[DataMember(Name = "responseErrorReason", IsRequired = false)]
		internal string responseErrorReason { get; private set; }

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x0600159C RID: 5532 RVA: 0x00019950 File Offset: 0x00017B50
		// (set) Token: 0x0600159D RID: 5533 RVA: 0x00019958 File Offset: 0x00017B58
		[DataMember(Name = "responseStatusCode", IsRequired = false)]
		public int? ResponseStatusCode { get; private set; }

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x0600159E RID: 5534 RVA: 0x00019961 File Offset: 0x00017B61
		// (set) Token: 0x0600159F RID: 5535 RVA: 0x00019969 File Offset: 0x00017B69
		[DataMember(Name = "responseHeaders", IsRequired = false)]
		public Headers ResponseHeaders { get; private set; }

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x060015A0 RID: 5536 RVA: 0x00019972 File Offset: 0x00017B72
		// (set) Token: 0x060015A1 RID: 5537 RVA: 0x0001997A File Offset: 0x00017B7A
		[DataMember(Name = "requestId", IsRequired = false)]
		public string RequestId { get; private set; }
	}
}
