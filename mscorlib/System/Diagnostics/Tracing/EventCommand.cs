using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200042A RID: 1066
	[__DynamicallyInvokable]
	public enum EventCommand
	{
		// Token: 0x040017A5 RID: 6053
		[__DynamicallyInvokable]
		Update,
		// Token: 0x040017A6 RID: 6054
		[__DynamicallyInvokable]
		SendManifest = -1,
		// Token: 0x040017A7 RID: 6055
		[__DynamicallyInvokable]
		Enable = -2,
		// Token: 0x040017A8 RID: 6056
		[__DynamicallyInvokable]
		Disable = -3
	}
}
