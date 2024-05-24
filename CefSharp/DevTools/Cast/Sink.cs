using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Cast
{
	// Token: 0x020003B0 RID: 944
	[DataContract]
	public class Sink : DevToolsDomainEntityBase
	{
		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06001B9F RID: 7071 RVA: 0x0002058D File Offset: 0x0001E78D
		// (set) Token: 0x06001BA0 RID: 7072 RVA: 0x00020595 File Offset: 0x0001E795
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06001BA1 RID: 7073 RVA: 0x0002059E File Offset: 0x0001E79E
		// (set) Token: 0x06001BA2 RID: 7074 RVA: 0x000205A6 File Offset: 0x0001E7A6
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; set; }

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06001BA3 RID: 7075 RVA: 0x000205AF File Offset: 0x0001E7AF
		// (set) Token: 0x06001BA4 RID: 7076 RVA: 0x000205B7 File Offset: 0x0001E7B7
		[DataMember(Name = "session", IsRequired = false)]
		public string Session { get; set; }
	}
}
