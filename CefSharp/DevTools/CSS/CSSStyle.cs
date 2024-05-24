using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C9 RID: 969
	[DataContract]
	public class CSSStyle : DevToolsDomainEntityBase
	{
		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x06001C5D RID: 7261 RVA: 0x00020ECA File Offset: 0x0001F0CA
		// (set) Token: 0x06001C5E RID: 7262 RVA: 0x00020ED2 File Offset: 0x0001F0D2
		[DataMember(Name = "styleSheetId", IsRequired = false)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x06001C5F RID: 7263 RVA: 0x00020EDB File Offset: 0x0001F0DB
		// (set) Token: 0x06001C60 RID: 7264 RVA: 0x00020EE3 File Offset: 0x0001F0E3
		[DataMember(Name = "cssProperties", IsRequired = true)]
		public IList<CSSProperty> CssProperties { get; set; }

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x06001C61 RID: 7265 RVA: 0x00020EEC File Offset: 0x0001F0EC
		// (set) Token: 0x06001C62 RID: 7266 RVA: 0x00020EF4 File Offset: 0x0001F0F4
		[DataMember(Name = "shorthandEntries", IsRequired = true)]
		public IList<ShorthandEntry> ShorthandEntries { get; set; }

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x06001C63 RID: 7267 RVA: 0x00020EFD File Offset: 0x0001F0FD
		// (set) Token: 0x06001C64 RID: 7268 RVA: 0x00020F05 File Offset: 0x0001F105
		[DataMember(Name = "cssText", IsRequired = false)]
		public string CssText { get; set; }

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x06001C65 RID: 7269 RVA: 0x00020F0E File Offset: 0x0001F10E
		// (set) Token: 0x06001C66 RID: 7270 RVA: 0x00020F16 File Offset: 0x0001F116
		[DataMember(Name = "range", IsRequired = false)]
		public SourceRange Range { get; set; }
	}
}
