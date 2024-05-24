using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200042F RID: 1071
	[DataContract]
	public class IssueAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000B64 RID: 2916
		// (get) Token: 0x06001F23 RID: 7971 RVA: 0x00023388 File Offset: 0x00021588
		// (set) Token: 0x06001F24 RID: 7972 RVA: 0x00023390 File Offset: 0x00021590
		[DataMember(Name = "issue", IsRequired = true)]
		public InspectorIssue Issue { get; private set; }
	}
}
