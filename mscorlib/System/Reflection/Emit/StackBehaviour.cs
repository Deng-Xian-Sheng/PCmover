using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000657 RID: 1623
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum StackBehaviour
	{
		// Token: 0x04002149 RID: 8521
		[__DynamicallyInvokable]
		Pop0,
		// Token: 0x0400214A RID: 8522
		[__DynamicallyInvokable]
		Pop1,
		// Token: 0x0400214B RID: 8523
		[__DynamicallyInvokable]
		Pop1_pop1,
		// Token: 0x0400214C RID: 8524
		[__DynamicallyInvokable]
		Popi,
		// Token: 0x0400214D RID: 8525
		[__DynamicallyInvokable]
		Popi_pop1,
		// Token: 0x0400214E RID: 8526
		[__DynamicallyInvokable]
		Popi_popi,
		// Token: 0x0400214F RID: 8527
		[__DynamicallyInvokable]
		Popi_popi8,
		// Token: 0x04002150 RID: 8528
		[__DynamicallyInvokable]
		Popi_popi_popi,
		// Token: 0x04002151 RID: 8529
		[__DynamicallyInvokable]
		Popi_popr4,
		// Token: 0x04002152 RID: 8530
		[__DynamicallyInvokable]
		Popi_popr8,
		// Token: 0x04002153 RID: 8531
		[__DynamicallyInvokable]
		Popref,
		// Token: 0x04002154 RID: 8532
		[__DynamicallyInvokable]
		Popref_pop1,
		// Token: 0x04002155 RID: 8533
		[__DynamicallyInvokable]
		Popref_popi,
		// Token: 0x04002156 RID: 8534
		[__DynamicallyInvokable]
		Popref_popi_popi,
		// Token: 0x04002157 RID: 8535
		[__DynamicallyInvokable]
		Popref_popi_popi8,
		// Token: 0x04002158 RID: 8536
		[__DynamicallyInvokable]
		Popref_popi_popr4,
		// Token: 0x04002159 RID: 8537
		[__DynamicallyInvokable]
		Popref_popi_popr8,
		// Token: 0x0400215A RID: 8538
		[__DynamicallyInvokable]
		Popref_popi_popref,
		// Token: 0x0400215B RID: 8539
		[__DynamicallyInvokable]
		Push0,
		// Token: 0x0400215C RID: 8540
		[__DynamicallyInvokable]
		Push1,
		// Token: 0x0400215D RID: 8541
		[__DynamicallyInvokable]
		Push1_push1,
		// Token: 0x0400215E RID: 8542
		[__DynamicallyInvokable]
		Pushi,
		// Token: 0x0400215F RID: 8543
		[__DynamicallyInvokable]
		Pushi8,
		// Token: 0x04002160 RID: 8544
		[__DynamicallyInvokable]
		Pushr4,
		// Token: 0x04002161 RID: 8545
		[__DynamicallyInvokable]
		Pushr8,
		// Token: 0x04002162 RID: 8546
		[__DynamicallyInvokable]
		Pushref,
		// Token: 0x04002163 RID: 8547
		[__DynamicallyInvokable]
		Varpop,
		// Token: 0x04002164 RID: 8548
		[__DynamicallyInvokable]
		Varpush,
		// Token: 0x04002165 RID: 8549
		[__DynamicallyInvokable]
		Popref_popi_pop1
	}
}
