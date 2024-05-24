using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000145 RID: 325
	[DataContract]
	public class ExceptionThrownEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x0600096F RID: 2415 RVA: 0x0000E68D File Offset: 0x0000C88D
		// (set) Token: 0x06000970 RID: 2416 RVA: 0x0000E695 File Offset: 0x0000C895
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x0000E69E File Offset: 0x0000C89E
		// (set) Token: 0x06000972 RID: 2418 RVA: 0x0000E6A6 File Offset: 0x0000C8A6
		[DataMember(Name = "exceptionDetails", IsRequired = true)]
		public ExceptionDetails ExceptionDetails { get; private set; }
	}
}
