using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000606 RID: 1542
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum MethodImplAttributes
	{
		// Token: 0x04001D88 RID: 7560
		[__DynamicallyInvokable]
		CodeTypeMask = 3,
		// Token: 0x04001D89 RID: 7561
		[__DynamicallyInvokable]
		IL = 0,
		// Token: 0x04001D8A RID: 7562
		[__DynamicallyInvokable]
		Native,
		// Token: 0x04001D8B RID: 7563
		[__DynamicallyInvokable]
		OPTIL,
		// Token: 0x04001D8C RID: 7564
		[__DynamicallyInvokable]
		Runtime,
		// Token: 0x04001D8D RID: 7565
		[__DynamicallyInvokable]
		ManagedMask,
		// Token: 0x04001D8E RID: 7566
		[__DynamicallyInvokable]
		Unmanaged = 4,
		// Token: 0x04001D8F RID: 7567
		[__DynamicallyInvokable]
		Managed = 0,
		// Token: 0x04001D90 RID: 7568
		[__DynamicallyInvokable]
		ForwardRef = 16,
		// Token: 0x04001D91 RID: 7569
		[__DynamicallyInvokable]
		PreserveSig = 128,
		// Token: 0x04001D92 RID: 7570
		[__DynamicallyInvokable]
		InternalCall = 4096,
		// Token: 0x04001D93 RID: 7571
		[__DynamicallyInvokable]
		Synchronized = 32,
		// Token: 0x04001D94 RID: 7572
		[__DynamicallyInvokable]
		NoInlining = 8,
		// Token: 0x04001D95 RID: 7573
		[ComVisible(false)]
		[__DynamicallyInvokable]
		AggressiveInlining = 256,
		// Token: 0x04001D96 RID: 7574
		[__DynamicallyInvokable]
		NoOptimization = 64,
		// Token: 0x04001D97 RID: 7575
		SecurityMitigations = 1024,
		// Token: 0x04001D98 RID: 7576
		MaxMethodImplVal = 65535
	}
}
