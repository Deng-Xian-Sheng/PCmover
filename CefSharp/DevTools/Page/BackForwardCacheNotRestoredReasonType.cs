using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000255 RID: 597
	public enum BackForwardCacheNotRestoredReasonType
	{
		// Token: 0x040009A4 RID: 2468
		[EnumMember(Value = "SupportPending")]
		SupportPending,
		// Token: 0x040009A5 RID: 2469
		[EnumMember(Value = "PageSupportNeeded")]
		PageSupportNeeded,
		// Token: 0x040009A6 RID: 2470
		[EnumMember(Value = "Circumstantial")]
		Circumstantial
	}
}
