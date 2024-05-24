using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000147 RID: 327
	[DataContract]
	public class ExecutionContextDestroyedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x0000E6D0 File Offset: 0x0000C8D0
		// (set) Token: 0x06000978 RID: 2424 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
		[DataMember(Name = "executionContextId", IsRequired = true)]
		public int ExecutionContextId { get; private set; }
	}
}
