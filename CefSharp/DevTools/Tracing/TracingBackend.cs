using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D2 RID: 466
	public enum TracingBackend
	{
		// Token: 0x0400070A RID: 1802
		[EnumMember(Value = "auto")]
		Auto,
		// Token: 0x0400070B RID: 1803
		[EnumMember(Value = "chrome")]
		Chrome,
		// Token: 0x0400070C RID: 1804
		[EnumMember(Value = "system")]
		System
	}
}
