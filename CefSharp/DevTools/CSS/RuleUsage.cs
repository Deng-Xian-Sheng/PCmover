using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C5 RID: 965
	[DataContract]
	public class RuleUsage : DevToolsDomainEntityBase
	{
		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x06001C3F RID: 7231 RVA: 0x00020DCD File Offset: 0x0001EFCD
		// (set) Token: 0x06001C40 RID: 7232 RVA: 0x00020DD5 File Offset: 0x0001EFD5
		[DataMember(Name = "styleSheetId", IsRequired = true)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x06001C41 RID: 7233 RVA: 0x00020DDE File Offset: 0x0001EFDE
		// (set) Token: 0x06001C42 RID: 7234 RVA: 0x00020DE6 File Offset: 0x0001EFE6
		[DataMember(Name = "startOffset", IsRequired = true)]
		public double StartOffset { get; set; }

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x06001C43 RID: 7235 RVA: 0x00020DEF File Offset: 0x0001EFEF
		// (set) Token: 0x06001C44 RID: 7236 RVA: 0x00020DF7 File Offset: 0x0001EFF7
		[DataMember(Name = "endOffset", IsRequired = true)]
		public double EndOffset { get; set; }

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x06001C45 RID: 7237 RVA: 0x00020E00 File Offset: 0x0001F000
		// (set) Token: 0x06001C46 RID: 7238 RVA: 0x00020E08 File Offset: 0x0001F008
		[DataMember(Name = "used", IsRequired = true)]
		public bool Used { get; set; }
	}
}
