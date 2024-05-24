using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000438 RID: 1080
	[Flags]
	[__DynamicallyInvokable]
	public enum EventKeywords : long
	{
		// Token: 0x040017FC RID: 6140
		[__DynamicallyInvokable]
		None = 0L,
		// Token: 0x040017FD RID: 6141
		[__DynamicallyInvokable]
		All = -1L,
		// Token: 0x040017FE RID: 6142
		MicrosoftTelemetry = 562949953421312L,
		// Token: 0x040017FF RID: 6143
		[__DynamicallyInvokable]
		WdiContext = 562949953421312L,
		// Token: 0x04001800 RID: 6144
		[__DynamicallyInvokable]
		WdiDiagnostic = 1125899906842624L,
		// Token: 0x04001801 RID: 6145
		[__DynamicallyInvokable]
		Sqm = 2251799813685248L,
		// Token: 0x04001802 RID: 6146
		[__DynamicallyInvokable]
		AuditFailure = 4503599627370496L,
		// Token: 0x04001803 RID: 6147
		[__DynamicallyInvokable]
		AuditSuccess = 9007199254740992L,
		// Token: 0x04001804 RID: 6148
		[__DynamicallyInvokable]
		CorrelationHint = 4503599627370496L,
		// Token: 0x04001805 RID: 6149
		[__DynamicallyInvokable]
		EventLogClassic = 36028797018963968L
	}
}
