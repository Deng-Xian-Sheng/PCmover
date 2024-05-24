using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003D9 RID: 985
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum NumberStyles
	{
		// Token: 0x0400156B RID: 5483
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x0400156C RID: 5484
		[__DynamicallyInvokable]
		AllowLeadingWhite = 1,
		// Token: 0x0400156D RID: 5485
		[__DynamicallyInvokable]
		AllowTrailingWhite = 2,
		// Token: 0x0400156E RID: 5486
		[__DynamicallyInvokable]
		AllowLeadingSign = 4,
		// Token: 0x0400156F RID: 5487
		[__DynamicallyInvokable]
		AllowTrailingSign = 8,
		// Token: 0x04001570 RID: 5488
		[__DynamicallyInvokable]
		AllowParentheses = 16,
		// Token: 0x04001571 RID: 5489
		[__DynamicallyInvokable]
		AllowDecimalPoint = 32,
		// Token: 0x04001572 RID: 5490
		[__DynamicallyInvokable]
		AllowThousands = 64,
		// Token: 0x04001573 RID: 5491
		[__DynamicallyInvokable]
		AllowExponent = 128,
		// Token: 0x04001574 RID: 5492
		[__DynamicallyInvokable]
		AllowCurrencySymbol = 256,
		// Token: 0x04001575 RID: 5493
		[__DynamicallyInvokable]
		AllowHexSpecifier = 512,
		// Token: 0x04001576 RID: 5494
		[__DynamicallyInvokable]
		Integer = 7,
		// Token: 0x04001577 RID: 5495
		[__DynamicallyInvokable]
		HexNumber = 515,
		// Token: 0x04001578 RID: 5496
		[__DynamicallyInvokable]
		Number = 111,
		// Token: 0x04001579 RID: 5497
		[__DynamicallyInvokable]
		Float = 167,
		// Token: 0x0400157A RID: 5498
		[__DynamicallyInvokable]
		Currency = 383,
		// Token: 0x0400157B RID: 5499
		[__DynamicallyInvokable]
		Any = 511
	}
}
