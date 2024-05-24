using System;

namespace System.Security.Policy
{
	// Token: 0x02000358 RID: 856
	internal interface IReportMatchMembershipCondition : IMembershipCondition, ISecurityEncodable, ISecurityPolicyEncodable
	{
		// Token: 0x06002A72 RID: 10866
		bool Check(Evidence evidence, out object usedEvidence);
	}
}
