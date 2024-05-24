using System;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000437 RID: 1079
	[FriendAccessAllowed]
	[__DynamicallyInvokable]
	public enum EventChannel : byte
	{
		// Token: 0x040017F6 RID: 6134
		[__DynamicallyInvokable]
		None,
		// Token: 0x040017F7 RID: 6135
		[__DynamicallyInvokable]
		Admin = 16,
		// Token: 0x040017F8 RID: 6136
		[__DynamicallyInvokable]
		Operational,
		// Token: 0x040017F9 RID: 6137
		[__DynamicallyInvokable]
		Analytic,
		// Token: 0x040017FA RID: 6138
		[__DynamicallyInvokable]
		Debug
	}
}
