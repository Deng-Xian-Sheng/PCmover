using System;

namespace System.Threading.Tasks
{
	// Token: 0x0200055A RID: 1370
	[__DynamicallyInvokable]
	public struct ParallelLoopResult
	{
		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x06004069 RID: 16489 RVA: 0x000F0529 File Offset: 0x000EE729
		[__DynamicallyInvokable]
		public bool IsCompleted
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_completed;
			}
		}

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x0600406A RID: 16490 RVA: 0x000F0531 File Offset: 0x000EE731
		[__DynamicallyInvokable]
		public long? LowestBreakIteration
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_lowestBreakIteration;
			}
		}

		// Token: 0x04001AE4 RID: 6884
		internal bool m_completed;

		// Token: 0x04001AE5 RID: 6885
		internal long? m_lowestBreakIteration;
	}
}
