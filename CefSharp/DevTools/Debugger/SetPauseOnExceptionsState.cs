using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000191 RID: 401
	public enum SetPauseOnExceptionsState
	{
		// Token: 0x0400063C RID: 1596
		[EnumMember(Value = "none")]
		None,
		// Token: 0x0400063D RID: 1597
		[EnumMember(Value = "uncaught")]
		Uncaught,
		// Token: 0x0400063E RID: 1598
		[EnumMember(Value = "all")]
		All
	}
}
