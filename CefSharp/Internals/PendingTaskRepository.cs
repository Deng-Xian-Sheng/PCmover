using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000E7 RID: 231
	public sealed class PendingTaskRepository<TResult>
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x0000B4A0 File Offset: 0x000096A0
		public KeyValuePair<long, TaskCompletionSource<TResult>> CreatePendingTask(TimeSpan? timeout = null)
		{
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			long id = Interlocked.Increment(ref this.lastId);
			this.pendingTasks.TryAdd(id, taskCompletionSource);
			if (timeout != null)
			{
				taskCompletionSource = taskCompletionSource.WithTimeout(timeout.Value, delegate()
				{
					this.RemovePendingTask(id);
				});
			}
			return new KeyValuePair<long, TaskCompletionSource<TResult>>(id, taskCompletionSource);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0000B514 File Offset: 0x00009714
		public KeyValuePair<long, TaskCompletionSource<TResult>> CreateJavascriptCallbackPendingTask(long id, TimeSpan? timeout = null)
		{
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			this.callbackPendingTasks.TryAdd(id, taskCompletionSource);
			if (timeout != null)
			{
				taskCompletionSource = taskCompletionSource.WithTimeout(timeout.Value, delegate()
				{
					this.RemoveJavascriptCallbackPendingTask(id);
				});
			}
			return new KeyValuePair<long, TaskCompletionSource<TResult>>(id, taskCompletionSource);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0000B580 File Offset: 0x00009780
		public TaskCompletionSource<TResult> RemovePendingTask(long id)
		{
			TaskCompletionSource<TResult> result;
			if (this.pendingTasks.TryRemove(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0000B5A0 File Offset: 0x000097A0
		public TaskCompletionSource<TResult> RemoveJavascriptCallbackPendingTask(long id)
		{
			TaskCompletionSource<TResult> result;
			if (this.callbackPendingTasks.TryRemove(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x04000389 RID: 905
		private readonly ConcurrentDictionary<long, TaskCompletionSource<TResult>> pendingTasks = new ConcurrentDictionary<long, TaskCompletionSource<TResult>>();

		// Token: 0x0400038A RID: 906
		private readonly ConcurrentDictionary<long, TaskCompletionSource<TResult>> callbackPendingTasks = new ConcurrentDictionary<long, TaskCompletionSource<TResult>>();

		// Token: 0x0400038B RID: 907
		private long lastId;
	}
}
