using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003B8 RID: 952
	[DataContract]
	public class CachedResponse : DevToolsDomainEntityBase
	{
		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06001BD6 RID: 7126 RVA: 0x00020894 File Offset: 0x0001EA94
		// (set) Token: 0x06001BD7 RID: 7127 RVA: 0x0002089C File Offset: 0x0001EA9C
		[DataMember(Name = "body", IsRequired = true)]
		public byte[] Body { get; set; }
	}
}
