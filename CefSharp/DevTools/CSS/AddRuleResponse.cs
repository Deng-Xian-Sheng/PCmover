using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003DB RID: 987
	[DataContract]
	public class AddRuleResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x06001CF0 RID: 7408 RVA: 0x000213DF File Offset: 0x0001F5DF
		// (set) Token: 0x06001CF1 RID: 7409 RVA: 0x000213E7 File Offset: 0x0001F5E7
		[DataMember]
		internal CSSRule rule { get; set; }

		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x06001CF2 RID: 7410 RVA: 0x000213F0 File Offset: 0x0001F5F0
		public CSSRule Rule
		{
			get
			{
				return this.rule;
			}
		}
	}
}
