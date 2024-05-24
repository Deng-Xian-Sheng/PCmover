using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000303 RID: 771
	[DataContract]
	public class GetCookiesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x0600167C RID: 5756 RVA: 0x0001A165 File Offset: 0x00018365
		// (set) Token: 0x0600167D RID: 5757 RVA: 0x0001A16D File Offset: 0x0001836D
		[DataMember]
		internal IList<Cookie> cookies { get; set; }

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x0600167E RID: 5758 RVA: 0x0001A176 File Offset: 0x00018376
		public IList<Cookie> Cookies
		{
			get
			{
				return this.cookies;
			}
		}
	}
}
