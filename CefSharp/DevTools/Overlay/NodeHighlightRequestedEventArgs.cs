using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x020002A0 RID: 672
	[DataContract]
	public class NodeHighlightRequestedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06001332 RID: 4914 RVA: 0x00017989 File Offset: 0x00015B89
		// (set) Token: 0x06001333 RID: 4915 RVA: 0x00017991 File Offset: 0x00015B91
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; private set; }
	}
}
