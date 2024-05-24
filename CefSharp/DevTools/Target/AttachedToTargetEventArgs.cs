using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001DF RID: 479
	[DataContract]
	public class AttachedToTargetEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00012E94 File Offset: 0x00011094
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x00012E9C File Offset: 0x0001109C
		[DataMember(Name = "sessionId", IsRequired = true)]
		public string SessionId { get; private set; }

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00012EA5 File Offset: 0x000110A5
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x00012EAD File Offset: 0x000110AD
		[DataMember(Name = "targetInfo", IsRequired = true)]
		public TargetInfo TargetInfo { get; private set; }

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00012EB6 File Offset: 0x000110B6
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x00012EBE File Offset: 0x000110BE
		[DataMember(Name = "waitingForDebugger", IsRequired = true)]
		public bool WaitingForDebugger { get; private set; }
	}
}
