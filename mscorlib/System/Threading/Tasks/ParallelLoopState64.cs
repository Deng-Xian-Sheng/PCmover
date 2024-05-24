using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000556 RID: 1366
	internal class ParallelLoopState64 : ParallelLoopState
	{
		// Token: 0x06004051 RID: 16465 RVA: 0x000F0210 File Offset: 0x000EE410
		internal ParallelLoopState64(ParallelLoopStateFlags64 sharedParallelStateFlags) : base(sharedParallelStateFlags)
		{
			this.m_sharedParallelStateFlags = sharedParallelStateFlags;
		}

		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x06004052 RID: 16466 RVA: 0x000F0220 File Offset: 0x000EE420
		// (set) Token: 0x06004053 RID: 16467 RVA: 0x000F0228 File Offset: 0x000EE428
		internal long CurrentIteration
		{
			get
			{
				return this.m_currentIteration;
			}
			set
			{
				this.m_currentIteration = value;
			}
		}

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x06004054 RID: 16468 RVA: 0x000F0231 File Offset: 0x000EE431
		internal override bool InternalShouldExitCurrentIteration
		{
			get
			{
				return this.m_sharedParallelStateFlags.ShouldExitLoop(this.CurrentIteration);
			}
		}

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x06004055 RID: 16469 RVA: 0x000F0244 File Offset: 0x000EE444
		internal override long? InternalLowestBreakIteration
		{
			get
			{
				return this.m_sharedParallelStateFlags.NullableLowestBreakIteration;
			}
		}

		// Token: 0x06004056 RID: 16470 RVA: 0x000F0251 File Offset: 0x000EE451
		internal override void InternalBreak()
		{
			ParallelLoopState.Break(this.CurrentIteration, this.m_sharedParallelStateFlags);
		}

		// Token: 0x04001ADA RID: 6874
		private ParallelLoopStateFlags64 m_sharedParallelStateFlags;

		// Token: 0x04001ADB RID: 6875
		private long m_currentIteration;
	}
}
