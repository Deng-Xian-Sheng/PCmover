using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x02000357 RID: 855
	[ComVisible(true)]
	public interface IMembershipCondition : ISecurityEncodable, ISecurityPolicyEncodable
	{
		// Token: 0x06002A6E RID: 10862
		bool Check(Evidence evidence);

		// Token: 0x06002A6F RID: 10863
		IMembershipCondition Copy();

		// Token: 0x06002A70 RID: 10864
		string ToString();

		// Token: 0x06002A71 RID: 10865
		bool Equals(object obj);
	}
}
