using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200038D RID: 909
	[DataContract]
	public class DistributedNodesUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700099E RID: 2462
		// (get) Token: 0x06001ABE RID: 6846 RVA: 0x0001F053 File Offset: 0x0001D253
		// (set) Token: 0x06001ABF RID: 6847 RVA: 0x0001F05B File Offset: 0x0001D25B
		[DataMember(Name = "insertionPointId", IsRequired = true)]
		public int InsertionPointId { get; private set; }

		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x06001AC0 RID: 6848 RVA: 0x0001F064 File Offset: 0x0001D264
		// (set) Token: 0x06001AC1 RID: 6849 RVA: 0x0001F06C File Offset: 0x0001D26C
		[DataMember(Name = "distributedNodes", IsRequired = true)]
		public IList<BackendNode> DistributedNodes { get; private set; }
	}
}
