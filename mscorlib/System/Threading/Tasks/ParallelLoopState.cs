using System;
using System.Diagnostics;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x02000554 RID: 1364
	[DebuggerDisplay("ShouldExitCurrentIteration = {ShouldExitCurrentIteration}")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class ParallelLoopState
	{
		// Token: 0x0600403F RID: 16447 RVA: 0x000F001C File Offset: 0x000EE21C
		internal ParallelLoopState(ParallelLoopStateFlags fbase)
		{
			this.m_flagsBase = fbase;
		}

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x06004040 RID: 16448 RVA: 0x000F002B File Offset: 0x000EE22B
		internal virtual bool InternalShouldExitCurrentIteration
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("ParallelState_NotSupportedException_UnsupportedMethod"));
			}
		}

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x06004041 RID: 16449 RVA: 0x000F003C File Offset: 0x000EE23C
		[__DynamicallyInvokable]
		public bool ShouldExitCurrentIteration
		{
			[__DynamicallyInvokable]
			get
			{
				return this.InternalShouldExitCurrentIteration;
			}
		}

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x06004042 RID: 16450 RVA: 0x000F0044 File Offset: 0x000EE244
		[__DynamicallyInvokable]
		public bool IsStopped
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.m_flagsBase.LoopStateFlags & ParallelLoopStateFlags.PLS_STOPPED) != 0;
			}
		}

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x06004043 RID: 16451 RVA: 0x000F005A File Offset: 0x000EE25A
		[__DynamicallyInvokable]
		public bool IsExceptional
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.m_flagsBase.LoopStateFlags & ParallelLoopStateFlags.PLS_EXCEPTIONAL) != 0;
			}
		}

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x06004044 RID: 16452 RVA: 0x000F0070 File Offset: 0x000EE270
		internal virtual long? InternalLowestBreakIteration
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("ParallelState_NotSupportedException_UnsupportedMethod"));
			}
		}

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x06004045 RID: 16453 RVA: 0x000F0081 File Offset: 0x000EE281
		[__DynamicallyInvokable]
		public long? LowestBreakIteration
		{
			[__DynamicallyInvokable]
			get
			{
				return this.InternalLowestBreakIteration;
			}
		}

		// Token: 0x06004046 RID: 16454 RVA: 0x000F0089 File Offset: 0x000EE289
		[__DynamicallyInvokable]
		public void Stop()
		{
			this.m_flagsBase.Stop();
		}

		// Token: 0x06004047 RID: 16455 RVA: 0x000F0096 File Offset: 0x000EE296
		internal virtual void InternalBreak()
		{
			throw new NotSupportedException(Environment.GetResourceString("ParallelState_NotSupportedException_UnsupportedMethod"));
		}

		// Token: 0x06004048 RID: 16456 RVA: 0x000F00A7 File Offset: 0x000EE2A7
		[__DynamicallyInvokable]
		public void Break()
		{
			this.InternalBreak();
		}

		// Token: 0x06004049 RID: 16457 RVA: 0x000F00B0 File Offset: 0x000EE2B0
		internal static void Break(int iteration, ParallelLoopStateFlags32 pflags)
		{
			int pls_NONE = ParallelLoopStateFlags.PLS_NONE;
			if (pflags.AtomicLoopStateUpdate(ParallelLoopStateFlags.PLS_BROKEN, ParallelLoopStateFlags.PLS_STOPPED | ParallelLoopStateFlags.PLS_EXCEPTIONAL | ParallelLoopStateFlags.PLS_CANCELED, ref pls_NONE))
			{
				int lowestBreakIteration = pflags.m_lowestBreakIteration;
				if (iteration < lowestBreakIteration)
				{
					SpinWait spinWait = default(SpinWait);
					while (Interlocked.CompareExchange(ref pflags.m_lowestBreakIteration, iteration, lowestBreakIteration) != lowestBreakIteration)
					{
						spinWait.SpinOnce();
						lowestBreakIteration = pflags.m_lowestBreakIteration;
						if (iteration > lowestBreakIteration)
						{
							break;
						}
					}
				}
				return;
			}
			if ((pls_NONE & ParallelLoopStateFlags.PLS_STOPPED) != 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("ParallelState_Break_InvalidOperationException_BreakAfterStop"));
			}
		}

		// Token: 0x0600404A RID: 16458 RVA: 0x000F0138 File Offset: 0x000EE338
		internal static void Break(long iteration, ParallelLoopStateFlags64 pflags)
		{
			int pls_NONE = ParallelLoopStateFlags.PLS_NONE;
			if (pflags.AtomicLoopStateUpdate(ParallelLoopStateFlags.PLS_BROKEN, ParallelLoopStateFlags.PLS_STOPPED | ParallelLoopStateFlags.PLS_EXCEPTIONAL | ParallelLoopStateFlags.PLS_CANCELED, ref pls_NONE))
			{
				long lowestBreakIteration = pflags.LowestBreakIteration;
				if (iteration < lowestBreakIteration)
				{
					SpinWait spinWait = default(SpinWait);
					while (Interlocked.CompareExchange(ref pflags.m_lowestBreakIteration, iteration, lowestBreakIteration) != lowestBreakIteration)
					{
						spinWait.SpinOnce();
						lowestBreakIteration = pflags.LowestBreakIteration;
						if (iteration > lowestBreakIteration)
						{
							break;
						}
					}
				}
				return;
			}
			if ((pls_NONE & ParallelLoopStateFlags.PLS_STOPPED) != 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("ParallelState_Break_InvalidOperationException_BreakAfterStop"));
			}
		}

		// Token: 0x04001AD7 RID: 6871
		private ParallelLoopStateFlags m_flagsBase;
	}
}
