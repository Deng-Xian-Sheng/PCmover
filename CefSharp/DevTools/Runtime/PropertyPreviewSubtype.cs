using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000135 RID: 309
	public enum PropertyPreviewSubtype
	{
		// Token: 0x040004F1 RID: 1265
		[EnumMember(Value = "array")]
		Array,
		// Token: 0x040004F2 RID: 1266
		[EnumMember(Value = "null")]
		Null,
		// Token: 0x040004F3 RID: 1267
		[EnumMember(Value = "node")]
		Node,
		// Token: 0x040004F4 RID: 1268
		[EnumMember(Value = "regexp")]
		Regexp,
		// Token: 0x040004F5 RID: 1269
		[EnumMember(Value = "date")]
		Date,
		// Token: 0x040004F6 RID: 1270
		[EnumMember(Value = "map")]
		Map,
		// Token: 0x040004F7 RID: 1271
		[EnumMember(Value = "set")]
		Set,
		// Token: 0x040004F8 RID: 1272
		[EnumMember(Value = "weakmap")]
		Weakmap,
		// Token: 0x040004F9 RID: 1273
		[EnumMember(Value = "weakset")]
		Weakset,
		// Token: 0x040004FA RID: 1274
		[EnumMember(Value = "iterator")]
		Iterator,
		// Token: 0x040004FB RID: 1275
		[EnumMember(Value = "generator")]
		Generator,
		// Token: 0x040004FC RID: 1276
		[EnumMember(Value = "error")]
		Error,
		// Token: 0x040004FD RID: 1277
		[EnumMember(Value = "proxy")]
		Proxy,
		// Token: 0x040004FE RID: 1278
		[EnumMember(Value = "promise")]
		Promise,
		// Token: 0x040004FF RID: 1279
		[EnumMember(Value = "typedarray")]
		Typedarray,
		// Token: 0x04000500 RID: 1280
		[EnumMember(Value = "arraybuffer")]
		Arraybuffer,
		// Token: 0x04000501 RID: 1281
		[EnumMember(Value = "dataview")]
		Dataview,
		// Token: 0x04000502 RID: 1282
		[EnumMember(Value = "webassemblymemory")]
		Webassemblymemory,
		// Token: 0x04000503 RID: 1283
		[EnumMember(Value = "wasmvalue")]
		Wasmvalue
	}
}
