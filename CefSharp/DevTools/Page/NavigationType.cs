using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000253 RID: 595
	public enum NavigationType
	{
		// Token: 0x04000925 RID: 2341
		[EnumMember(Value = "Navigation")]
		Navigation,
		// Token: 0x04000926 RID: 2342
		[EnumMember(Value = "BackForwardCacheRestore")]
		BackForwardCacheRestore
	}
}
