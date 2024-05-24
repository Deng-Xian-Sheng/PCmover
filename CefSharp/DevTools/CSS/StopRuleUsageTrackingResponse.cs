using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003ED RID: 1005
	[DataContract]
	public class StopRuleUsageTrackingResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x06001D50 RID: 7504 RVA: 0x000216F9 File Offset: 0x0001F8F9
		// (set) Token: 0x06001D51 RID: 7505 RVA: 0x00021701 File Offset: 0x0001F901
		[DataMember]
		internal IList<RuleUsage> ruleUsage { get; set; }

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x06001D52 RID: 7506 RVA: 0x0002170A File Offset: 0x0001F90A
		public IList<RuleUsage> RuleUsage
		{
			get
			{
				return this.ruleUsage;
			}
		}
	}
}
