using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Security.Permissions;

namespace System.Threading.Tasks
{
	// Token: 0x0200057A RID: 1402
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public class TaskCompletionSource<TResult>
	{
		// Token: 0x06004228 RID: 16936 RVA: 0x000F65A6 File Offset: 0x000F47A6
		[__DynamicallyInvokable]
		public TaskCompletionSource()
		{
			this.m_task = new Task<TResult>();
		}

		// Token: 0x06004229 RID: 16937 RVA: 0x000F65B9 File Offset: 0x000F47B9
		[__DynamicallyInvokable]
		public TaskCompletionSource(TaskCreationOptions creationOptions) : this(null, creationOptions)
		{
		}

		// Token: 0x0600422A RID: 16938 RVA: 0x000F65C3 File Offset: 0x000F47C3
		[__DynamicallyInvokable]
		public TaskCompletionSource(object state) : this(state, TaskCreationOptions.None)
		{
		}

		// Token: 0x0600422B RID: 16939 RVA: 0x000F65CD File Offset: 0x000F47CD
		[__DynamicallyInvokable]
		public TaskCompletionSource(object state, TaskCreationOptions creationOptions)
		{
			this.m_task = new Task<TResult>(state, creationOptions);
		}

		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x0600422C RID: 16940 RVA: 0x000F65E2 File Offset: 0x000F47E2
		[__DynamicallyInvokable]
		public Task<TResult> Task
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_task;
			}
		}

		// Token: 0x0600422D RID: 16941 RVA: 0x000F65EC File Offset: 0x000F47EC
		private void SpinUntilCompleted()
		{
			SpinWait spinWait = default(SpinWait);
			while (!this.m_task.IsCompleted)
			{
				spinWait.SpinOnce();
			}
		}

		// Token: 0x0600422E RID: 16942 RVA: 0x000F6618 File Offset: 0x000F4818
		[__DynamicallyInvokable]
		public bool TrySetException(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			bool flag = this.m_task.TrySetException(exception);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		// Token: 0x0600422F RID: 16943 RVA: 0x000F6658 File Offset: 0x000F4858
		[__DynamicallyInvokable]
		public bool TrySetException(IEnumerable<Exception> exceptions)
		{
			if (exceptions == null)
			{
				throw new ArgumentNullException("exceptions");
			}
			List<Exception> list = new List<Exception>();
			foreach (Exception ex in exceptions)
			{
				if (ex == null)
				{
					throw new ArgumentException(Environment.GetResourceString("TaskCompletionSourceT_TrySetException_NullException"), "exceptions");
				}
				list.Add(ex);
			}
			if (list.Count == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("TaskCompletionSourceT_TrySetException_NoExceptions"), "exceptions");
			}
			bool flag = this.m_task.TrySetException(list);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		// Token: 0x06004230 RID: 16944 RVA: 0x000F6710 File Offset: 0x000F4910
		internal bool TrySetException(IEnumerable<ExceptionDispatchInfo> exceptions)
		{
			bool flag = this.m_task.TrySetException(exceptions);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		// Token: 0x06004231 RID: 16945 RVA: 0x000F6741 File Offset: 0x000F4941
		[__DynamicallyInvokable]
		public void SetException(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			if (!this.TrySetException(exception))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x06004232 RID: 16946 RVA: 0x000F676A File Offset: 0x000F496A
		[__DynamicallyInvokable]
		public void SetException(IEnumerable<Exception> exceptions)
		{
			if (!this.TrySetException(exceptions))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x06004233 RID: 16947 RVA: 0x000F6788 File Offset: 0x000F4988
		[__DynamicallyInvokable]
		public bool TrySetResult(TResult result)
		{
			bool flag = this.m_task.TrySetResult(result);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		// Token: 0x06004234 RID: 16948 RVA: 0x000F67B9 File Offset: 0x000F49B9
		[__DynamicallyInvokable]
		public void SetResult(TResult result)
		{
			if (!this.TrySetResult(result))
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x06004235 RID: 16949 RVA: 0x000F67D4 File Offset: 0x000F49D4
		[__DynamicallyInvokable]
		public bool TrySetCanceled()
		{
			return this.TrySetCanceled(default(CancellationToken));
		}

		// Token: 0x06004236 RID: 16950 RVA: 0x000F67F0 File Offset: 0x000F49F0
		[__DynamicallyInvokable]
		public bool TrySetCanceled(CancellationToken cancellationToken)
		{
			bool flag = this.m_task.TrySetCanceled(cancellationToken);
			if (!flag && !this.m_task.IsCompleted)
			{
				this.SpinUntilCompleted();
			}
			return flag;
		}

		// Token: 0x06004237 RID: 16951 RVA: 0x000F6821 File Offset: 0x000F4A21
		[__DynamicallyInvokable]
		public void SetCanceled()
		{
			if (!this.TrySetCanceled())
			{
				throw new InvalidOperationException(Environment.GetResourceString("TaskT_TransitionToFinal_AlreadyCompleted"));
			}
		}

		// Token: 0x04001B71 RID: 7025
		private readonly Task<TResult> m_task;
	}
}
