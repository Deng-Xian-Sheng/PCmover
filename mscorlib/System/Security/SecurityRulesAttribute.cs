using System;

namespace System.Security
{
	// Token: 0x020001CC RID: 460
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	public sealed class SecurityRulesAttribute : Attribute
	{
		// Token: 0x06001C24 RID: 7204 RVA: 0x00060E61 File Offset: 0x0005F061
		public SecurityRulesAttribute(SecurityRuleSet ruleSet)
		{
			this.m_ruleSet = ruleSet;
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06001C25 RID: 7205 RVA: 0x00060E70 File Offset: 0x0005F070
		// (set) Token: 0x06001C26 RID: 7206 RVA: 0x00060E78 File Offset: 0x0005F078
		public bool SkipVerificationInFullTrust
		{
			get
			{
				return this.m_skipVerificationInFullTrust;
			}
			set
			{
				this.m_skipVerificationInFullTrust = value;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06001C27 RID: 7207 RVA: 0x00060E81 File Offset: 0x0005F081
		public SecurityRuleSet RuleSet
		{
			get
			{
				return this.m_ruleSet;
			}
		}

		// Token: 0x040009CA RID: 2506
		private SecurityRuleSet m_ruleSet;

		// Token: 0x040009CB RID: 2507
		private bool m_skipVerificationInFullTrust;
	}
}
