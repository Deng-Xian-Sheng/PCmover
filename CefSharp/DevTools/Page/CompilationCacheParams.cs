using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000252 RID: 594
	[DataContract]
	public class CompilationCacheParams : DevToolsDomainEntityBase
	{
		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x060010FE RID: 4350 RVA: 0x00015820 File Offset: 0x00013A20
		// (set) Token: 0x060010FF RID: 4351 RVA: 0x00015828 File Offset: 0x00013A28
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06001100 RID: 4352 RVA: 0x00015831 File Offset: 0x00013A31
		// (set) Token: 0x06001101 RID: 4353 RVA: 0x00015839 File Offset: 0x00013A39
		[DataMember(Name = "eager", IsRequired = false)]
		public bool? Eager { get; set; }
	}
}
