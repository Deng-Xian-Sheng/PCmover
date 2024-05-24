using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A4 RID: 932
	[DataContract]
	public class QuerySelectorResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x06001B28 RID: 6952 RVA: 0x0001F3C3 File Offset: 0x0001D5C3
		// (set) Token: 0x06001B29 RID: 6953 RVA: 0x0001F3CB File Offset: 0x0001D5CB
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06001B2A RID: 6954 RVA: 0x0001F3D4 File Offset: 0x0001D5D4
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
