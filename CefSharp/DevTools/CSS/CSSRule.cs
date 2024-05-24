using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C4 RID: 964
	[DataContract]
	public class CSSRule : DevToolsDomainEntityBase
	{
		// Token: 0x17000A20 RID: 2592
		// (get) Token: 0x06001C2E RID: 7214 RVA: 0x00020D1F File Offset: 0x0001EF1F
		// (set) Token: 0x06001C2F RID: 7215 RVA: 0x00020D27 File Offset: 0x0001EF27
		[DataMember(Name = "styleSheetId", IsRequired = false)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x06001C30 RID: 7216 RVA: 0x00020D30 File Offset: 0x0001EF30
		// (set) Token: 0x06001C31 RID: 7217 RVA: 0x00020D38 File Offset: 0x0001EF38
		[DataMember(Name = "selectorList", IsRequired = true)]
		public SelectorList SelectorList { get; set; }

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x06001C32 RID: 7218 RVA: 0x00020D41 File Offset: 0x0001EF41
		// (set) Token: 0x06001C33 RID: 7219 RVA: 0x00020D5D File Offset: 0x0001EF5D
		public StyleSheetOrigin Origin
		{
			get
			{
				return (StyleSheetOrigin)DevToolsDomainEntityBase.StringToEnum(typeof(StyleSheetOrigin), this.origin);
			}
			set
			{
				this.origin = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06001C34 RID: 7220 RVA: 0x00020D70 File Offset: 0x0001EF70
		// (set) Token: 0x06001C35 RID: 7221 RVA: 0x00020D78 File Offset: 0x0001EF78
		[DataMember(Name = "origin", IsRequired = true)]
		internal string origin { get; set; }

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06001C36 RID: 7222 RVA: 0x00020D81 File Offset: 0x0001EF81
		// (set) Token: 0x06001C37 RID: 7223 RVA: 0x00020D89 File Offset: 0x0001EF89
		[DataMember(Name = "style", IsRequired = true)]
		public CSSStyle Style { get; set; }

		// Token: 0x17000A25 RID: 2597
		// (get) Token: 0x06001C38 RID: 7224 RVA: 0x00020D92 File Offset: 0x0001EF92
		// (set) Token: 0x06001C39 RID: 7225 RVA: 0x00020D9A File Offset: 0x0001EF9A
		[DataMember(Name = "media", IsRequired = false)]
		public IList<CSSMedia> Media { get; set; }

		// Token: 0x17000A26 RID: 2598
		// (get) Token: 0x06001C3A RID: 7226 RVA: 0x00020DA3 File Offset: 0x0001EFA3
		// (set) Token: 0x06001C3B RID: 7227 RVA: 0x00020DAB File Offset: 0x0001EFAB
		[DataMember(Name = "containerQueries", IsRequired = false)]
		public IList<CSSContainerQuery> ContainerQueries { get; set; }

		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x06001C3C RID: 7228 RVA: 0x00020DB4 File Offset: 0x0001EFB4
		// (set) Token: 0x06001C3D RID: 7229 RVA: 0x00020DBC File Offset: 0x0001EFBC
		[DataMember(Name = "supports", IsRequired = false)]
		public IList<CSSSupports> Supports { get; set; }
	}
}
