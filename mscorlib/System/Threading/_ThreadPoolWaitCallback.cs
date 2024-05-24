using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000520 RID: 1312
	internal static class _ThreadPoolWaitCallback
	{
		// Token: 0x06003DDD RID: 15837 RVA: 0x000E7439 File Offset: 0x000E5639
		[SecurityCritical]
		internal static bool PerformWaitCallback()
		{
			return ThreadPoolWorkQueue.Dispatch();
		}
	}
}
