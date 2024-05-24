using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Log
{
	// Token: 0x02000317 RID: 791
	public enum LogEntrySource
	{
		// Token: 0x04000CD0 RID: 3280
		[EnumMember(Value = "xml")]
		Xml,
		// Token: 0x04000CD1 RID: 3281
		[EnumMember(Value = "javascript")]
		Javascript,
		// Token: 0x04000CD2 RID: 3282
		[EnumMember(Value = "network")]
		Network,
		// Token: 0x04000CD3 RID: 3283
		[EnumMember(Value = "storage")]
		Storage,
		// Token: 0x04000CD4 RID: 3284
		[EnumMember(Value = "appcache")]
		Appcache,
		// Token: 0x04000CD5 RID: 3285
		[EnumMember(Value = "rendering")]
		Rendering,
		// Token: 0x04000CD6 RID: 3286
		[EnumMember(Value = "security")]
		Security,
		// Token: 0x04000CD7 RID: 3287
		[EnumMember(Value = "deprecation")]
		Deprecation,
		// Token: 0x04000CD8 RID: 3288
		[EnumMember(Value = "worker")]
		Worker,
		// Token: 0x04000CD9 RID: 3289
		[EnumMember(Value = "violation")]
		Violation,
		// Token: 0x04000CDA RID: 3290
		[EnumMember(Value = "intervention")]
		Intervention,
		// Token: 0x04000CDB RID: 3291
		[EnumMember(Value = "recommendation")]
		Recommendation,
		// Token: 0x04000CDC RID: 3292
		[EnumMember(Value = "other")]
		Other
	}
}
