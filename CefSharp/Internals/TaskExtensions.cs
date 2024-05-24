using System;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000EB RID: 235
	public static class TaskExtensions
	{
		// Token: 0x060006F6 RID: 1782 RVA: 0x0000B680 File Offset: 0x00009880
		public static Task<TResult> WithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
		{
			TaskCompletionSource<TResult> result = new TaskCompletionSource<TResult>(task.AsyncState);
			Timer timer = new Timer(delegate(object state)
			{
				((TaskCompletionSource<TResult>)state).TrySetCanceled();
			}, result, timeout, TimeSpan.FromMilliseconds(-1.0));
			task.ContinueWith(delegate(Task<TResult> t)
			{
				timer.Dispose();
				result.TrySetFromTask(t);
			}, TaskContinuationOptions.ExecuteSynchronously);
			return result.Task;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0000B708 File Offset: 0x00009908
		public static bool TrySetFromTask<TResult>(this TaskCompletionSource<TResult> resultSetter, Task task)
		{
			switch (task.Status)
			{
			case TaskStatus.RanToCompletion:
				return resultSetter.TrySetResult((task is Task<TResult>) ? ((Task<TResult>)task).Result : default(TResult));
			case TaskStatus.Canceled:
				return resultSetter.TrySetCanceled();
			case TaskStatus.Faulted:
				return resultSetter.TrySetException(task.Exception.InnerExceptions);
			default:
				throw new InvalidOperationException("The task was not completed.");
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0000B77A File Offset: 0x0000997A
		public static bool TrySetFromTask<TResult>(this TaskCompletionSource<TResult> resultSetter, Task<TResult> task)
		{
			return resultSetter.TrySetFromTask(task);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0000B784 File Offset: 0x00009984
		public static Task<T> FromResult<T>(T value)
		{
			TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
			taskCompletionSource.SetResult(value);
			return taskCompletionSource.Task;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0000B7A4 File Offset: 0x000099A4
		public static TaskCompletionSource<TResult> WithTimeout<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, TimeSpan timeout)
		{
			return taskCompletionSource.WithTimeout(timeout, null);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0000B7B0 File Offset: 0x000099B0
		public static TaskCompletionSource<TResult> WithTimeout<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, TimeSpan timeout, Action cancelled)
		{
			Timer timer = null;
			timer = new Timer(delegate(object state)
			{
				timer.Dispose();
				if (taskCompletionSource.Task.Status != TaskStatus.RanToCompletion)
				{
					taskCompletionSource.TrySetCanceled();
					if (cancelled != null)
					{
						cancelled();
					}
				}
			}, null, timeout, TimeSpan.FromMilliseconds(-1.0));
			return taskCompletionSource;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0000B808 File Offset: 0x00009A08
		public static void TrySetResultAsync<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, TResult result)
		{
			Task.Factory.StartNew(delegate()
			{
				taskCompletionSource.TrySetResult(result);
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0000B84C File Offset: 0x00009A4C
		public static void TrySetExceptionAsync<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, Exception ex)
		{
			Task.Factory.StartNew(delegate()
			{
				taskCompletionSource.TrySetException(ex);
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0000B890 File Offset: 0x00009A90
		public static void TrySetCanceledAsync<TResult>(this TaskCompletionSource<TResult> taskCompletionSource)
		{
			Task.Factory.StartNew(delegate()
			{
				taskCompletionSource.TrySetCanceled();
			}, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
		}
	}
}
