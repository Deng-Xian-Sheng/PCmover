using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E0 RID: 992
	[DataContract]
	public class GetInlineStylesForNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x06001D0A RID: 7434 RVA: 0x000214B6 File Offset: 0x0001F6B6
		// (set) Token: 0x06001D0B RID: 7435 RVA: 0x000214BE File Offset: 0x0001F6BE
		[DataMember]
		internal CSSStyle inlineStyle { get; set; }

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x06001D0C RID: 7436 RVA: 0x000214C7 File Offset: 0x0001F6C7
		public CSSStyle InlineStyle
		{
			get
			{
				return this.inlineStyle;
			}
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x06001D0D RID: 7437 RVA: 0x000214CF File Offset: 0x0001F6CF
		// (set) Token: 0x06001D0E RID: 7438 RVA: 0x000214D7 File Offset: 0x0001F6D7
		[DataMember]
		internal CSSStyle attributesStyle { get; set; }

		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x06001D0F RID: 7439 RVA: 0x000214E0 File Offset: 0x0001F6E0
		public CSSStyle AttributesStyle
		{
			get
			{
				return this.attributesStyle;
			}
		}
	}
}
