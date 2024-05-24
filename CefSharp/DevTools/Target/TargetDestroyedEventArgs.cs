using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E3 RID: 483
	[DataContract]
	public class TargetDestroyedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00012F4D File Offset: 0x0001114D
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x00012F55 File Offset: 0x00011155
		[DataMember(Name = "targetId", IsRequired = true)]
		public string TargetId { get; private set; }
	}
}
