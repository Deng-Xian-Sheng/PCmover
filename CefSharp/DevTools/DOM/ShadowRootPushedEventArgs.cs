using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000393 RID: 915
	[DataContract]
	public class ShadowRootPushedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x06001ADA RID: 6874 RVA: 0x0001F13E File Offset: 0x0001D33E
		// (set) Token: 0x06001ADB RID: 6875 RVA: 0x0001F146 File Offset: 0x0001D346
		[DataMember(Name = "hostId", IsRequired = true)]
		public int HostId { get; private set; }

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06001ADC RID: 6876 RVA: 0x0001F14F File Offset: 0x0001D34F
		// (set) Token: 0x06001ADD RID: 6877 RVA: 0x0001F157 File Offset: 0x0001D357
		[DataMember(Name = "root", IsRequired = true)]
		public Node Root { get; private set; }
	}
}
