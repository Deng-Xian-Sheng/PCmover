using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000410 RID: 1040
	public enum MixedContentResolutionStatus
	{
		// Token: 0x0400101D RID: 4125
		[EnumMember(Value = "MixedContentBlocked")]
		MixedContentBlocked,
		// Token: 0x0400101E RID: 4126
		[EnumMember(Value = "MixedContentAutomaticallyUpgraded")]
		MixedContentAutomaticallyUpgraded,
		// Token: 0x0400101F RID: 4127
		[EnumMember(Value = "MixedContentWarning")]
		MixedContentWarning
	}
}
