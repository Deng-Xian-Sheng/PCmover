using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000245 RID: 581
	[DataContract]
	public class AppManifestError : DevToolsDomainEntityBase
	{
		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x060010AA RID: 4266 RVA: 0x0001555B File Offset: 0x0001375B
		// (set) Token: 0x060010AB RID: 4267 RVA: 0x00015563 File Offset: 0x00013763
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; set; }

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x060010AC RID: 4268 RVA: 0x0001556C File Offset: 0x0001376C
		// (set) Token: 0x060010AD RID: 4269 RVA: 0x00015574 File Offset: 0x00013774
		[DataMember(Name = "critical", IsRequired = true)]
		public int Critical { get; set; }

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x060010AE RID: 4270 RVA: 0x0001557D File Offset: 0x0001377D
		// (set) Token: 0x060010AF RID: 4271 RVA: 0x00015585 File Offset: 0x00013785
		[DataMember(Name = "line", IsRequired = true)]
		public int Line { get; set; }

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x0001558E File Offset: 0x0001378E
		// (set) Token: 0x060010B1 RID: 4273 RVA: 0x00015596 File Offset: 0x00013796
		[DataMember(Name = "column", IsRequired = true)]
		public int Column { get; set; }
	}
}
