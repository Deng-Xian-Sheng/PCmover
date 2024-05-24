using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000206 RID: 518
	[DataContract]
	public class GetCookiesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x00013C9B File Offset: 0x00011E9B
		// (set) Token: 0x06000ED6 RID: 3798 RVA: 0x00013CA3 File Offset: 0x00011EA3
		[DataMember]
		internal IList<Cookie> cookies { get; set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x00013CAC File Offset: 0x00011EAC
		public IList<Cookie> Cookies
		{
			get
			{
				return this.cookies;
			}
		}
	}
}
