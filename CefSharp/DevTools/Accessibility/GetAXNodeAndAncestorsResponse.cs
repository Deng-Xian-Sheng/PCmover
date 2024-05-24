using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200044D RID: 1101
	[DataContract]
	public class GetAXNodeAndAncestorsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000BB7 RID: 2999
		// (get) Token: 0x06001FEE RID: 8174 RVA: 0x00023DD1 File Offset: 0x00021FD1
		// (set) Token: 0x06001FEF RID: 8175 RVA: 0x00023DD9 File Offset: 0x00021FD9
		[DataMember]
		internal IList<AXNode> nodes { get; set; }

		// Token: 0x17000BB8 RID: 3000
		// (get) Token: 0x06001FF0 RID: 8176 RVA: 0x00023DE2 File Offset: 0x00021FE2
		public IList<AXNode> Nodes
		{
			get
			{
				return this.nodes;
			}
		}
	}
}
