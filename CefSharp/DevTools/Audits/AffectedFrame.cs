using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200040B RID: 1035
	[DataContract]
	public class AffectedFrame : DevToolsDomainEntityBase
	{
		// Token: 0x17000AF4 RID: 2804
		// (get) Token: 0x06001E2F RID: 7727 RVA: 0x00022984 File Offset: 0x00020B84
		// (set) Token: 0x06001E30 RID: 7728 RVA: 0x0002298C File Offset: 0x00020B8C
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; set; }
	}
}
