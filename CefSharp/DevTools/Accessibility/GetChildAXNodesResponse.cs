using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200044E RID: 1102
	[DataContract]
	public class GetChildAXNodesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000BB9 RID: 3001
		// (get) Token: 0x06001FF2 RID: 8178 RVA: 0x00023DF2 File Offset: 0x00021FF2
		// (set) Token: 0x06001FF3 RID: 8179 RVA: 0x00023DFA File Offset: 0x00021FFA
		[DataMember]
		internal IList<AXNode> nodes { get; set; }

		// Token: 0x17000BBA RID: 3002
		// (get) Token: 0x06001FF4 RID: 8180 RVA: 0x00023E03 File Offset: 0x00022003
		public IList<AXNode> Nodes
		{
			get
			{
				return this.nodes;
			}
		}
	}
}
