using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000190 RID: 400
	public enum SetInstrumentationBreakpointInstrumentation
	{
		// Token: 0x04000639 RID: 1593
		[EnumMember(Value = "beforeScriptExecution")]
		BeforeScriptExecution,
		// Token: 0x0400063A RID: 1594
		[EnumMember(Value = "beforeScriptWithSourceMapExecution")]
		BeforeScriptWithSourceMapExecution
	}
}
