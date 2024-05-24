using System;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000018 RID: 24
	public sealed class TaskSetCookieCallback : ISetCookieCallback, IDisposable
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000023E5 File Offset: 0x000005E5
		public TaskSetCookieCallback()
		{
			this.taskCompletionSource = new TaskCompletionSource<bool>();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000023F8 File Offset: 0x000005F8
		void ISetCookieCallback.OnComplete(bool success)
		{
			this.onComplete = true;
			this.taskCompletionSource.TrySetResultAsync(success);
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000240D File Offset: 0x0000060D
		public Task<bool> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000052 RID: 82 RVA: 0x0000241A File Offset: 0x0000061A
		bool ISetCookieCallback.IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002424 File Offset: 0x00000624
		void IDisposable.Dispose()
		{
			Task<bool> task = this.taskCompletionSource.Task;
			if (!this.onComplete && !task.IsCompleted)
			{
				this.taskCompletionSource.TrySetResultAsync(false);
			}
			this.isDisposed = true;
		}

		// Token: 0x04000011 RID: 17
		private readonly TaskCompletionSource<bool> taskCompletionSource;

		// Token: 0x04000012 RID: 18
		private volatile bool isDisposed;

		// Token: 0x04000013 RID: 19
		private bool onComplete;
	}
}
