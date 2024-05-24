using System;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000CB RID: 203
	public static class GlobalContextInitialized
	{
		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x00009B4A File Offset: 0x00007D4A
		public static Task<bool> Task
		{
			get
			{
				return GlobalContextInitialized.TaskCompletionSource.Task;
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00009B56 File Offset: 0x00007D56
		public static void SetResult(bool success)
		{
			GlobalContextInitialized.TaskCompletionSource.TrySetResult(success);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00009B64 File Offset: 0x00007D64
		public static void SetException(Exception ex)
		{
			GlobalContextInitialized.TaskCompletionSource.TrySetException(ex);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00009B74 File Offset: 0x00007D74
		public static void ExecuteOrEnqueue(Action<bool> action)
		{
			GlobalContextInitialized.TaskCompletionSource.Task.ContinueWith(delegate(Task<bool> t)
			{
				action(t.Result);
			}, TaskContinuationOptions.ExecuteSynchronously);
		}

		// Token: 0x04000344 RID: 836
		private static TaskCompletionSource<bool> TaskCompletionSource = new TaskCompletionSource<bool>();
	}
}
