using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000279 RID: 633
	[DataContract]
	public class GetAppIdResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x060011D5 RID: 4565 RVA: 0x00016066 File Offset: 0x00014266
		// (set) Token: 0x060011D6 RID: 4566 RVA: 0x0001606E File Offset: 0x0001426E
		[DataMember]
		internal string appId { get; set; }

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x060011D7 RID: 4567 RVA: 0x00016077 File Offset: 0x00014277
		public string AppId
		{
			get
			{
				return this.appId;
			}
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x0001607F File Offset: 0x0001427F
		// (set) Token: 0x060011D9 RID: 4569 RVA: 0x00016087 File Offset: 0x00014287
		[DataMember]
		internal string recommendedId { get; set; }

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x00016090 File Offset: 0x00014290
		public string RecommendedId
		{
			get
			{
				return this.recommendedId;
			}
		}
	}
}
