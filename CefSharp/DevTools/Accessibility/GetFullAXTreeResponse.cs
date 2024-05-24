using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200044B RID: 1099
	[DataContract]
	public class GetFullAXTreeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000BB3 RID: 2995
		// (get) Token: 0x06001FE6 RID: 8166 RVA: 0x00023D8F File Offset: 0x00021F8F
		// (set) Token: 0x06001FE7 RID: 8167 RVA: 0x00023D97 File Offset: 0x00021F97
		[DataMember]
		internal IList<AXNode> nodes { get; set; }

		// Token: 0x17000BB4 RID: 2996
		// (get) Token: 0x06001FE8 RID: 8168 RVA: 0x00023DA0 File Offset: 0x00021FA0
		public IList<AXNode> Nodes
		{
			get
			{
				return this.nodes;
			}
		}
	}
}
