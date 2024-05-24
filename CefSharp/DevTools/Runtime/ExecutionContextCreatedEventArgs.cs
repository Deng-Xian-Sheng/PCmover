using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000146 RID: 326
	[DataContract]
	public class ExecutionContextCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0000E6B7 File Offset: 0x0000C8B7
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x0000E6BF File Offset: 0x0000C8BF
		[DataMember(Name = "context", IsRequired = true)]
		public ExecutionContextDescription Context { get; private set; }
	}
}
