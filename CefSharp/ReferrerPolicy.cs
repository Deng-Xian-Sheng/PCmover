using System;

namespace CefSharp
{
	// Token: 0x0200003C RID: 60
	public enum ReferrerPolicy
	{
		// Token: 0x040001EF RID: 495
		ClearReferrerOnTransitionFromSecureToInsecure,
		// Token: 0x040001F0 RID: 496
		Default = 0,
		// Token: 0x040001F1 RID: 497
		ReduceReferrerGranularityOnTransitionCrossOrigin,
		// Token: 0x040001F2 RID: 498
		OriginOnlyOnTransitionCrossOrigin,
		// Token: 0x040001F3 RID: 499
		NeverClearReferrer,
		// Token: 0x040001F4 RID: 500
		Origin,
		// Token: 0x040001F5 RID: 501
		ClearReferrerOnTransitionCrossOrigin,
		// Token: 0x040001F6 RID: 502
		OriginClearOnTransitionFromSecureToInsecure,
		// Token: 0x040001F7 RID: 503
		NoReferrer,
		// Token: 0x040001F8 RID: 504
		LastValue = 7
	}
}
