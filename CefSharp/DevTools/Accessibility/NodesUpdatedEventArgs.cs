using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000449 RID: 1097
	[DataContract]
	public class NodesUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000BB0 RID: 2992
		// (get) Token: 0x06001FDF RID: 8159 RVA: 0x00023D55 File Offset: 0x00021F55
		// (set) Token: 0x06001FE0 RID: 8160 RVA: 0x00023D5D File Offset: 0x00021F5D
		[DataMember(Name = "nodes", IsRequired = true)]
		public IList<AXNode> Nodes { get; private set; }
	}
}
