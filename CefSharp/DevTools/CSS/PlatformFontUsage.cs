using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D1 RID: 977
	[DataContract]
	public class PlatformFontUsage : DevToolsDomainEntityBase
	{
		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x06001CA8 RID: 7336 RVA: 0x00021162 File Offset: 0x0001F362
		// (set) Token: 0x06001CA9 RID: 7337 RVA: 0x0002116A File Offset: 0x0001F36A
		[DataMember(Name = "familyName", IsRequired = true)]
		public string FamilyName { get; set; }

		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x06001CAA RID: 7338 RVA: 0x00021173 File Offset: 0x0001F373
		// (set) Token: 0x06001CAB RID: 7339 RVA: 0x0002117B File Offset: 0x0001F37B
		[DataMember(Name = "isCustomFont", IsRequired = true)]
		public bool IsCustomFont { get; set; }

		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x06001CAC RID: 7340 RVA: 0x00021184 File Offset: 0x0001F384
		// (set) Token: 0x06001CAD RID: 7341 RVA: 0x0002118C File Offset: 0x0001F38C
		[DataMember(Name = "glyphCount", IsRequired = true)]
		public double GlyphCount { get; set; }
	}
}
