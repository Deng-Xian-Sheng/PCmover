using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001CD RID: 461
	public enum TraceConfigRecordMode
	{
		// Token: 0x040006F3 RID: 1779
		[EnumMember(Value = "recordUntilFull")]
		RecordUntilFull,
		// Token: 0x040006F4 RID: 1780
		[EnumMember(Value = "recordContinuously")]
		RecordContinuously,
		// Token: 0x040006F5 RID: 1781
		[EnumMember(Value = "recordAsMuchAsPossible")]
		RecordAsMuchAsPossible,
		// Token: 0x040006F6 RID: 1782
		[EnumMember(Value = "echoToConsole")]
		EchoToConsole
	}
}
