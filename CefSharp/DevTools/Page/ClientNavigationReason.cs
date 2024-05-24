using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200024D RID: 589
	public enum ClientNavigationReason
	{
		// Token: 0x04000908 RID: 2312
		[EnumMember(Value = "formSubmissionGet")]
		FormSubmissionGet,
		// Token: 0x04000909 RID: 2313
		[EnumMember(Value = "formSubmissionPost")]
		FormSubmissionPost,
		// Token: 0x0400090A RID: 2314
		[EnumMember(Value = "httpHeaderRefresh")]
		HttpHeaderRefresh,
		// Token: 0x0400090B RID: 2315
		[EnumMember(Value = "scriptInitiated")]
		ScriptInitiated,
		// Token: 0x0400090C RID: 2316
		[EnumMember(Value = "metaTagRefresh")]
		MetaTagRefresh,
		// Token: 0x0400090D RID: 2317
		[EnumMember(Value = "pageBlockInterstitial")]
		PageBlockInterstitial,
		// Token: 0x0400090E RID: 2318
		[EnumMember(Value = "reload")]
		Reload,
		// Token: 0x0400090F RID: 2319
		[EnumMember(Value = "anchorClick")]
		AnchorClick
	}
}
