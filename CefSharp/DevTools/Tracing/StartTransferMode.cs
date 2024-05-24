using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D8 RID: 472
	public enum StartTransferMode
	{
		// Token: 0x04000719 RID: 1817
		[EnumMember(Value = "ReportEvents")]
		ReportEvents,
		// Token: 0x0400071A RID: 1818
		[EnumMember(Value = "ReturnAsStream")]
		ReturnAsStream
	}
}
