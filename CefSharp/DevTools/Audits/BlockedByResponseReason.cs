using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000413 RID: 1043
	public enum BlockedByResponseReason
	{
		// Token: 0x04001043 RID: 4163
		[EnumMember(Value = "CoepFrameResourceNeedsCoepHeader")]
		CoepFrameResourceNeedsCoepHeader,
		// Token: 0x04001044 RID: 4164
		[EnumMember(Value = "CoopSandboxedIFrameCannotNavigateToCoopPage")]
		CoopSandboxedIFrameCannotNavigateToCoopPage,
		// Token: 0x04001045 RID: 4165
		[EnumMember(Value = "CorpNotSameOrigin")]
		CorpNotSameOrigin,
		// Token: 0x04001046 RID: 4166
		[EnumMember(Value = "CorpNotSameOriginAfterDefaultedToSameOriginByCoep")]
		CorpNotSameOriginAfterDefaultedToSameOriginByCoep,
		// Token: 0x04001047 RID: 4167
		[EnumMember(Value = "CorpNotSameSite")]
		CorpNotSameSite
	}
}
