using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008BC RID: 2236
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum MethodImplOptions
	{
		// Token: 0x04002A14 RID: 10772
		Unmanaged = 4,
		// Token: 0x04002A15 RID: 10773
		ForwardRef = 16,
		// Token: 0x04002A16 RID: 10774
		[__DynamicallyInvokable]
		PreserveSig = 128,
		// Token: 0x04002A17 RID: 10775
		InternalCall = 4096,
		// Token: 0x04002A18 RID: 10776
		Synchronized = 32,
		// Token: 0x04002A19 RID: 10777
		[__DynamicallyInvokable]
		NoInlining = 8,
		// Token: 0x04002A1A RID: 10778
		[ComVisible(false)]
		[__DynamicallyInvokable]
		AggressiveInlining = 256,
		// Token: 0x04002A1B RID: 10779
		[__DynamicallyInvokable]
		NoOptimization = 64,
		// Token: 0x04002A1C RID: 10780
		SecurityMitigations = 1024
	}
}
