using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E2 RID: 994
	[DataContract]
	public class GetMediaQueriesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x06001D24 RID: 7460 RVA: 0x0002158E File Offset: 0x0001F78E
		// (set) Token: 0x06001D25 RID: 7461 RVA: 0x00021596 File Offset: 0x0001F796
		[DataMember]
		internal IList<CSSMedia> medias { get; set; }

		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x06001D26 RID: 7462 RVA: 0x0002159F File Offset: 0x0001F79F
		public IList<CSSMedia> Medias
		{
			get
			{
				return this.medias;
			}
		}
	}
}
