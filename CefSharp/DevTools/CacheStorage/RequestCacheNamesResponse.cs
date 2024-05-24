using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003B9 RID: 953
	[DataContract]
	public class RequestCacheNamesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06001BD9 RID: 7129 RVA: 0x000208AD File Offset: 0x0001EAAD
		// (set) Token: 0x06001BDA RID: 7130 RVA: 0x000208B5 File Offset: 0x0001EAB5
		[DataMember]
		internal IList<Cache> caches { get; set; }

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x06001BDB RID: 7131 RVA: 0x000208BE File Offset: 0x0001EABE
		public IList<Cache> Caches
		{
			get
			{
				return this.caches;
			}
		}
	}
}
