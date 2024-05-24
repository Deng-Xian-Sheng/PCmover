using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002FE RID: 766
	[DataContract]
	public class ReportingApiReportAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06001669 RID: 5737 RVA: 0x0001A0C7 File Offset: 0x000182C7
		// (set) Token: 0x0600166A RID: 5738 RVA: 0x0001A0CF File Offset: 0x000182CF
		[DataMember(Name = "report", IsRequired = true)]
		public ReportingApiReport Report { get; private set; }
	}
}
