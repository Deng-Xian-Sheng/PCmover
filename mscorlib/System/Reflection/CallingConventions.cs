using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005D0 RID: 1488
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum CallingConventions
	{
		// Token: 0x04001C3E RID: 7230
		[__DynamicallyInvokable]
		Standard = 1,
		// Token: 0x04001C3F RID: 7231
		[__DynamicallyInvokable]
		VarArgs = 2,
		// Token: 0x04001C40 RID: 7232
		[__DynamicallyInvokable]
		Any = 3,
		// Token: 0x04001C41 RID: 7233
		[__DynamicallyInvokable]
		HasThis = 32,
		// Token: 0x04001C42 RID: 7234
		[__DynamicallyInvokable]
		ExplicitThis = 64
	}
}
