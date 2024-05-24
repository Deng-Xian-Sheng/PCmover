using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200042C RID: 1068
	public enum InspectorIssueCode
	{
		// Token: 0x040010C1 RID: 4289
		[EnumMember(Value = "SameSiteCookieIssue")]
		SameSiteCookieIssue,
		// Token: 0x040010C2 RID: 4290
		[EnumMember(Value = "MixedContentIssue")]
		MixedContentIssue,
		// Token: 0x040010C3 RID: 4291
		[EnumMember(Value = "BlockedByResponseIssue")]
		BlockedByResponseIssue,
		// Token: 0x040010C4 RID: 4292
		[EnumMember(Value = "HeavyAdIssue")]
		HeavyAdIssue,
		// Token: 0x040010C5 RID: 4293
		[EnumMember(Value = "ContentSecurityPolicyIssue")]
		ContentSecurityPolicyIssue,
		// Token: 0x040010C6 RID: 4294
		[EnumMember(Value = "SharedArrayBufferIssue")]
		SharedArrayBufferIssue,
		// Token: 0x040010C7 RID: 4295
		[EnumMember(Value = "TrustedWebActivityIssue")]
		TrustedWebActivityIssue,
		// Token: 0x040010C8 RID: 4296
		[EnumMember(Value = "LowTextContrastIssue")]
		LowTextContrastIssue,
		// Token: 0x040010C9 RID: 4297
		[EnumMember(Value = "CorsIssue")]
		CorsIssue,
		// Token: 0x040010CA RID: 4298
		[EnumMember(Value = "AttributionReportingIssue")]
		AttributionReportingIssue,
		// Token: 0x040010CB RID: 4299
		[EnumMember(Value = "QuirksModeIssue")]
		QuirksModeIssue,
		// Token: 0x040010CC RID: 4300
		[EnumMember(Value = "NavigatorUserAgentIssue")]
		NavigatorUserAgentIssue,
		// Token: 0x040010CD RID: 4301
		[EnumMember(Value = "GenericIssue")]
		GenericIssue,
		// Token: 0x040010CE RID: 4302
		[EnumMember(Value = "DeprecationIssue")]
		DeprecationIssue,
		// Token: 0x040010CF RID: 4303
		[EnumMember(Value = "ClientHintIssue")]
		ClientHintIssue,
		// Token: 0x040010D0 RID: 4304
		[EnumMember(Value = "FederatedAuthRequestIssue")]
		FederatedAuthRequestIssue
	}
}
