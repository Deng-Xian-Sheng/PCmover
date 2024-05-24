using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200044F RID: 1103
	[DataContract]
	public class QueryAXTreeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000BBB RID: 3003
		// (get) Token: 0x06001FF6 RID: 8182 RVA: 0x00023E13 File Offset: 0x00022013
		// (set) Token: 0x06001FF7 RID: 8183 RVA: 0x00023E1B File Offset: 0x0002201B
		[DataMember]
		internal IList<AXNode> nodes { get; set; }

		// Token: 0x17000BBC RID: 3004
		// (get) Token: 0x06001FF8 RID: 8184 RVA: 0x00023E24 File Offset: 0x00022024
		public IList<AXNode> Nodes
		{
			get
			{
				return this.nodes;
			}
		}
	}
}
