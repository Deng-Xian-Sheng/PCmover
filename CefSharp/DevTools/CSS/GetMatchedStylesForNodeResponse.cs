using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E1 RID: 993
	[DataContract]
	public class GetMatchedStylesForNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A88 RID: 2696
		// (get) Token: 0x06001D11 RID: 7441 RVA: 0x000214F0 File Offset: 0x0001F6F0
		// (set) Token: 0x06001D12 RID: 7442 RVA: 0x000214F8 File Offset: 0x0001F6F8
		[DataMember]
		internal CSSStyle inlineStyle { get; set; }

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x06001D13 RID: 7443 RVA: 0x00021501 File Offset: 0x0001F701
		public CSSStyle InlineStyle
		{
			get
			{
				return this.inlineStyle;
			}
		}

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x06001D14 RID: 7444 RVA: 0x00021509 File Offset: 0x0001F709
		// (set) Token: 0x06001D15 RID: 7445 RVA: 0x00021511 File Offset: 0x0001F711
		[DataMember]
		internal CSSStyle attributesStyle { get; set; }

		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x06001D16 RID: 7446 RVA: 0x0002151A File Offset: 0x0001F71A
		public CSSStyle AttributesStyle
		{
			get
			{
				return this.attributesStyle;
			}
		}

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x06001D17 RID: 7447 RVA: 0x00021522 File Offset: 0x0001F722
		// (set) Token: 0x06001D18 RID: 7448 RVA: 0x0002152A File Offset: 0x0001F72A
		[DataMember]
		internal IList<RuleMatch> matchedCSSRules { get; set; }

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x06001D19 RID: 7449 RVA: 0x00021533 File Offset: 0x0001F733
		public IList<RuleMatch> MatchedCSSRules
		{
			get
			{
				return this.matchedCSSRules;
			}
		}

		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x06001D1A RID: 7450 RVA: 0x0002153B File Offset: 0x0001F73B
		// (set) Token: 0x06001D1B RID: 7451 RVA: 0x00021543 File Offset: 0x0001F743
		[DataMember]
		internal IList<PseudoElementMatches> pseudoElements { get; set; }

		// Token: 0x17000A8F RID: 2703
		// (get) Token: 0x06001D1C RID: 7452 RVA: 0x0002154C File Offset: 0x0001F74C
		public IList<PseudoElementMatches> PseudoElements
		{
			get
			{
				return this.pseudoElements;
			}
		}

		// Token: 0x17000A90 RID: 2704
		// (get) Token: 0x06001D1D RID: 7453 RVA: 0x00021554 File Offset: 0x0001F754
		// (set) Token: 0x06001D1E RID: 7454 RVA: 0x0002155C File Offset: 0x0001F75C
		[DataMember]
		internal IList<InheritedStyleEntry> inherited { get; set; }

		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x06001D1F RID: 7455 RVA: 0x00021565 File Offset: 0x0001F765
		public IList<InheritedStyleEntry> Inherited
		{
			get
			{
				return this.inherited;
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x06001D20 RID: 7456 RVA: 0x0002156D File Offset: 0x0001F76D
		// (set) Token: 0x06001D21 RID: 7457 RVA: 0x00021575 File Offset: 0x0001F775
		[DataMember]
		internal IList<CSSKeyframesRule> cssKeyframesRules { get; set; }

		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x06001D22 RID: 7458 RVA: 0x0002157E File Offset: 0x0001F77E
		public IList<CSSKeyframesRule> CssKeyframesRules
		{
			get
			{
				return this.cssKeyframesRules;
			}
		}
	}
}
