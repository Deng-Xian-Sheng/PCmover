using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000519 RID: 1305
	internal static class ThreadPoolGlobals
	{
		// Token: 0x040019F9 RID: 6649
		public static uint tpQuantum = 30U;

		// Token: 0x040019FA RID: 6650
		public static int processorCount = Environment.ProcessorCount;

		// Token: 0x040019FB RID: 6651
		public static bool tpHosted = ThreadPool.IsThreadPoolHosted();

		// Token: 0x040019FC RID: 6652
		public static volatile bool vmTpInitialized;

		// Token: 0x040019FD RID: 6653
		public static bool enableWorkerTracking;

		// Token: 0x040019FE RID: 6654
		[SecurityCritical]
		public static ThreadPoolWorkQueue workQueue = new ThreadPoolWorkQueue();
	}
}
