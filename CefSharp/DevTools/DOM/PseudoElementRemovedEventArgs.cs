using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000390 RID: 912
	[DataContract]
	public class PseudoElementRemovedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x06001ACB RID: 6859 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
		// (set) Token: 0x06001ACC RID: 6860 RVA: 0x0001F0C8 File Offset: 0x0001D2C8
		[DataMember(Name = "parentId", IsRequired = true)]
		public int ParentId { get; private set; }

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06001ACD RID: 6861 RVA: 0x0001F0D1 File Offset: 0x0001D2D1
		// (set) Token: 0x06001ACE RID: 6862 RVA: 0x0001F0D9 File Offset: 0x0001D2D9
		[DataMember(Name = "pseudoElementId", IsRequired = true)]
		public int PseudoElementId { get; private set; }
	}
}
