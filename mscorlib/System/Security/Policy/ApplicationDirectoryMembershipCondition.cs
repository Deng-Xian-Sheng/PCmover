using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Policy
{
	// Token: 0x02000341 RID: 833
	[ComVisible(true)]
	[Serializable]
	public sealed class ApplicationDirectoryMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable, IConstantMembershipCondition, IReportMatchMembershipCondition
	{
		// Token: 0x06002971 RID: 10609 RVA: 0x00099048 File Offset: 0x00097248
		public bool Check(Evidence evidence)
		{
			object obj = null;
			return ((IReportMatchMembershipCondition)this).Check(evidence, out obj);
		}

		// Token: 0x06002972 RID: 10610 RVA: 0x00099060 File Offset: 0x00097260
		bool IReportMatchMembershipCondition.Check(Evidence evidence, out object usedEvidence)
		{
			usedEvidence = null;
			if (evidence == null)
			{
				return false;
			}
			ApplicationDirectory hostEvidence = evidence.GetHostEvidence<ApplicationDirectory>();
			Url hostEvidence2 = evidence.GetHostEvidence<Url>();
			if (hostEvidence != null && hostEvidence2 != null)
			{
				string text = hostEvidence.Directory;
				if (text != null && text.Length > 1)
				{
					if (text[text.Length - 1] == '/')
					{
						text += "*";
					}
					else
					{
						text += "/*";
					}
					URLString operand = new URLString(text);
					if (hostEvidence2.GetURLString().IsSubsetOf(operand))
					{
						usedEvidence = hostEvidence;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06002973 RID: 10611 RVA: 0x000990E3 File Offset: 0x000972E3
		public IMembershipCondition Copy()
		{
			return new ApplicationDirectoryMembershipCondition();
		}

		// Token: 0x06002974 RID: 10612 RVA: 0x000990EA File Offset: 0x000972EA
		public SecurityElement ToXml()
		{
			return this.ToXml(null);
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x000990F3 File Offset: 0x000972F3
		public void FromXml(SecurityElement e)
		{
			this.FromXml(e, null);
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x00099100 File Offset: 0x00097300
		public SecurityElement ToXml(PolicyLevel level)
		{
			SecurityElement securityElement = new SecurityElement("IMembershipCondition");
			XMLUtil.AddClassAttribute(securityElement, base.GetType(), "System.Security.Policy.ApplicationDirectoryMembershipCondition");
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		// Token: 0x06002977 RID: 10615 RVA: 0x0009913A File Offset: 0x0009733A
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

		// Token: 0x06002978 RID: 10616 RVA: 0x0009916C File Offset: 0x0009736C
		public override bool Equals(object o)
		{
			return o is ApplicationDirectoryMembershipCondition;
		}

		// Token: 0x06002979 RID: 10617 RVA: 0x00099177 File Offset: 0x00097377
		public override int GetHashCode()
		{
			return typeof(ApplicationDirectoryMembershipCondition).GetHashCode();
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x00099188 File Offset: 0x00097388
		public override string ToString()
		{
			return Environment.GetResourceString("ApplicationDirectory_ToString");
		}
	}
}
