using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005C8 RID: 1480
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum AssemblyNameFlags
	{
		// Token: 0x04001C19 RID: 7193
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x04001C1A RID: 7194
		[__DynamicallyInvokable]
		PublicKey = 1,
		// Token: 0x04001C1B RID: 7195
		EnableJITcompileOptimizer = 16384,
		// Token: 0x04001C1C RID: 7196
		EnableJITcompileTracking = 32768,
		// Token: 0x04001C1D RID: 7197
		[__DynamicallyInvokable]
		Retargetable = 256
	}
}
