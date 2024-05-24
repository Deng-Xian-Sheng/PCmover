using System;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F8 RID: 2296
	[__DynamicallyInvokable]
	public struct ConfiguredTaskAwaitable<TResult>
	{
		// Token: 0x06005E47 RID: 24135 RVA: 0x0014B3D9 File Offset: 0x001495D9
		internal ConfiguredTaskAwaitable(Task<TResult> task, bool continueOnCapturedContext)
		{
			this.m_configuredTaskAwaiter = new ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter(task, continueOnCapturedContext);
		}

		// Token: 0x06005E48 RID: 24136 RVA: 0x0014B3E8 File Offset: 0x001495E8
		[__DynamicallyInvokable]
		public ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter GetAwaiter()
		{
			return this.m_configuredTaskAwaiter;
		}

		// Token: 0x04002A51 RID: 10833
		private readonly ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter m_configuredTaskAwaiter;

		// Token: 0x02000C93 RID: 3219
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public struct ConfiguredTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
		{
			// Token: 0x060070FD RID: 28925 RVA: 0x001850A6 File Offset: 0x001832A6
			internal ConfiguredTaskAwaiter(Task<TResult> task, bool continueOnCapturedContext)
			{
				this.m_task = task;
				this.m_continueOnCapturedContext = continueOnCapturedContext;
			}

			// Token: 0x17001361 RID: 4961
			// (get) Token: 0x060070FE RID: 28926 RVA: 0x001850B6 File Offset: 0x001832B6
			[__DynamicallyInvokable]
			public bool IsCompleted
			{
				[__DynamicallyInvokable]
				get
				{
					return this.m_task.IsCompleted;
				}
			}

			// Token: 0x060070FF RID: 28927 RVA: 0x001850C3 File Offset: 0x001832C3
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			public void OnCompleted(Action continuation)
			{
				TaskAwaiter.OnCompletedInternal(this.m_task, continuation, this.m_continueOnCapturedContext, true);
			}

			// Token: 0x06007100 RID: 28928 RVA: 0x001850D8 File Offset: 0x001832D8
			[SecurityCritical]
			[__DynamicallyInvokable]
			public void UnsafeOnCompleted(Action continuation)
			{
				TaskAwaiter.OnCompletedInternal(this.m_task, continuation, this.m_continueOnCapturedContext, false);
			}

			// Token: 0x06007101 RID: 28929 RVA: 0x001850ED File Offset: 0x001832ED
			[__DynamicallyInvokable]
			public TResult GetResult()
			{
				TaskAwaiter.ValidateEnd(this.m_task);
				return this.m_task.ResultOnSuccess;
			}

			// Token: 0x04003849 RID: 14409
			private readonly Task<TResult> m_task;

			// Token: 0x0400384A RID: 14410
			private readonly bool m_continueOnCapturedContext;
		}
	}
}
