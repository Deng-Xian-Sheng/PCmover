using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002AB RID: 683
	public enum CookieSourceScheme
	{
		// Token: 0x04000ABF RID: 2751
		[EnumMember(Value = "Unset")]
		Unset,
		// Token: 0x04000AC0 RID: 2752
		[EnumMember(Value = "NonSecure")]
		NonSecure,
		// Token: 0x04000AC1 RID: 2753
		[EnumMember(Value = "Secure")]
		Secure
	}
}
