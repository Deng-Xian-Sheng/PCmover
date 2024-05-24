using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200038B RID: 907
	[DataContract]
	public class ChildNodeInsertedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000999 RID: 2457
		// (get) Token: 0x06001AB2 RID: 6834 RVA: 0x0001EFEE File Offset: 0x0001D1EE
		// (set) Token: 0x06001AB3 RID: 6835 RVA: 0x0001EFF6 File Offset: 0x0001D1F6
		[DataMember(Name = "parentNodeId", IsRequired = true)]
		public int ParentNodeId { get; private set; }

		// Token: 0x1700099A RID: 2458
		// (get) Token: 0x06001AB4 RID: 6836 RVA: 0x0001EFFF File Offset: 0x0001D1FF
		// (set) Token: 0x06001AB5 RID: 6837 RVA: 0x0001F007 File Offset: 0x0001D207
		[DataMember(Name = "previousNodeId", IsRequired = true)]
		public int PreviousNodeId { get; private set; }

		// Token: 0x1700099B RID: 2459
		// (get) Token: 0x06001AB6 RID: 6838 RVA: 0x0001F010 File Offset: 0x0001D210
		// (set) Token: 0x06001AB7 RID: 6839 RVA: 0x0001F018 File Offset: 0x0001D218
		[DataMember(Name = "node", IsRequired = true)]
		public Node Node { get; private set; }
	}
}
