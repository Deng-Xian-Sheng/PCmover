using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200012D RID: 301
	public enum RemoteObjectType
	{
		// Token: 0x0400049C RID: 1180
		[EnumMember(Value = "object")]
		Object,
		// Token: 0x0400049D RID: 1181
		[EnumMember(Value = "function")]
		Function,
		// Token: 0x0400049E RID: 1182
		[EnumMember(Value = "undefined")]
		Undefined,
		// Token: 0x0400049F RID: 1183
		[EnumMember(Value = "string")]
		String,
		// Token: 0x040004A0 RID: 1184
		[EnumMember(Value = "number")]
		Number,
		// Token: 0x040004A1 RID: 1185
		[EnumMember(Value = "boolean")]
		Boolean,
		// Token: 0x040004A2 RID: 1186
		[EnumMember(Value = "symbol")]
		Symbol,
		// Token: 0x040004A3 RID: 1187
		[EnumMember(Value = "bigint")]
		Bigint
	}
}
