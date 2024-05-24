using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001A9 RID: 425
	public enum ContextState
	{
		// Token: 0x0400067F RID: 1663
		[EnumMember(Value = "suspended")]
		Suspended,
		// Token: 0x04000680 RID: 1664
		[EnumMember(Value = "running")]
		Running,
		// Token: 0x04000681 RID: 1665
		[EnumMember(Value = "closed")]
		Closed
	}
}
