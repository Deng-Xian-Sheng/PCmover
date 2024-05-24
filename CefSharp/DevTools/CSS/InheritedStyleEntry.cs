using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003BF RID: 959
	[DataContract]
	public class InheritedStyleEntry : DevToolsDomainEntityBase
	{
		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x06001BF5 RID: 7157 RVA: 0x00020B1F File Offset: 0x0001ED1F
		// (set) Token: 0x06001BF6 RID: 7158 RVA: 0x00020B27 File Offset: 0x0001ED27
		[DataMember(Name = "inlineStyle", IsRequired = false)]
		public CSSStyle InlineStyle { get; set; }

		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x06001BF7 RID: 7159 RVA: 0x00020B30 File Offset: 0x0001ED30
		// (set) Token: 0x06001BF8 RID: 7160 RVA: 0x00020B38 File Offset: 0x0001ED38
		[DataMember(Name = "matchedCSSRules", IsRequired = true)]
		public IList<RuleMatch> MatchedCSSRules { get; set; }
	}
}
