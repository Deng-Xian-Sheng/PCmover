using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E0 RID: 480
	[DataContract]
	public class DetachedFromTargetEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00012ECF File Offset: 0x000110CF
		// (set) Token: 0x06000DD7 RID: 3543 RVA: 0x00012ED7 File Offset: 0x000110D7
		[DataMember(Name = "sessionId", IsRequired = true)]
		public string SessionId { get; private set; }

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00012EE0 File Offset: 0x000110E0
		// (set) Token: 0x06000DD9 RID: 3545 RVA: 0x00012EE8 File Offset: 0x000110E8
		[DataMember(Name = "targetId", IsRequired = false)]
		public string TargetId { get; private set; }
	}
}
