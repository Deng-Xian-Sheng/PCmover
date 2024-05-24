using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200027E RID: 638
	[DataContract]
	public class GetResourceTreeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06001201 RID: 4609 RVA: 0x000161D3 File Offset: 0x000143D3
		// (set) Token: 0x06001202 RID: 4610 RVA: 0x000161DB File Offset: 0x000143DB
		[DataMember]
		internal FrameResourceTree frameTree { get; set; }

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06001203 RID: 4611 RVA: 0x000161E4 File Offset: 0x000143E4
		public FrameResourceTree FrameTree
		{
			get
			{
				return this.frameTree;
			}
		}
	}
}
