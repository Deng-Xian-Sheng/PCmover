using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200038C RID: 908
	[DataContract]
	public class ChildNodeRemovedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x06001AB9 RID: 6841 RVA: 0x0001F029 File Offset: 0x0001D229
		// (set) Token: 0x06001ABA RID: 6842 RVA: 0x0001F031 File Offset: 0x0001D231
		[DataMember(Name = "parentNodeId", IsRequired = true)]
		public int ParentNodeId { get; private set; }

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x06001ABB RID: 6843 RVA: 0x0001F03A File Offset: 0x0001D23A
		// (set) Token: 0x06001ABC RID: 6844 RVA: 0x0001F042 File Offset: 0x0001D242
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; private set; }
	}
}
