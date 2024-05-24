using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200013F RID: 319
	[DataContract]
	public class StackTrace : DevToolsDomainEntityBase
	{
		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x0000E515 File Offset: 0x0000C715
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x0000E51D File Offset: 0x0000C71D
		[DataMember(Name = "description", IsRequired = false)]
		public string Description { get; set; }

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x0000E526 File Offset: 0x0000C726
		// (set) Token: 0x06000949 RID: 2377 RVA: 0x0000E52E File Offset: 0x0000C72E
		[DataMember(Name = "callFrames", IsRequired = true)]
		public IList<CallFrame> CallFrames { get; set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x0000E537 File Offset: 0x0000C737
		// (set) Token: 0x0600094B RID: 2379 RVA: 0x0000E53F File Offset: 0x0000C73F
		[DataMember(Name = "parent", IsRequired = false)]
		public StackTrace Parent { get; set; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0000E548 File Offset: 0x0000C748
		// (set) Token: 0x0600094D RID: 2381 RVA: 0x0000E550 File Offset: 0x0000C750
		[DataMember(Name = "parentId", IsRequired = false)]
		public StackTraceId ParentId { get; set; }
	}
}
