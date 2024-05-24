using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C6 RID: 966
	[DataContract]
	public class SourceRange : DevToolsDomainEntityBase
	{
		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x06001C48 RID: 7240 RVA: 0x00020E19 File Offset: 0x0001F019
		// (set) Token: 0x06001C49 RID: 7241 RVA: 0x00020E21 File Offset: 0x0001F021
		[DataMember(Name = "startLine", IsRequired = true)]
		public int StartLine { get; set; }

		// Token: 0x17000A2D RID: 2605
		// (get) Token: 0x06001C4A RID: 7242 RVA: 0x00020E2A File Offset: 0x0001F02A
		// (set) Token: 0x06001C4B RID: 7243 RVA: 0x00020E32 File Offset: 0x0001F032
		[DataMember(Name = "startColumn", IsRequired = true)]
		public int StartColumn { get; set; }

		// Token: 0x17000A2E RID: 2606
		// (get) Token: 0x06001C4C RID: 7244 RVA: 0x00020E3B File Offset: 0x0001F03B
		// (set) Token: 0x06001C4D RID: 7245 RVA: 0x00020E43 File Offset: 0x0001F043
		[DataMember(Name = "endLine", IsRequired = true)]
		public int EndLine { get; set; }

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x06001C4E RID: 7246 RVA: 0x00020E4C File Offset: 0x0001F04C
		// (set) Token: 0x06001C4F RID: 7247 RVA: 0x00020E54 File Offset: 0x0001F054
		[DataMember(Name = "endColumn", IsRequired = true)]
		public int EndColumn { get; set; }
	}
}
