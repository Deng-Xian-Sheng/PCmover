using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E5 RID: 485
	[DataContract]
	public class TargetInfoChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x00012FA1 File Offset: 0x000111A1
		// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x00012FA9 File Offset: 0x000111A9
		[DataMember(Name = "targetInfo", IsRequired = true)]
		public TargetInfo TargetInfo { get; private set; }
	}
}
