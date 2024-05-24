using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x02000353 RID: 851
	[ComVisible(true)]
	[Obsolete("This type is obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
	[Serializable]
	public sealed class FirstMatchCodeGroup : CodeGroup
	{
		// Token: 0x06002A63 RID: 10851 RVA: 0x0009CF66 File Offset: 0x0009B166
		internal FirstMatchCodeGroup()
		{
		}

		// Token: 0x06002A64 RID: 10852 RVA: 0x0009CF6E File Offset: 0x0009B16E
		public FirstMatchCodeGroup(IMembershipCondition membershipCondition, PolicyStatement policy) : base(membershipCondition, policy)
		{
		}

		// Token: 0x06002A65 RID: 10853 RVA: 0x0009CF78 File Offset: 0x0009B178
		[SecuritySafeCritical]
		public override PolicyStatement Resolve(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			object obj = null;
			if (!PolicyManager.CheckMembershipCondition(base.MembershipCondition, evidence, out obj))
			{
				return null;
			}
			PolicyStatement policyStatement = null;
			foreach (object obj2 in base.Children)
			{
				policyStatement = PolicyManager.ResolveCodeGroup(obj2 as CodeGroup, evidence);
				if (policyStatement != null)
				{
					break;
				}
			}
			IDelayEvaluatedEvidence delayEvaluatedEvidence = obj as IDelayEvaluatedEvidence;
			bool flag = delayEvaluatedEvidence != null && !delayEvaluatedEvidence.IsVerified;
			PolicyStatement policyStatement2 = base.PolicyStatement;
			if (policyStatement2 == null)
			{
				if (flag)
				{
					policyStatement = policyStatement.Copy();
					policyStatement.AddDependentEvidence(delayEvaluatedEvidence);
				}
				return policyStatement;
			}
			if (policyStatement != null)
			{
				PolicyStatement policyStatement3 = policyStatement2.Copy();
				if (flag)
				{
					policyStatement3.AddDependentEvidence(delayEvaluatedEvidence);
				}
				policyStatement3.InplaceUnion(policyStatement);
				return policyStatement3;
			}
			if (flag)
			{
				policyStatement2.AddDependentEvidence(delayEvaluatedEvidence);
			}
			return policyStatement2;
		}

		// Token: 0x06002A66 RID: 10854 RVA: 0x0009D040 File Offset: 0x0009B240
		public override CodeGroup ResolveMatchingCodeGroups(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			if (base.MembershipCondition.Check(evidence))
			{
				CodeGroup codeGroup = this.Copy();
				codeGroup.Children = new ArrayList();
				foreach (object obj in base.Children)
				{
					CodeGroup codeGroup2 = ((CodeGroup)obj).ResolveMatchingCodeGroups(evidence);
					if (codeGroup2 != null)
					{
						codeGroup.AddChild(codeGroup2);
						break;
					}
				}
				return codeGroup;
			}
			return null;
		}

		// Token: 0x06002A67 RID: 10855 RVA: 0x0009D0B4 File Offset: 0x0009B2B4
		public override CodeGroup Copy()
		{
			FirstMatchCodeGroup firstMatchCodeGroup = new FirstMatchCodeGroup();
			firstMatchCodeGroup.MembershipCondition = base.MembershipCondition;
			firstMatchCodeGroup.PolicyStatement = base.PolicyStatement;
			firstMatchCodeGroup.Name = base.Name;
			firstMatchCodeGroup.Description = base.Description;
			foreach (object obj in base.Children)
			{
				firstMatchCodeGroup.AddChild((CodeGroup)obj);
			}
			return firstMatchCodeGroup;
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06002A68 RID: 10856 RVA: 0x0009D11F File Offset: 0x0009B31F
		public override string MergeLogic
		{
			get
			{
				return Environment.GetResourceString("MergeLogic_FirstMatch");
			}
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0009D12B File Offset: 0x0009B32B
		internal override string GetTypeName()
		{
			return "System.Security.Policy.FirstMatchCodeGroup";
		}
	}
}
