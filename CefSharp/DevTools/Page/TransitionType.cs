using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000241 RID: 577
	public enum TransitionType
	{
		// Token: 0x040008C8 RID: 2248
		[EnumMember(Value = "link")]
		Link,
		// Token: 0x040008C9 RID: 2249
		[EnumMember(Value = "typed")]
		Typed,
		// Token: 0x040008CA RID: 2250
		[EnumMember(Value = "address_bar")]
		AddressBar,
		// Token: 0x040008CB RID: 2251
		[EnumMember(Value = "auto_bookmark")]
		AutoBookmark,
		// Token: 0x040008CC RID: 2252
		[EnumMember(Value = "auto_subframe")]
		AutoSubframe,
		// Token: 0x040008CD RID: 2253
		[EnumMember(Value = "manual_subframe")]
		ManualSubframe,
		// Token: 0x040008CE RID: 2254
		[EnumMember(Value = "generated")]
		Generated,
		// Token: 0x040008CF RID: 2255
		[EnumMember(Value = "auto_toplevel")]
		AutoToplevel,
		// Token: 0x040008D0 RID: 2256
		[EnumMember(Value = "form_submit")]
		FormSubmit,
		// Token: 0x040008D1 RID: 2257
		[EnumMember(Value = "reload")]
		Reload,
		// Token: 0x040008D2 RID: 2258
		[EnumMember(Value = "keyword")]
		Keyword,
		// Token: 0x040008D3 RID: 2259
		[EnumMember(Value = "keyword_generated")]
		KeywordGenerated,
		// Token: 0x040008D4 RID: 2260
		[EnumMember(Value = "other")]
		Other
	}
}
