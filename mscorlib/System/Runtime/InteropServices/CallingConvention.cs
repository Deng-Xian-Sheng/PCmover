using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000941 RID: 2369
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum CallingConvention
	{
		// Token: 0x04002B2D RID: 11053
		[__DynamicallyInvokable]
		Winapi = 1,
		// Token: 0x04002B2E RID: 11054
		[__DynamicallyInvokable]
		Cdecl,
		// Token: 0x04002B2F RID: 11055
		[__DynamicallyInvokable]
		StdCall,
		// Token: 0x04002B30 RID: 11056
		[__DynamicallyInvokable]
		ThisCall,
		// Token: 0x04002B31 RID: 11057
		FastCall
	}
}
