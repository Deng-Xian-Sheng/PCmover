using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D0 RID: 976
	[DataContract]
	public class CSSSupports : DevToolsDomainEntityBase
	{
		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06001CA1 RID: 7329 RVA: 0x00021127 File Offset: 0x0001F327
		// (set) Token: 0x06001CA2 RID: 7330 RVA: 0x0002112F File Offset: 0x0001F32F
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06001CA3 RID: 7331 RVA: 0x00021138 File Offset: 0x0001F338
		// (set) Token: 0x06001CA4 RID: 7332 RVA: 0x00021140 File Offset: 0x0001F340
		[DataMember(Name = "range", IsRequired = false)]
		public SourceRange Range { get; set; }

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06001CA5 RID: 7333 RVA: 0x00021149 File Offset: 0x0001F349
		// (set) Token: 0x06001CA6 RID: 7334 RVA: 0x00021151 File Offset: 0x0001F351
		[DataMember(Name = "styleSheetId", IsRequired = false)]
		public string StyleSheetId { get; set; }
	}
}
