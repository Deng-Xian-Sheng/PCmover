using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000144 RID: 324
	[DataContract]
	public class ExceptionRevokedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x0000E663 File Offset: 0x0000C863
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x0000E66B File Offset: 0x0000C86B
		[DataMember(Name = "reason", IsRequired = true)]
		public string Reason { get; private set; }

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x0000E674 File Offset: 0x0000C874
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x0000E67C File Offset: 0x0000C87C
		[DataMember(Name = "exceptionId", IsRequired = true)]
		public int ExceptionId { get; private set; }
	}
}
