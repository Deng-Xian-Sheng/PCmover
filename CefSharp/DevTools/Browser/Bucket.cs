using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F6 RID: 1014
	[DataContract]
	public class Bucket : DevToolsDomainEntityBase
	{
		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x06001D99 RID: 7577 RVA: 0x00021F26 File Offset: 0x00020126
		// (set) Token: 0x06001D9A RID: 7578 RVA: 0x00021F2E File Offset: 0x0002012E
		[DataMember(Name = "low", IsRequired = true)]
		public int Low { get; set; }

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x06001D9B RID: 7579 RVA: 0x00021F37 File Offset: 0x00020137
		// (set) Token: 0x06001D9C RID: 7580 RVA: 0x00021F3F File Offset: 0x0002013F
		[DataMember(Name = "high", IsRequired = true)]
		public int High { get; set; }

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x06001D9D RID: 7581 RVA: 0x00021F48 File Offset: 0x00020148
		// (set) Token: 0x06001D9E RID: 7582 RVA: 0x00021F50 File Offset: 0x00020150
		[DataMember(Name = "count", IsRequired = true)]
		public int Count { get; set; }
	}
}
