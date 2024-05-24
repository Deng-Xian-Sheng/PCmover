using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200038F RID: 911
	[DataContract]
	public class PseudoElementAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x0001F096 File Offset: 0x0001D296
		// (set) Token: 0x06001AC7 RID: 6855 RVA: 0x0001F09E File Offset: 0x0001D29E
		[DataMember(Name = "parentId", IsRequired = true)]
		public int ParentId { get; private set; }

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x06001AC8 RID: 6856 RVA: 0x0001F0A7 File Offset: 0x0001D2A7
		// (set) Token: 0x06001AC9 RID: 6857 RVA: 0x0001F0AF File Offset: 0x0001D2AF
		[DataMember(Name = "pseudoElement", IsRequired = true)]
		public Node PseudoElement { get; private set; }
	}
}
