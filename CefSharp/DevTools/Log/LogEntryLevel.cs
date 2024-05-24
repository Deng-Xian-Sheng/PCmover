using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Log
{
	// Token: 0x02000318 RID: 792
	public enum LogEntryLevel
	{
		// Token: 0x04000CDE RID: 3294
		[EnumMember(Value = "verbose")]
		Verbose,
		// Token: 0x04000CDF RID: 3295
		[EnumMember(Value = "info")]
		Info,
		// Token: 0x04000CE0 RID: 3296
		[EnumMember(Value = "warning")]
		Warning,
		// Token: 0x04000CE1 RID: 3297
		[EnumMember(Value = "error")]
		Error
	}
}
