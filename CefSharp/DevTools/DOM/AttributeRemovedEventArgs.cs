using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000388 RID: 904
	[DataContract]
	public class AttributeRemovedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x06001AA3 RID: 6819 RVA: 0x0001EF70 File Offset: 0x0001D170
		// (set) Token: 0x06001AA4 RID: 6820 RVA: 0x0001EF78 File Offset: 0x0001D178
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; private set; }

		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x06001AA5 RID: 6821 RVA: 0x0001EF81 File Offset: 0x0001D181
		// (set) Token: 0x06001AA6 RID: 6822 RVA: 0x0001EF89 File Offset: 0x0001D189
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; private set; }
	}
}
