using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D6 RID: 470
	[DataContract]
	public class GetCategoriesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00012A21 File Offset: 0x00010C21
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x00012A29 File Offset: 0x00010C29
		[DataMember]
		internal string[] categories { get; set; }

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x00012A32 File Offset: 0x00010C32
		public string[] Categories
		{
			get
			{
				return this.categories;
			}
		}
	}
}
