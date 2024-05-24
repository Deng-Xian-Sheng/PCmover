using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000140 RID: 320
	[DataContract]
	public class StackTraceId : DevToolsDomainEntityBase
	{
		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x0000E561 File Offset: 0x0000C761
		// (set) Token: 0x06000950 RID: 2384 RVA: 0x0000E569 File Offset: 0x0000C769
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x0000E572 File Offset: 0x0000C772
		// (set) Token: 0x06000952 RID: 2386 RVA: 0x0000E57A File Offset: 0x0000C77A
		[DataMember(Name = "debuggerId", IsRequired = false)]
		public string DebuggerId { get; set; }
	}
}
