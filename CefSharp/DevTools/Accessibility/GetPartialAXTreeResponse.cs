using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200044A RID: 1098
	[DataContract]
	public class GetPartialAXTreeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000BB1 RID: 2993
		// (get) Token: 0x06001FE2 RID: 8162 RVA: 0x00023D6E File Offset: 0x00021F6E
		// (set) Token: 0x06001FE3 RID: 8163 RVA: 0x00023D76 File Offset: 0x00021F76
		[DataMember]
		internal IList<AXNode> nodes { get; set; }

		// Token: 0x17000BB2 RID: 2994
		// (get) Token: 0x06001FE4 RID: 8164 RVA: 0x00023D7F File Offset: 0x00021F7F
		public IList<AXNode> Nodes
		{
			get
			{
				return this.nodes;
			}
		}
	}
}
