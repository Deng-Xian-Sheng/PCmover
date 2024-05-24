using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003B6 RID: 950
	[DataContract]
	public class Cache : DevToolsDomainEntityBase
	{
		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06001BCA RID: 7114 RVA: 0x0002082F File Offset: 0x0001EA2F
		// (set) Token: 0x06001BCB RID: 7115 RVA: 0x00020837 File Offset: 0x0001EA37
		[DataMember(Name = "cacheId", IsRequired = true)]
		public string CacheId { get; set; }

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06001BCC RID: 7116 RVA: 0x00020840 File Offset: 0x0001EA40
		// (set) Token: 0x06001BCD RID: 7117 RVA: 0x00020848 File Offset: 0x0001EA48
		[DataMember(Name = "securityOrigin", IsRequired = true)]
		public string SecurityOrigin { get; set; }

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06001BCE RID: 7118 RVA: 0x00020851 File Offset: 0x0001EA51
		// (set) Token: 0x06001BCF RID: 7119 RVA: 0x00020859 File Offset: 0x0001EA59
		[DataMember(Name = "cacheName", IsRequired = true)]
		public string CacheName { get; set; }
	}
}
