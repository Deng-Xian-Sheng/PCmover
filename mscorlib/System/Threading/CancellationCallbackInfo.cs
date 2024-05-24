using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000546 RID: 1350
	internal class CancellationCallbackInfo
	{
		// Token: 0x06003F64 RID: 16228 RVA: 0x000EC01C File Offset: 0x000EA21C
		internal CancellationCallbackInfo(Action<object> callback, object stateForCallback, SynchronizationContext targetSyncContext, ExecutionContext targetExecutionContext, CancellationTokenSource cancellationTokenSource)
		{
			this.Callback = callback;
			this.StateForCallback = stateForCallback;
			this.TargetSyncContext = targetSyncContext;
			this.TargetExecutionContext = targetExecutionContext;
			this.CancellationTokenSource = cancellationTokenSource;
		}

		// Token: 0x06003F65 RID: 16229 RVA: 0x000EC04C File Offset: 0x000EA24C
		[SecuritySafeCritical]
		internal void ExecuteCallback()
		{
			if (this.TargetExecutionContext != null)
			{
				ContextCallback contextCallback = CancellationCallbackInfo.s_executionContextCallback;
				if (contextCallback == null)
				{
					contextCallback = (CancellationCallbackInfo.s_executionContextCallback = new ContextCallback(CancellationCallbackInfo.ExecutionContextCallback));
				}
				ExecutionContext.Run(this.TargetExecutionContext, contextCallback, this);
				return;
			}
			CancellationCallbackInfo.ExecutionContextCallback(this);
		}

		// Token: 0x06003F66 RID: 16230 RVA: 0x000EC094 File Offset: 0x000EA294
		[SecurityCritical]
		private static void ExecutionContextCallback(object obj)
		{
			CancellationCallbackInfo cancellationCallbackInfo = obj as CancellationCallbackInfo;
			cancellationCallbackInfo.Callback(cancellationCallbackInfo.StateForCallback);
		}

		// Token: 0x04001AA7 RID: 6823
		internal readonly Action<object> Callback;

		// Token: 0x04001AA8 RID: 6824
		internal readonly object StateForCallback;

		// Token: 0x04001AA9 RID: 6825
		internal readonly SynchronizationContext TargetSyncContext;

		// Token: 0x04001AAA RID: 6826
		internal readonly ExecutionContext TargetExecutionContext;

		// Token: 0x04001AAB RID: 6827
		internal readonly CancellationTokenSource CancellationTokenSource;

		// Token: 0x04001AAC RID: 6828
		[SecurityCritical]
		private static ContextCallback s_executionContextCallback;
	}
}
