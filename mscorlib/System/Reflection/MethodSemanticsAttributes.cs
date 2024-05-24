using System;

namespace System.Reflection
{
	// Token: 0x020005F8 RID: 1528
	[Flags]
	[Serializable]
	internal enum MethodSemanticsAttributes
	{
		// Token: 0x04001D25 RID: 7461
		Setter = 1,
		// Token: 0x04001D26 RID: 7462
		Getter = 2,
		// Token: 0x04001D27 RID: 7463
		Other = 4,
		// Token: 0x04001D28 RID: 7464
		AddOn = 8,
		// Token: 0x04001D29 RID: 7465
		RemoveOn = 16,
		// Token: 0x04001D2A RID: 7466
		Fire = 32
	}
}
