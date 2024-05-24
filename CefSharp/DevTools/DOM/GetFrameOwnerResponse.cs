using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003AB RID: 939
	[DataContract]
	public class GetFrameOwnerResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06001B44 RID: 6980 RVA: 0x0001F4AA File Offset: 0x0001D6AA
		// (set) Token: 0x06001B45 RID: 6981 RVA: 0x0001F4B2 File Offset: 0x0001D6B2
		[DataMember]
		internal int backendNodeId { get; set; }

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x06001B46 RID: 6982 RVA: 0x0001F4BB File Offset: 0x0001D6BB
		public int BackendNodeId
		{
			get
			{
				return this.backendNodeId;
			}
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06001B47 RID: 6983 RVA: 0x0001F4C3 File Offset: 0x0001D6C3
		// (set) Token: 0x06001B48 RID: 6984 RVA: 0x0001F4CB File Offset: 0x0001D6CB
		[DataMember]
		internal int? nodeId { get; set; }

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06001B49 RID: 6985 RVA: 0x0001F4D4 File Offset: 0x0001D6D4
		public int? NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
