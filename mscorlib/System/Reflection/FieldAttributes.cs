using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005E3 RID: 1507
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum FieldAttributes
	{
		// Token: 0x04001C9E RID: 7326
		[__DynamicallyInvokable]
		FieldAccessMask = 7,
		// Token: 0x04001C9F RID: 7327
		[__DynamicallyInvokable]
		PrivateScope = 0,
		// Token: 0x04001CA0 RID: 7328
		[__DynamicallyInvokable]
		Private = 1,
		// Token: 0x04001CA1 RID: 7329
		[__DynamicallyInvokable]
		FamANDAssem = 2,
		// Token: 0x04001CA2 RID: 7330
		[__DynamicallyInvokable]
		Assembly = 3,
		// Token: 0x04001CA3 RID: 7331
		[__DynamicallyInvokable]
		Family = 4,
		// Token: 0x04001CA4 RID: 7332
		[__DynamicallyInvokable]
		FamORAssem = 5,
		// Token: 0x04001CA5 RID: 7333
		[__DynamicallyInvokable]
		Public = 6,
		// Token: 0x04001CA6 RID: 7334
		[__DynamicallyInvokable]
		Static = 16,
		// Token: 0x04001CA7 RID: 7335
		[__DynamicallyInvokable]
		InitOnly = 32,
		// Token: 0x04001CA8 RID: 7336
		[__DynamicallyInvokable]
		Literal = 64,
		// Token: 0x04001CA9 RID: 7337
		[__DynamicallyInvokable]
		NotSerialized = 128,
		// Token: 0x04001CAA RID: 7338
		[__DynamicallyInvokable]
		SpecialName = 512,
		// Token: 0x04001CAB RID: 7339
		[__DynamicallyInvokable]
		PinvokeImpl = 8192,
		// Token: 0x04001CAC RID: 7340
		ReservedMask = 38144,
		// Token: 0x04001CAD RID: 7341
		[__DynamicallyInvokable]
		RTSpecialName = 1024,
		// Token: 0x04001CAE RID: 7342
		[__DynamicallyInvokable]
		HasFieldMarshal = 4096,
		// Token: 0x04001CAF RID: 7343
		[__DynamicallyInvokable]
		HasDefault = 32768,
		// Token: 0x04001CB0 RID: 7344
		[__DynamicallyInvokable]
		HasFieldRVA = 256
	}
}
