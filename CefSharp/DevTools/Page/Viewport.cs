using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000249 RID: 585
	[DataContract]
	public class Viewport : DevToolsDomainEntityBase
	{
		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x0001569C File Offset: 0x0001389C
		// (set) Token: 0x060010D1 RID: 4305 RVA: 0x000156A4 File Offset: 0x000138A4
		[DataMember(Name = "x", IsRequired = true)]
		public double X { get; set; }

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x000156AD File Offset: 0x000138AD
		// (set) Token: 0x060010D3 RID: 4307 RVA: 0x000156B5 File Offset: 0x000138B5
		[DataMember(Name = "y", IsRequired = true)]
		public double Y { get; set; }

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x060010D4 RID: 4308 RVA: 0x000156BE File Offset: 0x000138BE
		// (set) Token: 0x060010D5 RID: 4309 RVA: 0x000156C6 File Offset: 0x000138C6
		[DataMember(Name = "width", IsRequired = true)]
		public double Width { get; set; }

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x060010D6 RID: 4310 RVA: 0x000156CF File Offset: 0x000138CF
		// (set) Token: 0x060010D7 RID: 4311 RVA: 0x000156D7 File Offset: 0x000138D7
		[DataMember(Name = "height", IsRequired = true)]
		public double Height { get; set; }

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x060010D8 RID: 4312 RVA: 0x000156E0 File Offset: 0x000138E0
		// (set) Token: 0x060010D9 RID: 4313 RVA: 0x000156E8 File Offset: 0x000138E8
		[DataMember(Name = "scale", IsRequired = true)]
		public double Scale { get; set; }
	}
}
