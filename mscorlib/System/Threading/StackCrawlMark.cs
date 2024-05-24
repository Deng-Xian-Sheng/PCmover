using System;

namespace System.Threading
{
	// Token: 0x02000516 RID: 1302
	[Serializable]
	internal enum StackCrawlMark
	{
		// Token: 0x040019F5 RID: 6645
		LookForMe,
		// Token: 0x040019F6 RID: 6646
		LookForMyCaller,
		// Token: 0x040019F7 RID: 6647
		LookForMyCallersCaller,
		// Token: 0x040019F8 RID: 6648
		LookForThread
	}
}
