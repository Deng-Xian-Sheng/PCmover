using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000603 RID: 1539
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum MethodAttributes
	{
		// Token: 0x04001D61 RID: 7521
		[__DynamicallyInvokable]
		MemberAccessMask = 7,
		// Token: 0x04001D62 RID: 7522
		[__DynamicallyInvokable]
		PrivateScope = 0,
		// Token: 0x04001D63 RID: 7523
		[__DynamicallyInvokable]
		Private = 1,
		// Token: 0x04001D64 RID: 7524
		[__DynamicallyInvokable]
		FamANDAssem = 2,
		// Token: 0x04001D65 RID: 7525
		[__DynamicallyInvokable]
		Assembly = 3,
		// Token: 0x04001D66 RID: 7526
		[__DynamicallyInvokable]
		Family = 4,
		// Token: 0x04001D67 RID: 7527
		[__DynamicallyInvokable]
		FamORAssem = 5,
		// Token: 0x04001D68 RID: 7528
		[__DynamicallyInvokable]
		Public = 6,
		// Token: 0x04001D69 RID: 7529
		[__DynamicallyInvokable]
		Static = 16,
		// Token: 0x04001D6A RID: 7530
		[__DynamicallyInvokable]
		Final = 32,
		// Token: 0x04001D6B RID: 7531
		[__DynamicallyInvokable]
		Virtual = 64,
		// Token: 0x04001D6C RID: 7532
		[__DynamicallyInvokable]
		HideBySig = 128,
		// Token: 0x04001D6D RID: 7533
		[__DynamicallyInvokable]
		CheckAccessOnOverride = 512,
		// Token: 0x04001D6E RID: 7534
		[__DynamicallyInvokable]
		VtableLayoutMask = 256,
		// Token: 0x04001D6F RID: 7535
		[__DynamicallyInvokable]
		ReuseSlot = 0,
		// Token: 0x04001D70 RID: 7536
		[__DynamicallyInvokable]
		NewSlot = 256,
		// Token: 0x04001D71 RID: 7537
		[__DynamicallyInvokable]
		Abstract = 1024,
		// Token: 0x04001D72 RID: 7538
		[__DynamicallyInvokable]
		SpecialName = 2048,
		// Token: 0x04001D73 RID: 7539
		[__DynamicallyInvokable]
		PinvokeImpl = 8192,
		// Token: 0x04001D74 RID: 7540
		[__DynamicallyInvokable]
		UnmanagedExport = 8,
		// Token: 0x04001D75 RID: 7541
		[__DynamicallyInvokable]
		RTSpecialName = 4096,
		// Token: 0x04001D76 RID: 7542
		ReservedMask = 53248,
		// Token: 0x04001D77 RID: 7543
		[__DynamicallyInvokable]
		HasSecurity = 16384,
		// Token: 0x04001D78 RID: 7544
		[__DynamicallyInvokable]
		RequireSecObject = 32768
	}
}
