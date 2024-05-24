using System;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000015 RID: 21
	public class TaskDeleteCookiesCallback : IDeleteCookiesCallback, IDisposable
	{
		// Token: 0x06000040 RID: 64 RVA: 0x0000225A File Offset: 0x0000045A
		public TaskDeleteCookiesCallback()
		{
			this.taskCompletionSource = new TaskCompletionSource<int>();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000226D File Offset: 0x0000046D
		void IDeleteCookiesCallback.OnComplete(int numDeleted)
		{
			this.onComplete = true;
			this.taskCompletionSource.TrySetResultAsync(numDeleted);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002282 File Offset: 0x00000482
		public Task<int> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000228F File Offset: 0x0000048F
		bool IDeleteCookiesCallback.IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000229C File Offset: 0x0000049C
		void IDisposable.Dispose()
		{
			Task<int> task = this.taskCompletionSource.Task;
			if (!this.onComplete && !task.IsCompleted)
			{
				this.taskCompletionSource.TrySetResultAsync(-1);
			}
			this.isDisposed = true;
		}

		// Token: 0x04000007 RID: 7
		public const int InvalidNoOfCookiesDeleted = -1;

		// Token: 0x04000008 RID: 8
		private readonly TaskCompletionSource<int> taskCompletionSource;

		// Token: 0x04000009 RID: 9
		private volatile bool isDisposed;

		// Token: 0x0400000A RID: 10
		private bool onComplete;
	}
}
