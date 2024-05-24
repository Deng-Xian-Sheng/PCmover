using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200024B RID: 587
	[DataContract]
	public class ScriptFontFamilies : DevToolsDomainEntityBase
	{
		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x060010EA RID: 4330 RVA: 0x00015778 File Offset: 0x00013978
		// (set) Token: 0x060010EB RID: 4331 RVA: 0x00015780 File Offset: 0x00013980
		[DataMember(Name = "script", IsRequired = true)]
		public string Script { get; set; }

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x060010EC RID: 4332 RVA: 0x00015789 File Offset: 0x00013989
		// (set) Token: 0x060010ED RID: 4333 RVA: 0x00015791 File Offset: 0x00013991
		[DataMember(Name = "fontFamilies", IsRequired = true)]
		public FontFamilies FontFamilies { get; set; }
	}
}
