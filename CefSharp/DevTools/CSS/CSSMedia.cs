using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003CC RID: 972
	[DataContract]
	public class CSSMedia : DevToolsDomainEntityBase
	{
		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06001C79 RID: 7289 RVA: 0x00020FB7 File Offset: 0x0001F1B7
		// (set) Token: 0x06001C7A RID: 7290 RVA: 0x00020FBF File Offset: 0x0001F1BF
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }

		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x06001C7B RID: 7291 RVA: 0x00020FC8 File Offset: 0x0001F1C8
		// (set) Token: 0x06001C7C RID: 7292 RVA: 0x00020FE4 File Offset: 0x0001F1E4
		public CSSMediaSource Source
		{
			get
			{
				return (CSSMediaSource)DevToolsDomainEntityBase.StringToEnum(typeof(CSSMediaSource), this.source);
			}
			set
			{
				this.source = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06001C7D RID: 7293 RVA: 0x00020FF7 File Offset: 0x0001F1F7
		// (set) Token: 0x06001C7E RID: 7294 RVA: 0x00020FFF File Offset: 0x0001F1FF
		[DataMember(Name = "source", IsRequired = true)]
		internal string source { get; set; }

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x06001C7F RID: 7295 RVA: 0x00021008 File Offset: 0x0001F208
		// (set) Token: 0x06001C80 RID: 7296 RVA: 0x00021010 File Offset: 0x0001F210
		[DataMember(Name = "sourceURL", IsRequired = false)]
		public string SourceURL { get; set; }

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06001C81 RID: 7297 RVA: 0x00021019 File Offset: 0x0001F219
		// (set) Token: 0x06001C82 RID: 7298 RVA: 0x00021021 File Offset: 0x0001F221
		[DataMember(Name = "range", IsRequired = false)]
		public SourceRange Range { get; set; }

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x06001C83 RID: 7299 RVA: 0x0002102A File Offset: 0x0001F22A
		// (set) Token: 0x06001C84 RID: 7300 RVA: 0x00021032 File Offset: 0x0001F232
		[DataMember(Name = "styleSheetId", IsRequired = false)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A48 RID: 2632
		// (get) Token: 0x06001C85 RID: 7301 RVA: 0x0002103B File Offset: 0x0001F23B
		// (set) Token: 0x06001C86 RID: 7302 RVA: 0x00021043 File Offset: 0x0001F243
		[DataMember(Name = "mediaList", IsRequired = false)]
		public IList<MediaQuery> MediaList { get; set; }
	}
}
