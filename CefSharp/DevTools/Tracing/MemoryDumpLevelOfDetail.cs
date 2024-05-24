using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D1 RID: 465
	public enum MemoryDumpLevelOfDetail
	{
		// Token: 0x04000706 RID: 1798
		[EnumMember(Value = "background")]
		Background,
		// Token: 0x04000707 RID: 1799
		[EnumMember(Value = "light")]
		Light,
		// Token: 0x04000708 RID: 1800
		[EnumMember(Value = "detailed")]
		Detailed
	}
}
