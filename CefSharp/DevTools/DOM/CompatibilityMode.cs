using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000380 RID: 896
	public enum CompatibilityMode
	{
		// Token: 0x04000E6E RID: 3694
		[EnumMember(Value = "QuirksMode")]
		QuirksMode,
		// Token: 0x04000E6F RID: 3695
		[EnumMember(Value = "LimitedQuirksMode")]
		LimitedQuirksMode,
		// Token: 0x04000E70 RID: 3696
		[EnumMember(Value = "NoQuirksMode")]
		NoQuirksMode
	}
}
