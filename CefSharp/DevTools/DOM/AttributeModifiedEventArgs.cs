using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000387 RID: 903
	[DataContract]
	public class AttributeModifiedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x06001A9C RID: 6812 RVA: 0x0001EF35 File Offset: 0x0001D135
		// (set) Token: 0x06001A9D RID: 6813 RVA: 0x0001EF3D File Offset: 0x0001D13D
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; private set; }

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x06001A9E RID: 6814 RVA: 0x0001EF46 File Offset: 0x0001D146
		// (set) Token: 0x06001A9F RID: 6815 RVA: 0x0001EF4E File Offset: 0x0001D14E
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; private set; }

		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x06001AA0 RID: 6816 RVA: 0x0001EF57 File Offset: 0x0001D157
		// (set) Token: 0x06001AA1 RID: 6817 RVA: 0x0001EF5F File Offset: 0x0001D15F
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; private set; }
	}
}
