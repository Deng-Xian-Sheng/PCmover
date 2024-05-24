using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000373 RID: 883
	[ComVisible(true)]
	[Serializable]
	public sealed class GacMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002BC1 RID: 11201 RVA: 0x000A2EDC File Offset: 0x000A10DC
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002BC2 RID: 11202 RVA: 0x000A2EF4 File Offset: 0x000A10F4
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			return evidence != null && evidence.GetHostEvidence<GacInstalled>() != null;
		}

		// Token: 0x06002BC3 RID: 11203 RVA: 0x000A2F07 File Offset: 0x000A1107
		public IMembershipCondition Copy()
		{
			return new GacMembershipCondition();
		}

		// Token: 0x06002BC4 RID: 11204 RVA: 0x000A2F0E File Offset: 0x000A110E
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002BC5 RID: 11205 RVA: 0x000A2F17 File Offset: 0x000A1117
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002BC6 RID: 11206 RVA: 0x000A2F24 File Offset: 0x000A1124
		public SecurityElement ToXml(PolicyLevel level)
		{
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), base.GetType().FullName);
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		// Token: 0x06002BC7 RID: 11207 RVA: 0x000A2F64 File Offset: 0x000A1164
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

		// Token: 0x06002BC8 RID: 11208 RVA: 0x000A2F98 File Offset: 0x000A1198
		public override bool Equals(object o)
		{
			return o is GacMembershipCondition;
		}

		// Token: 0x06002BC9 RID: 11209 RVA: 0x000A2FB2 File Offset: 0x000A11B2
		public override int GetHashCode()
		{
			return 0;
		}

		// Token: 0x06002BCA RID: 11210 RVA: 0x000A2FB5 File Offset: 0x000A11B5
		public override string ToString()
		{
			return Environment.GetResourceString("GAC_ToString");
		}
	}
}
