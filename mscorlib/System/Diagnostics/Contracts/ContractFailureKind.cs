using System;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000415 RID: 1045
	[__DynamicallyInvokable]
	public enum ContractFailureKind
	{
		// Token: 0x0400170A RID: 5898
		[__DynamicallyInvokable]
		Precondition,
		// Token: 0x0400170B RID: 5899
		[__DynamicallyInvokable]
		Postcondition,
		// Token: 0x0400170C RID: 5900
		[__DynamicallyInvokable]
		PostconditionOnException,
		// Token: 0x0400170D RID: 5901
		[__DynamicallyInvokable]
		Invariant,
		// Token: 0x0400170E RID: 5902
		[__DynamicallyInvokable]
		Assert,
		// Token: 0x0400170F RID: 5903
		[__DynamicallyInvokable]
		Assume
	}
}
