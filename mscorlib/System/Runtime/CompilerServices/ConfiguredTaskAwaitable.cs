using System;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F7 RID: 2295
	[__DynamicallyInvokable]
	public struct ConfiguredTaskAwaitable
	{
		// Token: 0x06005E45 RID: 24133 RVA: 0x0014B3C2 File Offset: 0x001495C2
		internal ConfiguredTaskAwaitable(Task task, bool continueOnCapturedContext)
		{
			this.m_configuredTaskAwaiter = new ConfiguredTaskAwaitable.ConfiguredTaskAwaiter(task, continueOnCapturedContext);
		}

		// Token: 0x06005E46 RID: 24134 RVA: 0x0014B3D1 File Offset: 0x001495D1
		[__DynamicallyInvokable]
		public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter()
		{
			return this.m_configuredTaskAwaiter;
		}

		// Token: 0x04002A50 RID: 10832
		private readonly ConfiguredTaskAwaitable.ConfiguredTaskAwaiter m_configuredTaskAwaiter;

		// Token: 0x02000C92 RID: 3218
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
		public struct ConfiguredTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
		{
			// Token: 0x060070F8 RID: 28920 RVA: 0x00185052 File Offset: 0x00183252
			internal ConfiguredTaskAwaiter(Task task, bool continueOnCapturedContext)
			{
				this.m_task = task;
				this.m_continueOnCapturedContext = continueOnCapturedContext;
			}

			// Token: 0x17001360 RID: 4960
			// (get) Token: 0x060070F9 RID: 28921 RVA: 0x00185062 File Offset: 0x00183262
			[__DynamicallyInvokable]
			public bool IsCompleted
			{
				[__DynamicallyInvokable]
				get
				{
					return this.m_task.IsCompleted;
				}
			}

			// Token: 0x060070FA RID: 28922 RVA: 0x0018506F File Offset: 0x0018326F
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			public void OnCompleted(Action continuation)
			{
				TaskAwaiter.OnCompletedInternal(this.m_task, continuation, this.m_continueOnCapturedContext, true);
			}

			// Token: 0x060070FB RID: 28923 RVA: 0x00185084 File Offset: 0x00183284
			[SecurityCritical]
			[__DynamicallyInvokable]
			public void UnsafeOnCompleted(Action continuation)
			{
				TaskAwaiter.OnCompletedInternal(this.m_task, continuation, this.m_continueOnCapturedContext, false);
			}

			// Token: 0x060070FC RID: 28924 RVA: 0x00185099 File Offset: 0x00183299
			[__DynamicallyInvokable]
			public void GetResult()
			{
				TaskAwaiter.ValidateEnd(this.m_task);
			}

			// Token: 0x04003847 RID: 14407
			private readonly Task m_task;

			// Token: 0x04003848 RID: 14408
			private readonly bool m_continueOnCapturedContext;
		}
	}
}
