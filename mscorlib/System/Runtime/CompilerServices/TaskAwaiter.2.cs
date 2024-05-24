using System;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F6 RID: 2294
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public struct TaskAwaiter<TResult> : ICriticalNotifyCompletion, INotifyCompletion
	{
		// Token: 0x06005E40 RID: 24128 RVA: 0x0014B374 File Offset: 0x00149574
		internal TaskAwaiter(Task<TResult> task)
		{
			this.m_task = task;
		}

		// Token: 0x1700102F RID: 4143
		// (get) Token: 0x06005E41 RID: 24129 RVA: 0x0014B37D File Offset: 0x0014957D
		[__DynamicallyInvokable]
		public bool IsCompleted
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_task.IsCompleted;
			}
		}

		// Token: 0x06005E42 RID: 24130 RVA: 0x0014B38A File Offset: 0x0014958A
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public void OnCompleted(Action continuation)
		{
			TaskAwaiter.OnCompletedInternal(this.m_task, continuation, true, true);
		}

		// Token: 0x06005E43 RID: 24131 RVA: 0x0014B39A File Offset: 0x0014959A
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void UnsafeOnCompleted(Action continuation)
		{
			TaskAwaiter.OnCompletedInternal(this.m_task, continuation, true, false);
		}

		// Token: 0x06005E44 RID: 24132 RVA: 0x0014B3AA File Offset: 0x001495AA
		[__DynamicallyInvokable]
		public TResult GetResult()
		{
			TaskAwaiter.ValidateEnd(this.m_task);
			return this.m_task.ResultOnSuccess;
		}

		// Token: 0x04002A4F RID: 10831
		private readonly Task<TResult> m_task;
	}
}
