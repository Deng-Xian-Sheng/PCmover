using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002A9 RID: 681
	public enum CookieSameSite
	{
		// Token: 0x04000AB7 RID: 2743
		[EnumMember(Value = "Strict")]
		Strict,
		// Token: 0x04000AB8 RID: 2744
		[EnumMember(Value = "Lax")]
		Lax,
		// Token: 0x04000AB9 RID: 2745
		[EnumMember(Value = "None")]
		None
	}
}
