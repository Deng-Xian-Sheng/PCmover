using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200017D RID: 381
	public enum DebugSymbolsType
	{
		// Token: 0x040005E2 RID: 1506
		[EnumMember(Value = "None")]
		None,
		// Token: 0x040005E3 RID: 1507
		[EnumMember(Value = "SourceMap")]
		SourceMap,
		// Token: 0x040005E4 RID: 1508
		[EnumMember(Value = "EmbeddedDWARF")]
		EmbeddedDWARF,
		// Token: 0x040005E5 RID: 1509
		[EnumMember(Value = "ExternalDWARF")]
		ExternalDWARF
	}
}
