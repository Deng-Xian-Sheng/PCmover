using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000332 RID: 818
	[DataContract]
	public class DragDataItem : DevToolsDomainEntityBase
	{
		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x060017F5 RID: 6133 RVA: 0x0001BEDB File Offset: 0x0001A0DB
		// (set) Token: 0x060017F6 RID: 6134 RVA: 0x0001BEE3 File Offset: 0x0001A0E3
		[DataMember(Name = "mimeType", IsRequired = true)]
		public string MimeType { get; set; }

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x060017F7 RID: 6135 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		// (set) Token: 0x060017F8 RID: 6136 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		[DataMember(Name = "data", IsRequired = true)]
		public string Data { get; set; }

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x060017F9 RID: 6137 RVA: 0x0001BEFD File Offset: 0x0001A0FD
		// (set) Token: 0x060017FA RID: 6138 RVA: 0x0001BF05 File Offset: 0x0001A105
		[DataMember(Name = "title", IsRequired = false)]
		public string Title { get; set; }

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x060017FB RID: 6139 RVA: 0x0001BF0E File Offset: 0x0001A10E
		// (set) Token: 0x060017FC RID: 6140 RVA: 0x0001BF16 File Offset: 0x0001A116
		[DataMember(Name = "baseURL", IsRequired = false)]
		public string BaseURL { get; set; }
	}
}
