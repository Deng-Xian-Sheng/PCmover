using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D3 RID: 979
	[DataContract]
	public class FontFace : DevToolsDomainEntityBase
	{
		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x06001CBA RID: 7354 RVA: 0x000211FA File Offset: 0x0001F3FA
		// (set) Token: 0x06001CBB RID: 7355 RVA: 0x00021202 File Offset: 0x0001F402
		[DataMember(Name = "fontFamily", IsRequired = true)]
		public string FontFamily { get; set; }

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x06001CBC RID: 7356 RVA: 0x0002120B File Offset: 0x0001F40B
		// (set) Token: 0x06001CBD RID: 7357 RVA: 0x00021213 File Offset: 0x0001F413
		[DataMember(Name = "fontStyle", IsRequired = true)]
		public string FontStyle { get; set; }

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x06001CBE RID: 7358 RVA: 0x0002121C File Offset: 0x0001F41C
		// (set) Token: 0x06001CBF RID: 7359 RVA: 0x00021224 File Offset: 0x0001F424
		[DataMember(Name = "fontVariant", IsRequired = true)]
		public string FontVariant { get; set; }

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x06001CC0 RID: 7360 RVA: 0x0002122D File Offset: 0x0001F42D
		// (set) Token: 0x06001CC1 RID: 7361 RVA: 0x00021235 File Offset: 0x0001F435
		[DataMember(Name = "fontWeight", IsRequired = true)]
		public string FontWeight { get; set; }

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x06001CC2 RID: 7362 RVA: 0x0002123E File Offset: 0x0001F43E
		// (set) Token: 0x06001CC3 RID: 7363 RVA: 0x00021246 File Offset: 0x0001F446
		[DataMember(Name = "fontStretch", IsRequired = true)]
		public string FontStretch { get; set; }

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x06001CC4 RID: 7364 RVA: 0x0002124F File Offset: 0x0001F44F
		// (set) Token: 0x06001CC5 RID: 7365 RVA: 0x00021257 File Offset: 0x0001F457
		[DataMember(Name = "unicodeRange", IsRequired = true)]
		public string UnicodeRange { get; set; }

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x06001CC6 RID: 7366 RVA: 0x00021260 File Offset: 0x0001F460
		// (set) Token: 0x06001CC7 RID: 7367 RVA: 0x00021268 File Offset: 0x0001F468
		[DataMember(Name = "src", IsRequired = true)]
		public string Src { get; set; }

		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x06001CC8 RID: 7368 RVA: 0x00021271 File Offset: 0x0001F471
		// (set) Token: 0x06001CC9 RID: 7369 RVA: 0x00021279 File Offset: 0x0001F479
		[DataMember(Name = "platformFontFamily", IsRequired = true)]
		public string PlatformFontFamily { get; set; }

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x06001CCA RID: 7370 RVA: 0x00021282 File Offset: 0x0001F482
		// (set) Token: 0x06001CCB RID: 7371 RVA: 0x0002128A File Offset: 0x0001F48A
		[DataMember(Name = "fontVariationAxes", IsRequired = false)]
		public IList<FontVariationAxis> FontVariationAxes { get; set; }
	}
}
