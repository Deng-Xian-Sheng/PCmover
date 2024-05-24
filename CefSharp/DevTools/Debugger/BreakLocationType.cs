using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200017A RID: 378
	public enum BreakLocationType
	{
		// Token: 0x040005D7 RID: 1495
		[EnumMember(Value = "debuggerStatement")]
		DebuggerStatement,
		// Token: 0x040005D8 RID: 1496
		[EnumMember(Value = "call")]
		Call,
		// Token: 0x040005D9 RID: 1497
		[EnumMember(Value = "return")]
		Return
	}
}
