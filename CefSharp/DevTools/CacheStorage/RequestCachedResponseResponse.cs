using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003BA RID: 954
	[DataContract]
	public class RequestCachedResponseResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x06001BDD RID: 7133 RVA: 0x000208CE File Offset: 0x0001EACE
		// (set) Token: 0x06001BDE RID: 7134 RVA: 0x000208D6 File Offset: 0x0001EAD6
		[DataMember]
		internal CachedResponse response { get; set; }

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x06001BDF RID: 7135 RVA: 0x000208DF File Offset: 0x0001EADF
		public CachedResponse Response
		{
			get
			{
				return this.response;
			}
		}
	}
}
