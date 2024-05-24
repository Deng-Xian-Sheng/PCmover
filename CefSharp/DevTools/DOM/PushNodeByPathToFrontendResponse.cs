using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A2 RID: 930
	[DataContract]
	public class PushNodeByPathToFrontendResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x06001B20 RID: 6944 RVA: 0x0001F381 File Offset: 0x0001D581
		// (set) Token: 0x06001B21 RID: 6945 RVA: 0x0001F389 File Offset: 0x0001D589
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x06001B22 RID: 6946 RVA: 0x0001F392 File Offset: 0x0001D592
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
