using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F7 RID: 759
	[DataContract]
	public class ResponseReceivedExtraInfoEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x0600162F RID: 5679 RVA: 0x00019E83 File Offset: 0x00018083
		// (set) Token: 0x06001630 RID: 5680 RVA: 0x00019E8B File Offset: 0x0001808B
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06001631 RID: 5681 RVA: 0x00019E94 File Offset: 0x00018094
		// (set) Token: 0x06001632 RID: 5682 RVA: 0x00019E9C File Offset: 0x0001809C
		[DataMember(Name = "blockedCookies", IsRequired = true)]
		public IList<BlockedSetCookieWithReason> BlockedCookies { get; private set; }

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06001633 RID: 5683 RVA: 0x00019EA5 File Offset: 0x000180A5
		// (set) Token: 0x06001634 RID: 5684 RVA: 0x00019EAD File Offset: 0x000180AD
		[DataMember(Name = "headers", IsRequired = true)]
		public Headers Headers { get; private set; }

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06001635 RID: 5685 RVA: 0x00019EB6 File Offset: 0x000180B6
		// (set) Token: 0x06001636 RID: 5686 RVA: 0x00019ED2 File Offset: 0x000180D2
		public IPAddressSpace ResourceIPAddressSpace
		{
			get
			{
				return (IPAddressSpace)DevToolsDomainEventArgsBase.StringToEnum(typeof(IPAddressSpace), this.resourceIPAddressSpace);
			}
			set
			{
				this.resourceIPAddressSpace = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06001637 RID: 5687 RVA: 0x00019EE5 File Offset: 0x000180E5
		// (set) Token: 0x06001638 RID: 5688 RVA: 0x00019EED File Offset: 0x000180ED
		[DataMember(Name = "resourceIPAddressSpace", IsRequired = true)]
		internal string resourceIPAddressSpace { get; private set; }

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06001639 RID: 5689 RVA: 0x00019EF6 File Offset: 0x000180F6
		// (set) Token: 0x0600163A RID: 5690 RVA: 0x00019EFE File Offset: 0x000180FE
		[DataMember(Name = "statusCode", IsRequired = true)]
		public int StatusCode { get; private set; }

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x0600163B RID: 5691 RVA: 0x00019F07 File Offset: 0x00018107
		// (set) Token: 0x0600163C RID: 5692 RVA: 0x00019F0F File Offset: 0x0001810F
		[DataMember(Name = "headersText", IsRequired = false)]
		public string HeadersText { get; private set; }
	}
}
