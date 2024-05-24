using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200025B RID: 603
	[DataContract]
	public class FrameAttachedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x0600111F RID: 4383 RVA: 0x00015990 File Offset: 0x00013B90
		// (set) Token: 0x06001120 RID: 4384 RVA: 0x00015998 File Offset: 0x00013B98
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001121 RID: 4385 RVA: 0x000159A1 File Offset: 0x00013BA1
		// (set) Token: 0x06001122 RID: 4386 RVA: 0x000159A9 File Offset: 0x00013BA9
		[DataMember(Name = "parentFrameId", IsRequired = true)]
		public string ParentFrameId { get; private set; }

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06001123 RID: 4387 RVA: 0x000159B2 File Offset: 0x00013BB2
		// (set) Token: 0x06001124 RID: 4388 RVA: 0x000159BA File Offset: 0x00013BBA
		[DataMember(Name = "stack", IsRequired = false)]
		public StackTrace Stack { get; private set; }
	}
}
