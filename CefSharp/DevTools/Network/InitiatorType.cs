using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C0 RID: 704
	public enum InitiatorType
	{
		// Token: 0x04000B6D RID: 2925
		[EnumMember(Value = "parser")]
		Parser,
		// Token: 0x04000B6E RID: 2926
		[EnumMember(Value = "script")]
		Script,
		// Token: 0x04000B6F RID: 2927
		[EnumMember(Value = "preload")]
		Preload,
		// Token: 0x04000B70 RID: 2928
		[EnumMember(Value = "SignedExchange")]
		SignedExchange,
		// Token: 0x04000B71 RID: 2929
		[EnumMember(Value = "preflight")]
		Preflight,
		// Token: 0x04000B72 RID: 2930
		[EnumMember(Value = "other")]
		Other
	}
}
