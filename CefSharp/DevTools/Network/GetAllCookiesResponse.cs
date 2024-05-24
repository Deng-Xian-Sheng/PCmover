using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000301 RID: 769
	[DataContract]
	public class GetAllCookiesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06001674 RID: 5748 RVA: 0x0001A123 File Offset: 0x00018323
		// (set) Token: 0x06001675 RID: 5749 RVA: 0x0001A12B File Offset: 0x0001832B
		[DataMember]
		internal IList<Cookie> cookies { get; set; }

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06001676 RID: 5750 RVA: 0x0001A134 File Offset: 0x00018334
		public IList<Cookie> Cookies
		{
			get
			{
				return this.cookies;
			}
		}
	}
}
