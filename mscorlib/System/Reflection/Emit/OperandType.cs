using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000658 RID: 1624
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum OperandType
	{
		// Token: 0x04002167 RID: 8551
		[__DynamicallyInvokable]
		InlineBrTarget,
		// Token: 0x04002168 RID: 8552
		[__DynamicallyInvokable]
		InlineField,
		// Token: 0x04002169 RID: 8553
		[__DynamicallyInvokable]
		InlineI,
		// Token: 0x0400216A RID: 8554
		[__DynamicallyInvokable]
		InlineI8,
		// Token: 0x0400216B RID: 8555
		[__DynamicallyInvokable]
		InlineMethod,
		// Token: 0x0400216C RID: 8556
		[__DynamicallyInvokable]
		InlineNone,
		// Token: 0x0400216D RID: 8557
		[Obsolete("This API has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		InlinePhi,
		// Token: 0x0400216E RID: 8558
		[__DynamicallyInvokable]
		InlineR,
		// Token: 0x0400216F RID: 8559
		[__DynamicallyInvokable]
		InlineSig = 9,
		// Token: 0x04002170 RID: 8560
		[__DynamicallyInvokable]
		InlineString,
		// Token: 0x04002171 RID: 8561
		[__DynamicallyInvokable]
		InlineSwitch,
		// Token: 0x04002172 RID: 8562
		[__DynamicallyInvokable]
		InlineTok,
		// Token: 0x04002173 RID: 8563
		[__DynamicallyInvokable]
		InlineType,
		// Token: 0x04002174 RID: 8564
		[__DynamicallyInvokable]
		InlineVar,
		// Token: 0x04002175 RID: 8565
		[__DynamicallyInvokable]
		ShortInlineBrTarget,
		// Token: 0x04002176 RID: 8566
		[__DynamicallyInvokable]
		ShortInlineI,
		// Token: 0x04002177 RID: 8567
		[__DynamicallyInvokable]
		ShortInlineR,
		// Token: 0x04002178 RID: 8568
		[__DynamicallyInvokable]
		ShortInlineVar
	}
}
