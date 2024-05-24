using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000141 RID: 321
	[DataContract]
	public class BindingCalledEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x0000E58B File Offset: 0x0000C78B
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x0000E593 File Offset: 0x0000C793
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; private set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0000E59C File Offset: 0x0000C79C
		// (set) Token: 0x06000957 RID: 2391 RVA: 0x0000E5A4 File Offset: 0x0000C7A4
		[DataMember(Name = "payload", IsRequired = true)]
		public string Payload { get; private set; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x0000E5AD File Offset: 0x0000C7AD
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x0000E5B5 File Offset: 0x0000C7B5
		[DataMember(Name = "executionContextId", IsRequired = true)]
		public int ExecutionContextId { get; private set; }
	}
}
