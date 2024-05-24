using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E1 RID: 481
	[DataContract]
	public class ReceivedMessageFromTargetEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x00012EF9 File Offset: 0x000110F9
		// (set) Token: 0x06000DDC RID: 3548 RVA: 0x00012F01 File Offset: 0x00011101
		[DataMember(Name = "sessionId", IsRequired = true)]
		public string SessionId { get; private set; }

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00012F0A File Offset: 0x0001110A
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00012F12 File Offset: 0x00011112
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; private set; }

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00012F1B File Offset: 0x0001111B
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x00012F23 File Offset: 0x00011123
		[DataMember(Name = "targetId", IsRequired = false)]
		public string TargetId { get; private set; }
	}
}
