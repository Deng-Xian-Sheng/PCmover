using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003AA RID: 938
	[DataContract]
	public class SetNodeNameResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06001B40 RID: 6976 RVA: 0x0001F489 File Offset: 0x0001D689
		// (set) Token: 0x06001B41 RID: 6977 RVA: 0x0001F491 File Offset: 0x0001D691
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06001B42 RID: 6978 RVA: 0x0001F49A File Offset: 0x0001D69A
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
