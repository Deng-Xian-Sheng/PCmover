using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000774 RID: 1908
	[Flags]
	[Serializable]
	internal enum MessageEnum
	{
		// Token: 0x0400254E RID: 9550
		NoArgs = 1,
		// Token: 0x0400254F RID: 9551
		ArgsInline = 2,
		// Token: 0x04002550 RID: 9552
		ArgsIsArray = 4,
		// Token: 0x04002551 RID: 9553
		ArgsInArray = 8,
		// Token: 0x04002552 RID: 9554
		NoContext = 16,
		// Token: 0x04002553 RID: 9555
		ContextInline = 32,
		// Token: 0x04002554 RID: 9556
		ContextInArray = 64,
		// Token: 0x04002555 RID: 9557
		MethodSignatureInArray = 128,
		// Token: 0x04002556 RID: 9558
		PropertyInArray = 256,
		// Token: 0x04002557 RID: 9559
		NoReturnValue = 512,
		// Token: 0x04002558 RID: 9560
		ReturnValueVoid = 1024,
		// Token: 0x04002559 RID: 9561
		ReturnValueInline = 2048,
		// Token: 0x0400255A RID: 9562
		ReturnValueInArray = 4096,
		// Token: 0x0400255B RID: 9563
		ExceptionInArray = 8192,
		// Token: 0x0400255C RID: 9564
		GenericMethod = 32768
	}
}
