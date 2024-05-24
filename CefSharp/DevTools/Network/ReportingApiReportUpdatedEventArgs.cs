using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002FF RID: 767
	[DataContract]
	public class ReportingApiReportUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x0600166C RID: 5740 RVA: 0x0001A0E0 File Offset: 0x000182E0
		// (set) Token: 0x0600166D RID: 5741 RVA: 0x0001A0E8 File Offset: 0x000182E8
		[DataMember(Name = "report", IsRequired = true)]
		public ReportingApiReport Report { get; private set; }
	}
}
