using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002BA RID: 698
	internal static class KdfWorkLimiter
	{
		// Token: 0x060024F3 RID: 9459 RVA: 0x00085AE4 File Offset: 0x00083CE4
		internal static void SetIterationLimit(ulong workLimit)
		{
			KdfWorkLimiter.t_State = new KdfWorkLimiter.State
			{
				RemainingAllowedWork = workLimit
			};
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x00085B04 File Offset: 0x00083D04
		internal static bool WasWorkLimitExceeded()
		{
			return KdfWorkLimiter.t_State.WorkLimitWasExceeded;
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x00085B10 File Offset: 0x00083D10
		internal static void ResetIterationLimit()
		{
			KdfWorkLimiter.t_State = null;
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x00085B18 File Offset: 0x00083D18
		internal static void RecordIterations(int workCount)
		{
			KdfWorkLimiter.RecordIterations((long)workCount);
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x00085B24 File Offset: 0x00083D24
		internal static void RecordIterations(long workCount)
		{
			KdfWorkLimiter.State state = KdfWorkLimiter.t_State;
			bool flag = false;
			checked
			{
				try
				{
					if (!state.WorkLimitWasExceeded)
					{
						state.RemainingAllowedWork -= (ulong)workCount;
						flag = true;
					}
				}
				finally
				{
					if (!flag)
					{
						state.RemainingAllowedWork = 0UL;
						state.WorkLimitWasExceeded = true;
						throw new CryptographicException();
					}
				}
			}
		}

		// Token: 0x04000DC6 RID: 3526
		[ThreadStatic]
		private static KdfWorkLimiter.State t_State;

		// Token: 0x02000B4E RID: 2894
		private sealed class State
		{
			// Token: 0x040033D7 RID: 13271
			internal ulong RemainingAllowedWork;

			// Token: 0x040033D8 RID: 13272
			internal bool WorkLimitWasExceeded;
		}
	}
}
