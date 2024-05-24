using System;

namespace System.Threading
{
	// Token: 0x02000538 RID: 1336
	internal static class PlatformHelper
	{
		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x06003EBC RID: 16060 RVA: 0x000E992C File Offset: 0x000E7B2C
		internal static int ProcessorCount
		{
			get
			{
				int tickCount = Environment.TickCount;
				int num = PlatformHelper.s_processorCount;
				if (num == 0 || tickCount - PlatformHelper.s_lastProcessorCountRefreshTicks >= 30000)
				{
					num = (PlatformHelper.s_processorCount = Environment.ProcessorCount);
					PlatformHelper.s_lastProcessorCountRefreshTicks = tickCount;
				}
				return num;
			}
		}

		// Token: 0x17000945 RID: 2373
		// (get) Token: 0x06003EBD RID: 16061 RVA: 0x000E9971 File Offset: 0x000E7B71
		internal static bool IsSingleProcessor
		{
			get
			{
				return PlatformHelper.ProcessorCount == 1;
			}
		}

		// Token: 0x04001A5F RID: 6751
		private const int PROCESSOR_COUNT_REFRESH_INTERVAL_MS = 30000;

		// Token: 0x04001A60 RID: 6752
		private static volatile int s_processorCount;

		// Token: 0x04001A61 RID: 6753
		private static volatile int s_lastProcessorCountRefreshTicks;
	}
}
