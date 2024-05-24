using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000659 RID: 1625
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum FlowControl
	{
		// Token: 0x0400217A RID: 8570
		[__DynamicallyInvokable]
		Branch,
		// Token: 0x0400217B RID: 8571
		[__DynamicallyInvokable]
		Break,
		// Token: 0x0400217C RID: 8572
		[__DynamicallyInvokable]
		Call,
		// Token: 0x0400217D RID: 8573
		[__DynamicallyInvokable]
		Cond_Branch,
		// Token: 0x0400217E RID: 8574
		[__DynamicallyInvokable]
		Meta,
		// Token: 0x0400217F RID: 8575
		[__DynamicallyInvokable]
		Next,
		// Token: 0x04002180 RID: 8576
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		Phi,
		// Token: 0x04002181 RID: 8577
		[__DynamicallyInvokable]
		Return,
		// Token: 0x04002182 RID: 8578
		[__DynamicallyInvokable]
		Throw
	}
}
