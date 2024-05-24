using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000420 RID: 1056
	[Flags]
	[__DynamicallyInvokable]
	public enum EventSourceSettings
	{
		// Token: 0x0400176A RID: 5994
		[__DynamicallyInvokable]
		Default = 0,
		// Token: 0x0400176B RID: 5995
		[__DynamicallyInvokable]
		ThrowOnEventWriteErrors = 1,
		// Token: 0x0400176C RID: 5996
		[__DynamicallyInvokable]
		EtwManifestEventFormat = 4,
		// Token: 0x0400176D RID: 5997
		[__DynamicallyInvokable]
		EtwSelfDescribingEventFormat = 8
	}
}
