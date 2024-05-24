using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000180 RID: 384
	public enum PausedReason
	{
		// Token: 0x040005EB RID: 1515
		[EnumMember(Value = "ambiguous")]
		Ambiguous,
		// Token: 0x040005EC RID: 1516
		[EnumMember(Value = "assert")]
		Assert,
		// Token: 0x040005ED RID: 1517
		[EnumMember(Value = "CSPViolation")]
		CSPViolation,
		// Token: 0x040005EE RID: 1518
		[EnumMember(Value = "debugCommand")]
		DebugCommand,
		// Token: 0x040005EF RID: 1519
		[EnumMember(Value = "DOM")]
		DOM,
		// Token: 0x040005F0 RID: 1520
		[EnumMember(Value = "EventListener")]
		EventListener,
		// Token: 0x040005F1 RID: 1521
		[EnumMember(Value = "exception")]
		Exception,
		// Token: 0x040005F2 RID: 1522
		[EnumMember(Value = "instrumentation")]
		Instrumentation,
		// Token: 0x040005F3 RID: 1523
		[EnumMember(Value = "OOM")]
		OOM,
		// Token: 0x040005F4 RID: 1524
		[EnumMember(Value = "other")]
		Other,
		// Token: 0x040005F5 RID: 1525
		[EnumMember(Value = "promiseRejection")]
		PromiseRejection,
		// Token: 0x040005F6 RID: 1526
		[EnumMember(Value = "XHR")]
		XHR
	}
}
