using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200038A RID: 906
	[DataContract]
	public class ChildNodeCountUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x06001AAD RID: 6829 RVA: 0x0001EFC4 File Offset: 0x0001D1C4
		// (set) Token: 0x06001AAE RID: 6830 RVA: 0x0001EFCC File Offset: 0x0001D1CC
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; private set; }

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x06001AAF RID: 6831 RVA: 0x0001EFD5 File Offset: 0x0001D1D5
		// (set) Token: 0x06001AB0 RID: 6832 RVA: 0x0001EFDD File Offset: 0x0001D1DD
		[DataMember(Name = "childNodeCount", IsRequired = true)]
		public int ChildNodeCount { get; private set; }
	}
}
