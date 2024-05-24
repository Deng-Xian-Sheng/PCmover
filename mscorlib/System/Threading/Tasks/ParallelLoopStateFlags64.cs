using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000559 RID: 1369
	internal class ParallelLoopStateFlags64 : ParallelLoopStateFlags
	{
		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x06004064 RID: 16484 RVA: 0x000F042F File Offset: 0x000EE62F
		internal long LowestBreakIteration
		{
			get
			{
				if (IntPtr.Size >= 8)
				{
					return this.m_lowestBreakIteration;
				}
				return Interlocked.Read(ref this.m_lowestBreakIteration);
			}
		}

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x06004065 RID: 16485 RVA: 0x000F044C File Offset: 0x000EE64C
		internal long? NullableLowestBreakIteration
		{
			get
			{
				if (this.m_lowestBreakIteration == 9223372036854775807L)
				{
					return null;
				}
				if (IntPtr.Size >= 8)
				{
					return new long?(this.m_lowestBreakIteration);
				}
				return new long?(Interlocked.Read(ref this.m_lowestBreakIteration));
			}
		}

		// Token: 0x06004066 RID: 16486 RVA: 0x000F0498 File Offset: 0x000EE698
		internal bool ShouldExitLoop(long CallerIteration)
		{
			int loopStateFlags = base.LoopStateFlags;
			return loopStateFlags != ParallelLoopStateFlags.PLS_NONE && ((loopStateFlags & (ParallelLoopStateFlags.PLS_EXCEPTIONAL | ParallelLoopStateFlags.PLS_STOPPED | ParallelLoopStateFlags.PLS_CANCELED)) != 0 || ((loopStateFlags & ParallelLoopStateFlags.PLS_BROKEN) != 0 && CallerIteration > this.LowestBreakIteration));
		}

		// Token: 0x06004067 RID: 16487 RVA: 0x000F04E4 File Offset: 0x000EE6E4
		internal bool ShouldExitLoop()
		{
			int loopStateFlags = base.LoopStateFlags;
			return loopStateFlags != ParallelLoopStateFlags.PLS_NONE && (loopStateFlags & (ParallelLoopStateFlags.PLS_EXCEPTIONAL | ParallelLoopStateFlags.PLS_CANCELED)) != 0;
		}

		// Token: 0x04001AE3 RID: 6883
		internal long m_lowestBreakIteration = long.MaxValue;
	}
}
