using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000396 RID: 918
	[DataContract]
	public class DescribeNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x06001AE7 RID: 6887 RVA: 0x0001F1AA File Offset: 0x0001D3AA
		// (set) Token: 0x06001AE8 RID: 6888 RVA: 0x0001F1B2 File Offset: 0x0001D3B2
		[DataMember]
		internal Node node { get; set; }

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x06001AE9 RID: 6889 RVA: 0x0001F1BB File Offset: 0x0001D3BB
		public Node Node
		{
			get
			{
				return this.node;
			}
		}
	}
}
