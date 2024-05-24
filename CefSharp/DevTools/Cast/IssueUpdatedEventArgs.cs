using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Cast
{
	// Token: 0x020003B2 RID: 946
	[DataContract]
	public class IssueUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06001BA9 RID: 7081 RVA: 0x000205E1 File Offset: 0x0001E7E1
		// (set) Token: 0x06001BAA RID: 7082 RVA: 0x000205E9 File Offset: 0x0001E7E9
		[DataMember(Name = "issueMessage", IsRequired = true)]
		public string IssueMessage { get; private set; }
	}
}
