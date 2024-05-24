using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000557 RID: 1367
	internal class ParallelLoopStateFlags
	{
		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x06004057 RID: 16471 RVA: 0x000F0264 File Offset: 0x000EE464
		internal int LoopStateFlags
		{
			get
			{
				return this.m_LoopStateFlags;
			}
		}

		// Token: 0x06004058 RID: 16472 RVA: 0x000F0270 File Offset: 0x000EE470
		internal bool AtomicLoopStateUpdate(int newState, int illegalStates)
		{
			int num = 0;
			return this.AtomicLoopStateUpdate(newState, illegalStates, ref num);
		}

		// Token: 0x06004059 RID: 16473 RVA: 0x000F028C File Offset: 0x000EE48C
		internal bool AtomicLoopStateUpdate(int newState, int illegalStates, ref int oldState)
		{
			SpinWait spinWait = default(SpinWait);
			for (;;)
			{
				oldState = this.m_LoopStateFlags;
				if ((oldState & illegalStates) != 0)
				{
					break;
				}
				if (Interlocked.CompareExchange(ref this.m_LoopStateFlags, oldState | newState, oldState) == oldState)
				{
					return true;
				}
				spinWait.SpinOnce();
			}
			return false;
		}

		// Token: 0x0600405A RID: 16474 RVA: 0x000F02D2 File Offset: 0x000EE4D2
		internal void SetExceptional()
		{
			this.AtomicLoopStateUpdate(ParallelLoopStateFlags.PLS_EXCEPTIONAL, ParallelLoopStateFlags.PLS_NONE);
		}

		// Token: 0x0600405B RID: 16475 RVA: 0x000F02E5 File Offset: 0x000EE4E5
		internal void Stop()
		{
			if (!this.AtomicLoopStateUpdate(ParallelLoopStateFlags.PLS_STOPPED, ParallelLoopStateFlags.PLS_BROKEN))
			{
				throw new InvalidOperationException(Environment.GetResourceString("ParallelState_Stop_InvalidOperationException_StopAfterBreak"));
			}
		}

		// Token: 0x0600405C RID: 16476 RVA: 0x000F0309 File Offset: 0x000EE509
		internal bool Cancel()
		{
			return this.AtomicLoopStateUpdate(ParallelLoopStateFlags.PLS_CANCELED, ParallelLoopStateFlags.PLS_NONE);
		}

		// Token: 0x04001ADC RID: 6876
		internal static int PLS_NONE;

		// Token: 0x04001ADD RID: 6877
		internal static int PLS_EXCEPTIONAL = 1;

		// Token: 0x04001ADE RID: 6878
		internal static int PLS_BROKEN = 2;

		// Token: 0x04001ADF RID: 6879
		internal static int PLS_STOPPED = 4;

		// Token: 0x04001AE0 RID: 6880
		internal static int PLS_CANCELED = 8;

		// Token: 0x04001AE1 RID: 6881
		private volatile int m_LoopStateFlags = ParallelLoopStateFlags.PLS_NONE;
	}
}
