using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200024A RID: 586
	[DataContract]
	public class FontFamilies : DevToolsDomainEntityBase
	{
		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x000156F9 File Offset: 0x000138F9
		// (set) Token: 0x060010DC RID: 4316 RVA: 0x00015701 File Offset: 0x00013901
		[DataMember(Name = "standard", IsRequired = false)]
		public string Standard { get; set; }

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x060010DD RID: 4317 RVA: 0x0001570A File Offset: 0x0001390A
		// (set) Token: 0x060010DE RID: 4318 RVA: 0x00015712 File Offset: 0x00013912
		[DataMember(Name = "fixed", IsRequired = false)]
		public string Fixed { get; set; }

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x060010DF RID: 4319 RVA: 0x0001571B File Offset: 0x0001391B
		// (set) Token: 0x060010E0 RID: 4320 RVA: 0x00015723 File Offset: 0x00013923
		[DataMember(Name = "serif", IsRequired = false)]
		public string Serif { get; set; }

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x060010E1 RID: 4321 RVA: 0x0001572C File Offset: 0x0001392C
		// (set) Token: 0x060010E2 RID: 4322 RVA: 0x00015734 File Offset: 0x00013934
		[DataMember(Name = "sansSerif", IsRequired = false)]
		public string SansSerif { get; set; }

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x060010E3 RID: 4323 RVA: 0x0001573D File Offset: 0x0001393D
		// (set) Token: 0x060010E4 RID: 4324 RVA: 0x00015745 File Offset: 0x00013945
		[DataMember(Name = "cursive", IsRequired = false)]
		public string Cursive { get; set; }

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x060010E5 RID: 4325 RVA: 0x0001574E File Offset: 0x0001394E
		// (set) Token: 0x060010E6 RID: 4326 RVA: 0x00015756 File Offset: 0x00013956
		[DataMember(Name = "fantasy", IsRequired = false)]
		public string Fantasy { get; set; }

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x060010E7 RID: 4327 RVA: 0x0001575F File Offset: 0x0001395F
		// (set) Token: 0x060010E8 RID: 4328 RVA: 0x00015767 File Offset: 0x00013967
		[DataMember(Name = "pictograph", IsRequired = false)]
		public string Pictograph { get; set; }
	}
}
