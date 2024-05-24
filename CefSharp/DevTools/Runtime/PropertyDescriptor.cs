using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000138 RID: 312
	[DataContract]
	public class PropertyDescriptor : DevToolsDomainEntityBase
	{
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x0000E246 File Offset: 0x0000C446
		// (set) Token: 0x060008F2 RID: 2290 RVA: 0x0000E24E File Offset: 0x0000C44E
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x0000E257 File Offset: 0x0000C457
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x0000E25F File Offset: 0x0000C45F
		[DataMember(Name = "value", IsRequired = false)]
		public RemoteObject Value { get; set; }

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0000E268 File Offset: 0x0000C468
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x0000E270 File Offset: 0x0000C470
		[DataMember(Name = "writable", IsRequired = false)]
		public bool? Writable { get; set; }

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0000E279 File Offset: 0x0000C479
		// (set) Token: 0x060008F8 RID: 2296 RVA: 0x0000E281 File Offset: 0x0000C481
		[DataMember(Name = "get", IsRequired = false)]
		public RemoteObject Get { get; set; }

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x0000E28A File Offset: 0x0000C48A
		// (set) Token: 0x060008FA RID: 2298 RVA: 0x0000E292 File Offset: 0x0000C492
		[DataMember(Name = "set", IsRequired = false)]
		public RemoteObject Set { get; set; }

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0000E29B File Offset: 0x0000C49B
		// (set) Token: 0x060008FC RID: 2300 RVA: 0x0000E2A3 File Offset: 0x0000C4A3
		[DataMember(Name = "configurable", IsRequired = true)]
		public bool Configurable { get; set; }

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0000E2AC File Offset: 0x0000C4AC
		// (set) Token: 0x060008FE RID: 2302 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		[DataMember(Name = "enumerable", IsRequired = true)]
		public bool Enumerable { get; set; }

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x0000E2BD File Offset: 0x0000C4BD
		// (set) Token: 0x06000900 RID: 2304 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
		[DataMember(Name = "wasThrown", IsRequired = false)]
		public bool? WasThrown { get; set; }

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0000E2CE File Offset: 0x0000C4CE
		// (set) Token: 0x06000902 RID: 2306 RVA: 0x0000E2D6 File Offset: 0x0000C4D6
		[DataMember(Name = "isOwn", IsRequired = false)]
		public bool? IsOwn { get; set; }

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x0000E2DF File Offset: 0x0000C4DF
		// (set) Token: 0x06000904 RID: 2308 RVA: 0x0000E2E7 File Offset: 0x0000C4E7
		[DataMember(Name = "symbol", IsRequired = false)]
		public RemoteObject Symbol { get; set; }
	}
}
