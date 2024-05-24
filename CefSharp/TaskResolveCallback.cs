using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000017 RID: 23
	public sealed class TaskResolveCallback : IResolveCallback, IDisposable
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00002359 File Offset: 0x00000559
		public TaskResolveCallback()
		{
			this.taskCompletionSource = new TaskCompletionSource<ResolveCallbackResult>();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000236C File Offset: 0x0000056C
		void IResolveCallback.OnResolveCompleted(CefErrorCode result, IList<string> resolvedIpAddresses)
		{
			this.onComplete = true;
			this.taskCompletionSource.TrySetResultAsync(new ResolveCallbackResult(result, resolvedIpAddresses));
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002387 File Offset: 0x00000587
		bool IResolveCallback.IsDisposed
		{
			get
			{
				return this.isDisposed;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002391 File Offset: 0x00000591
		public Task<ResolveCallbackResult> Task
		{
			get
			{
				return this.taskCompletionSource.Task;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000023A0 File Offset: 0x000005A0
		void IDisposable.Dispose()
		{
			Task<ResolveCallbackResult> task = this.taskCompletionSource.Task;
			if (!this.onComplete && !task.IsCompleted)
			{
				this.taskCompletionSource.TrySetResultAsync(new ResolveCallbackResult(CefErrorCode.Unexpected, null));
			}
			this.isDisposed = true;
		}

		// Token: 0x0400000E RID: 14
		private readonly TaskCompletionSource<ResolveCallbackResult> taskCompletionSource;

		// Token: 0x0400000F RID: 15
		private volatile bool isDisposed;

		// Token: 0x04000010 RID: 16
		private bool onComplete;
	}
}
