using System;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008EE RID: 2286
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct AsyncTaskMethodBuilder
	{
		// Token: 0x06005E0F RID: 24079 RVA: 0x0014A7EC File Offset: 0x001489EC
		[__DynamicallyInvokable]
		public static AsyncTaskMethodBuilder Create()
		{
			return default(AsyncTaskMethodBuilder);
		}

		// Token: 0x06005E10 RID: 24080 RVA: 0x0014A804 File Offset: 0x00148A04
		[SecuritySafeCritical]
		[DebuggerStepThrough]
		[__DynamicallyInvokable]
		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
		{
			if (stateMachine == null)
			{
				throw new ArgumentNullException("stateMachine");
			}
			ExecutionContextSwitcher executionContextSwitcher = default(ExecutionContextSwitcher);
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				ExecutionContext.EstablishCopyOnWriteScope(ref executionContextSwitcher);
				stateMachine.MoveNext();
			}
			finally
			{
				executionContextSwitcher.Undo();
			}
		}

		// Token: 0x06005E11 RID: 24081 RVA: 0x0014A864 File Offset: 0x00148A64
		[__DynamicallyInvokable]
		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			this.m_builder.SetStateMachine(stateMachine);
		}

		// Token: 0x06005E12 RID: 24082 RVA: 0x0014A872 File Offset: 0x00148A72
		[__DynamicallyInvokable]
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			this.m_builder.AwaitOnCompleted<TAwaiter, TStateMachine>(ref awaiter, ref stateMachine);
		}

		// Token: 0x06005E13 RID: 24083 RVA: 0x0014A881 File Offset: 0x00148A81
		[__DynamicallyInvokable]
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			this.m_builder.AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref awaiter, ref stateMachine);
		}

		// Token: 0x1700102A RID: 4138
		// (get) Token: 0x06005E14 RID: 24084 RVA: 0x0014A890 File Offset: 0x00148A90
		[__DynamicallyInvokable]
		public Task Task
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_builder.Task;
			}
		}

		// Token: 0x06005E15 RID: 24085 RVA: 0x0014A89D File Offset: 0x00148A9D
		[__DynamicallyInvokable]
		public void SetResult()
		{
			this.m_builder.SetResult(AsyncTaskMethodBuilder.s_cachedCompleted);
		}

		// Token: 0x06005E16 RID: 24086 RVA: 0x0014A8AF File Offset: 0x00148AAF
		[__DynamicallyInvokable]
		public void SetException(Exception exception)
		{
			this.m_builder.SetException(exception);
		}

		// Token: 0x06005E17 RID: 24087 RVA: 0x0014A8BD File Offset: 0x00148ABD
		internal void SetNotificationForWaitCompletion(bool enabled)
		{
			this.m_builder.SetNotificationForWaitCompletion(enabled);
		}

		// Token: 0x1700102B RID: 4139
		// (get) Token: 0x06005E18 RID: 24088 RVA: 0x0014A8CB File Offset: 0x00148ACB
		private object ObjectIdForDebugger
		{
			get
			{
				return this.Task;
			}
		}

		// Token: 0x04002A42 RID: 10818
		private static readonly Task<VoidTaskResult> s_cachedCompleted = AsyncTaskMethodBuilder<VoidTaskResult>.s_defaultResultTask;

		// Token: 0x04002A43 RID: 10819
		private AsyncTaskMethodBuilder<VoidTaskResult> m_builder;
	}
}
