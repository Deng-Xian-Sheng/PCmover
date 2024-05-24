using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200017C RID: 380
	public enum ScriptLanguage
	{
		// Token: 0x040005DF RID: 1503
		[EnumMember(Value = "JavaScript")]
		JavaScript,
		// Token: 0x040005E0 RID: 1504
		[EnumMember(Value = "WebAssembly")]
		WebAssembly
	}
}
