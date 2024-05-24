using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D5 RID: 981
	[DataContract]
	public class CSSKeyframeRule : DevToolsDomainEntityBase
	{
		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x06001CD2 RID: 7378 RVA: 0x000212C5 File Offset: 0x0001F4C5
		// (set) Token: 0x06001CD3 RID: 7379 RVA: 0x000212CD File Offset: 0x0001F4CD
		[DataMember(Name = "styleSheetId", IsRequired = false)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x06001CD4 RID: 7380 RVA: 0x000212D6 File Offset: 0x0001F4D6
		// (set) Token: 0x06001CD5 RID: 7381 RVA: 0x000212F2 File Offset: 0x0001F4F2
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

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x06001CD6 RID: 7382 RVA: 0x00021305 File Offset: 0x0001F505
		// (set) Token: 0x06001CD7 RID: 7383 RVA: 0x0002130D File Offset: 0x0001F50D
		[DataMember(Name = "origin", IsRequired = true)]
		internal string origin { get; set; }

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x06001CD8 RID: 7384 RVA: 0x00021316 File Offset: 0x0001F516
		// (set) Token: 0x06001CD9 RID: 7385 RVA: 0x0002131E File Offset: 0x0001F51E
		[DataMember(Name = "keyText", IsRequired = true)]
		public Value KeyText { get; set; }

		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x06001CDA RID: 7386 RVA: 0x00021327 File Offset: 0x0001F527
		// (set) Token: 0x06001CDB RID: 7387 RVA: 0x0002132F File Offset: 0x0001F52F
		[DataMember(Name = "style", IsRequired = true)]
		public CSSStyle Style { get; set; }
	}
}
