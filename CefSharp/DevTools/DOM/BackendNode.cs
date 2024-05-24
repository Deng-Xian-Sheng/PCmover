using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200037D RID: 893
	[DataContract]
	public class BackendNode : DevToolsDomainEntityBase
	{
		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x06001A27 RID: 6695 RVA: 0x0001EAFC File Offset: 0x0001CCFC
		// (set) Token: 0x06001A28 RID: 6696 RVA: 0x0001EB04 File Offset: 0x0001CD04
		[DataMember(Name = "nodeType", IsRequired = true)]
		public int NodeType { get; set; }

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x06001A29 RID: 6697 RVA: 0x0001EB0D File Offset: 0x0001CD0D
		// (set) Token: 0x06001A2A RID: 6698 RVA: 0x0001EB15 File Offset: 0x0001CD15
		[DataMember(Name = "nodeName", IsRequired = true)]
		public string NodeName { get; set; }

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x06001A2B RID: 6699 RVA: 0x0001EB1E File Offset: 0x0001CD1E
		// (set) Token: 0x06001A2C RID: 6700 RVA: 0x0001EB26 File Offset: 0x0001CD26
		[DataMember(Name = "backendNodeId", IsRequired = true)]
		public int BackendNodeId { get; set; }
	}
}
