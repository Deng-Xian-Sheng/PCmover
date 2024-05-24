using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003CA RID: 970
	[DataContract]
	public class CSSProperty : DevToolsDomainEntityBase
	{
		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x06001C68 RID: 7272 RVA: 0x00020F27 File Offset: 0x0001F127
		// (set) Token: 0x06001C69 RID: 7273 RVA: 0x00020F2F File Offset: 0x0001F12F
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x06001C6A RID: 7274 RVA: 0x00020F38 File Offset: 0x0001F138
		// (set) Token: 0x06001C6B RID: 7275 RVA: 0x00020F40 File Offset: 0x0001F140
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }

		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06001C6C RID: 7276 RVA: 0x00020F49 File Offset: 0x0001F149
		// (set) Token: 0x06001C6D RID: 7277 RVA: 0x00020F51 File Offset: 0x0001F151
		[DataMember(Name = "important", IsRequired = false)]
		public bool? Important { get; set; }

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x00020F5A File Offset: 0x0001F15A
		// (set) Token: 0x06001C6F RID: 7279 RVA: 0x00020F62 File Offset: 0x0001F162
		[DataMember(Name = "implicit", IsRequired = false)]
		public bool? Implicit { get; set; }

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x06001C70 RID: 7280 RVA: 0x00020F6B File Offset: 0x0001F16B
		// (set) Token: 0x06001C71 RID: 7281 RVA: 0x00020F73 File Offset: 0x0001F173
		[DataMember(Name = "text", IsRequired = false)]
		public string Text { get; set; }

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x06001C72 RID: 7282 RVA: 0x00020F7C File Offset: 0x0001F17C
		// (set) Token: 0x06001C73 RID: 7283 RVA: 0x00020F84 File Offset: 0x0001F184
		[DataMember(Name = "parsedOk", IsRequired = false)]
		public bool? ParsedOk { get; set; }

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x06001C74 RID: 7284 RVA: 0x00020F8D File Offset: 0x0001F18D
		// (set) Token: 0x06001C75 RID: 7285 RVA: 0x00020F95 File Offset: 0x0001F195
		[DataMember(Name = "disabled", IsRequired = false)]
		public bool? Disabled { get; set; }

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x06001C76 RID: 7286 RVA: 0x00020F9E File Offset: 0x0001F19E
		// (set) Token: 0x06001C77 RID: 7287 RVA: 0x00020FA6 File Offset: 0x0001F1A6
		[DataMember(Name = "range", IsRequired = false)]
		public SourceRange Range { get; set; }
	}
}
