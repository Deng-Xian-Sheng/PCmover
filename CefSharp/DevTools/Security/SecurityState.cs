using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000216 RID: 534
	public enum SecurityState
	{
		// Token: 0x040007CE RID: 1998
		[EnumMember(Value = "unknown")]
		Unknown,
		// Token: 0x040007CF RID: 1999
		[EnumMember(Value = "neutral")]
		Neutral,
		// Token: 0x040007D0 RID: 2000
		[EnumMember(Value = "insecure")]
		Insecure,
		// Token: 0x040007D1 RID: 2001
		[EnumMember(Value = "secure")]
		Secure,
		// Token: 0x040007D2 RID: 2002
		[EnumMember(Value = "info")]
		Info,
		// Token: 0x040007D3 RID: 2003
		[EnumMember(Value = "insecure-broken")]
		InsecureBroken
	}
}
