using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000131 RID: 305
	public enum ObjectPreviewType
	{
		// Token: 0x040004C4 RID: 1220
		[EnumMember(Value = "object")]
		Object,
		// Token: 0x040004C5 RID: 1221
		[EnumMember(Value = "function")]
		Function,
		// Token: 0x040004C6 RID: 1222
		[EnumMember(Value = "undefined")]
		Undefined,
		// Token: 0x040004C7 RID: 1223
		[EnumMember(Value = "string")]
		String,
		// Token: 0x040004C8 RID: 1224
		[EnumMember(Value = "number")]
		Number,
		// Token: 0x040004C9 RID: 1225
		[EnumMember(Value = "boolean")]
		Boolean,
		// Token: 0x040004CA RID: 1226
		[EnumMember(Value = "symbol")]
		Symbol,
		// Token: 0x040004CB RID: 1227
		[EnumMember(Value = "bigint")]
		Bigint
	}
}
