using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000327 RID: 807
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum TokenImpersonationLevel
	{
		// Token: 0x0400101A RID: 4122
		[__DynamicallyInvokable]
		None,
		// Token: 0x0400101B RID: 4123
		[__DynamicallyInvokable]
		Anonymous,
		// Token: 0x0400101C RID: 4124
		[__DynamicallyInvokable]
		Identification,
		// Token: 0x0400101D RID: 4125
		[__DynamicallyInvokable]
		Impersonation,
		// Token: 0x0400101E RID: 4126
		[__DynamicallyInvokable]
		Delegation
	}
}
