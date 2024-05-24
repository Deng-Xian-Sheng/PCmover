using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000558 RID: 1368
	internal class ParallelLoopStateFlags32 : ParallelLoopStateFlags
	{
		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x0600405F RID: 16479 RVA: 0x000F034A File Offset: 0x000EE54A
		internal int LowestBreakIteration
		{
			get
			{
				return this.m_lowestBreakIteration;
			}
		}

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x06004060 RID: 16480 RVA: 0x000F0354 File Offset: 0x000EE554
		internal long? NullableLowestBreakIteration
		{
			get
			{
				if (this.m_lowestBreakIteration == 2147483647)
				{
					return null;
				}
				long value = (long)this.m_lowestBreakIteration;
				if (IntPtr.Size >= 8)
				{
					return new long?(value);
				}
				return new long?(Interlocked.Read(ref value));
			}
		}

		// Token: 0x06004061 RID: 16481 RVA: 0x000F03A0 File Offset: 0x000EE5A0
		internal bool ShouldExitLoop(int CallerIteration)
		{
			int loopStateFlags = base.LoopStateFlags;
			return loopStateFlags != ParallelLoopStateFlags.PLS_NONE && ((loopStateFlags & (ParallelLoopStateFlags.PLS_EXCEPTIONAL | ParallelLoopStateFlags.PLS_STOPPED | ParallelLoopStateFlags.PLS_CANCELED)) != 0 || ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0 && CallerIteration > this.LowestBreakIteration));
		}

		// Token: 0x06004062 RID: 16482 RVA: 0x000F03EC File Offset: 0x000EE5EC
		internal bool ShouldExitLoop()
		{
			int loopStateFlags = base.LoopStateFlags;
			return loopStateFlags != ParallelLoopStateFlags.PLS_NONE && (loopStateFlags & (ParallelLoopStateFlags.PLS_EXCEPTIONAL | ParallelLoopStateFlags.PLS_CANCELED)) != 0;
		}

		// Token: 0x04001AE2 RID: 6882
		internal volatile int m_lowestBreakIteration = int.MaxValue;
	}
}
