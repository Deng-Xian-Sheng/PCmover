using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200039E RID: 926
	[DataContract]
	public class GetRelayoutBoundaryResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009C3 RID: 2499
		// (get) Token: 0x06001B0D RID: 6925 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
		// (set) Token: 0x06001B0E RID: 6926 RVA: 0x0001F2EC File Offset: 0x0001D4EC
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x06001B0F RID: 6927 RVA: 0x0001F2F5 File Offset: 0x0001D4F5
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
