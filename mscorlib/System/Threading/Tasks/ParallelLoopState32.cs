using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000555 RID: 1365
	internal class ParallelLoopState32 : ParallelLoopState
	{
		// Token: 0x0600404B RID: 16459 RVA: 0x000F01BC File Offset: 0x000EE3BC
		internal ParallelLoopState32(ParallelLoopStateFlags32 sharedParallelStateFlags) : base(sharedParallelStateFlags)
		{
			this.m_sharedParallelStateFlags = sharedParallelStateFlags;
		}

		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x0600404C RID: 16460 RVA: 0x000F01CC File Offset: 0x000EE3CC
		// (set) Token: 0x0600404D RID: 16461 RVA: 0x000F01D4 File Offset: 0x000EE3D4
		internal int CurrentIteration
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

		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x0600404E RID: 16462 RVA: 0x000F01DD File Offset: 0x000EE3DD
		internal override bool InternalShouldExitCurrentIteration
		{
			get
			{
				return this.m_sharedParallelStateFlags.ShouldExitLoop(this.CurrentIteration);
			}
		}

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x0600404F RID: 16463 RVA: 0x000F01F0 File Offset: 0x000EE3F0
		internal override long? InternalLowestBreakIteration
		{
			get
			{
				return this.m_sharedParallelStateFlags.NullableLowestBreakIteration;
			}
		}

		// Token: 0x06004050 RID: 16464 RVA: 0x000F01FD File Offset: 0x000EE3FD
		internal override void InternalBreak()
		{
			ParallelLoopState.Break(this.CurrentIteration, this.m_sharedParallelStateFlags);
		}

		// Token: 0x04001AD8 RID: 6872
		private ParallelLoopStateFlags32 m_sharedParallelStateFlags;

		// Token: 0x04001AD9 RID: 6873
		private int m_currentIteration;
	}
}
