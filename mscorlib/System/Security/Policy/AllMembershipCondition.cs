using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x0200033E RID: 830
	[ComVisible(true)]
	[Serializable]
	public sealed class AllMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002959 RID: 10585 RVA: 0x00098DE8 File Offset: 0x00096FE8
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x00098E00 File Offset: 0x00097000
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			return true;
		}

		// Token: 0x0600295B RID: 10587 RVA: 0x00098E06 File Offset: 0x00097006
		public IMembershipCondition Copy()
		{
			return new AllMembershipCondition();
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x00098E0D File Offset: 0x0009700D
		public override string ToString()
		{
			return Environment.GetResourceString("All_ToString");
		}

		// Token: 0x0600295D RID: 10589 RVA: 0x00098E19 File Offset: 0x00097019
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x0600295E RID: 10590 RVA: 0x00098E22 File Offset: 0x00097022
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x00098E2C File Offset: 0x0009702C
		public SecurityElement ToXml(PolicyLevel level)
		{
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.AllMembershipCondition");
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		// Token: 0x06002960 RID: 10592 RVA: 0x00098E66 File Offset: 0x00097066
		public void FromXml(SecurityElement e, PolicyLevel level)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (!e.Tag.Equals("IMembershipCondition"))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MembershipConditionElement"));
			}
		}

		// Token: 0x06002961 RID: 10593 RVA: 0x00098E98 File Offset: 0x00097098
		public override bool Equals(object o)
		{
			return o is AllMembershipCondition;
		}

		// Token: 0x06002962 RID: 10594 RVA: 0x00098EA3 File Offset: 0x000970A3
		public override int GetHashCode()
		{
			return typeof(AllMembershipCondition).GetHashCode();
		}
	}
}
