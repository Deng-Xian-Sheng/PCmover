using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B4 RID: 692
	public enum BlockedReason
	{
		// Token: 0x04000B0B RID: 2827
		[EnumMember(Value = "other")]
		Other,
		// Token: 0x04000B0C RID: 2828
		[EnumMember(Value = "csp")]
		Csp,
		// Token: 0x04000B0D RID: 2829
		[EnumMember(Value = "mixed-content")]
		MixedContent,
		// Token: 0x04000B0E RID: 2830
		[EnumMember(Value = "origin")]
		Origin,
		// Token: 0x04000B0F RID: 2831
		[EnumMember(Value = "inspector")]
		Inspector,
		// Token: 0x04000B10 RID: 2832
		[EnumMember(Value = "subresource-filter")]
		SubresourceFilter,
		// Token: 0x04000B11 RID: 2833
		[EnumMember(Value = "content-type")]
		ContentType,
		// Token: 0x04000B12 RID: 2834
		[EnumMember(Value = "coep-frame-resource-needs-coep-header")]
		CoepFrameResourceNeedsCoepHeader,
		// Token: 0x04000B13 RID: 2835
		[EnumMember(Value = "coop-sandboxed-iframe-cannot-navigate-to-coop-page")]
		CoopSandboxedIframeCannotNavigateToCoopPage,
		// Token: 0x04000B14 RID: 2836
		[EnumMember(Value = "corp-not-same-origin")]
		CorpNotSameOrigin,
		// Token: 0x04000B15 RID: 2837
		[EnumMember(Value = "corp-not-same-origin-after-defaulted-to-same-origin-by-coep")]
		CorpNotSameOriginAfterDefaultedToSameOriginByCoep,
		// Token: 0x04000B16 RID: 2838
		[EnumMember(Value = "corp-not-same-site")]
		CorpNotSameSite
	}
}
