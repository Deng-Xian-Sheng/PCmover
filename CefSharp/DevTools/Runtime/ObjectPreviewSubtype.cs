using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000132 RID: 306
	public enum ObjectPreviewSubtype
	{
		// Token: 0x040004CD RID: 1229
		[EnumMember(Value = "array")]
		Array,
		// Token: 0x040004CE RID: 1230
		[EnumMember(Value = "null")]
		Null,
		// Token: 0x040004CF RID: 1231
		[EnumMember(Value = "node")]
		Node,
		// Token: 0x040004D0 RID: 1232
		[EnumMember(Value = "regexp")]
		Regexp,
		// Token: 0x040004D1 RID: 1233
		[EnumMember(Value = "date")]
		Date,
		// Token: 0x040004D2 RID: 1234
		[EnumMember(Value = "map")]
		Map,
		// Token: 0x040004D3 RID: 1235
		[EnumMember(Value = "set")]
		Set,
		// Token: 0x040004D4 RID: 1236
		[EnumMember(Value = "weakmap")]
		Weakmap,
		// Token: 0x040004D5 RID: 1237
		[EnumMember(Value = "weakset")]
		Weakset,
		// Token: 0x040004D6 RID: 1238
		[EnumMember(Value = "iterator")]
		Iterator,
		// Token: 0x040004D7 RID: 1239
		[EnumMember(Value = "generator")]
		Generator,
		// Token: 0x040004D8 RID: 1240
		[EnumMember(Value = "error")]
		Error,
		// Token: 0x040004D9 RID: 1241
		[EnumMember(Value = "proxy")]
		Proxy,
		// Token: 0x040004DA RID: 1242
		[EnumMember(Value = "promise")]
		Promise,
		// Token: 0x040004DB RID: 1243
		[EnumMember(Value = "typedarray")]
		Typedarray,
		// Token: 0x040004DC RID: 1244
		[EnumMember(Value = "arraybuffer")]
		Arraybuffer,
		// Token: 0x040004DD RID: 1245
		[EnumMember(Value = "dataview")]
		Dataview,
		// Token: 0x040004DE RID: 1246
		[EnumMember(Value = "webassemblymemory")]
		Webassemblymemory,
		// Token: 0x040004DF RID: 1247
		[EnumMember(Value = "wasmvalue")]
		Wasmvalue
	}
}
