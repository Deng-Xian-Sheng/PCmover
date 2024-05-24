using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000130 RID: 304
	[DataContract]
	public class CustomPreview : DevToolsDomainEntityBase
	{
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0000E06B File Offset: 0x0000C26B
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0000E073 File Offset: 0x0000C273
		[DataMember(Name = "header", IsRequired = true)]
		public string Header { get; set; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0000E07C File Offset: 0x0000C27C
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x0000E084 File Offset: 0x0000C284
		[DataMember(Name = "bodyGetterId", IsRequired = false)]
		public string BodyGetterId { get; set; }
	}
}
