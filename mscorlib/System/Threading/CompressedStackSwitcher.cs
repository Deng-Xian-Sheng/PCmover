using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004EE RID: 1262
	internal struct CompressedStackSwitcher : IDisposable
	{
		// Token: 0x06003B9E RID: 15262 RVA: 0x000E2700 File Offset: 0x000E0900
		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is CompressedStackSwitcher))
			{
				return false;
			}
			CompressedStackSwitcher compressedStackSwitcher = (CompressedStackSwitcher)obj;
			return this.curr_CS == compressedStackSwitcher.curr_CS && this.prev_CS == compressedStackSwitcher.prev_CS && this.prev_ADStack == compressedStackSwitcher.prev_ADStack;
		}

		// Token: 0x06003B9F RID: 15263 RVA: 0x000E2750 File Offset: 0x000E0950
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		// Token: 0x06003BA0 RID: 15264 RVA: 0x000E2763 File Offset: 0x000E0963
		public static bool operator ==(CompressedStackSwitcher c1, CompressedStackSwitcher c2)
		{
			return c1.Equals(c2);
		}

		// Token: 0x06003BA1 RID: 15265 RVA: 0x000E2778 File Offset: 0x000E0978
		public static bool operator !=(CompressedStackSwitcher c1, CompressedStackSwitcher c2)
		{
			return !c1.Equals(c2);
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x000E2790 File Offset: 0x000E0990
		[SecuritySafeCritical]
		public void Dispose()
		{
			this.Undo();
		}

		// Token: 0x06003BA3 RID: 15267 RVA: 0x000E2798 File Offset: 0x000E0998
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[HandleProcessCorruptedStateExceptions]
		internal bool UndoNoThrow()
		{
			try
			{
				this.Undo();
			}
			catch (Exception exception)
			{
				if (!AppContextSwitches.UseLegacyExecutionContextBehaviorUponUndoFailure)
				{
					Environment.FailFast(Environment.GetResourceString("ExecutionContext_UndoFailed"), exception);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06003BA4 RID: 15268 RVA: 0x000E27DC File Offset: 0x000E09DC
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public void Undo()
		{
			if (this.curr_CS == null && this.prev_CS == null)
			{
				return;
			}
			if (this.prev_ADStack != (IntPtr)0)
			{
				CompressedStack.RestoreAppDomainStack(this.prev_ADStack);
			}
			CompressedStack.SetCompressedStackThread(this.prev_CS);
			this.prev_CS = null;
			this.curr_CS = null;
			this.prev_ADStack = (IntPtr)0;
		}

		// Token: 0x0400196E RID: 6510
		internal CompressedStack curr_CS;

		// Token: 0x0400196F RID: 6511
		internal CompressedStack prev_CS;

		// Token: 0x04001970 RID: 6512
		internal IntPtr prev_ADStack;
	}
}
