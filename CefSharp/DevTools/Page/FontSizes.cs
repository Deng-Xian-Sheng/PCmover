using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200024C RID: 588
	[DataContract]
	public class FontSizes : DevToolsDomainEntityBase
	{
		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x060010EF RID: 4335 RVA: 0x000157A2 File Offset: 0x000139A2
		// (set) Token: 0x060010F0 RID: 4336 RVA: 0x000157AA File Offset: 0x000139AA
		[DataMember(Name = "standard", IsRequired = false)]
		public int? Standard { get; set; }

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x060010F1 RID: 4337 RVA: 0x000157B3 File Offset: 0x000139B3
		// (set) Token: 0x060010F2 RID: 4338 RVA: 0x000157BB File Offset: 0x000139BB
		[DataMember(Name = "fixed", IsRequired = false)]
		public int? Fixed { get; set; }
	}
}
