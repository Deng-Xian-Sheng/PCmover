using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002F6 RID: 758
	[DataContract]
	public class RequestWillBeSentExtraInfoEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06001624 RID: 5668 RVA: 0x00019E26 File Offset: 0x00018026
		// (set) Token: 0x06001625 RID: 5669 RVA: 0x00019E2E File Offset: 0x0001802E
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06001626 RID: 5670 RVA: 0x00019E37 File Offset: 0x00018037
		// (set) Token: 0x06001627 RID: 5671 RVA: 0x00019E3F File Offset: 0x0001803F
		[DataMember(Name = "associatedCookies", IsRequired = true)]
		public IList<BlockedCookieWithReason> AssociatedCookies { get; private set; }

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06001628 RID: 5672 RVA: 0x00019E48 File Offset: 0x00018048
		// (set) Token: 0x06001629 RID: 5673 RVA: 0x00019E50 File Offset: 0x00018050
		[DataMember(Name = "headers", IsRequired = true)]
		public Headers Headers { get; private set; }

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x0600162A RID: 5674 RVA: 0x00019E59 File Offset: 0x00018059
		// (set) Token: 0x0600162B RID: 5675 RVA: 0x00019E61 File Offset: 0x00018061
		[DataMember(Name = "connectTiming", IsRequired = true)]
		public ConnectTiming ConnectTiming { get; private set; }

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x00019E6A File Offset: 0x0001806A
		// (set) Token: 0x0600162D RID: 5677 RVA: 0x00019E72 File Offset: 0x00018072
		[DataMember(Name = "clientSecurityState", IsRequired = false)]
		public ClientSecurityState ClientSecurityState { get; private set; }
	}
}
