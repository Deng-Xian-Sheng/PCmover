using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000134 RID: 308
	public enum PropertyPreviewType
	{
		// Token: 0x040004E7 RID: 1255
		[EnumMember(Value = "object")]
		Object,
		// Token: 0x040004E8 RID: 1256
		[EnumMember(Value = "function")]
		Function,
		// Token: 0x040004E9 RID: 1257
		[EnumMember(Value = "undefined")]
		Undefined,
		// Token: 0x040004EA RID: 1258
		[EnumMember(Value = "string")]
		String,
		// Token: 0x040004EB RID: 1259
		[EnumMember(Value = "number")]
		Number,
		// Token: 0x040004EC RID: 1260
		[EnumMember(Value = "boolean")]
		Boolean,
		// Token: 0x040004ED RID: 1261
		[EnumMember(Value = "symbol")]
		Symbol,
		// Token: 0x040004EE RID: 1262
		[EnumMember(Value = "accessor")]
		Accessor,
		// Token: 0x040004EF RID: 1263
		[EnumMember(Value = "bigint")]
		Bigint
	}
}
