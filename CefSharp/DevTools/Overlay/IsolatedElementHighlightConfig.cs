using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200029C RID: 668
	[DataContract]
	public class IsolatedElementHighlightConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x0001790B File Offset: 0x00015B0B
		// (set) Token: 0x06001324 RID: 4900 RVA: 0x00017913 File Offset: 0x00015B13
		[DataMember(Name = "isolationModeHighlightConfig", IsRequired = true)]
		public IsolationModeHighlightConfig IsolationModeHighlightConfig { get; set; }

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06001325 RID: 4901 RVA: 0x0001791C File Offset: 0x00015B1C
		// (set) Token: 0x06001326 RID: 4902 RVA: 0x00017924 File Offset: 0x00015B24
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }
	}
}
