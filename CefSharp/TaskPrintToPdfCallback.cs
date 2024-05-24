using System;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000016 RID: 22
	public sealed class TaskPrintToPdfCallback : IPrintToPdfCallback, IDisposable
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000022DA File Offset: 0x000004DA
		public Task<bool> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000022E7 File Offset: 0x000004E7
		void IPrintToPdfCallback.OnPdfPrintFinished(string path, bool ok)
		{
			this.onComplete = true;
			this.taskCompletionSource.TrySetResultAsync(ok);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000022FC File Offset: 0x000004FC
		bool IPrintToPdfCallback.IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002308 File Offset: 0x00000508
		void IDisposable.Dispose()
		{
			Task<bool> task = this.taskCompletionSource.Task;
			if (!this.onComplete && !task.IsCompleted)
			{
				this.taskCompletionSource.TrySetResultAsync(false);
			}
			this.isDisposed = true;
		}

		// Token: 0x0400000B RID: 11
		private readonly TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

		// Token: 0x0400000C RID: 12
		private volatile bool isDisposed;

		// Token: 0x0400000D RID: 13
		private bool onComplete;
	}
}
