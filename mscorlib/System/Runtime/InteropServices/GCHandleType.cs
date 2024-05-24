using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000946 RID: 2374
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum GCHandleType
	{
		// Token: 0x04002B3A RID: 11066
		[__DynamicallyInvokable]
		Weak,
		// Token: 0x04002B3B RID: 11067
		[__DynamicallyInvokable]
		WeakTrackResurrection,
		// Token: 0x04002B3C RID: 11068
		[__DynamicallyInvokable]
		Normal,
		// Token: 0x04002B3D RID: 11069
		[__DynamicallyInvokable]
		Pinned
	}
}
