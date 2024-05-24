using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Security.Principal;

namespace System.Threading
{
	// Token: 0x020004F5 RID: 1269
	internal struct ExecutionContextSwitcher
	{
		// Token: 0x06003BE5 RID: 15333 RVA: 0x000E3128 File Offset: 0x000E1328
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

		// Token: 0x06003BE6 RID: 15334 RVA: 0x000E316C File Offset: 0x000E136C
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal void Undo()
		{
			if (this.thread == null)
			{
				return;
			}
			Thread thread = this.thread;
			if (this.hecsw != null)
			{
				HostExecutionContextSwitcher.Undo(this.hecsw);
			}
			ExecutionContext.Reader executionContextReader = thread.GetExecutionContextReader();
			thread.SetExecutionContext(this.outerEC, this.outerECBelongsToScope);
			if (this.scsw.currSC != null)
			{
				this.scsw.Undo();
			}
			if (this.wiIsValid)
			{
				SecurityContext.RestoreCurrentWI(this.outerEC, executionContextReader, this.wi, this.cachedAlwaysFlowImpersonationPolicy);
			}
			this.thread = null;
			ExecutionContext.OnAsyncLocalContextChanged(executionContextReader.DangerousGetRawExecutionContext(), this.outerEC.DangerousGetRawExecutionContext());
		}

		// Token: 0x0400197B RID: 6523
		internal ExecutionContext.Reader outerEC;

		// Token: 0x0400197C RID: 6524
		internal bool outerECBelongsToScope;

		// Token: 0x0400197D RID: 6525
		internal SecurityContextSwitcher scsw;

		// Token: 0x0400197E RID: 6526
		internal object hecsw;

		// Token: 0x0400197F RID: 6527
		internal WindowsIdentity wi;

		// Token: 0x04001980 RID: 6528
		internal bool cachedAlwaysFlowImpersonationPolicy;

		// Token: 0x04001981 RID: 6529
		internal bool wiIsValid;

		// Token: 0x04001982 RID: 6530
		internal Thread thread;
	}
}
