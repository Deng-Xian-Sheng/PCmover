using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000391 RID: 913
	[DataContract]
	public class SetChildNodesEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x0001F0EA File Offset: 0x0001D2EA
		// (set) Token: 0x06001AD1 RID: 6865 RVA: 0x0001F0F2 File Offset: 0x0001D2F2
		[DataMember(Name = "parentId", IsRequired = true)]
		public int ParentId { get; private set; }

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06001AD2 RID: 6866 RVA: 0x0001F0FB File Offset: 0x0001D2FB
		// (set) Token: 0x06001AD3 RID: 6867 RVA: 0x0001F103 File Offset: 0x0001D303
		[DataMember(Name = "nodes", IsRequired = true)]
		public IList<Node> Nodes { get; private set; }
	}
}
