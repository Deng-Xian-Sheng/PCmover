using System;

namespace System.Threading
{
	// Token: 0x02000539 RID: 1337
	internal static class TimeoutHelper
	{
		// Token: 0x06003EBE RID: 16062 RVA: 0x000E997B File Offset: 0x000E7B7B
		public static uint GetTime()
		{
			return (uint)Environment.TickCount;
		}

		// Token: 0x06003EBF RID: 16063 RVA: 0x000E9984 File Offset: 0x000E7B84
		public static int UpdateTimeOut(uint startTime, int originalWaitMillisecondsTimeout)
		{
			uint num = TimeoutHelper.GetTime() - startTime;
			if (num > 2147483647U)
			{
				return 0;
			}
			int num2 = originalWaitMillisecondsTimeout - (int)num;
			if (num2 <= 0)
			{
				return 0;
			}
			return num2;
		}
	}
}
