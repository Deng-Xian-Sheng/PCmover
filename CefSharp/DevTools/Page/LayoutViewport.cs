using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000247 RID: 583
	[DataContract]
	public class LayoutViewport : DevToolsDomainEntityBase
	{
		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x060010B6 RID: 4278 RVA: 0x000155C0 File Offset: 0x000137C0
		// (set) Token: 0x060010B7 RID: 4279 RVA: 0x000155C8 File Offset: 0x000137C8
		[DataMember(Name = "pageX", IsRequired = true)]
		public int PageX { get; set; }

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x000155D1 File Offset: 0x000137D1
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x000155D9 File Offset: 0x000137D9
		[DataMember(Name = "pageY", IsRequired = true)]
		public int PageY { get; set; }

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x000155E2 File Offset: 0x000137E2
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x000155EA File Offset: 0x000137EA
		[DataMember(Name = "clientWidth", IsRequired = true)]
		public int ClientWidth { get; set; }

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x000155F3 File Offset: 0x000137F3
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x000155FB File Offset: 0x000137FB
		[DataMember(Name = "clientHeight", IsRequired = true)]
		public int ClientHeight { get; set; }
	}
}
