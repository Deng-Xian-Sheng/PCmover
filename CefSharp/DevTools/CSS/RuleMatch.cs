using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C0 RID: 960
	[DataContract]
	public class RuleMatch : DevToolsDomainEntityBase
	{
		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x06001BFA RID: 7162 RVA: 0x00020B49 File Offset: 0x0001ED49
		// (set) Token: 0x06001BFB RID: 7163 RVA: 0x00020B51 File Offset: 0x0001ED51
		[DataMember(Name = "rule", IsRequired = true)]
		public CSSRule Rule { get; set; }

		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x06001BFC RID: 7164 RVA: 0x00020B5A File Offset: 0x0001ED5A
		// (set) Token: 0x06001BFD RID: 7165 RVA: 0x00020B62 File Offset: 0x0001ED62
		[DataMember(Name = "matchingSelectors", IsRequired = true)]
		public int[] MatchingSelectors { get; set; }
	}
}
