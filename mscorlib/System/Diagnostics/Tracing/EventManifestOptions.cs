using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200042F RID: 1071
	[Flags]
	[__DynamicallyInvokable]
	public enum EventManifestOptions
	{
		// Token: 0x040017C0 RID: 6080
		[__DynamicallyInvokable]
		None = 0,
		// Token: 0x040017C1 RID: 6081
		[__DynamicallyInvokable]
		Strict = 1,
		// Token: 0x040017C2 RID: 6082
		[__DynamicallyInvokable]
		AllCultures = 2,
		// Token: 0x040017C3 RID: 6083
		[__DynamicallyInvokable]
		OnlyIfNeededForRegistration = 4,
		// Token: 0x040017C4 RID: 6084
		[__DynamicallyInvokable]
		AllowEventSourceOverride = 8
	}
}
