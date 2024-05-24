using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003CF RID: 975
	[DataContract]
	public class CSSContainerQuery : DevToolsDomainEntityBase
	{
		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06001C98 RID: 7320 RVA: 0x000210DB File Offset: 0x0001F2DB
		// (set) Token: 0x06001C99 RID: 7321 RVA: 0x000210E3 File Offset: 0x0001F2E3
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06001C9A RID: 7322 RVA: 0x000210EC File Offset: 0x0001F2EC
		// (set) Token: 0x06001C9B RID: 7323 RVA: 0x000210F4 File Offset: 0x0001F2F4
		[DataMember(Name = "range", IsRequired = false)]
		public SourceRange Range { get; set; }

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06001C9C RID: 7324 RVA: 0x000210FD File Offset: 0x0001F2FD
		// (set) Token: 0x06001C9D RID: 7325 RVA: 0x00021105 File Offset: 0x0001F305
		[DataMember(Name = "styleSheetId", IsRequired = false)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06001C9E RID: 7326 RVA: 0x0002110E File Offset: 0x0001F30E
		// (set) Token: 0x06001C9F RID: 7327 RVA: 0x00021116 File Offset: 0x0001F316
		[DataMember(Name = "name", IsRequired = false)]
		public string Name { get; set; }
	}
}
