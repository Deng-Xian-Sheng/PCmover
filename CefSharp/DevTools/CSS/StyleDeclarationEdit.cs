using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D6 RID: 982
	[DataContract]
	public class StyleDeclarationEdit : DevToolsDomainEntityBase
	{
		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x06001CDD RID: 7389 RVA: 0x00021340 File Offset: 0x0001F540
		// (set) Token: 0x06001CDE RID: 7390 RVA: 0x00021348 File Offset: 0x0001F548
		[DataMember(Name = "styleSheetId", IsRequired = true)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x06001CDF RID: 7391 RVA: 0x00021351 File Offset: 0x0001F551
		// (set) Token: 0x06001CE0 RID: 7392 RVA: 0x00021359 File Offset: 0x0001F559
		[DataMember(Name = "range", IsRequired = true)]
		public SourceRange Range { get; set; }

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x06001CE1 RID: 7393 RVA: 0x00021362 File Offset: 0x0001F562
		// (set) Token: 0x06001CE2 RID: 7394 RVA: 0x0002136A File Offset: 0x0001F56A
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }
	}
}
