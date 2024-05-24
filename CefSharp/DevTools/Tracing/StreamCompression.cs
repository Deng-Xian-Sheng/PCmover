using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D0 RID: 464
	public enum StreamCompression
	{
		// Token: 0x04000703 RID: 1795
		[EnumMember(Value = "none")]
		None,
		// Token: 0x04000704 RID: 1796
		[EnumMember(Value = "gzip")]
		Gzip
	}
}
