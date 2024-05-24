using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F9 RID: 761
	[DataContract]
	public class TrustTokenOperationDoneEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x0600163E RID: 5694 RVA: 0x00019F20 File Offset: 0x00018120
		// (set) Token: 0x0600163F RID: 5695 RVA: 0x00019F3C File Offset: 0x0001813C
		public TrustTokenOperationDoneStatus Status
		{
			get
			{
				return (TrustTokenOperationDoneStatus)DevToolsDomainEventArgsBase.StringToEnum(typeof(TrustTokenOperationDoneStatus), this.status);
			}
			set
			{
				this.status = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06001640 RID: 5696 RVA: 0x00019F4F File Offset: 0x0001814F
		// (set) Token: 0x06001641 RID: 5697 RVA: 0x00019F57 File Offset: 0x00018157
		[DataMember(Name = "status", IsRequired = true)]
		internal string status { get; private set; }

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06001642 RID: 5698 RVA: 0x00019F60 File Offset: 0x00018160
		// (set) Token: 0x06001643 RID: 5699 RVA: 0x00019F7C File Offset: 0x0001817C
		public TrustTokenOperationType Type
		{
			get
			{
				return (TrustTokenOperationType)DevToolsDomainEventArgsBase.StringToEnum(typeof(TrustTokenOperationType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06001644 RID: 5700 RVA: 0x00019F8F File Offset: 0x0001818F
		// (set) Token: 0x06001645 RID: 5701 RVA: 0x00019F97 File Offset: 0x00018197
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06001646 RID: 5702 RVA: 0x00019FA0 File Offset: 0x000181A0
		// (set) Token: 0x06001647 RID: 5703 RVA: 0x00019FA8 File Offset: 0x000181A8
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06001648 RID: 5704 RVA: 0x00019FB1 File Offset: 0x000181B1
		// (set) Token: 0x06001649 RID: 5705 RVA: 0x00019FB9 File Offset: 0x000181B9
		[DataMember(Name = "topLevelOrigin", IsRequired = false)]
		public string TopLevelOrigin { get; private set; }

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x0600164A RID: 5706 RVA: 0x00019FC2 File Offset: 0x000181C2
		// (set) Token: 0x0600164B RID: 5707 RVA: 0x00019FCA File Offset: 0x000181CA
		[DataMember(Name = "issuerOrigin", IsRequired = false)]
		public string IssuerOrigin { get; private set; }

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x0600164C RID: 5708 RVA: 0x00019FD3 File Offset: 0x000181D3
		// (set) Token: 0x0600164D RID: 5709 RVA: 0x00019FDB File Offset: 0x000181DB
		[DataMember(Name = "issuedTokenCount", IsRequired = false)]
		public int? IssuedTokenCount { get; private set; }
	}
}
