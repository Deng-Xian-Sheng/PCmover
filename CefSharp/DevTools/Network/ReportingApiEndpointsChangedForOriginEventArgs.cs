using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000300 RID: 768
	[DataContract]
	public class ReportingApiEndpointsChangedForOriginEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x0600166F RID: 5743 RVA: 0x0001A0F9 File Offset: 0x000182F9
		// (set) Token: 0x06001670 RID: 5744 RVA: 0x0001A101 File Offset: 0x00018301
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; private set; }

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06001671 RID: 5745 RVA: 0x0001A10A File Offset: 0x0001830A
		// (set) Token: 0x06001672 RID: 5746 RVA: 0x0001A112 File Offset: 0x00018312
		[DataMember(Name = "endpoints", IsRequired = true)]
		public IList<ReportingApiEndpoint> Endpoints { get; private set; }
	}
}
