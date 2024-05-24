using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000395 RID: 917
	[DataContract]
	public class CopyToResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06001AE3 RID: 6883 RVA: 0x0001F189 File Offset: 0x0001D389
		// (set) Token: 0x06001AE4 RID: 6884 RVA: 0x0001F191 File Offset: 0x0001D391
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x06001AE5 RID: 6885 RVA: 0x0001F19A File Offset: 0x0001D39A
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
