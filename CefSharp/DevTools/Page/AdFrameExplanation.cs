using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200022E RID: 558
	public enum AdFrameExplanation
	{
		// Token: 0x0400082E RID: 2094
		[EnumMember(Value = "ParentIsAd")]
		ParentIsAd,
		// Token: 0x0400082F RID: 2095
		[EnumMember(Value = "CreatedByAdScript")]
		CreatedByAdScript,
		// Token: 0x04000830 RID: 2096
		[EnumMember(Value = "MatchedBlockingRule")]
		MatchedBlockingRule
	}
}
