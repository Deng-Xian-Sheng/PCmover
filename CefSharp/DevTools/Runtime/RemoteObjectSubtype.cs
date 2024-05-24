using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200012E RID: 302
	public enum RemoteObjectSubtype
	{
		// Token: 0x040004A5 RID: 1189
		[EnumMember(Value = "array")]
		Array,
		// Token: 0x040004A6 RID: 1190
		[EnumMember(Value = "null")]
		Null,
		// Token: 0x040004A7 RID: 1191
		[EnumMember(Value = "node")]
		Node,
		// Token: 0x040004A8 RID: 1192
		[EnumMember(Value = "regexp")]
		Regexp,
		// Token: 0x040004A9 RID: 1193
		[EnumMember(Value = "date")]
		Date,
		// Token: 0x040004AA RID: 1194
		[EnumMember(Value = "map")]
		Map,
		// Token: 0x040004AB RID: 1195
		[EnumMember(Value = "set")]
		Set,
		// Token: 0x040004AC RID: 1196
		[EnumMember(Value = "weakmap")]
		Weakmap,
		// Token: 0x040004AD RID: 1197
		[EnumMember(Value = "weakset")]
		Weakset,
		// Token: 0x040004AE RID: 1198
		[EnumMember(Value = "iterator")]
		Iterator,
		// Token: 0x040004AF RID: 1199
		[EnumMember(Value = "generator")]
		Generator,
		// Token: 0x040004B0 RID: 1200
		[EnumMember(Value = "error")]
		Error,
		// Token: 0x040004B1 RID: 1201
		[EnumMember(Value = "proxy")]
		Proxy,
		// Token: 0x040004B2 RID: 1202
		[EnumMember(Value = "promise")]
		Promise,
		// Token: 0x040004B3 RID: 1203
		[EnumMember(Value = "typedarray")]
		Typedarray,
		// Token: 0x040004B4 RID: 1204
		[EnumMember(Value = "arraybuffer")]
		Arraybuffer,
		// Token: 0x040004B5 RID: 1205
		[EnumMember(Value = "dataview")]
		Dataview,
		// Token: 0x040004B6 RID: 1206
		[EnumMember(Value = "webassemblymemory")]
		Webassemblymemory,
		// Token: 0x040004B7 RID: 1207
		[EnumMember(Value = "wasmvalue")]
		Wasmvalue
	}
}
