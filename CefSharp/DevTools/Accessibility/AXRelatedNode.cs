using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000443 RID: 1091
	[DataContract]
	public class AXRelatedNode : DevToolsDomainEntityBase
	{
		// Token: 0x17000B98 RID: 2968
		// (get) Token: 0x06001FAA RID: 8106 RVA: 0x00023B59 File Offset: 0x00021D59
		// (set) Token: 0x06001FAB RID: 8107 RVA: 0x00023B61 File Offset: 0x00021D61
		[DataMember(Name = "backendDOMNodeId", IsRequired = true)]
		public int BackendDOMNodeId { get; set; }

		// Token: 0x17000B99 RID: 2969
		// (get) Token: 0x06001FAC RID: 8108 RVA: 0x00023B6A File Offset: 0x00021D6A
		// (set) Token: 0x06001FAD RID: 8109 RVA: 0x00023B72 File Offset: 0x00021D72
		[DataMember(Name = "idref", IsRequired = false)]
		public string Idref { get; set; }

		// Token: 0x17000B9A RID: 2970
		// (get) Token: 0x06001FAE RID: 8110 RVA: 0x00023B7B File Offset: 0x00021D7B
		// (set) Token: 0x06001FAF RID: 8111 RVA: 0x00023B83 File Offset: 0x00021D83
		[DataMember(Name = "text", IsRequired = false)]
		public string Text { get; set; }
	}
}
